using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Configuration;

namespace Weavver.Testing.Accounting
{
     [TestFixture]
     public class Import : WeavverTest
     {
//-------------------------------------------------------------------------------------------
          [Test]
          public void ImportData()
          {
               webDriver.Navigate().GoToUrl(BaseURL);
               LogIn();
               SelectDDLOption(By.Id("ctl00_OrganizationsList"), "WeavverTest");

               js.ExecuteScript("return $(\"a:contains('New')\").mouseover();");
               js.ExecuteScript("return $(\"a:contains('Accounting')\").next(':eq(1)').mouseover();");
               //js.ExecuteScript("return $(\"a:contains('Account')\").click();");

               webDriver.FindElement(By.LinkText("Account")).Click();

               webDriver.FindElement(By.Id("ctl00_Content_AccountName")).Clear();
               webDriver.FindElement(By.Id("ctl00_Content_AccountName")).SendKeys("CreditCardImportTest");
               SelectDDLOption(By.Id("ctl00_Content_AccountType"), "Credit Card");
               webDriver.FindElement(By.Id("ctl00_Content_Save")).Click();
               webDriver.FindElement(By.Id("ctl00_Content_LedgerLink")).Click();

               js.ExecuteScript("return $(\"a:contains('Tools')\").mouseover();");
               webDriver.FindElement(By.LinkText("Import")).Click();

               string filepath = Path.Combine(ConfigurationManager.AppSettings["working_folder"], "_Samples" + Path.DirectorySeparatorChar + "Credit Card Statement.qif");
               Assert.IsTrue(File.Exists(filepath), filepath);
               webDriver.FindElement(By.Id("ctl00_Content_FileUpload1")).SendKeys(filepath);
               webDriver.FindElement(By.Id("ctl00_Content_Load")).Click();

               Assert.AreEqual("19", webDriver.FindElement(By.Id("ctl00_Content_DetectedTotal")).Text);
               SelectDDLOption(By.Id("ctl00_Content_Accounts"), "CreditCardImportTest");
               js.ExecuteScript("return $('input[value=\"Import\"]').click();");
               Assert.AreEqual("Imported 19 row(s).", webDriver.FindElement(By.Id("ctl00_ErrorLayer")).Text);
               LogOut();
          }
//-------------------------------------------------------------------------------------------
     }
}