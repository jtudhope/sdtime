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


        public ActionResult UpdateTicket(Ticket ticket)
        {
            CWTicketService.TicketServiceClient client = new CWTicketService.TicketServiceClient();
            
            return Json(client.SetTicket(ticket.GetContractObject()));
        }

        public ActionResult ServiceBoard(int? [] members, int? [] clients)
        {
            SupportResponse response = new SupportResponse();
            response.buckets = new List<Bucket>();
            response.members = new List<Member>();
            response.clients= new List<Client>();
                 

            /*
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
            */

            CWTicketService.TicketServiceClient client = new CWTicketService.TicketServiceClient();
            List<CWTicketService.Ticket> svcTickets = client.GetTicketsForTheWeek(members, clients, 11).ToList();
            List<CWTicketService.Status> svcStatuss = client.GetStatus(11).ToList();
                
            foreach (CWTicketService.Status svcStatus in svcStatuss)
            {
                response.buckets.Add(new Bucket { name = svcStatus.Title, status = svcStatus.Title, statusId = svcStatus.StatusID, sortOrder = svcStatus.SortOrder });
            }
            foreach (CWTicketService.Ticket svcTicket in svcTickets)
            {
                Bucket tmp = response.buckets.FirstOrDefault(b => b.statusId == svcTicket.StatusID);
                if (tmp != null)
                {
                    if (tmp.tickets == null)
                        tmp.tickets = new List<Ticket>();
                    if (!response.members.Any(m => m.memberId == svcTicket.AssignedMemberId))
                        response.members.Add(new Member { fullName = svcTicket.AssignedMember, memberId = svcTicket.AssignedMemberId });
                    if (!response.clients.Any(m => m.clientId == svcTicket.ClientID))
                        response.clients.Add(new Client { clientId = svcTicket.ClientID, clientName = svcTicket.ClientName });

                    tmp.tickets.Add(new Ticket { assigned = svcTicket.AssignedMember, budget = svcTicket.HoursBudget, actual = svcTicket.HoursActual, client = svcTicket.ClientName, description = "", name = svcTicket.Title, number = svcTicket.TicketID, statusId = svcTicket.StatusID });
                }
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}
