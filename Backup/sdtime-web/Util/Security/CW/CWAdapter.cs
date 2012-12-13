using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GA.Core.Util;
using sdtime.Members;

namespace sdtime.Util.Security
{
    public class CWAdapter : ICWAdapter
    {
        public bool CheckMemberIDExists(string id)
        {
            try
            {
                var client = new Members.MemberApiSoapClient();
                var query = string.Empty;

                if (string.IsNullOrWhiteSpace(id)) return false;

                if (!string.IsNullOrEmpty(id)) 
                    query += string.Format("MemberID = \"{0}\"", id.Replace("\"", "\"\""));

                var resultsArray = client.FindMembers(this.GetMembersApiCreds(), query, "", null, null);

                return resultsArray.Any();
            }
            catch (Exception ex)
            {
                IOCContainer.Resolve<ILogger>().Error(ex, "Check CW Member Exists");
                return false;
            }
        }

        public ApiCredentials GetMembersApiCreds()
        {
            return new ApiCredentials
                    { // TODO: refactor to remove cred from the codepage
                        CompanyId = "SD",
                        IntegratorLoginId = "SDAppUser",
                        IntegratorPassword = "s0m3th!ng"
                    };
        }

        public MemberFindResult[] FindMember(string login = null, string email = null)
        {
            var client = new Members.MemberApiSoapClient();
            // TODO: Async?
            var query = string.Empty;
            if (!String.IsNullOrEmpty(email))
            {
                query += "EmailAddress = \"" + email.Replace("\"", "\"\"") + "\"";
            }
            if (!string.IsNullOrEmpty(login))
            {
                if (string.IsNullOrEmpty(query))
                {
                    query += "MemberID = \"" + login.Replace("\"", "\"\"") + "\"";
                }
                else
                {
                    query += " And MemberID = \"" + login.Replace("\"", "\"\"") + "\"";
                }
            }
            var resultsArray = client.FindMembers(this.GetMembersApiCreds(), query, "", null, null);

            return resultsArray;
        }
    }
}