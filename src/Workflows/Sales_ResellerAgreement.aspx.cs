using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;

using Weavver.Data;

public partial class Company_Sales_Reseller_Agreement : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          Master.FormTitle = "Reseller Agreement";
          Agreement.InnerHtml = AgreementText();
     }
//-------------------------------------------------------------------------------------------
     public string AgreementText()
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               Legal_Agreements agreement = (from x in data.Legal_Agreements
                                             where x.Id == new Guid("a618950e-db72-46ac-afd9-47693caabb96")
                                             select x).First();
               return agreement.Body;
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Agree_Click(object sender, EventArgs e)
     {
          MailMessage msg = new System.Net.Mail.MailMessage("reselleragreement@weavver.com", ConfigurationManager.AppSettings.Get("admin_address"));
          msg.Subject = "Reseller Agreement signed by " + NameFirst.Text + " " + NameLast.Text + " (" + OrganizationName.Text + ")";

          string body = AgreementText() + "\r\n\r\nDigital Signature:\r\n\r\n";
          body += "First Name: " + NameFirst.Text + "\r\n";
          body += "Last Name: " + NameLast.Text + "\r\n";
          body += "Title: " + OrganizationTitle.Text + "\r\n";
          body += "Organization Name: " + OrganizationName.Text + "\r\n\r\n";
          body += "Signed At: " + DateTime.UtcNow.ToString("MM/dd/yyy hh:mm:ss") + " UTC\r\n";
          body += "From IP Address: " + Request.UserHostAddress;
          msg.Body = body;

          SmtpClient sClient = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings.Get("smtp_address"));
          sClient.Send(msg);

          Response.Redirect("~/company/sales/");
     }
//-------------------------------------------------------------------------------------------
}
