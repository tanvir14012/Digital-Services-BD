using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using Digital_Services_BD.Models;
using Digital_Services_BD.Services;
using Digital_Services_BD.Utilities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Digital_Services_BD.Controllers
{
    public class SurjopayIPNController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IOrderOps orderOps;
        private readonly AppDbContext context;
        private readonly ILogger<SurjopayIPNController> logger;

        public SurjopayIPNController(IConfiguration configuration, IOrderOps orderOps,
            AppDbContext context, ILogger<SurjopayIPNController> logger)
        {
            this.configuration = configuration;
            this.orderOps = orderOps;
            this.context = context;
            this.logger = logger;
        }

        [ServiceFilter(typeof(SurjopayIPNIpFilter))]
        [HttpPost]
        public async Task<IActionResult> Webhook()
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.Form["order_id"]))
                {

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, $"An exception is thrown in SSLCommerze IPN handler: {ex.Message}");
                return BadRequest();
            }
        }
    }
}
