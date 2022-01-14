using Digital_Services_BD.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services.Surjopay
{
    public interface ISurjopayService
    {
        Task<JObject> InitAndGetToken();
        Task<JObject> Pay(IDictionary<string, dynamic> postData);
        Task<PaymentTransaction> ValidateOrder(string sujopayOrderId, string authToken);
    }
}
