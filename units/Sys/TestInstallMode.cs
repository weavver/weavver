using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Weavver.Units;
using System.IO;

namespace Weavver.Testing.Sys
{
     public class TestInstallMode :  WeavverTestingContext
     {
//-------------------------------------------------------------------------------------------
          [StagingTest]
          public void RunTest()
          {
               string config = Path.Combine(RepoPath, @"www\web.config");
               Weavver.Utilities.Common.SetConfigSetting(config, "install_mode", "true");

               webDriver.Navigate().GoToUrl(BaseURL + "/");
               WaitForPageLoad();
               Assert.IsTrue(WaitForTextExists(By.Id("TitleDiv"), "Weavver First-Time Set-Up"), "Page title is wrong");

               Weavver.Utilities.Common.SetConfigSetting(config, "install_mode", "false");
          }
//-------------------------------------------------------------------------------------------
     }
}
