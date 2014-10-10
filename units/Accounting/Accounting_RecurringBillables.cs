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

               //webDriver.Navigate().GoToUrl(BaseURL + "/Accounting_RecurringBillables/Details.aspx");
               WaitForPageLoad();

               ((IJavaScriptExecutor)webDriver).ExecuteScript("createPopup('/weavvertest/Accounting_RecurringBillables/List.aspx', '800', '500')");
               WaitForPageLoad();

               IWebDriver listFrame = webDriver.SwitchTo().Frame(1);

               ClickButton(listFrame, By.Id("Content_DList_newObjectLink"));
               WaitForPageLoad(listFrame);

               listFrame.SwitchTo().DefaultContent();

               IWebDriver insertFrame = webDriver.SwitchTo().Frame(2);
               //Math.floor((Math.random() * 10) + 1);

               //fill out the form
               SelectDDLOption(insertFrame, By.Id("Content_FormView1_ctl01___AccountFromData_DropDownList1"), "Company A");
               SelectDDLOption(insertFrame, By.Id("Content_FormView1_ctl01___AccountToData_DropDownList1"), "Company B");
               //SendKeys(insertFrame, By.Id("Content_FormView1_ctl03_ctl03___AccountToData_DropDownList1")).SendKeys("MyFax");
               SendKeys(insertFrame, By.Id("Content_FormView1_ctl01___Memo_TextBox1"), "Fax Service, %timespan%");
               SendKeys(insertFrame, By.Id("Content_FormView1_ctl01___Amount_TextBox1"), "5");
               SendKeys(insertFrame, By.Id("Content_FormView1_ctl01___StartAt_TextBox1"), "1/1/11");
               SendKeys(insertFrame, By.Id("Content_FormView1_ctl01___Position_TextBox1"), "1/1/11");

               SendKeys(insertFrame, By.Id("Content_FormView1_ctl01___EndAt_TextBox1"), "01/01/12\t");
               ((IJavaScriptExecutor)insertFrame).ExecuteScript("isPageLoaded = false;");
               ClickButton(insertFrame, By.Id("Content_FormView1_Button1"));

               // check the projections are accurate
               WaitForPageLoad(insertFrame);
               WaitForTextExists2("a[href=\"#Projection\"]", "Projection");
               // this is the line with the error
               ClickButton(insertFrame, By.XPath("//a[@href='#Projection']")); //("Projection"));
               Assert.IsTrue(insertFrame.PageSource.Contains("Fax Service, 01/01/11 to 02/01/11"), "Text 'Fax Service, 01/01/11 to 02/01/11' is missing");
               Assert.IsTrue(insertFrame.PageSource.Contains("Fax Service, 11/01/11 to 12/01/11"), "Text 'Fax Service, 11/01/11 to 12/01/11' is missing");

               // Push unbilled items
               ((IJavaScriptExecutor)insertFrame).ExecuteScript("isDialogLoaded = false;");
               ClickButton(insertFrame, By.Id("Content_DynamicWebMethod_PushUnbilledItems"));

               // Check the unbilled items were processed correctly
               WaitForDialogLoaded(insertFrame);
               Assert.IsTrue(insertFrame.PageSource.Contains("Total periods billed: 12"), "Total periods billed: 12");
               WaitForTextExists(insertFrame, By.Id("modalBoxOK"), "OK");
               ((IJavaScriptExecutor)insertFrame).ExecuteScript("isPageLoaded = false;");
               ClickButton(insertFrame, By.Id("modalBoxOK"));

               WaitForPageLoad(insertFrame);
               Assert.AreEqual("02/01/12", insertFrame.FindElement(By.Id("Content_FormView1_ctl01___Position_Date")).Text.Trim());
               ClickButton(insertFrame, By.Id("Content_DynamicWebMethod_PushUnbilledItems"));

               WaitForDialogLoaded(insertFrame);
               Assert.IsTrue(insertFrame.PageSource.Contains("Total periods billed: 0"), "Total periods billed: 0");

               WaitForTextExists(insertFrame, By.Id("modalBox"), "Total periods billed: 0");
               WaitForTextExists(insertFrame, By.Id("modalBoxOK"), "OK");
               ClickButton(By.Id("modalBoxOK"));
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
