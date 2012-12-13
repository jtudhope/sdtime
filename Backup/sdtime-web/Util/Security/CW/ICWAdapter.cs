using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace sdtime.Util.Security
{
    using sdtime.Members;

    public interface ICWAdapter
    {
        bool CheckMemberIDExists(string id);
        ApiCredentials GetMembersApiCreds();
        MemberFindResult[] FindMember(string login = null, string email = null);
    }
}