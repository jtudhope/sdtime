using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.IdentityModel.Claims;
using GA.Core.Security;
using System.Diagnostics;
using sdtime.Util.Security.Model;
using sdtime.Util.Security;
using GA.Core.Util;

namespace sdtime.Controllers
{
    public class RegisterUserController : Controller
    {
        //
        // GET: /RegisterUser/

        public ActionResult Index()
        {
            var id = User.Identity as ClaimsIdentity;
            if (id != null)
            {
                var claims = id.Claims;
                var data = claims.GetClaimsInfo();
                return View(data);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Submit(FormCollection collection)
        {
            var id = User.Identity as ClaimsIdentity;
            if (id != null)
            {
                var claims = id.Claims;
                var data = claims.GetClaimsInfo();

                data.ConnectwiseID = collection["ConnectwiseID"];

                var cw = IOCContainer.Resolve<ICWAdapter>();
                
                if (cw.CheckMemberIDExists(data.ConnectwiseID).GetValueOrDefault(false))
                {
                    var mgr = new UserManager();
                    var user = new User { IsActive = true, MemberSince = DateTime.Now, EmailAddress = data.EmailAddress, DisplayName = data.ConnectwiseID, IdentityProviderKey = data.ProviderKey, IdentityProviderName = data.IdentityProviderName };
                    mgr.RegisterNewUser(user);
                }
                else
                {
                    ViewBag.ErrorMessage = "Unknown Connectwise user";
                    return View("Index", data);
                }
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
