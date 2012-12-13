using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using GA.Core.Util;
using sdtime.Util.Security;

namespace sdtime.Controllers
{
    public class ApiController : Controller
    {
        public JsonResult FindMember(FindMemberRequest req)
        {
            dynamic data = new ExpandoObject();
            try
            {
                var cw = IOCContainer.Resolve<ICWAdapter>();
                var resultsArray = cw.FindMember(req.Name, req.EmailAddress);
                data.Results = resultsArray.FirstOrDefault(); // assume one match
                data.HasError = false;
            }
            catch (Exception ex)
            {
                data.Message = ex.Message;
                data.HasError = true;
            }
            return Json(data);
        }

        // TODO: WIP
        public JsonResult GetTimeEntries(TimeEntryRequest req)
        {
            return Json(new { f = "rrr" });           
        }
    }
}
