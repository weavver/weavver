using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Configuration;

using Weavver.Company.Accounting;
using Weavver.Data;

public partial class Vendors_AuthorizeNet_SilentPost : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;

          if (Request["x_response_code"] == "1")
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    Accounting_LedgerItems item = new Accounting_LedgerItems();
                    item.OrganizationId = SelectedOrganization.Id;
                    item.Id = Guid.NewGuid();
                    item.PostAt = DateTime.UtcNow;
                    item.AccountId = new Guid(Request["accountid"]);
                    item.LedgerType = LedgerType.Savings.ToString();
                    item.Code = CodeType.Deposit.ToString();
                    item.Memo = Request["x_first_name"] + " " + Request["x_last_name"] + ", TXNID#" + Request["x_trans_id"] + ", ACCT#" + Request["x_account_number"];
                    item.Amount = Decimal.Parse(Request["x_amount"]);
                    item.CreatedAt = DateTime.UtcNow;
                    item.CreatedBy = (LoggedInUser == null) ? Guid.Empty : LoggedInUser.Id;
                    item.UpdatedAt = DateTime.UtcNow;
                    item.UpdatedBy = (LoggedInUser == null) ? Guid.Empty : LoggedInUser.Id;
                    
                    Guid orderId = Guid.Empty;
                    if (Guid.TryParse(Request["OrderId"], out orderId))
                    {
                         item.TransactionId = orderId;
                    }
                    data.Accounting_LedgerItems.Add(item);
                    data.SaveChanges();
               }
          }
          else
          {
               string toHash = ConfigurationManager.AppSettings["authorize.net_hash"] + Request["authorize.net_loginid"] + Request["x_trans_id"] + Request["x_amount"];

               MailMessage message = new MailMessage();
               message.From = new MailAddress("noreply@weavver.com");
               message.To.Add(new MailAddress(ConfigurationManager.AppSettings["admin_address"]));
               message.Subject = "Unhandled Silent Post";
               message.Body = "Silent post to: \r\n\r\n";
               //message.Body += Request["aspxerrorpath"] + "\r\n\r\n";

               message.Body += "To hash: " + toHash + "\r\n";

               for (int i = 0; i < Request.ServerVariables.Count; i++)
               {
                    message.Body += Request.ServerVariables.Keys[i] + ": " + Request.ServerVariables[i] + "\r\n";
               }
               message.Body += "\r\nQuery String:\r\n";
               for (int i = 0; i < Request.QueryString.Count; i++)
               {
                    message.Body += Request.QueryString.Keys[i] + ": " + Request.QueryString[i] + "\r\n";
               }
               message.Body += "\r\nPOST:\r\n";
               for (int i = 0; i < Request.Form.Count; i++)
               {
                    message.Body += Request.Form.Keys[i] + ": " + Request.Form[i] + "\r\n";
               }

               SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["smtp_server"]);
               client.Send(message);
          }
     }
//-------------------------------------------------------------------------------------------
}