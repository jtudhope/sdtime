using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

namespace sdtime.Controllers
{
    public class ApiController : Controller
    {
        //
        // GET: /Api/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult FindMember(FindMemberRequest req)
        {
            dynamic data = new ExpandoObject();
            try
            {
                var client = new Members.MemberApiSoapClient();
                // TODO: Async?
                var query = string.Empty;
                if (!String.IsNullOrEmpty(req.EmailAddress))
                {
                    query += "EmailAddress = \"" + req.EmailAddress.Replace("\"", "\"\"") + "\"";
                }
                if (!string.IsNullOrEmpty(req.Name))
                {
                    if (string.IsNullOrEmpty(query))
                    {
                        query += "MemberID = \"" + req.Name.Replace("\"", "\"\"") + "\"";
                    }
                    else
                    {
                        query += " And MemberID = \"" + req.Name.Replace("\"", "\"\"") + "\"";
                    }
                }
                var resultsArray = client.FindMembers(
                    new Members.ApiCredentials { // TODO: refactor to remove cred from the codepage
                        CompanyId = "SD", IntegratorLoginId = "SDAppUser", IntegratorPassword = "s0m3th!ng" }, 
                        query, "", null, null);
                data.Results = resultsArray.FirstOrDefault(); // assume one match
                data.HasError = true;
            }
            catch (Exception ex)
            {
                data.Message = ex.Message;
                data.HasError = true;
            }
            return Json(data);
        }
    }
}
