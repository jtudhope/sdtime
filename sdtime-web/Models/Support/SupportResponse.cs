using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sdtime.Models.Support
{
    public class SupportResponse
    {
        public SupportResponse()
        {
            members = new List<Member>();
            buckets = new List<Bucket>();
            clients = new List<Client>();
        }
        public List<Member> members { get; set; }
        public List<Bucket> buckets { get; set; }
        public List<Client> clients { get; set; }
        
    }
}