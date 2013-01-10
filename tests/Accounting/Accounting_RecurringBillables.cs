using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Weavver.Testing.Accounting
{
     // check out migratordotnet
     public class Accounting_RecurringBillables : WeavverTest
     {
//-------------------------------------------------------------------------------------------
          [StagingTest]
          public void RunTest()
          {
               webDriver.Navigate().GoToUrl(BaseURL + "/");
               LogIn();

               SelectDDLOption(By.Id("MasterHeader1_OrganizationsList"), "WeavverTest");

               //js.ExecuteScript("return $(\"a:contains('New')\").mouseover();");
               //js.ExecuteScript("return $(\"a:contains('Accounting')\").next(':eq(1)').mouseover();");
               //webDriver.FindElement(By.LinkText("Recurring Billable")).Click();

               webDriver.Navigate().GoToUrl(BaseURL + "/Accounting_RecurringBillables/Insert.aspx");
               WaitForPageLoad();

               SelectDDLOption(By.Id("Content_FormView1_ctl02___AccountFromData_DropDownList1"), "Company A");
               SelectDDLOption(By.Id("Content_FormView1_ctl02___AccountToData_DropDownList1"), "Company B");
               //webDriver.FindElement(By.Id("Content_FormView1_ctl03_ctl03___AccountToData_DropDownList1")).SendKeys("MyFax");
               webDriver.FindElement(By.Id("Content_FormView1_ctl02___Memo_TextBox1")).SendKeys("Fax Service, %timespan%");
               webDriver.FindElement(By.Id("Content_FormView1_ctl02___Amount_TextBox1")).SendKeys("5");
               webDriver.FindElement(By.Id("Content_FormView1_ctl02___StartAt_TextBox1")).SendKeys("1/1/11");
               webDriver.FindElement(By.Id("Content_FormView1_ctl02___Position_TextBox1")).SendKeys("1/1/11");
               webDriver.FindElement(By.Id("Content_FormView1_ctl02___EndAt_TextBox1")).SendKeys("01/01/12\t");

               ClickButton(By.Id("Content_FormView1_Button1"));

               WaitForPageLoad();
               Assert.IsTrue(webDriver.PageSource.Contains("Fax Service, 01/01/11 to 02/01/11"), "Text 'Fax Service, 01/01/11 to 02/01/11' is missing");
               Assert.IsTrue(webDriver.PageSource.Contains("Fax Service, 01/01/12 to 02/01/12"), "Text 'Fax Service, 01/01/12 to 02/01/12' is missing");

               webDriver.FindElement(By.Id("DynamicMethod_PushUnbilledItems")).Click();
               WaitForPageLoad();

               Assert.IsTrue(webDriver.PageSource.Contains("Total periods billed: 13"), "Total periods billed: 13");
               webDriver.FindElement(By.Id("modalBoxOK")).Click();
               WaitForPageLoad();

               Assert.AreEqual("02/01/12", webDriver.FindElement(By.Id("Content_FormView1_ctl02___Position_Date")).Text.Trim());

               webDriver.FindElement(By.Id("DynamicMethod_PushUnbilledItems")).Click();
               WaitForPageLoad();
               Assert.IsTrue(webDriver.PageSource.Contains("Total periods billed: 0"), "Total periods billed: 0");

               webDriver.FindElement(By.Id("modalBoxOK")).Click();
          }
//-------------------------------------------------------------------------------------------
//          [Test]
//          public void BillingProcess()
//          {
//               return;
//               // Given I have a client set up
//               Organization subscriberOrg = new Organization {
//                         DatabaseHelper = Helper.DatabaseHelper,
//                         Id = Guid.NewGuid(),
//                         OrganizationId = Guid.Empty,
//                         OrganizationType = OrganizationTypes.SoleProprietorship,
//                         Name = "Test Organization",
//                         EIN = "Aasdf",
//                         Bio = "Hello, this is my testing organization.",
//                         CreatedAt= DateTime.UtcNow,
//                         CreatedBy = Guid.Empty,
//                         UpdatedAt = DateTime.UtcNow,
//                         UpdatedBy = Guid.Empty
//                    };
//               Assert.IsTrue(subscriberOrg.Commit());

//               // And they have subscribed to a recurring service for $55/month
//               RecurringBillable recurringBillable = new RecurringBillable {
//                         DatabaseHelper = Helper.DatabaseHelper,
//                         Id = Guid.NewGuid(),
//                         OrganizationId = Guid.NewGuid(),
//                         Service = Guid.Empty,
//                         AccountFrom = Guid.Empty,
//                         AccountTo = subscriberOrg.Id,
//                         BillingDirection = "Pre",
//                         BillingPeriod = "Monthly",
//                         EndAt = null,
//                         Memo = "Cell Phone Bill",
//                         Amount = 55m, // $55
//                         StartAt = DateTime.UtcNow.AddMonths(-1),
//                         Position = DateTime.UtcNow.AddMonths(-1),
//                         Status = "Active",
//                         CreatedAt = DateTime.UtcNow,
//                         CreatedBy = Guid.Empty,
//                         UpdatedAt = DateTime.UtcNow,
//                         UpdatedBy = Guid.Empty
//                    };
//               Assert.IsTrue(recurringBillable.Commit());

//               AccountingHelper accountingHelper = new AccountingHelper {
//                    DatabaseHelper = Helper.DatabaseHelper
//                    };

//               decimal bal = accountingHelper.Balance_ForLedger(LedgerType.Receivable, Guid.Empty, subscriberOrg.Id, null, null);
//               Assert.AreEqual(bal, 0.00m);

//               accountingHelper.ProcessBillables(new Guid("0baae579-dbd8-488d-9e51-dd4dd6079e95"));

//               decimal bal2 = accountingHelper.Balance_ForLedger(LedgerType.Receivable, Guid.Empty, subscriberOrg.Id, null, null);
//               Assert.AreEqual(bal, -110.00m);

//               //subscriberOrg.Delete();
//               recurringBillable.Delete();
//          }
//          //[ExpectedException(typeof(InsufficientFundsException))]
////-------------------------------------------------------------------------------------------
//          [TestFixtureSetUp]
//          public void Init()
//          {
//               return;
//               Helper.DatabaseHelper.DeploySchema();
//          }
////-------------------------------------------------------------------------------------------
//          [TestFixtureTearDown]
//          public void Dispose()
//          {
//               return;
//          }
//-------------------------------------------------------------------------------------------
     }     
}
