using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GA.Core.Util
{
    public class ServicesLogger : TraceSourceLogger
    {
        public ServicesLogger() : base("Services")
        {

        }
    }

    public class ServerLogger : TraceSourceLogger
    {
        public ServerLogger() : base("Server")
        {

        }
    }
}