using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZarinpalSandbox.Models;

namespace ZarinpalSandbox
{
    public class Refresh
    {
        private const string MerchantId = "c632f574-bd37-15e7-99ca-000c295eb9d3";


        /// <summary>
        /// تمدید طول عمر شناسه پرداخت
        /// </summary>
        /// <param name="authority">کد یکتای شناسه مرجع</param>
        /// <param name="expireIn">مدت زماني كه مي خواهيد طول عمر اين شناسه تمديد شود به ثانيه</param>
        /// <returns></returns>
        public async Task<RefreshAuthorityResponse> Authority(string authority, int expireIn)
        {
            RefreshAuthorityResponse deserializedResponse;
            using (var httpClient = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(new
                {
                    MerchantID = MerchantId,
                    ExpireIn = expireIn,
                    Authority = authority
                });
                using (var httpResponseMessage = await httpClient.PostAsync("https://sandbox.zarinpal.com/pg/rest/WebGate/RefreshAuthority.json", new StringContent(content, Encoding.UTF8, "application/json")))
                {
                    var response = await httpResponseMessage.Content.ReadAsStringAsync();
                    deserializedResponse = JsonConvert.DeserializeObject<RefreshAuthorityResponse>(response);
                }
            }
            return deserializedResponse;
        }
    }
}
