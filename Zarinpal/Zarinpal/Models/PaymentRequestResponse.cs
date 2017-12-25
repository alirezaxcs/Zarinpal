using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zarinpal.Models
{
    public class PaymentRequestResponse
    {
        public int Status { get; set; }
        public string Authority { get; set; }
        public string Link => $"https://www.zarinpal.com/pg/StartPay/{Authority}";
    }
}
