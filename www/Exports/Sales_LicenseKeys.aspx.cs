using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weavver.Data;

using Weavver.Exports;
using System.Xml;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Configuration;

public partial class Exports_Sales_LicenseKeys : SkeletonPage
{
     XmlTextWriter writer;
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;

          Response.ContentType = "text/plain";

          MemoryStream ms = new MemoryStream();
          writer = new XmlTextWriter(ms, new UTF8Encoding(false));
          //writer.Indentation = 5;
          writer.Formatting = Formatting.Indented;
          writer.WriteStartDocument();

          if (Request["action"] == "resettestkey")
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    string testKey = System.Configuration.ConfigurationManager.AppSettings["sales_licensekeys_locatortestkey"];
                    var key = (from a in data.Sales_LicenseKeys
                               where a.Key == testKey
                               select a).FirstOrDefault();

                    if (key == null)
                    {
                         writer.WriteStartElement("FAIL_NO_KEY_FOUND");
                         writer.WriteEndElement();
                    }
                    else
                    {
                         var activations = (from b in data.Sales_LicenseKeyActivations
                                            where b.LicenseKeyId == key.Id
                                            select b);

                         var rows = activations.ToList();
                         rows.ForEach(x =>  data.Sales_LicenseKeyActivations.Remove(x));
                         data.SaveChanges();

                         writer.WriteStartElement("OK");
                         writer.WriteEndElement();
                    }
               }
          }
          else
          {
               try
               {
                    IssueKey();
               }
               catch (Exception ex)
               {
                    writer.WriteStartElement("ActivationRequestRejected");
                    WriteAttribute("Reason", ex.Message);
                    writer.WriteEndElement();
               }
          }
          writer.WriteEndDocument();
          writer.Flush();
          ms.Position = 0;

          StreamReader reader = new StreamReader(ms);
          string xmlOutput = reader.ReadToEnd();

          string signedXML = SignXML(xmlOutput);
          Response.Write(signedXML);
     }
//-------------------------------------------------------------------------------------------
     private string SignXML(string xml)
     {
          // Signing XML Documents: http://msdn.microsoft.com/en-us/library/ms229745.aspx

          var rsaKey = new RSACryptoServiceProvider();
          string sales_licensekeys_privatekey = ConfigurationManager.AppSettings["sales_licensekeys_privatekey"];
          if (!File.Exists(sales_licensekeys_privatekey))
               throw new Exception("The private signing key is missing");
          rsaKey.FromXmlString(System.IO.File.ReadAllText(sales_licensekeys_privatekey));

          XmlDocument doc = new XmlDocument();
          doc.PreserveWhitespace = true;
          doc.LoadXml(xml);

          SignedXml signedXml = new SignedXml(doc);
          signedXml.SigningKey = rsaKey;

          // Create a reference to be signed.
          Reference reference = new Reference();
          reference.Uri = ""; // set to "" to sign the entire doc

          XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
          reference.AddTransform(env);

          signedXml.AddReference(reference);
          signedXml.ComputeSignature();

          XmlElement xmlDigitalSignature = signedXml.GetXml();

          doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

          MemoryStream ms = new MemoryStream();
          XmlTextWriter writer = new XmlTextWriter(ms, new UTF8Encoding(false));
          writer = new XmlTextWriter(ms, new UTF8Encoding(false));
          //writer.Formatting = Formatting.Indented;

          doc.WriteContentTo(writer);
          writer.Flush();
          ms.Position = 0;
          StreamReader reader = new StreamReader(ms);
          return reader.ReadToEnd();
     }
//-------------------------------------------------------------------------------------------
     private void IssueKey()
     {
          string LicenseKey = GetRequiredParam("LicenseKey");
          string ProductId = GetRequiredParam("ProductId");
          string ProductVersion = GetRequiredParam("ProductVersion");
          string RemoteMachineCode = GetRequiredParam("MachineCode");
          string RemoteMachineName = GetRequiredParam("MachineName");

          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               var key = (from y in data.Sales_LicenseKeys
                              where y.Key == LicenseKey
                              select y).FirstOrDefault();

               if (key == null)
               {
                    writer.WriteStartElement("ActivationRequestRejected");
                    WriteAttribute("Reason", "The license key could not be found.");
                    writer.WriteEndElement();
               }
               else
               {
                    data.Entry(key).State = System.Data.Entity.EntityState.Detached;

                    int activations = key.Activations.Value;

                    // FIND AN EXISTING ACTIVATION FOR THIS MACHINE
                    var existingActivation = (from x in data.Sales_LicenseKeyActivations
                                      where x.LicenseKeyId == key.Id
                                         && x.MachineCode == RemoteMachineCode
                                      select x).FirstOrDefault();

                    if (existingActivation == null)
                    {
                         if (key.Activations.Value < key.MachineCount)
                         {
                              Sales_LicenseKeyActivations activation = new Sales_LicenseKeyActivations();
                              activation.Id = Guid.NewGuid();
                              activation.OrganizationId = SelectedOrganization.Id;
                              activation.LicenseKeyId = key.Id;
                              activation.MachineCode = RemoteMachineCode;
                              activation.LastHeardFrom = DateTime.UtcNow;
                              data.Sales_LicenseKeyActivations.Add(activation);

                              activations++;
                         }
                         else
                         {
                              writer.WriteStartElement("ActivationRequestRejected");
                              WriteAttribute("Reason", "Too many activations.");
                              writer.WriteEndElement();
                              return;
                         }
                    }
                    else
                    {
                         existingActivation.LastHeardFrom = DateTime.UtcNow;
                    }
                    data.SaveChanges();

                    if (key != null)
                    {
                         writer.WriteStartElement("MachineLicense");
                         WriteAttribute("LicenseKey", key.Key);
                         WriteAttribute("MachineCode", RemoteMachineCode);
                         WriteAttribute("FullName", key.FullName);
                         WriteAttribute("Organization", key.Organization);
                         WriteAttribute("ConcurrentUsersPerMachine", key.ConcurrentUsersPerMachine.ToString());
                         WriteAttribute("ExpirationDate", key.ExpirationDate.ToString());
                         WriteAttribute("ActivationCount", activations.ToString());
                         if (!String.IsNullOrEmpty(key.ExtraXML))
                              writer.WriteRaw(Environment.NewLine + "     " + key.ExtraXML + Environment.NewLine);
                         writer.WriteEndElement();
                    }
               }
          }
     }
//-------------------------------------------------------------------------------------------
     private string GetRequiredParam(string param)
     {
          string val = Request[param];
          if (val == null)
          {
               throw new Exception("The required parameter \"" + param + "\" is missing.");
          }
          return val;
     }
//-------------------------------------------------------------------------------------------
     private void WriteAttribute(string AttributeName, string AttributeValue)
     {
          if (!String.IsNullOrEmpty(AttributeValue))
               writer.WriteElementString(AttributeName, AttributeValue);
     }
//-------------------------------------------------------------------------------------------
}