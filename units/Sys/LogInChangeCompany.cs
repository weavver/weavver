using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using Weavver.Testing;

namespace Weavver.Testing.Sys
{
     public class LogInChangeCompany : WeavverTest
     {
//-------------------------------------------------------------------------------------------
          [ManualTest]
          [StagingTest]
          public void ChangeCompany()
          {
               webDriver.Navigate().GoToUrl(BaseURL + "/");
               LogIn();
               Assert.AreEqual("Weavver :: Abre Los Ojos.", webDriver.Title);
               SelectDDLOption(By.Name("ctl00$MasterHeader1$OrganizationsList"), "WeavverTest");
               Assert.AreEqual("Weavver :: Abre Los Ojos.", webDriver.Title);
               Assert.IsTrue(webDriver.PageSource.Contains("weavvertest"), "\"weavvertest\" username is missing from the page source!");
               Assert.AreEqual("Weavver :: Abre Los Ojos.", webDriver.Title);

               LogOut();
          }
     }
//-------------------------------------------------------------------------------------------
}
