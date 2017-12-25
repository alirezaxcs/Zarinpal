namespace ZarinpalSandbox.Models
{
    public class PaymentRequestResponse
    {
        public int Status { get; set; }
        public string Authority { get; set; }
        public string Link => $"https://sandbox.zarinpal.com/pg/StartPay/{Authority}";

    }
}
