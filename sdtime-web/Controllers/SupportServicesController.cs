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

        

        public ActionResult ServiceBoard(int? [] members, int? [] clients)
        {
            SupportResponse response = new SupportResponse();
            response.buckets = new List<Bucket>();
            response.members = new List<Member>();
            response.clients= new List<Client>();
                 

            
            int diff = DateTime.Now.DayOfWeek - DayOfWeek.Monday;
            if (diff < 0) { diff += 7; }
            DateTime startDate = DateTime.Now.AddDays((-1 * diff) -1).Date;
            DateTime endDate = startDate.AddDays(7);

            ConnectWiseEntities entities = new ConnectWiseEntities();

            var tickets = entities.somethingdigital_vTickets.Where(t => t.scheduleDate < endDate && t.scheduleDate > startDate);
            if (members != null)
                tickets = tickets.Where(t => members.Contains(t.employeeId));
            if (clients != null)
                tickets = tickets.Where(t => clients.Contains(t.clientId));
            tickets = tickets.OrderBy(t => t.Sort_Order);
            
                
            foreach (string status in tickets.Select(t => t.status).Distinct())
            {
                response.buckets.Add(new Bucket { name = status, status = status });
            }
            foreach (somethingdigital_vTickets ticket in tickets)
            {
                Bucket tmp = response.buckets.First(b => b.status == ticket.status);
                if (tmp.tickets == null)
                    tmp.tickets = new List<Ticket>();
                if (!response.members.Any(m => m.memberId == ticket.employeeId))
                    response.members.Add(new Member { fullName = ticket.Employee, memberId = ticket.employeeId.GetValueOrDefault(0) });
                if (!response.clients.Any(m => m.clientId == ticket.clientId))
                    response.clients.Add(new Client { clientId = ticket.clientId.GetValueOrDefault(0), clientName = ticket.client });
                
                tmp.tickets.Add(new Ticket { assigned = ticket.Employee, budget = Convert.ToDouble(ticket.budget.GetValueOrDefault(0)), client = ticket.client, description = "", name = ticket.name, number = ticket.ticketid });
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}
