using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Weavver.Data;
using System.Web.Services;

// Weavver.. "Improving the way the world works."

public partial class Controls_Chat : System.Web.UI.Page
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
         // Inquiry.InnerText = Request.UserAgent;
         if (!Request.UserAgent.Contains("iPhone")
              && !Request.UserAgent.Contains("Android"))
         {
              //status.Style.Remove("position");
              //status.Style.Remove("bottom");

              status.Style["position"] = "fixed";
              status.Style["bottom"] = "-0px";
         }
    }
//-------------------------------------------------------------------------------------------
    [WebMethod]
    public static string LogInquiry(string username, string emailAddress, string phoneNumber, string department, string inquiry)
    {
         MailMessage newInquiry = new MailMessage("system@weavver.com", System.Configuration.ConfigurationManager.AppSettings["admin_address"]);
         newInquiry.Subject = "Inquiry";
         newInquiry.Body = "Department: " + department + "\r\n"
                 + "User: " + username + "\r\n"
                 + "Email Address: " + emailAddress + "\r\n"
                 + "Phone Number: " + phoneNumber + "\r\n"
                 + "Inquiry: " + inquiry + "\r\n"
                 + "Created At: " + DateTime.Now.ToString() + "\r\n"
                 + "By IP: " + HttpContext.Current.Request.UserHostAddress + "\r\n"
                 + "Referred By: " + HttpContext.Current.Session["ReferredBy"] + "\r\n\r\n"
                 + HttpContext.Current.Request.UserAgent;

         SmtpClient client = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["smtp_server"]);
         client.Send(newInquiry);

         return "OK";
    }
//-------------------------------------------------------------------------------------------
     protected void UpdatePage()
     {
          //if (Request["id"] != null && Visible)
          //{
          //     Guid parentId = new Guid(Request["id"].ToString());

          //     using (WeavverEntityContainer data = new WeavverEntityContainer())
          //     {
          //          var messages = (from x in data.Communication_Messages
          //                          where x.OrganizationId == BasePage.LoggedInUser.OrganizationId
          //                          && x.Account == parentId
          //                          orderby x.CreatedAt ascending
          //                          select x);

          //          List.DataKeyField = "Id";
          //          List.DataSource = messages;
          //          //List.DataBind();
          //     }
          //}
     }
//-------------------------------------------------------------------------------------------
     public void Save_Click(object sender, EventArgs e)
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               //Communication_Messages item = new Communication_Messages();
               //Guid parentId = new Guid(Request["id"].ToString());
               //item.Id = Guid.NewGuid();
               //item.OrganizationId = BasePage.LoggedInUser.OrganizationId;
               //item.Account = parentId;
               //item.Body = CommentUpdate.Text;
               //item.CreatedAt = DateTime.UtcNow;
               //item.CreatedBy = BasePage.LoggedInUser.Id;
               //item.UpdatedAt = DateTime.UtcNow;
               //item.UpdatedBy = BasePage.LoggedInUser.Id;
               //data.Communication_Messages.AddObject(item);
               //data.SaveChanges();

               //CommentUpdate.Text = "";

               //UpdatePage();
          }
     }
//-------------------------------------------------------------------------------------------
     public string GetName(Guid nameId)
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               return data.GetName(nameId);
          }
     }
//-------------------------------------------------------------------------------------------
}