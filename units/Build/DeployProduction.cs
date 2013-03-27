using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Weavver.Data;
using Weavver.Testing;
using System.Reflection;

namespace Weavver.Testing.Staging
{
     public class DeployProduction
     {
//-------------------------------------------------------------------------------------------
          [ManualTest]
          public void Run()
          {
               //var count = (from x in TestingContext.Tests
               //             where x.Status != "Passed" &&
               //                   IsStagingOrProductionTest(x)
               //             select x).Count();

               //if (count > 0)
               //{
               //     throw new Exception(String.Format("Detected {0} non-passing tests.. This deployment can not continue.", count));
               //     return;
               //}
               //else
               //{
               //     Console.WriteLine("The tests are all in a Passed state.. Now deploying to the production system.");
               //}

               Console.WriteLine("Publishing the updated files from SVN...");
               string localPath = @"C:\inetpub\weavver.com";
               string svnPath = "https://svn.weavver.com/main/Servers/web/c/Inetpub/www";
               UpdateStagingSVN.UpdateSVN(localPath, svnPath);

               Console.WriteLine("Copying the binaries...");
               Weavver.Utilities.Common.CopyFolder(@"C:\Weavver\Main\Projects\WeavverLib\bin\Release\",
                                                   @"C:\inetpub\weavver.com\bin\");

               //var workingCopyClient = new SvnWorkingCopyClient();
               //SvnWorkingCopyVersion version;
               //workingCopyClient.GetVersion(localPath, out version);
               //long localRev = version.End;

               //string config = @"C:\inetpub\weavver.com\web.config";
               //string buildLabel = "Build " + TestingContext.BuildNumber + " SVN " + localRev.ToString();
               //Weavver.Utilities.Common.SetConfigSetting(config, "version", buildLabel);
               Assert.Fail("blah");
          }
//-------------------------------------------------------------------------------------------
          public bool IsStagingOrProductionTest(System_Tests test)
          {
               string classPath = test.Path.Substring(0, test.Path.LastIndexOf("."));
               var matchingType = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                   where x.FullName == classPath
                                        select x).FirstOrDefault();

               if (matchingType != null &&
                   LinqTestHelpers.HasAttribute(typeof(StagingTest), matchingType))
               {
                    return true;
               }

               return false;
          }
//-------------------------------------------------------------------------------------------
          public void TearDown()
          {
               // If there were no exceptions then close chromedriver
               //<!-- CLEAN UP THE TEST ENVIRONMENT -->
               //<exec executable="c:\Windows\System32\cmd.exe"
               //      buildArgs="/C taskkill /IM chromedriver.exe /F"
               //      successExitCodes="0,128" />
          }
//-------------------------------------------------------------------------------------------
     }
}

     // CoreExtensions.Host.InitializeService();
     // TestPackage testPackage = new TestPackage(Path.Combine(svnTempPath, Updater.Properties.Settings.Default.testassembly));
     // RemoteTestRunner remoteTestRunner = new RemoteTestRunner();
     // remoteTestRunner.Load(testPackage);
     // TestResult testResult = remoteTestRunner.Run(new WeavverEventListener());
     // PrintResults(testResult, 0);