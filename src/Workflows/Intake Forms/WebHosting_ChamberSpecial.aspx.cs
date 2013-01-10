using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Net;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

using System.Net.Mail;

//using Weavver.Vendors.Parallels;

public partial class Company_Services_Hosting_ChamberSpecial : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;
     }
//-------------------------------------------------------------------------------------------
     protected void SignUp_Click(object sender, EventArgs e)
     {
          Weavver.Vendors.Parallels.PleskRequest pr = new Weavver.Vendors.Parallels.PleskRequest();
          string errmsg = pr.CustomerAdd(BusinessName.Text, PrimaryContact1.FirstName.Text + " " + PrimaryContact1.LastName.Text, Username.Text, Password.Text, PrimaryContact1.PhoneNumber.Text, PrimaryContact1.EmailAddress.Text, PrimaryContact1.AddressLine1.Text, PrimaryContact1.ZipCode.Text);

          if (errmsg != null)
          {
               ErrorMSG.Text = errmsg;
          }
          else
          {
               MailMessage msg = new System.Net.Mail.MailMessage("orders@weavver.com", PrimaryContact1.EmailAddress.Text);
               msg.Subject = "Basic Web Hosting - Fullerton Chamber Special"; //  +Name.Text;

               string body = "Thank you for your order. Please allow 24 hours for your account to be provisioned.\r\n\r\n";
               body += "Your order details:\r\n\r\n";
               body += "Plan: Basic Web Hosting\r\n";
               body += "Value: $59.88/year\r\n\r\n";
               body += "Business Name:  {0}\r\n";
               body += "Domain Name:  {1}\r\n";
               body += "Username:  {2}\r\n\r\n";
               body += "First Name:  {3}\r\n";
               body += "Last Name:  {4}\r\n";
               body += "Email Address:  {5}\r\n";
               body += "Address Line 1:  {6}\r\n";
               body += "Address Line 2:  {7}\r\n";
               body += "Zip Code:  {8}\r\n";
               body += "Phone Number:  {9}\r\n";
               body += "Extension:  {10}\r\n\r\n";
               body += "Sincerely,\r\nThe Weavver Team";

               body = String.Format(body, BusinessName.Text, Domain.Text, Username.Text, PrimaryContact1.FirstName, PrimaryContact1.LastName, PrimaryContact1.EmailAddress, PrimaryContact1.AddressLine1,
                                             PrimaryContact1.AddressLine2, PrimaryContact1.ZipCode, PrimaryContact1.PhoneNumber, PrimaryContact1.PhoneExtension);

               msg.Body = body;
               SmtpClient sClient = new SmtpClient(ConfigurationManager.AppSettings["smtp_address"]);
               sClient.Send(msg);

               msg.Body = "Copy of order to provision:\r\n\r\n" + body + "\r\n\r\nPassword: " + Password.Text;
               msg.To.Clear();
               msg.To.Add(ConfigurationManager.AppSettings["admin_address"]);
               sClient.Send(msg);

               HostingSignUp.Visible = false;
               HostingSignedUp.Visible = true;
          }
     }
//-------------------------------------------------------------------------------------------
}