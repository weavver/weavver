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

public partial class Company_Services_Phone_Systems_Project : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;
     }
//-------------------------------------------------------------------------------------------
     protected void SendLead_Click(object sender, EventArgs e)
     {
          // Code that runs when an unhandled error occurs
          System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage("leads@weavver.com", "fatcat@weavver.com");
          msg.CC.Add(ConfigurationManager.AppSettings.Get("admin_address"));
          msg.Subject = "Lead for Phone System Consultation";

          string err = "New Sales Lead\r\n\r\n";
          msg.Body = "Phone system lead:\r\n\r\n" +
                     "Phone Count: " + PhoneCount.Text + "\r\n" +
                     "Network Administrator: " + NetworkAdmin.Text + "\r\n" +
                     "Network Connections: " + NetworkConnections.Text + "\r\n" +
                     "Telephone Provider: " + Provider.Text + "\r\n" +
                     "Wanted system type: " + SystemList.Text + "\r\n" +
                     "E-mail Address: " + EmailAddress.Text + "\r\n" +
                     "Phone: " + PhoneNumber.Text + "\r\n" +
                     "Other: " + Other.Text + "\r\n";

          System.Net.Mail.SmtpClient sClient = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings.Get("smtp_address"));
          sClient.Send(msg);

          LeadForm.Visible = false;
          LeadSent.Visible = true;
     }
//-------------------------------------------------------------------------------------------
}
