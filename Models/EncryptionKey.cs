using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    //One row table, stores the key in Id field.
    public class EncryptionKey
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
