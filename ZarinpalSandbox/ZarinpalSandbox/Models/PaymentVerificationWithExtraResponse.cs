using Newtonsoft.Json;

namespace ZarinpalSandbox.Models
{
    public class PaymentVerificationWithExtraResponse
    {
        public int Status { get; set; }
        [JsonProperty("RefID")]
        public int RefId { get; set; }
        public string ExtraDetail { get; set; }
    }
}
