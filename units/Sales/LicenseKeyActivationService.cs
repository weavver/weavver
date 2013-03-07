using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Configuration;

using Weavver.Data;

namespace Weavver.Testing.Sales
{
//-------------------------------------------------------------------------------------------
     public partial class Sales_LicenseKeyActivationService
     {
          string LicenseKey;
          string ProductId;
          string ProductVersion;
          string RemoteMachineCode;
          string RemoteMachineName;
          string weavverurl;
//-------------------------------------------------------------------------------------------
          public Sales_LicenseKeyActivationService()
          {
               SetDefaultVars();
          }
//-------------------------------------------------------------------------------------------
          private void SetDefaultVars()
          {
               weavverurl = ConfigurationManager.AppSettings["weavver_url"];
               LicenseKey = ConfigurationManager.AppSettings["sales_licensekeys_licensekey"];
               ProductId = ConfigurationManager.AppSettings["sales_licensekeys_productid"];
               ProductVersion = ConfigurationManager.AppSettings["sales_licensekeys_productversion"];
               RemoteMachineCode = ConfigurationManager.AppSettings["sales_licensekeys_machinecode"];
               RemoteMachineName = ConfigurationManager.AppSettings["sales_licensekeys_machinename"];
          }
//-------------------------------------------------------------------------------------------
          [StagingTest]
          public void RunTest()
          {
               ResetLocatorKeyState();

               CheckMissingParameterError();
               CheckLocatorKeyNotFoundError();
               GetActivationKey();
               CheckTooManyActivationsError();
          }
//-------------------------------------------------------------------------------------------
          public void ResetLocatorKeyState()
          {
               string queryUrl = "$weavverurl/exports/sales_licensekeys?action=resettestkey";
               queryUrl = queryUrl.Replace("$weavverurl", weavverurl);

               string response = GetVerifiedXML(queryUrl);
               XmlDocument doc = new XmlDocument();
               doc.LoadXml(response);

               var okNode = doc.SelectSingleNode("//OK");
               Assert.IsNotNull(okNode, "Activations for the test key could not be reset.");
          }
//-------------------------------------------------------------------------------------------          
          public void CheckMissingParameterError()
          {
               string queryUrl = "$weavverurl/exports/sales_licensekeys";
               queryUrl = queryUrl.Replace("$weavverurl", weavverurl);

               string response = GetVerifiedXML(queryUrl);
               XmlDocument doc = new XmlDocument();
               doc.LoadXml(response);

               var okNode = doc.SelectSingleNode("//Reason");

               Assert.AreEqual("The required parameter \"LicenseKey\" is missing.", okNode.InnerText, "Not found xml is invalid");
          }
//-------------------------------------------------------------------------------------------
          public void CheckLocatorKeyNotFoundError()
          {
               string queryUrl = "$weavverurl/exports/sales_licensekeys?LicenseKey=$licensekey&ProductId=$productid&ProductVersion=$productversion&MachineCode=$machinecode&MachineName=$machinename";
               queryUrl = queryUrl.Replace("$weavverurl", weavverurl);
               queryUrl = queryUrl.Replace("$licensekey", "wrong key");
               queryUrl = queryUrl.Replace("$productid", ProductId);
               queryUrl = queryUrl.Replace("$productversion", ProductVersion);
               queryUrl = queryUrl.Replace("$machinecode", RemoteMachineCode);
               queryUrl = queryUrl.Replace("$machinename", RemoteMachineName);

               string response = GetVerifiedXML(queryUrl);
               XmlDocument doc = new XmlDocument();
               doc.LoadXml(response);

               var reasonNode = doc.SelectSingleNode("//Reason");

               Assert.AreEqual("The license key could not be found.", reasonNode.InnerText, "The returned fail reason does not match.");
          }
//-------------------------------------------------------------------------------------------
          public void GetActivationKey()
          {
               string queryUrl = "$weavverurl/exports/sales_licensekeys?LicenseKey=$licensekey&ProductId=$productid&ProductVersion=$productversion&MachineCode=$machinecode&MachineName=$machinename";
               queryUrl = queryUrl.Replace("$weavverurl", weavverurl);
               queryUrl = queryUrl.Replace("$licensekey", LicenseKey);
               queryUrl = queryUrl.Replace("$productid", ProductId);
               queryUrl = queryUrl.Replace("$productversion", ProductVersion);
               queryUrl = queryUrl.Replace("$machinecode", RemoteMachineCode);
               queryUrl = queryUrl.Replace("$machinename", RemoteMachineName);

               string response = GetVerifiedXML(queryUrl);

               XmlDocument doc = new XmlDocument();
               doc.PreserveWhitespace = true;
               doc.LoadXml(response);

               var mlNode = doc.DocumentElement.SelectSingleNode("//MachineLicense");

               Assert.IsNotNull(mlNode, "We were expecting a <MachineLicense> stanza.");

               string MyMachineCode = doc.DocumentElement.SelectSingleNode("//MachineCode").InnerText;
               if (RemoteMachineCode == MyMachineCode) // the license is valid for this machine
               {
                    string FullName = doc.DocumentElement.SelectSingleNode("//FullName").InnerText;
                    string Organization = doc.DocumentElement.SelectSingleNode("//Organization").InnerText;
                    string ConcurrentUsers = doc.DocumentElement.SelectSingleNode("//ConcurrentUsersPerMachine").InnerText;
                    string ActivationCount = doc.DocumentElement.SelectSingleNode("//ActivationCount").InnerText;
               }
          }
//-------------------------------------------------------------------------------------------
          public void CheckTooManyActivationsError()
          {
               // Set current activations to ZERO:
               ResetLocatorKeyState();

               // Run it 3 times to overexhaust the limit:
               RemoteMachineCode = "1";
               GetActivationKey();
               RemoteMachineCode = "2";
               GetActivationKey();
               RemoteMachineCode = "3";
               GetActivationKey();

               // It should fail this time:
               try
               {
                    RemoteMachineCode = "4";
                    GetActivationKey();
                    Assert.Fail("Key returned");
               }
               catch (Exception ex)
               {
                    if (ex.Message == "Key returned")
                         Assert.Fail("The activation counter is not working.");

                    // Assert.Pass("The 4th activation failed which is CORRECT behavior.;");
               }

               SetDefaultVars();
          }
//-------------------------------------------------------------------------------------------
          private string GetVerifiedXML(string url)
          {
               System.Net.HttpWebRequest req = (HttpWebRequest)System.Net.HttpWebRequest.Create(url);
               WebResponse wr = req.GetResponse();

               StreamReader reader = new StreamReader(wr.GetResponseStream());
               string xml = reader.ReadToEnd();

               XmlDocument doc = new XmlDocument();
               doc.PreserveWhitespace = true;
               doc.LoadXml(xml);

               var rsaKey = new RSACryptoServiceProvider();
               rsaKey.FromXmlString(File.ReadAllText("C:\\public.key"));
               bool isNotTamperedWith = VerifyXml(doc, rsaKey);
               Assert.IsTrue(isNotTamperedWith, "The XML was tampered with or the signature does not match.");

               return xml;
          }
//-------------------------------------------------------------------------------------------
          public static Boolean VerifyXml(XmlDocument Doc, RSA Key)
          {
               if (Doc == null)
                    throw new ArgumentException("Doc");
               if (Key == null)
                    throw new ArgumentException("Key");

               SignedXml signedXml = new SignedXml(Doc);
               XmlNodeList nodeList = Doc.GetElementsByTagName("Signature");
               if (nodeList.Count <= 0)
               {
                    throw new CryptographicException("Verification failed: No Signature was found in the document.");
               }
               else if (nodeList.Count >= 2)
               {
                    throw new CryptographicException("Verification failed: More that one signature was found for the document.");
               }
               signedXml.LoadXml((XmlElement)nodeList[0]);
               return signedXml.CheckSignature(Key);
          }
//-------------------------------------------------------------------------------------------
     }
}