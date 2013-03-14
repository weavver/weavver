using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Weavver.Data;

public partial class Controls_Waiting_List : System.Web.UI.UserControl
{
//-------------------------------------------------------------------------------------------
     private string listname;
     public string ListName
     {
          get
          {
               return listname;
          }
          set
          {
               listname = value;
          }
     }
//-------------------------------------------------------------------------------------------
     private string displayname;
     public string DiplayName
     {
          get
          {
               return displayname;
          }
          set
          {
               displayname = value;
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {

     }
//-------------------------------------------------------------------------------------------
     protected void Join_Click(object sender, EventArgs e)
     {
          //Weavver.Company.Common.WaitingList wl = new Weavver.Company.Common.WaitingList();
          //wl.Id = Guid.NewGuid();
          //wl.Name = "sipfordomains";
          //wl.PhoneNumber = Name.Text;
          //wl.EmailAddress = Email.Text;
          //wl.Domain = Domain.Text;
          //wl.PhoneNumber = Phone.Text;
          //wl.SubmittedAt = DateTime.UtcNow;
          //if (wl.Commit())
          //{
          //     WaitingList.Visible = false;
          //     WaitingListJoined.Visible = true;
          //}

          MailMessage msg = new System.Net.Mail.MailMessage("Weavver Waiting Lists <waitinglists@weavver.com>", ConfigurationManager.AppSettings.Get("admin_address"));
          msg.Subject = DiplayName + ": " + Domain.Text;

          string body = "Name: " + Name.Text + "\r\n\r\n" +
                         "Email: " + Email.Text + "\r\n\r\n" +
                         "Domain: " + Domain.Text + "\r\n\r\n" +
                         "Phone: " + Phone.Text;
          msg.Body = "New Hosting Request:\r\n\r\n" + body;
          System.Net.Mail.SmtpClient sClient = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings.Get("smtp_address"));
          sClient.Send(msg);
     }
//-------------------------------------------------------------------------------------------
}