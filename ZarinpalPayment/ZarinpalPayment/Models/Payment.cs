using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZarinpalPayment.Models
{
    public class Payment
    {
        public int Amount { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
