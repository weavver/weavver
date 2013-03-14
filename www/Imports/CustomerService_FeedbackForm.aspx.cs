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

public partial class Company_CustomerService_FeedbackForm : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;
          Master.FormTitle = "Feedback";
     }
//-------------------------------------------------------------------------------------------
     public void Send_Click(object sender, EventArgs e)
     {
          MailMessage msg = new System.Net.Mail.MailMessage(Name.Text + " <" + EmailAddress.Text + ">", ConfigurationManager.AppSettings.Get("admin_address"));
          msg.Subject = "Feedback from " + Name.Text;

          string body = "Type: " + FeedbackType.Text + "\r\n\r\n" + Message.Text;
          msg.Body = body;

          SmtpClient sClient = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings.Get("smtp_address"));
          sClient.Send(msg);

          FeedbackPan.Visible = false;
          ThankYou.Visible = true;
     }
//-------------------------------------------------------------------------------------------
}
