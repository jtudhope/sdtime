using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sdtime.Models.Support
{
    public class Ticket
    {
        public string name { get; set; }
        public string client { get; set; }
        public int number { get; set; }
        public string assigned { get; set; }
        public string description { get; set; }
        public double budget { get; set; }
        public double actual { get; set; }
        public int statusId { get; set; }

        public CWTicketService.Ticket GetContractObject()
        {
            CWTicketService.Ticket tc = new CWTicketService.Ticket();
            tc.AssignedMember = assigned;
            tc.ClientName = client;
            tc.HoursBudget = budget;
            tc.HoursActual = actual;
            tc.StatusID = statusId;
            tc.Title = name;
            tc.TicketID = number;
            return tc;
        }
    }
}