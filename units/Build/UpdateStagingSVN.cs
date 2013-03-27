using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibGit2Sharp;

namespace Weavver.Testing.Staging
{
     public class UpdateStagingSVN
     {
//-------------------------------------------------------------------------------------------
          [ManualTest]
          public void Run()
          {
               string localPath = @"C:\Weavver\Main";
               string svnPath = "https://svn.weavver.com/main/";
               UpdateSVN(localPath, "https://svn.weavver.com/main/");

               // Compile the project
               //<msbuild>
               //  <executable>C:\windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe</executable>
               //  <workingDirectory>C:\Weavver\Main</workingDirectory>
               //  <projectFile>C:\Weavver\Main\Weavver 2010.sln</projectFile>
               //  <timeout>600</timeout>
               //  <buildArgs>/p:ProjectFile=$SolutionFile$ /p:Configuration=Release /p:Platform="Mixed Platforms"</buildArgs>
               //  <logger>ThoughtWorks.CruiseControl.MsBuild.XmlLogger,C:\Program Files (x86)\CruiseControl.NET\server\ThoughtWorks.CruiseControl.MSBuild.dll</logger>
               //</msbuild>
          }
//-------------------------------------------------------------------------------------------
          public static void UpdateSVN(string localPath, string svnURL)
          {
               Repository repo = new Repository(localPath);
               

               Assert.Fail("not implemented");
               //Uri repo = new Uri(svnURL);

               //SvnClient client = new SharpSvn.SvnClient();
               //var workingCopyClient = new SvnWorkingCopyClient();
               //SvnWorkingCopyVersion version;
               //workingCopyClient.GetVersion(localPath, out version);
               //long localRev = version.End;

               //SvnInfoEventArgs info;
               //client.GetInfo(repo, out info);

               //Console.WriteLine(string.Format("The last revision of {0} is {1}", repo, info.Revision));
               //Console.WriteLine("Your local revision is: " + localRev);

               //if (localRev < info.Revision)
               //{
               //     Console.WriteLine("Updating..");

               //     if (client.Update(localPath))
               //     {
               //          Console.WriteLine("Updated.");
               //     }
               //     else
               //     {
               //          Console.WriteLine("The folder could not be updated from SVN.");
               //     }
               //}
               //else if (localRev == info.Revision)
               //{
               //     Console.WriteLine("You have the most current version.");
               //}
          }
//-------------------------------------------------------------------------------------------
     }
}