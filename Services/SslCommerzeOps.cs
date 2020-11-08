using Digital_Services_BD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Digital_Services_BD.Services
{
    public class SslCommerzeOps
    {
        private readonly IOptions<SslConfig> sslConfig;

        public SslCommerzeOps(IOptions<SslConfig> sslConfig)
        {
            this.sslConfig = sslConfig;
        }

        public string GetOrderPaymentRedirectUrl(Order order)
        {
            var customer = new SslCustomer(order.BillingAddress.FirstName + " " + order.BillingAddress.LastName,
                order.ConfirmEmail, order.BillingAddress.Mobile)
            {
                AddressOne = order.BillingAddress.AddressLineOne,
                AddressTwo = order.BillingAddress.AddressLineTwo,
                PostCode = order.BillingAddress.Zip,
                City = order.BillingAddress.City,
                State = order.BillingAddress.State,
                Country = order.BillingAddress.Country
            };

            var emiTrnx = new EmiTransaction();
            var cart = new CartInformation
            {
                ProductAmount = order.Cart.Subtotal,
                DiscountAmount = order.Cart.PromoCodeDiscount,
                ConvenienceFee = order.Cart.TaxesAndFees
            };
            order.Cart.CartItems.ToList().ForEach(i => cart.SslCartItems.Add(new SslCartItem(i.Name, (i.Price + i.Vat - i.Discount) * i.Quantity)));
            order.Cart.CartItemBundlesViewModel.ToList().ForEach(i => cart.SslCartItems.Add(new SslCartItem(i.Name, i.BundlePrice - i.BundleDiscount)));

            var transaction = new Digital_Services_BD.Models.Trasnaction(order.TotalPrice,
                order.TransactionId.ToString(), sslConfig.Value.SuccessUrl + "/"  +order.Id,
                sslConfig.Value.FailUrl + "/" + order.Id, sslConfig.Value.CancelUrl + "/" + order.Id, emiTrnx,
                customer, sslConfig.Value.StoreUrl, sslConfig.Value.StoreId,
                sslConfig.Value.StorePass)
            { 
                Cart = cart,
                Curency = order.PriceCurrency,
                Curency1 = order.PriceCurrency,
                ValueA = order.Id.ToString()
            };

            try
            {
                var trnxSession = GetSessionAsync(transaction).Result;
                return trnxSession.GatewayPageUrl;
            }
            catch (Exception e)
            {
                return null;
            }
        }
		public async Task<TransactionSession> GetSessionAsync(Trasnaction trasnaction)
		{
			string requestUrl = sslConfig.Value.StoreUrl + "/gwprocess/v3/api.php";

			using (HttpClient client = new HttpClient())
			{
				Dictionary<string, string> parameters = GetSessionRequestParameter(trasnaction);
				HttpContent content = new FormUrlEncodedContent(parameters);
				HttpResponseMessage response = await client.PostAsync(requestUrl, content);
				response.EnsureSuccessStatusCode();
				string responseString = await response.Content.ReadAsStringAsync();
				TransactionSession session = JsonConvert.DeserializeObject<TransactionSession>(responseString);
				return session;
			}
		}

        public TransactionResponse GetTransactionResponse(IFormCollection form)
        {
            //Dictionary<string, string> inDictionary = form.AllKeys.ToDictionary(x=> x, v=> form[v]);
            //Dictionary<string, object> inDictionary = new Dictionary<string, object>();
            //inDictionary = form.ToDictionary(x => x.Key, x => (object)x.Value);
            Dictionary<string, string> inDictionary = new Dictionary<string, string>();
            inDictionary = form.ToDictionary(x => x.Key, x => x.Value[0]);
            string inJson = JsonConvert.SerializeObject(inDictionary);
            TransactionResponse response = JsonConvert.DeserializeObject<TransactionResponse>(inJson);
            return response;
        }
        public ValidatedTransaction ValidateTransaction(IFormCollection form)
        {
            ValidatedTransaction transaction = new ValidatedTransaction();

            if (VerifyHash(form))
            {
                string validationId = form["val_id"];

                if (form["status"].Equals("VALID"))
                {
                    transaction = CheckValidationAsync(validationId).Result;
                }
            }

            return transaction;
        }

        private bool VerifyHash(IFormCollection form)
        {
            bool isValid = false;

            try
            {
                string[] predefinedKeys = form["verify_key"].ToString().Split(',');
                Dictionary<string, string> newData = new Dictionary<string, string>();

                foreach (string key in predefinedKeys)
                {
                    if (!string.IsNullOrEmpty(form[key]))
                    {
                        newData.Add(key, form[key]);
                    }
                    else
                    {
                        newData.Add(key, "");
                    }
                }

                newData.Add("store_passwd", CalculateMD5Hash(sslConfig.Value.StorePass));
                newData = newData.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
                List<string> keyData = new List<string>();

                foreach (KeyValuePair<string, string> item in newData)
                    keyData.Add(item.Key + "=" + item.Value);

                string mergedString = string.Join("&", keyData);

                string hashedData = CalculateMD5Hash(mergedString);

                isValid = hashedData.Equals(form["verify_sign"]);
            }
            catch
            {
                throw;
            }

            return isValid;
        }

        private string CalculateMD5Hash(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = MD5.Create().ComputeHash(inputBytes);
            string hashedString = BitConverter.ToString(hash).Replace("-", "").ToLower();
            return hashedString;
        }

        private async Task<ValidatedTransaction> CheckValidationAsync(string validationId)
        {
            string requestUrl = sslConfig.Value.StoreUrl + "/validator/api/validationserverAPI.php";
            using (HttpClient client = new HttpClient())
            {
                Dictionary<string, string> parameters = GetTransactionValidationParameter(validationId);
                requestUrl = requestUrl + "?" + string.Join("&", parameters.Select(x => x.Key + "=" + x.Value).ToList());
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();
                string responseString = await response.Content.ReadAsStringAsync();
                ValidatedTransaction validateResult = JsonConvert.DeserializeObject<ValidatedTransaction>(responseString);
                return validateResult;
            }
        }

        private Dictionary<string, string> GetTransactionValidationParameter(string validationId)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add("val_id", validationId);
            data.Add("store_id", sslConfig.Value.StoreId);
            data.Add("store_passwd", sslConfig.Value.StorePass);
            data.Add("format", "json");

            return data;
        }
        private Dictionary<string, string> GetSessionRequestParameter(Trasnaction trasnaction)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add("store_id", trasnaction.StoreId);
            data.Add("store_passwd", trasnaction.StorePassword);
            data.Add("total_amount", trasnaction.TotalAmount.ToString());
            data.Add("currency", trasnaction.Curency);
            data.Add("tran_id", trasnaction.TransactionID);
            data.Add("success_url", trasnaction.SuccessUrl);
            data.Add("fail_url", trasnaction.FailUrl);
            data.Add("cancel_url", trasnaction.CancelUrl);
            data.Add("multi_card_name", trasnaction.MultiCardName);
            data.Add("emi_option", trasnaction.EmiTransaction.IsEmiEnabled ? "1" : "0");

            if (trasnaction.EmiTransaction.MaxInstallationOption.HasValue)
                data.Add("emi_max_inst_option", trasnaction.EmiTransaction.MaxInstallationOption.ToString());

            if (trasnaction.EmiTransaction.SelectedInstallment.HasValue)
                data.Add("emi_selected_inst", trasnaction.EmiTransaction.SelectedInstallment.ToString());

            data.Add("cus_name", trasnaction.SslCustomer.Name);
            data.Add("cus_email", trasnaction.SslCustomer.Email);

            if (!string.IsNullOrEmpty(trasnaction.SslCustomer.AddressOne))
                data.Add("cus_add1", trasnaction.SslCustomer.AddressOne);
            if (!string.IsNullOrEmpty(trasnaction.SslCustomer.AddressTwo))
                data.Add("cus_add2", trasnaction.SslCustomer.AddressTwo);
            if (!string.IsNullOrEmpty(trasnaction.SslCustomer.City))
                data.Add("cus_city", trasnaction.SslCustomer.City);
            if (!string.IsNullOrEmpty(trasnaction.SslCustomer.State))
                data.Add("cus_state", trasnaction.SslCustomer.State);
            if (!string.IsNullOrEmpty(trasnaction.SslCustomer.PostCode))
                data.Add("cus_postcode", trasnaction.SslCustomer.PostCode);
            if (!string.IsNullOrEmpty(trasnaction.SslCustomer.Country))
                data.Add("cus_country", trasnaction.SslCustomer.Country);
            data.Add("cus_phone", trasnaction.SslCustomer.Phone);
            if (!string.IsNullOrEmpty(trasnaction.SslCustomer.Fax))
                data.Add("cus_fax", trasnaction.SslCustomer.Fax);

            if (!string.IsNullOrEmpty(trasnaction.Shipment?.ShipmentAddressName))
                data.Add("ship_name", trasnaction.Shipment.ShipmentAddressName);
            if (!string.IsNullOrEmpty(trasnaction.Shipment?.AddressOne))
                data.Add("ship_add1", trasnaction.Shipment.AddressOne);
            if (!string.IsNullOrEmpty(trasnaction.Shipment?.AddressTwo))
                data.Add("ship_add2", trasnaction.Shipment.AddressTwo);
            if (!string.IsNullOrEmpty(trasnaction.Shipment?.City))
                data.Add("ship_city", trasnaction.Shipment.City);
            if (!string.IsNullOrEmpty(trasnaction.Shipment?.State))
                data.Add("ship_state", trasnaction.Shipment.State);
            if (!string.IsNullOrEmpty(trasnaction.Shipment?.PostCode))
                data.Add("ship_postcode", trasnaction.Shipment.PostCode);
            if (!string.IsNullOrEmpty(trasnaction.Shipment?.Country))
                data.Add("ship_country", trasnaction.Shipment.Country);

            if (!string.IsNullOrEmpty(trasnaction.ValueA))
                data.Add("value_a", trasnaction.ValueA);
            if (!string.IsNullOrEmpty(trasnaction.ValueB))
                data.Add("value_b", trasnaction.ValueB);
            if (!string.IsNullOrEmpty(trasnaction.ValueC))
                data.Add("value_c", trasnaction.ValueC);
            if (!string.IsNullOrEmpty(trasnaction.ValueD))
                data.Add("value_d", trasnaction.ValueD);

            if (trasnaction.Cart?.SslCartItems.Count > 0)
                data.Add("cart", JsonConvert.SerializeObject(trasnaction.Cart.SslCartItems));
            if (trasnaction.Cart?.ProductAmount != null)
                data.Add("product_amount", trasnaction.Cart.ProductAmount.ToString());
            if (trasnaction.Cart?.ProductAmount != null)
                data.Add("vat", trasnaction.Cart.Vat.ToString());
            if (trasnaction.Cart?.ProductAmount != null)
                data.Add("discount_amount", trasnaction.Cart.DiscountAmount.ToString());
            if (trasnaction.Cart?.ProductAmount != null)
                data.Add("convenience_fee", trasnaction.Cart.ConvenienceFee.ToString());

            return data;
        }
    }
}
