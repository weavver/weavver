using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using Weavver.Testing.App;

namespace Weavver.Testing.Sales
{
     //[TestFixture]
     public partial class WebStore : WeavverTest
     {
//-------------------------------------------------------------------------------------------
          [StagingTest]
          public void PlaceOrder()
          {
               WeavverApp weavver = new WeavverApp();

               webDriver.Navigate().GoToUrl(BaseURL);
               FindElement(By.LinkText("Products")).Click();
               WaitForPageLoad();
               FindElement(By.Id("fb151ed5-ebe6-41a1-8035-7ae836e84708")).Click(); // Colocation
               WaitForPageLoad();
               SelectDDLOption(By.Id("Content_feature-0"), "6 Mbps - ($180.00)");
               SelectDDLOption(By.Id("Content_feature-1"), "64 IPs - ($31.95)");
               SelectDDLOption(By.Id("Content_feature-2"), "2AMP - ($60.00)");
               SelectDDLOption(By.Id("Content_feature-3"), "3U - ($60.00)");
               FindElement(By.LinkText("+")).Click();
               WaitForPageLoad();

               Assert.IsTrue(WaitForTextExists(By.Id("Monthly"), "$331.95"), "Monthly is wrong");
               Assert.IsTrue(WaitForTextExists(By.Id("Due"), "$663.90"), "Due is wrong");

               ClickButton(By.Id("Content_Next"));
               WaitForPageLoad();

               // on the shopping cart page now
               FindElement(By.Id("Content_btnOrder")).Click();
               WaitForPageLoad();

               weavver.Register("testing@weavver.com", "user" + new Random().Next(10000, 99999).ToString(), "password1234", true);
               //weavver.Activate();

               // on the checkout/placeorder page
               Assert.AreEqual("John", webDriver.FindElement(By.Id("Content_PrimaryContact_tbFirstName")).GetAttribute("value"));
               Assert.AreEqual("Doe", webDriver.FindElement(By.Id("Content_PrimaryContact_tbLastName")).GetAttribute("value"));
               SetControlValue(By.Id("Content_PrimaryContact_tbOrganization"),  "CompanyA");
               Assert.AreEqual(Helper.GetAppSetting("pop3_emailaddress"), webDriver.FindElement(By.Id("Content_PrimaryContact_tbEmailAddress")).GetAttribute("value"));
               SetControlValue(By.Id("Content_PrimaryContact_tbAddressLine1"),  "210 N. Malden Ave.");
               SetControlValue(By.Id("Content_PrimaryContact_tbZipCode"),  "92832");
               SetControlValue(By.Id("Content_PrimaryContact_tbPhoneNumber"),  "714-872-5920");
               SetControlValue(By.Id("Content_BillingContact_tbFirstName"),  "Dexter");
               SetControlValue(By.Id("Content_BillingContact_tbLastName"),  "Countswell");
               SetControlValue(By.Id("Content_BillingContact_tbOrganization"),  "CompanyB");
               SetControlValue(By.Id("Content_BillingContact_tbEmailAddress"), Helper.GetAppSetting("pop3_emailaddress"));
               SetControlValue(By.Id("Content_BillingContact_tbAddressLine1"),  "210 N. Malden Ave.");
               SetControlValue(By.Id("Content_BillingContact_tbZipCode"),  "92832");
               SetControlValue(By.Id("Content_BillingContact_tbPhoneNumber"),  "714-872-5920");
               //webDriver.FindElement(By.Id("Content_PaymentMethod1_Issuer_0")).Click();
               SetControlValue(By.Id("Content_PaymentMethod1_CreditCard"),  "4007000001027"); // test a bad card number first
               SetControlValue(By.Id("Content_PaymentMethod1_SecurityCode"),  "123");
               SelectDDLOption(By.Id("Content_PaymentMethod1_ExpirationMonth"), "May");
               SelectDDLOption(By.Id("Content_PaymentMethod1_ExpirationYear"), "2013");
               //webDriver.FindElement(By.Id("Content_cbWeavverPrivacy")).Click();
               //webDriver.FindElement(By.Id("Content_cbVoiceScribePrivacy")).Click();
               //webDriver.FindElement(By.Id("Content_cbMailer")).Click();
               FindElement(By.Id("Content_btnOrder")).Click();
               WaitForPageLoad ();
               Assert.IsTrue(webDriver.PageSource.Contains("Please check the card number and try again."), "Card error message is missing");
               SetControlValue(By.Id("Content_PaymentMethod1_CreditCard"),  "4007000000027");
               SetControlValue(By.Id("Content_PaymentMethod1_SecurityCode"),  "123");
               //SelectDDLOption(By.Id("Content_PaymentMethod1_ExpirationMonth"), "May");
               //SelectDDLOption(By.Id("Content_PaymentMethod1_ExpirationYear"), "2013");
               FindElement(By.Id("Content_btnOrder")).Click();

               // on the Thank you page
               Pause(5);
               WaitForPageLoad();

               Assert.IsTrue(WaitForTextExists(By.Id("ContentDIV"), "Thank you. Your order has been placed."), "Thank you text is missing.");
          }
//-------------------------------------------------------------------------------------------
     }
}