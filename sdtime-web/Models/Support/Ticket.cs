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
    }
}