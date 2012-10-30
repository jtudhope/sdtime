using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GA.Core.Security;
using Microsoft.IdentityModel.Claims;

namespace sdtime.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult ViewProfile()
        {
            var mgr = new UserManager();
            var id = User.Identity as ClaimsIdentity;
            if (id != null)
            {
                var claims = id.Claims;
                var data = claims.GetClaimsInfo();
                if (!mgr.UserExists(data.IdentityProviderName, data.ProviderKey))
                    return RedirectToAction("Index", "RegisterUser");
                var user = mgr.GetUserByKey(data.IdentityProviderName, data.ProviderKey);
                ViewBag.Username = user.DisplayName;
                ViewBag.ProviderName = user.IdentityProviderName;
                ViewBag.MemerSince = user.MemberSince.GetValueOrDefault().ToString("mm/dd/yy");
            }
            return View();
            
        }

    }
}
