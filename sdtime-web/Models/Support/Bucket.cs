using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sdtime.Models.Support
{
    public class Bucket
    {
        public string name { get; set; }
        public string status { get; set; }
        public int statusId { get; set; }
        public int sortOrder { get; set; }
        public List<Ticket> tickets { get; set; }
    }
}
