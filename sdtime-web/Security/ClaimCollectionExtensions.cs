using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.IdentityModel.Claims;
using sdtime.Security;


namespace Microsoft.IdentityModel.Claims
{
    public static class ClaimCollectionExtensions
    {
        public static ClaimsInfo GetClaimsInfo(this ClaimCollection claims)
        {
            var ni = claims.FirstOrDefault(q => q.ClaimType == ClaimTypes.NameIdentifier);
            var ip = claims.FirstOrDefault(q => q.ClaimType == "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider");
            var eml = claims.FirstOrDefault(q => q.ClaimType == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            var name = claims.FirstOrDefault(q => q.ClaimType == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");

            Func<Claim, string> checknull = c => c == null ? string.Empty : c.Value;
            return new ClaimsInfo { DisplayName = checknull(name), EmailAddress = checknull(eml), ProviderKey = checknull(ni), IdentityProviderName = checknull(ip) };

                
        }
    }
}