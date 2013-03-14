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

public partial class Company_Sales_ResellerApplication : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;
          Master.FormTitle = "Reseller Application";
          Master.FixedWidth = true;
          if (SelectedOrganization.Id != Guid.Empty && LoggedInUser != null)
          {
               Anonymous.Visible = false;
               ResellerApp.Visible = true;
          }
          else
          {
               Anonymous.Visible = true;
               ResellerApp.Visible = false;
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Apply_Click(object sender, EventArgs e)
     {
          string querystring = "";
          foreach (string key in Request.QueryString.Keys)
          {
               querystring += key + "=" + Request.QueryString[key] + "&";
          }

          string formdata = "";
          foreach (string key in Request.Form.Keys)
          {
               if (key.StartsWith("ctl00$Content$"))
                    formdata += key.Replace("ctl00$Content$", "") + ": " + Request.Form[key] + "\r\n";
          }

          foreach (string key in Request.Files.Keys)
          {
               formdata += key + "=" + Request.Files[key].ContentType + "-" + Request.Files[key].ContentLength;
          }
          MailMessage msg = new System.Net.Mail.MailMessage("resellerapplication@weavver.com", ConfigurationManager.AppSettings["admin_address"]);
          msg.Subject = "Reseller Application"; //  +Name.Text;

          string body = "QueryString:\r\n" + querystring;
          body += "Reseller Org: " + SelectedOrganization.Id.ToString() + "\r\n";
          body += "PersonId: " + LoggedInUser.Id.ToString() + "\r\n";
          body += "\r\n\r\nFrom IP: " + Request.UserHostAddress;
          body += "\r\n\r\nForm Data:\r\n" + formdata;
          body += "\r\nRequested At: " + DateTime.Now.ToString() + " PST";
          msg.Body = body;

          SmtpClient sClient = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["smtp_address"]);
          sClient.Send(msg);

          ResellerApp.Visible = false;
          ResellerApplied.Visible = true;
     }
//-------------------------------------------------------------------------------------------
}
