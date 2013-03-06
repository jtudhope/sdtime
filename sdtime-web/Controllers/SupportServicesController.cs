using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sdtime.Models.Support;
using sdtime.Models;

namespace sdtime.Controllers
{
    public class SupportServicesController : Controller
    {
        //
        // GET: /SupportServices/

        public ActionResult ServiceBoard()
        {
            List<Bucket> buckets = new List<Bucket>();
            int diff = DateTime.Now.DayOfWeek - DayOfWeek.Monday;
            if (diff < 0) { diff += 7; }
            DateTime startDate = DateTime.Now.AddDays((-1 * diff) -1).Date;
            DateTime endDate = startDate.AddDays(7);

            ConnectWiseEntities entities = new ConnectWiseEntities();
            var tickets = entities.somethingdigital_vTickets.Where(t => t.scheduleDate < endDate && t.scheduleDate > startDate).OrderBy(t=>t.Sort_Order);
            foreach (string status in tickets.Select(t => t.status).Distinct())
            {
                buckets.Add(new Bucket { name = status, status = status });
            }
            foreach (somethingdigital_vTickets ticket in tickets)
            {
                Bucket tmp = buckets.First(b=>b.status == ticket.status);
                if (tmp.tickets == null)
                    tmp.tickets = new List<Ticket>();
                tmp.tickets.Add(new Ticket { assigned = ticket.Employee, budget = Convert.ToDouble(ticket.budget.GetValueOrDefault(0)), client = ticket.client, description = "", name = ticket.name, number = ticket.ticketid });
            }

            return Json(buckets, JsonRequestBehavior.AllowGet);
        }

    }
}
