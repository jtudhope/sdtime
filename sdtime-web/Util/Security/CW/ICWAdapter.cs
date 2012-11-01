using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sdtime.Util.Security
{
    public interface ICWAdapter
    {
        bool? CheckMemberIDExists(string id);
    }
}