using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weavver.Data;

public partial class Imports_Communication_Emails : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
     {
          if (Request.RequestType != "POST")
          {
               Response.Write("This page expects an HTTP POST");
               return;
          }

          string eRecipient = Request.Form["recipient"];  
          string eSender = Request.Form["sender"];
          string sBodyStrippedPlain = Request.Form["stripped-text"]; // instead of body-plain
          string eBodyStrippedHTML = Request.Form["stripped-html"]; // or body-html -- these have the signature/quoted parts remoted

          using (Weavver.Data.WeavverEntityContainer data = new Weavver.Data.WeavverEntityContainer())
          {
               Communication_Emails incomingEmail = new Communication_Emails();
               incomingEmail.Id = Guid.NewGuid();
               incomingEmail.OrganizationId = new Guid(Request.QueryString["OrganizationId"]);
               incomingEmail.From = eSender;
               incomingEmail.To = eRecipient;
               incomingEmail.HTMLBody = Request.Form["stripped-text"];
               incomingEmail.Subject = Request.Form["subject"];
               incomingEmail.CreatedAt = DateTime.UtcNow;
               incomingEmail.CreatedBy = Guid.Empty;
               incomingEmail.UpdatedAt = DateTime.UtcNow;
               incomingEmail.UpdatedBy = Guid.Empty;
               data.Communication_Emails.Add(incomingEmail);
               data.SaveChanges();
          }

          Response.Write("OK");

     }
}