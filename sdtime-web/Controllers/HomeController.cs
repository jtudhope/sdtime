using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.IdentityModel.Claims;

using GA.Core.Security;
using sdtime.Security;

namespace sdtime.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var mgr = new UserManager();
            var id = User.Identity as ClaimsIdentity;
            if (id != null)
            {
                var claims = id.Claims;
                var data = claims.GetClaimsInfo();

                if (!mgr.UserExists(data.IdentityProviderName, data.ProviderKey))
                {
                    return RedirectToAction("Index", "RegisterUser");
                }
                
            }
            return View();
        }

    }
}
