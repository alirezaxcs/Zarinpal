using Newtonsoft.Json;

namespace ZarinpalSandbox.Models
{
    public class PaymentVerificationResponse
    {
        public int Status { get; set; }
        [JsonProperty("RefID")]
        public int RefId { get; set; }
    }
}
