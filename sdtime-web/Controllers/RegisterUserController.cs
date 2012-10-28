using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.IdentityModel.Claims;
using GA.Core.Security;
using sdtime.Security.Model;

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

                if (this._checkCWID(data.ConnectwiseID))
                {
                    var mgr = new UserManager();
                    var user = new User { EmailAddress = data.EmailAddress, DisplayName = data.ConnectwiseID, IdentityProviderKey = data.ProviderKey, IdentityProviderName = data.IdentityProviderName };
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

        private bool _checkCWID(string id)
        {
            var client = new Members.MemberApiSoapClient();
            var query = string.Empty;
            
            if (!string.IsNullOrEmpty(id))
            {
                
                query += "MemberID = \"" + id.Replace("\"", "\"\"") + "\"";
                
            }

            if (string.IsNullOrWhiteSpace(id)) return false;

            var resultsArray = client.FindMembers(
                new Members.ApiCredentials
                { // TODO: refactor to remove cred from the codepage
                    CompanyId = "SD",
                    IntegratorLoginId = "SDAppUser",
                    IntegratorPassword = "s0m3th!ng"
                },
                    query, "", null, null);

            return resultsArray.Any();
        }
    }
}
