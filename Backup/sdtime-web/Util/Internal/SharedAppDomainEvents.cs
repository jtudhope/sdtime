using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GA.Core.Util.Internal
{
    public static class SharedAppDomainEvents
    {
        public static void HandleAssemblyResolveEvent()
        {
            AppDomain.CurrentDomain.AssemblyResolve += SharedAppDomainEvents.AssemblyResolveHandler;
        }

        public static Assembly AssemblyResolveHandler(object sender, ResolveEventArgs args)
        {
            var logger = new ServerLogger();
            logger.Log(TraceEventType.Warning, "Resolving Assembly: " + args.Name);
            Assembly match = null;
            var argsParts = args.Name.Split(',');
            var targetToLower = (argsParts.Length > 0) ? argsParts[0].ToLower() : args.Name.ToLower();
            var basedir = AppDomain.CurrentDomain.BaseDirectory;
            var providersdir = Path.Combine(basedir, "Providers");
            var assemblypaths_all = Directory.GetFiles(providersdir)
                                .Where(q => q.ToLower().Contains(".dll"));

            var assemblypaths = assemblypaths_all
                .Where(q => q.ToLower().Contains(targetToLower)).ToList();

            var count = assemblypaths.Count;
            logger.Log(TraceEventType.Verbose, "Items found in Providers dir: {0}", count);

            foreach (var item in assemblypaths)
            {
                Assembly a1 = null;
                try { a1 = Assembly.LoadFile(item); }
                finally { }
                if (a1 != null)
                {
                    if (a1.FullName == args.Name)
                    {
                        match = a1;
                        break;
                    }

                    if (a1.FullName.StartsWith(args.Name))
                    {
                        match = a1;
                        break;
                    }
                }
            }

            if (match == null)
                logger.Log(TraceEventType.Warning, "NO Match found");
            else
                logger.Log(TraceEventType.Information, "Match found");

            logger = null;
            return match;
        }
    }
}
