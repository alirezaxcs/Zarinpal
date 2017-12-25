using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zarinpal.Models;

namespace Zarinpal
{
    public class Refresh
    {
        private readonly string _merchantId;

        public Refresh(string merchantId)
        {
            _merchantId = merchantId;
        }

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
                    MerchantID = _merchantId,
                    ExpireIn = expireIn,
                    Authority = authority
                });
                using (var httpResponseMessage = await httpClient.PostAsync("https://www.zarinpal.com/pg/rest/WebGate/RefreshAuthority.json", new StringContent(content, Encoding.UTF8, "application/json")))
                {
                    var response = await httpResponseMessage.Content.ReadAsStringAsync();
                    deserializedResponse = JsonConvert.DeserializeObject<RefreshAuthorityResponse>(response);
                }
            }
            return deserializedResponse;
        }
    }
}
