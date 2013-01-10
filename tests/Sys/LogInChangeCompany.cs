using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Weavver.Testing.Sys
{
     [TestFixture]
     public class LogInChangeCompany : WeavverTest
     {
//-------------------------------------------------------------------------------------------
          [Test]
          public void ChangeCompany()
          {
               webDriver.Navigate().GoToUrl(BaseURL + "/");
               LogIn();
               Assert.AreEqual("Weavver :: Abre Los Ojos.", webDriver.Title);
               SelectDDLOption(By.Id("ctl00_OrganizationsList"), "WeavverTest");
               Assert.AreEqual("Weavver :: Abre Los Ojos.", webDriver.Title);
               Assert.IsTrue(webDriver.PageSource.Contains("weavvertest"));
               Assert.AreEqual("Weavver :: Abre Los Ojos.", webDriver.Title);

               LogOut();
          }
     }
//-------------------------------------------------------------------------------------------
}
