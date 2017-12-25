using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zarinpal.Models;

namespace Zarinpal
{
    public class Payment
    {
        private readonly string _merchantId;
        private readonly int _amount;

        public Payment(string merchantId, int amount)
        {
            _merchantId = merchantId;
            _amount = amount;
        }

        #region Normal

        /// <summary>
        /// فرایند خرید
        /// </summary>
        /// <param name="description">توضیحات</param>
        /// <param name="callbackUrl">آدرس برگشت</param>
        /// <param name="email">ایمیل</param>
        /// <param name="mobile">موبایل</param>
        /// <returns></returns>
        public async Task<PaymentRequestResponse> PaymentRequest(string description, string callbackUrl, string email = null, string mobile = null)
        {
            PaymentRequestResponse deserializedResponse;
            using (var httpClient = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(new
                {
                    MerchantID = _merchantId,
                    Amount = _amount,
                    Description = description,
                    Email = email,
                    Mobile = mobile,
                    CallbackURL = callbackUrl
                });
                using (var httpResponseMessage = await httpClient.PostAsync("https://www.zarinpal.com/pg/rest/WebGate/PaymentRequest.json", new StringContent(content, Encoding.UTF8, "application/json")))
                {
                    var response = await httpResponseMessage.Content.ReadAsStringAsync();
                    deserializedResponse = JsonConvert.DeserializeObject<PaymentRequestResponse>(response);
                }
            }
            return deserializedResponse;
        }

        /// <summary>
        /// تاییدیه خرید
        /// </summary>
        /// <param name="authority">كد يكتاي شناسه مرجع درخواست</param>
        /// <returns></returns>
        public async Task<PaymentVerificationResponse> Verification(string authority)
        {
            PaymentVerificationResponse deserializedResponse;
            using (var httpClient = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(new
                {
                    MerchantID = _merchantId,
                    Amount = _amount,
                    Authority = authority
                });
                using (var httpResponseMessage = await httpClient.PostAsync("https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json", new StringContent(content, Encoding.UTF8, "application/json")))
                {
                    var response = await httpResponseMessage.Content.ReadAsStringAsync();
                    deserializedResponse = JsonConvert.DeserializeObject<PaymentVerificationResponse>(response);
                }
            }
            return deserializedResponse;
        }

        #endregion

        #region WithExtra

        /// <summary>
        /// خرید با تسویه اشتراکی
        /// </summary>
        /// <param name="description">توضیحات</param>
        /// <param name="additionalData">مقادیر تسویه اشتراکی</param>
        /// <param name="callbackUrl">آدرس برگشت</param>
        /// <param name="email">ایمیل</param>
        /// <param name="mobile">موبایل</param>
        /// <returns></returns>
        public async Task<PaymentRequestResponse> PaymentRequestWithExtra(string description, string additionalData, string callbackUrl, string email = null, string mobile = null)
        {
            PaymentRequestResponse deserializedResponse;
            using (var httpClient = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(new
                {
                    MerchantID = _merchantId,
                    Amount = _amount,
                    Description = description,
                    AdditionalData = additionalData,
                    Email = email,
                    Mobile = mobile,
                    CallbackURL = callbackUrl
                });
                using (var httpResponseMessage = await httpClient.PostAsync("https://www.zarinpal.com/pg/rest/WebGate/PaymentRequestWithExtra.json", new StringContent(content, Encoding.UTF8, "application/json")))
                {
                    var response = await httpResponseMessage.Content.ReadAsStringAsync();
                    deserializedResponse = JsonConvert.DeserializeObject<PaymentRequestResponse>(response);
                }
            }
            return deserializedResponse;
        }

        /// <summary>
        /// تایید خرید تسویه اشتراکی
        /// </summary>
        /// <param name="authority">كد يكتاي شناسه مرجع درخواست</param>
        /// <returns></returns>
        public async Task<PaymentVerificationWithExtraResponse> VerificationWithExtra(string authority)
        {
            PaymentVerificationWithExtraResponse deserializedResponse;
            using (var httpClient = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(new
                {
                    MerchantID = _merchantId,
                    Amount = _amount,
                    Authority = authority
                });
                using (var httpResponseMessage = await httpClient.PostAsync("https://www.zarinpal.com/pg/rest/WebGate/PaymentVerificationWithExtra.json", new StringContent(content, Encoding.UTF8, "application/json")))
                {
                    var response = await httpResponseMessage.Content.ReadAsStringAsync();
                    deserializedResponse = JsonConvert.DeserializeObject<PaymentVerificationWithExtraResponse>(response);
                }
            }
            return deserializedResponse;
        }

        #endregion
    }
}
