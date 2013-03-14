using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Weavver.Data;
using Weavver.Security;
using Weavver.Utilities;

namespace WeavverConsole
{
     public class Program
     {
//-------------------------------------------------------------------------------------------
          static void Main(string[] args)
          {
               AppDomain appdomain = AppDomain.CurrentDomain;
               appdomain.UnhandledException += new UnhandledExceptionEventHandler(AppDomain_UnhandledException);

               Environment.ExitCode = 1;

               CommandLineArguments parsedArgs = new CommandLineArguments(args);

               if (parsedArgs["run-cron"] == "true")
               {
                    var type = typeof(ICRON);
                    var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
                        .SelectMany(s => s.GetTypes())
                        .Where(p => type.IsAssignableFrom(p) && p.IsClass);

                    foreach (var interfacedClassType in types)
                    {
                         object o = Activator.CreateInstance(interfacedClassType);
                         var cronInterface = o as ICRON;
                         cronInterface.RunCronTasks(parsedArgs);
                    }

                    Environment.ExitCode = 0;
               }

               if (parsedArgs["ejabberd-extauth"] == "true")
               {
                    Weavver.Vendors.ejabberdAuth ejabberAuth = new Weavver.Vendors.ejabberdAuth();
                    ejabberAuth.Check();

                    Environment.ExitCode = 0;
               }
          }
//-------------------------------------------------------------------------------------------
          static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
          {
               Exception ex = (Exception) e.ExceptionObject;
               Weavver.Utilities.Common.Log("Weavver Console error:", ex.ToString());

               Environment.Exit(1);
          }
//-------------------------------------------------------------------------------------------
     }
}