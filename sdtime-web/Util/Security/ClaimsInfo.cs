using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sdtime.Security
{
    public class ClaimsInfo
    {
        public string IdentityProviderName { get; set; }
        
        public string ProviderKey { get; set; }

        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }

        public string ConnectwiseID { get; set; }


    }
}