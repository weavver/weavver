using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Weavver.Units;
using System.IO;
using Weavver.Testing.Attributes;

namespace Weavver.Testing.Sys
{
     public class TestInstallMode :  WeavverTest
     {
//-------------------------------------------------------------------------------------------
          [TestFixtureSetUpAttribute]
          public void SetUpTest()
          {
               string config = Path.Combine(WeavverUnitContext.RepoPath, @"www\web.config");
               Weavver.Utilities.Common.SetConfigSetting(config, "install_mode", "true");
          }
//-------------------------------------------------------------------------------------------
          [StagingTest]
          public void RunTest()
          {
               webDriver.Navigate().GoToUrl(BaseURL + "/");
               WaitForPageLoad();
               Assert.IsTrue(WaitForTextExists(By.Id("TitleDiv"), "Weavver First-Time Set-Up"), "Page title is wrong");

               ClickButton(By.Id("Content_TestConnection"));
               WaitForTextExists(By.Id("ConnectionInformation"), "The connection works.");

               SetControlValue(By.Id("Content_Organization"), "Example Org");
               SetControlValue(By.Id("Content_Username"), "testusername");
               SetControlValue(By.Id("Content_Password"), "testpassword");

               ClickButton(By.Id("Content_Create"));
          }
//-------------------------------------------------------------------------------------------
          [TestFixtureTearDownAttribute]
          public void TearDown()
          {
               string config = Path.Combine(WeavverUnitContext.RepoPath, @"www\web.config");
               Weavver.Utilities.Common.SetConfigSetting(config, "install_mode", "false");
          }
//-------------------------------------------------------------------------------------------
     }
}
