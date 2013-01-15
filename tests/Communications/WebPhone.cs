using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using Weavver.Testing.App;

namespace Weavver.Testing.Communication
{
     //[TestFixture]
     public partial class WebPhone : WeavverTest
     {
//-------------------------------------------------------------------------------------------
          [StagingTest]
          public void Run()
          {
               WeavverApp weavver = new WeavverApp();

               webDriver.Navigate().GoToUrl(BaseURL + "/about/");
               WaitForPageLoad();

               FindElement(By.LinkText("Web Phone")).Click();
               FindElement(By.ClassName("ui-icon-closethick")).Click();
          }
//-------------------------------------------------------------------------------------------
     }
}