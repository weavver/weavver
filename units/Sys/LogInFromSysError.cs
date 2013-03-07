using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Weavver.Testing.Sys
{
     [StagingTest]
     public class LogInFromSysError :  WeavverTest
     {
//-------------------------------------------------------------------------------------------
          [ManualTest]
          public void SysError()
          {
               webDriver.Navigate().GoToUrl(BaseURL + "/system/error");
               Assert.AreEqual("Weavver :: System :: Error", webDriver.Title);

               // surfs to the log in page since we're on the error page
               webDriver.FindElement(By.Id("ctl00_LoginView1_SignInLink")).Click();
               WaitForPageLoad();

               webDriver.FindElement(By.Id("ctl00_Content_Login1_UserName")).SendKeys("weavvertest");
               webDriver.FindElement(By.Id("ctl00_Content_Login1_Password")).SendKeys("test1234");
               webDriver.FindElement(By.Id("ctl00_Content_Login1_LoginButton")).Click();
               WaitForPageLoad();

               Assert.AreEqual("Weavver Account :: Welcome Home!", webDriver.Title);
               Assert.IsTrue(webDriver.PageSource.Contains("WeavverTest"), "weavvertest username is not in the page source");

               LogOut();
          }
//-------------------------------------------------------------------------------------------
     }
}
