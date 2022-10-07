using Finary.Attributes;
using Finary.DomainUtils;
using Finary.Jobs;
using Finary.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using RockCandy.Web.Framework.Utilities;

namespace Finary.Controllers
{
    
    public class InstantExchangeController : Controller
    {
        public ActionResult SearchTransaction()
        {
            return View();
        }
        public async Task<ActionResult> TransactionStatus(string id)
        {
            var res = await new Changenow().TransactionStatus(id);
            if (res.id!=null)
            {
                switch(res.status)
                {
                    case "new":
                        res.status = "";
                        break;
                    case "waiting":
                        res.status = "منتظر واریز";
                        break;
                    case "confirming":
                        res.status = "درحال تایید";
                        break;
                    case "exchanging":
                        res.status = "در حال تبدیل";
                        break;
                    case "sending":
                        res.status = "در حال ارسال";
                        break;
                    case "finished":
                        res.status = "پایان";
                        break;
                    case "failed":
                        res.status = "خطا در تبادل";
                        break;
                    case "refunded":
                        res.status = "بازپرداخت شده";
                        break;
                    case "verifying":
                        res.status = "در حال تایید";
                        break;
                    case "expired":
                        res.status = "منقضی شده";
                        break;
                }
                var updateAtDateObject = DateTime.Parse(res.updatedAt);
                res.updatedAt = DateConvertor.MiladiToShamsi(updateAtDateObject) + "- " + updateAtDateObject.ToShortTimeString();

                var createdAtDateObject = DateTime.Parse(res.createdAt);
                res.createdAt = DateConvertor.MiladiToShamsi(createdAtDateObject) + "- " + createdAtDateObject.ToShortTimeString();
            }
            else
            {
                res.status = "تراکنش پیدا نشد";
            }
            ViewBag.TransactionStatusModel = res;
            return View();
        }
        public async Task<ActionResult> CreateTransaction(double amount, string from,string to,string recipientWallet,string refundWallet,string userEmail, bool fixedExchange = false)
        {
            //return Json(await new Changenow().CreateClassicTransaction();
            var changeNow = new Changenow();
            if(!(await changeNow.AddressValidation(to,recipientWallet)).result)
            {
                TempData["err"] = "آدرس ولت مقصد معتبر نیست";
            }
            if (!(await changeNow.AddressValidation(from, refundWallet)).result)
            {
                TempData["err"] = "آدرس ولت بازپرداخت معتبر نیست";
            }
            if (((await changeNow.MinExchangeAmount(from+"_"+to)).minAmount>amount))
            {
                TempData["err"] = "کمینه تبادل رعایت نشده است";
            }

            if(fixedExchange)
            {

            }
            else
            {
                var res=await changeNow.CreateClassicTransaction(from, to, recipientWallet, amount, refundWallet, "", "", "");
                if(res.fromCurrency==null)
                {
                    return RedirectToAction(nameof(HomeController.CustomError), "Home", new { err = "لطفا دقایقی بعد مجدد امتحان کنید" });
                }

                //long userID = new SessionUtils().GetSessionValue<long>(Session, DomainInfo.UserSessionName);

                return RedirectToAction(nameof(TransactionStatus), new { id = res.id });
            }
            
            return null;
        }
        public ActionResult StartExchange(double amount=1, string from_to="eth_btc", bool fixedExchange = false)
        {
            ViewBag.amount = amount;
            ViewBag.from = from_to.Split('_')[0];
            ViewBag.to = from_to.Split('_')[1];
            ViewBag.fixedExchange = fixedExchange;
            return View();
        }

        [AllowJsonGetAttribute]
        public ActionResult GetAvailableCurrencies(bool fixedRate=false)
        {
            if(fixedRate)
            {
                return Json(DomainInfo.AvailableCurrencies.Select(x => x.Value).Where(y => y.supportsFixedRate == true).ToList().OrderBy(x=>x.name));
            }
            else
            {
                return Json(DomainInfo.AvailableCurrencies.Select(x => x.Value).ToList().OrderBy(x => x.name));
            }
            
        }


        [AllowJsonGetAttribute]
        public async Task<ActionResult> AddressValidation(string currency, string address)
        {
            return Json(await new Changenow().AddressValidation(currency,address));
        }

        [AllowJsonGetAttribute]
        public async Task<ActionResult> GetAvailableCurrenciesFor(string basePair,bool fixedRate = false)
        {
            var res = await new Changenow().GetAvailbleCurrenciesFor(basePair, fixedRate);
            return Json(res.Where(x=>x.isAvailable && x.isFiat==false).ToList());
        }

        [AllowJsonGetAttribute]
        public async Task<ActionResult> EstimatedExchangeAmount(double amount,string from_to,bool fixedRate=false)
        {


            /*var chObj = new Changenow();
            var res = await chObj.EstimatedExchangeAmount(amount, from_to);
            if(res.estimatedAmount==null)
            {
                var minAmount = await chObj.MinExchangeAmount(from_to);
                return Json(await chObj.EstimatedExchangeAmount(minAmount.minAmount, from_to));
            }
            else
            {
                return Json(await chObj.EstimatedExchangeAmount(amount, from_to));
            }
            */
            var res = await new Changenow().EstimatedExchangeAmount(amount, from_to, fixedRate);
            return Json(res);
        }

        [AllowJsonGetAttribute]
        public async Task<ActionResult> MinExchangeAmount(string from_to)
        {
            return Json(await new Changenow().MinExchangeAmount(from_to));
        }

    }
}