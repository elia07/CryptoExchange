using BotDetect.Web.Mvc;
using Finary.Core;
using Finary.Core.Models.DTO;
using Finary.Core.Repositories;
using Finary.Core.Utils;
using RockCandy.Web.Framework.Core.ActionFilters;
using RockCandy.Web.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Finary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [CaptchaValidation("CaptchaLogin", "CaptchaLogin", "")]
        [AjaxAntiForgeryValidateAttribute]
        //[Throttle(Name = "HomeLogin", Message = "You must wait {n} seconds before accessing this url again.", Seconds = 1)]
        public ActionResult Login(UserDTO args, bool captchaValid)
        {
            JsonResponse jr = new JsonResponse(false, "");
            try
            {
                if (!captchaValid)
                {
                    jr.Message = "کد امنیتی اشتباه است";
                    jr.CustomFields.Add("title", "خطا");
                    jr.CustomFields.Add("confirmButtonText", "باشه");
                    return Json(jr);
                }


                using (UserRepository ur = new UserRepository(null, true))
                {


                    var saltInstance = ur.GetbyEmail(args.Email);
                    if (saltInstance == null)
                    {
                        jr.CustomFields.Add("title", "خطا");
                        jr.CustomFields.Add("confirmButtonText", "باشه");
                        jr.Message = "اطلاعات ورود اشتباه است";
                    }
                    else
                    {
                        args.Password = new EncryptionUtils().ComputeSha256Hash(args.Password + saltInstance.xSalt);
                        var userInstance = ur.Authentication(args);
                        if (userInstance != null)
                        {
                            if (userInstance.xIsActive)
                            {
                                CookieUtils cu = new CookieUtils();
                                string deviceID = "";
                                var deviceIDCookie = cu.GetCookieValue<string>("deviceID",DomainInfo.Setting.ApplicationName,DomainInfo.Setting.SecurityKey, Request);
                                if (deviceIDCookie != null)
                                {
                                    deviceID = deviceIDCookie;
                                }
                                else
                                {
                                    cu.AddCookie("deviceID", DomainInfo.Setting.ApplicationName, DomainInfo.Setting.SecurityKey, userInstance.xEmail, Int32.MaxValue);
                                }

                                string cfray = "";
                                try
                                {
                                    cfray = Request.Headers["CF-Ray"];
                                }
                                catch { }
                                new LoginHistoryRepository().Insert(IPUtils.GetClientIpAddress(Request), deviceID, userInstance.xID, Request.UserAgent, cfray);
                                jr.CustomFields.Add("title", "خوش آمدید");
                                jr.CustomFields.Add("confirmButtonText", "باشه");
                                jr.Message = "";
                                jr.Status = true;
                                try
                                {
                                    new SessionUtils().AddSession(Session, DomainInfo.UserSessionName, userInstance.xID);
                                }
                                catch
                                {
                                    new SessionUtils().RemoveSession(Session, DomainInfo.UserSessionName);
                                    new SessionUtils().AddSession(Session, DomainInfo.UserSessionName, userInstance.xID);
                                }

                                userInstance.xLastSigninDate = DateTime.Now;
                                ur.Update(userInstance);
                               
                            }
                            else
                            {
                                jr.CustomFields.Add("title", "خطا در ورود");
                                jr.CustomFields.Add("confirmButtonText", "باشه");
                                jr.Message = userInstance.xDescription;
                            }


                        }
                        else
                        {
                            jr.CustomFields.Add("title", "خطا در ورود");
                            jr.CustomFields.Add("confirmButtonText", "باشه");
                            jr.Message ="اطلاعات ورود صحیح نیست";
                        }
                    }


                }
            }
            catch (Exception e)
            {
                jr.Message = e.Message;
            }



            return Json(jr);

        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [CaptchaValidation("RegisterCaptcha", "RegisterCaptcha", "")]
        [AjaxAntiForgeryValidateAttribute]
        public async Task<ActionResult> Register(UserDTO args, bool captchaValid)
        {
            if (!captchaValid)
            {
                JsonResponse jr = new JsonResponse(false, "");
                jr.Message = "کد امنیتی اشتباه است";
                jr.CustomFields.Add("title", "خطا");
                jr.CustomFields.Add("confirmButtonText", "باشه");
                return Json(jr);
            }
            var res = await new UserRepository().RegisterUser(args);
            if (res.Status)
            {
                //TODO Send Email ,sms ,....
            }
            return Json(res);
        }

        public ActionResult CustomError(string err="")
        {
            ViewBag.err = err;
            return View();
        }

        public ActionResult Page404()
        {
            //TODO View
            return View();
        }

        public ActionResult Page500()
        {
            //TODO View
            return View();
        }

    }
}