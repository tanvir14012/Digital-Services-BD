using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public enum OrderStatus
    {
        AWAITING,
        AWITING_EXPIRED,
        CANCELLED,
        PROCESSING,
        COMPLETED,
        PARTIAL_COMPLETED,
        DISPUTED,
        FAILED,
        REFUNDED
    }
}
