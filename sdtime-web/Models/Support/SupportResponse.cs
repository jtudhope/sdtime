using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sdtime.Models.Support
{
    public class SupportResponse
    {
        public List<Member> members { get; set; }
        public List<Bucket> buckets { get; set; }
        public List<Client> clients { get; set; }
        
    }
}