using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class CustomerClientInfo
    {
        public string CustomerId { get; set; }
        public string IPAddress { get; set; }
        public string UserAgentString { get; set; }
        public string TimeZone { get; set; }
        public string WindowXY { get; set; }
        public string LattitudeMagnitude { get; set; }
    }
}
