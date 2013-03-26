using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Configuration;

namespace Weavver.Testing.Accounting
{
     public class Import : WeavverTest
     {
//-------------------------------------------------------------------------------------------
          [StagingTest]
          [ManualTest]
          public void ImportData()
          {
               IJavaScriptExecutor js = ((IJavaScriptExecutor)webDriver);
               webDriver.Navigate().GoToUrl(BaseURL);
               LogIn();
               SelectDDLOption(By.Id("MasterHeader1_OrganizationsList"), "WeavverTest");

               js.ExecuteScript("return $('.MenuRoot').mouseover().click()");
               js.ExecuteScript("return $(\"div:contains('New')\").mouseover().click();");
               js.ExecuteScript("return $(\"div:contains('Accounting')\").mouseover().click();");
               js.ExecuteScript("return $(\"div:contains('Financial Account')\").mouseover().click();");

               //webDriver.FindElement(By.LinkText("Account")).Click();

               // Create a Financial account
               webDriver.FindElement(By.Id("Content_FormView1_ctl02___Name_TextBox1")).Clear();
               webDriver.FindElement(By.Id("Content_FormView1_ctl02___Name_TextBox1")).SendKeys("CreditCardImportTest");
               SelectDDLOption(By.Id("Content_FormView1_ctl02___LedgerType_DropDownList1"), "CreditCard");
               webDriver.FindElement(By.Id("Content_FormView1_Button1")).Click();

               //// Go to the import page
               //webDriver.FindElement(By.Id("DynamicMethod_ImportData1")).Click();

               //string filepath = Path.Combine(ConfigurationManager.AppSettings["working_folder"], "_Samples" + Path.DirectorySeparatorChar + "Credit Card Statement.qif");
               //Assert.IsTrue(File.Exists(filepath), filepath);
               //webDriver.FindElement(By.Id("ctl00_Content_FileUpload1")).SendKeys(filepath);
               //webDriver.FindElement(By.Id("ctl00_Content_Load")).Click();

               //Assert.AreEqual("19", webDriver.FindElement(By.Id("ctl00_Content_DetectedTotal")).Text);
               //SelectDDLOption(By.Id("ctl00_Content_Accounts"), "CreditCardImportTest");
               //js.ExecuteScript("return $('input[value=\"Import\"]').click();");
               //Assert.AreEqual("Imported 19 row(s).", webDriver.FindElement(By.Id("ctl00_ErrorLayer")).Text);
               LogOut();
          }
//-------------------------------------------------------------------------------------------
     }
}