using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SD.CWServices.Model;
using SD.CWServices.Model.Tickets;

namespace SD.CWServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class TicketService : ITicketService
    {

        public IEnumerable<Ticket> GetTicketsForTheWeek(int?[] members, int?[] clients, int serviceBoard)
        {
            List<Ticket> returnTickets = new List<Ticket>();
            ConnectwiseEntities entities = new ConnectwiseEntities();

            int diff = DateTime.Now.DayOfWeek - DayOfWeek.Monday;
            if (diff < 0) { diff += 7; }
            DateTime startDate = DateTime.Now.AddDays((-1 * diff) - 1).Date;
            DateTime endDate = startDate.AddDays(7);

            var tickets = entities.somethingdigital_vTickets.Where(t => t.scheduleDate < endDate && t.scheduleDate > startDate);
            if (members != null)
                tickets = tickets.Where(t => members.Contains(t.employeeId));
            if (clients != null)
                tickets = tickets.Where(t => clients.Contains(t.clientId));
            tickets = tickets.Where(t => t.boardId == serviceBoard);
            tickets = tickets.OrderBy(t => t.Sort_Order);

            foreach (somethingdigital_vTickets ticket in tickets)
                returnTickets.Add( Ticket.CreateTicket(ticket));

            return returnTickets;
        }

        public IEnumerable<Ticket> GetTicketsForAllTime(int?[] members, int?[] clients, int serviceBoard)
        {
            List<Ticket> returnTickets = new List<Ticket>();
            ConnectwiseEntities entities = new ConnectwiseEntities();

            int diff = DateTime.Now.DayOfWeek - DayOfWeek.Monday;
            if (diff < 0) { diff += 7; }
            DateTime startDate = DateTime.Now.AddDays((-1 * diff) - 1).Date;
            DateTime endDate = startDate.AddDays(7);

            var tickets = entities.somethingdigital_vTickets.Where(t => t.boardId == serviceBoard);
            if (members != null)
                tickets = tickets.Where(t => members.Contains(t.employeeId));
            if (clients != null)
                tickets = tickets.Where(t => clients.Contains(t.clientId));

            tickets = tickets.OrderBy(t => t.Sort_Order);

            foreach (somethingdigital_vTickets ticket in tickets)
                returnTickets.Add(Ticket.CreateTicket(ticket));

            return returnTickets;
        }

        public bool SetTicket(Model.Tickets.Ticket ticket)
        {
            ConnectwiseEntities entities = new ConnectwiseEntities();
            SR_Service SR_ticket = entities.SR_Service.First(t => t.SR_Service_RecID == ticket.TicketID);
            if (ticket.StatusID > 0)
                SR_ticket.SR_Status_RecID = ticket.StatusID;
            if (ticket.HoursBudget > 0) 
                SR_ticket.Hours_Budget = (decimal)ticket.HoursBudget;
            return entities.SaveChanges() > 0;

        }


        public IEnumerable<Status> GetStatus(int serviceBoard)
        {
            List<Status> statusList = new List<Status>();
            ConnectwiseEntities entities = new ConnectwiseEntities();

            List<string> exclusions = new List<string>  {"New (portal)", "New (email connector)", "Ready for Front End Development", "Closed", "Code Status Review", "Canceled", "Done yet?", "Waiting parts/repair" };

            foreach (SR_Status status in entities.SR_Status.Where(s => s.SR_Board_RecID == serviceBoard))
            {
                if (!exclusions.Contains(status.Description))
                    statusList.Add(Status.CreateStatus(status));
            }
            return statusList;
        }
    }
}
