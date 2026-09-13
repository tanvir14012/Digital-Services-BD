using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Digital_Services_BD.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Digital_Services_BD.Services.Surjopay
{
    public class SurjopayService : ISurjopayService
    {
        private readonly AppDbContext context;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly PaymentGwConfig paymentGwConfig;

        public SurjopayService(AppDbContext context, IHttpClientFactory httpClientFactory)
        {
            this.context = context;
            this.httpClientFactory = httpClientFactory;
            this.paymentGwConfig = context.PaymentGwConfigs.AsNoTracking().FirstOrDefault();
        }

        public async Task<JObject> InitAndGetToken()
        {
            var login = new
            {
                username = paymentGwConfig.Username,
                password = paymentGwConfig.Password
            };
            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post,
            $"{paymentGwConfig.ApiRoot}{paymentGwConfig.Data_a}")
            {
                Content = content
            };

            var httpClient = this.httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var respContent = await httpResponseMessage.Content.ReadAsStringAsync();
                JObject responseObj = JsonConvert.DeserializeObject<JObject>(respContent);
                return responseObj;
            }
            else
            {
                throw new HttpRequestException($"Http {httpResponseMessage.StatusCode} response.");
            }
        }

        public async Task<JObject> Pay(IDictionary<string, dynamic> postData)
        {
            var json = JsonConvert.SerializeObject(postData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post,
            $"{paymentGwConfig.ApiRoot}{paymentGwConfig.Data_b}")
            {
                Content = content
            };

            var httpClient = this.httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var respContent = await httpResponseMessage.Content.ReadAsStringAsync();
                JObject responseObj = JsonConvert.DeserializeObject<JObject>(respContent);
                return responseObj;
            }
            else
            {
                throw new HttpRequestException($"Http {httpResponseMessage.StatusCode} response.");
            }
        }

        public async Task<PaymentTransaction> ValidateOrder(string sujopayOrderId, string authToken)
        {
            var transaction = await context.PaymentTransactions
                .Include(trnx => trnx.Order)
                .FirstOrDefaultAsync(trnx => trnx.SurjoPayOrderId == sujopayOrderId);

            if (transaction != null && transaction.Order != null)
            {
                var json = JsonConvert.SerializeObject(new
                {
                    order_id = sujopayOrderId
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post,
                        $"{paymentGwConfig.ApiRoot}{paymentGwConfig.Data_c}")
                {
                    Headers =
                    {
                        { HeaderNames.Authorization, $"Bearer {authToken}"}
                    },
                    Content = content
                };

                var httpClient = this.httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var respContent = await httpResponseMessage.Content.ReadAsStringAsync();
                    JObject[] responseData = JsonConvert.DeserializeObject<JObject[]>(respContent);
                    JObject responseObj = responseData[0];
                    if (responseObj["customer_order_id"].ToString() == transaction.OrderId.ToString() &&
                        (Convert.ToDecimal(responseObj["payable_amount"].ToString()) == transaction.Amount &&
                        transaction.Amount == transaction.Order.GrandTotal) &&
                        (responseObj["currency"].ToString().ToUpper() == "BDT"))

                    {
                        if (transaction.SurjoPayCode == 0)
                        {
                            switch (Convert.ToInt32(responseObj["sp_code"].ToString()))
                            {
                                case 1000:
                                    transaction.Order.Status = OrderStatus.PROCESSING;
                                    break;
                                case 1001:
                                    transaction.Order.Status = OrderStatus.FAILED;
                                    break;
                                case 1002:
                                    transaction.Order.Status = OrderStatus.CANCELLED;
                                    break;
                                default:
                                    transaction.Order.Status = OrderStatus.FAILED;
                                    break;
                            }
                            transaction.LastModifiedOn = DateTime.UtcNow;
                            transaction.BankTrnxId = responseObj["bank_trx_id"].ToString();
                            transaction.Status = responseObj["transaction_status"].ToString();
                            transaction.TrnxMethod = responseObj["method"].ToString();
                            transaction.Name = responseObj["name"].ToString();
                            transaction.Phone = responseObj["phone_no"].ToString();
                            transaction.Email = responseObj["email"].ToString();
                            transaction.Address = responseObj["address"].ToString();
                            transaction.City = responseObj["city"].ToString();
                            transaction.CardNo = responseObj["card_number"].ToString();
                            transaction.CardHolderName = responseObj["card_holder_name"].ToString();
                            transaction.BankStatus = responseObj["bank_status"].ToString();
                            transaction.InvoiceId = responseObj["invoice_no"].ToString();
                            transaction.Currency = responseObj["currency"].ToString();
                            transaction.SurjoPayCode = Convert.ToInt32(responseObj["sp_code"].ToString());
                            transaction.SurjoPayMsg = responseObj["sp_massage"].ToString();
                            transaction.AmountInUSD = Convert.ToDecimal(responseObj["usd_amt"].ToString());
                            transaction.RateOfUSD = Convert.ToDecimal(responseObj["usd_rate"].ToString());
                            transaction.UserVerificationToken = responseObj["value2"].ToString();
                            await context.SaveChangesAsync();
                        }

                        return transaction;
                    }
                }
                else
                {
                    throw new HttpRequestException($"Http {httpResponseMessage.StatusCode} response.");
                }
            }
            throw new KeyNotFoundException();
        }
    }
}
