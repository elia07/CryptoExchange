using Finary.Core.Repositories;
using Finary.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Finary.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public async Task<ActionResult> Index()
        {
            long userID = new SessionUtils().GetSessionValue<long>(Session, DomainInfo.UserSessionName);
            using (UserRepository ur = new UserRepository())
            {
                var instance = await ur.GetByID(userID);
               
                ViewBag.UserInstance = instance;

            }
            return View();
        }
    }
}