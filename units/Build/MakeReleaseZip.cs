using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Ionic.Zip;
using LibGit2Sharp;
using Weavver.Data;
using Weavver.Units;
using System.Diagnostics;

namespace Weavver.Testing.Staging
{
     public class MakeReleaseZip
     {
          [ManualTest]
          public void Run()
          {
               string RepoPath = WeavverUnitContext.RepoPath;
               Repository xx = new Repository(RepoPath);

               string localRev = xx.Head.Tip.Id.ToString().Substring(0, 7);
               string buildLabel = "Build " + DateTime.Now.ToString("MM.dd.yy") + " GIT " + localRev.ToString();

               #region Add WWW folder
               string tempFolder = Path.Combine(Path.GetTempPath(), "WeavverBuild");
               if (Directory.Exists(tempFolder))
                    Directory.Delete(tempFolder, true);
               Directory.CreateDirectory(tempFolder);

               Weavver.Utilities.Common.CopyFolder(Path.Combine(RepoPath, "www"), Path.Combine(tempFolder, "www"));
               
               string config = Path.Combine(tempFolder, @"www\web-default.config");
               Weavver.Utilities.Common.SetConfigSetting(config, "version", buildLabel);
               Weavver.Utilities.Common.SetConfigSetting(config, "install_mode", "true");

               string webconfigPath = Path.Combine(tempFolder, "www/web.config");
               if (File.Exists(webconfigPath))
                    File.Delete(webconfigPath);
               string aspnetFolder = Path.Combine(tempFolder, "www/aspnet_client/");
               if (Directory.Exists(aspnetFolder))
                    Directory.Delete(aspnetFolder, true);

               string binPath = Path.Combine(tempFolder, "www", "Bin");
               string[] binConfigFiles = Directory.GetFiles(binPath, "*.config");
               foreach (string binConfigFile in binConfigFiles)
               {
                    if (File.Exists(binConfigFile))
                         File.Delete(binConfigFile);
               }

               string uploadFolder = Path.Combine(tempFolder, "www", "Uploads");
               Directory.Delete(uploadFolder, true);

               string swFolder = Path.Combine(tempFolder, "www", "Bin", "SnapWeavver.dll");
               File.Delete(swFolder);

               //string appBase = @"C:\Weavver\Main\Projects\App\bin\x86\Release\";
               //File.Copy(appBase + @"Weavver.exe", Path.Combine(tempFolder, "Weavver.exe"));
               //File.Copy(appBase + @"CassiniDev4-lib.dll", Path.Combine(tempFolder, "CassiniDev4-lib.dll"));
               //File.Copy(appBase + @"Weavver.exe.config", Path.Combine(tempFolder, "Weavver.exe.config"));
               #endregion
               
               #region Add DB Files
               string dataPath = Path.Combine(new DirectoryInfo(RepoPath).Parent.FullName, "data");
               File.Copy(
                    Path.Combine(dataPath, @"database\bin\Release\Weavver.DAL.dll"),
                    Path.Combine(tempFolder, @"www\bin\Weavver.DAL.dll"),
                    true
                    );
               using (WeavverEntityContainer db = new WeavverEntityContainer())
               {
                    string createScript = db.CreateDatabaseScript() + "\r\n";
                    createScript += File.ReadAllText(Path.Combine(dataPath, @"database\Database.sql")) + "\r\n";

                    string databaseSqlPath = Path.Combine(tempFolder, @"www\bin\Database.sql");
                    File.WriteAllText(databaseSqlPath, createScript);
               }
               #endregion

               File.Copy(Path.Combine(RepoPath, @"units\build\Readme.txt"), Path.Combine(tempFolder, "Readme.txt"));

               string distDir = Path.Combine(RepoPath, "dist");
               if (!Directory.Exists(distDir))
                    Directory.CreateDirectory(distDir);

               string zipPath = Path.Combine(distDir, "Weavver-" + buildLabel.Replace(" ", "-") + ".zip");
               if (File.Exists(zipPath))
                    File.Delete(zipPath);

               Process p = new Process();
               p.StartInfo.WorkingDirectory = tempFolder;
               p.StartInfo.FileName = Path.Combine(RepoPath, @"vendors\7-Zip\7z.exe");
               p.StartInfo.Arguments = "a " + zipPath + " " + tempFolder + "\\*";
               p.Start();
               p.WaitForExit();

               //Ionic.Zip.ZipFile weavverZip = new ZipFile();
               //weavverZip.AddDirectory(tempFolder);
               //weavverZip.Save(zipPath);
          }

          //string svnOldPath = Updater.Properties.Settings.Default.svnpath;
          //string svnTempPath = Path.Combine(Updater.Properties.Settings.Default.deploymentpath, "www-temp-" + DateTime.Now.ToString("Mddyy hhmmss"));
     }
}
