using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zarinpal.Models;

namespace Zarinpal
{
    public class Get
    {
        private readonly string _merchantId;

        public Get(string merchantId)
        {
            _merchantId = merchantId;
        }

        public async Task<UnverifiedTransactionsResponse> UnverifiedTransactions()
        {
            UnverifiedTransactionsResponse deserializedResponse;
            using (var httpClient = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(new
                {
                    MerchantID = _merchantId
                });
                using (var httpResponseMessage = await httpClient.PostAsync("https://www.zarinpal.com/pg/rest/WebGate/GetUnverifiedTransactions.json", new StringContent(content, Encoding.UTF8, "application/json")))
                {
                    var response = await httpResponseMessage.Content.ReadAsStringAsync();
                    deserializedResponse = JsonConvert.DeserializeObject<UnverifiedTransactionsResponse>(response);
                }
            }
            return deserializedResponse;
        }
    }
}
