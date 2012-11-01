using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sdtime.Util.Security
{
    public class CWAdapter : ICWAdapter
    {
        public bool? CheckMemberIDExists(string id)
        {
            try
            {
                var client = new Members.MemberApiSoapClient();
                var query = string.Empty;

                if (!string.IsNullOrEmpty(id))
                {

                    query += "MemberID = \"" + id.Replace("\"", "\"\"") + "\"";

                }

                if (string.IsNullOrWhiteSpace(id)) return false;

                var resultsArray = client.FindMembers(
                    new Members.ApiCredentials
                    { // TODO: refactor to remove cred from the codepage
                        CompanyId = "SD",
                        IntegratorLoginId = "SDAppUser",
                        IntegratorPassword = "s0m3th!ng"
                    },
                        query, "", null, null);

                return resultsArray.Any();
            }
            catch (Exception)
            {
                //Debug.Fail(ex.ToString());
                return true;
            }
        }
    }
}