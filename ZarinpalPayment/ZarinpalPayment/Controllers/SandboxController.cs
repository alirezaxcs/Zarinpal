﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZarinpalPayment.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZarinpalPayment.Controllers
{
    public class SandboxController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment(Payment model)
        {
            //برای سندباکس نیازی به وارد کردن مرچنت کد نیست
            var payment = await new ZarinpalSandbox.Payment(model.Amount)
                .PaymentRequest(model.Description,
                    Url.Action(nameof(PaymentVerify), "Sandbox", new { amount = model.Amount }, Request.Scheme),
                    model.Email,
                    model.Mobile);
            //در صورت موفق آمیز بودن درخواست، کاربر به صفحه پرداخت هدایت می شود
            //در غیر این صورت خطا نمایش داده شود
            return payment.Status == 100 ? (IActionResult)Redirect(payment.Link) : BadRequest();
        }

        public async Task<IActionResult> PaymentVerify(int amount, string Authority, string Status)
        {
            //توجه
            //بهتر است که به جای ارسال مبلغ به این متد، در این متد هم مبلغ را محاسبه کنید و سپس ادامه دهید.
            //****************
            if (Status == "NOK") return View("Error");
            //گرفتن تاییدیه پرداخت
            var verification = await new ZarinpalSandbox.Payment(amount)
                .Verification(Authority);
            //ارسال به صفحه خطا
            if (verification.Status != 100) return View("Error");
            //ارسال کد تراکنش به جهت نمایش به کاربر
            var refId = verification.RefId;
            return Ok();
        }
    }
}
