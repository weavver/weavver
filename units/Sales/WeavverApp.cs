using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Configuration;
using OpenPop.Pop3;
using OpenPop.Mime;
using System.Diagnostics;

namespace Weavver.Testing.App
{
     [ManualTest]
     public class WeavverApp : WeavverTest
     {
//-------------------------------------------------------------------------------------------
          [StagingTest]
          public void RunTests()
          {
               webDriver.Navigate().GoToUrl(BaseURL + "/account/register");
               //webDriver.FindElement(By.Id("LoginView1_SignInLink")).Click();
               Register("testing@weavver.com", "m1" + new Random().Next(10000, 99999).ToString(), "1234", false);
          }
//-------------------------------------------------------------------------------------------
          public void Register(string emailAddress, string userName, string password, bool checkingOut)
          {
               WeavverTest wt = new WeavverTest();

               // enter user info
               wt.SetControlValue(By.Id("Content_RegisterUser_Wizard1_ctl09_FirstName"), "John");
               wt.SetControlValue(By.Id("Content_RegisterUser_Wizard1_ctl09_LastName"), "Doe");
               wt.SetControlValue(By.Id("Content_RegisterUser_Wizard1_ctl09_OrganizationName"), "Sprockets, Inc.");
               wt.SetControlValue(By.Id("Content_RegisterUser_Wizard1_ctl09_EmailAddress"), emailAddress);
               wt.SetControlValue(By.Id("Content_RegisterUser_Wizard1_ctl09_UserName"), userName);
               wt.SetControlValue(By.Id("Content_RegisterUser_Wizard1_ctl09_Password"), password);
               wt.webDriver.FindElement(By.Name("ctl00$Content$RegisterUser$Wizard1$__CustomNav0$Next")).Click();
               wt.WaitForPageLoad();

               if (!checkingOut)
               {
                    // bypass captcha test
                    wt.SetControlValue(By.Id("recaptcha_response_field"), Helper.GetAppSetting("recaptcha_bypasskey"));
                    wt.webDriver.FindElement(By.Id("Content_RegisterUser_Wizard1_ctl10_Register")).Click();

                    // download e-mail/activate account
                    Activate();
               }
          }
//-------------------------------------------------------------------------------------------
          public void Activate()
          {
               Stopwatch sw = new Stopwatch();
               sw.Start();
               while (sw.Elapsed < TimeSpan.FromSeconds(30))
               {
                    string activationCode = GetActivationCode();
                    if (!String.IsNullOrEmpty(activationCode))
                    {
                         SetControlValue(By.Name("ctl00$Content$RegisterUser$Wizard1$ctl11$ActivationCode"), activationCode);
                         webDriver.FindElement(By.Name("ctl00$Content$RegisterUser$Wizard1$ctl11$Activate")).Click();
                         WaitForPageLoad();
                         break;
                    }
               }
               sw.Stop();
          }
//-------------------------------------------------------------------------------------------
          private string GetActivationCode()
          {
               using (Pop3Client client = new Pop3Client())
               {
                    client.Connect(Helper.GetAppSetting("pop3_server"), 110, false);
                    client.Authenticate(Helper.GetAppSetting("pop3_username"), Helper.GetAppSetting("pop3_password"));
                    int x = client.GetMessageCount();
                    for (int i = 1; i < x + 1; i++)
                    {
                         Message msg = client.GetMessage(i);
                         string subj = msg.Headers.Subject;
                         if (subj == "Please activate your Weavver ID")
                         {
                              string activationCode = System.Text.Encoding.GetEncoding("utf-8").GetString(msg.FindFirstHtmlVersion().Body);
                              activationCode = activationCode.Substring(activationCode.IndexOf("Or use the following code:") + 30);
                              activationCode = activationCode.Substring(0, activationCode.IndexOf("<br>"));
                              client.DeleteMessage(i);
                              return activationCode;
                         }
                    }
               }
               return null;
          }
//-------------------------------------------------------------------------------------------
     }
}
