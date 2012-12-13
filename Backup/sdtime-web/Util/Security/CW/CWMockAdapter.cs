using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace sdtime.Util.Security
{
    using sdtime.Members;

    public class CWMockAdapter : ICWAdapter
    {

        public bool CheckMemberIDExists(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return false;
            return true;
        }


        public Members.ApiCredentials GetMembersApiCreds()
        {
            return new Members.ApiCredentials
            { // TODO: refactor to remove cred from the codepage
                CompanyId = "SD",
                IntegratorLoginId = "SDAppUser",
                IntegratorPassword = "s0m3th!ng"
            };
        }


        public MemberFindResult[] FindMember(string login = null, string email = null)
        {
            return new MemberFindResult[] {
                new MemberFindResult { MemberID = "GFERRIE", FirstName = "Glenn", LastName = "Ferrie", EmailAddress = "gferrie@somethingdigital.com" }
            };
        }
    }
}