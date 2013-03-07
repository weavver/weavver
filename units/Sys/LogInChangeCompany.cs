using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using Weavver.Testing;

namespace Weavver.Testing.Sys
{
     [StagingTest]
     public class LogInChangeCompany : WeavverTest
     {
//-------------------------------------------------------------------------------------------
          [ManualTest]
          public void ChangeCompany()
          {
               webDriver.Navigate().GoToUrl(BaseURL + "/");
               LogIn();
               Assert.AreEqual("Weavver :: Abre Los Ojos.", webDriver.Title);
               SelectDDLOption(By.Id("ctl00_OrganizationsList"), "WeavverTest");
               Assert.AreEqual("Weavver :: Abre Los Ojos.", webDriver.Title);
               Assert.IsTrue(webDriver.PageSource.Contains("weavvertest"), "\"weavvertest\" username is missing from the page source!");
               Assert.AreEqual("Weavver :: Abre Los Ojos.", webDriver.Title);

               LogOut();
          }
     }
//-------------------------------------------------------------------------------------------
}
