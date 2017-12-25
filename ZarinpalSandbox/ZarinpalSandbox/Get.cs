using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZarinpalSandbox.Models;

namespace ZarinpalSandbox
{
    public class Get
    {
        private const string MerchantId = "c632f574-bd37-15e7-99ca-000c295eb9d3";

        public async Task<UnverifiedTransactionsResponse> UnverifiedTransactions()
        {
            UnverifiedTransactionsResponse deserializedResponse;
            using (var httpClient = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(new
                {
                    MerchantID = MerchantId
                });
                using (var httpResponseMessage = await httpClient.PostAsync("https://sandbox.zarinpal.com/pg/rest/WebGate/GetUnverifiedTransactions.json", new StringContent(content, Encoding.UTF8, "application/json")))
                {
                    var response = await httpResponseMessage.Content.ReadAsStringAsync();
                    deserializedResponse = JsonConvert.DeserializeObject<UnverifiedTransactionsResponse>(response);
                }
            }
            return deserializedResponse;
        }
    }
}
