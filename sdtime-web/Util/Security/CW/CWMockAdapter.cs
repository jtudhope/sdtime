using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sdtime.Util.Security
{
    public class CWMockAdapter : ICWAdapter
    {

        public bool? CheckMemberIDExists(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return false;
            return true;
        }
    }
}