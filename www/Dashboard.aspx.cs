using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weavver.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

public partial class Dashboard : SkeletonPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
         // Request
         // do dns check to see if www.weavver.internal resolves to this server...
         // http://192.168.5.31/weavverweb

         if (!IsPostBack)
         {
              if (SelectedOrganization != null)
                   UpdatePage(null);

              // Get host name
              string strHostName = Dns.GetHostName();
              Console.WriteLine("Host Name: " + strHostName);

              // Find host by name
              IPHostEntry iphostentry = Dns.GetHostByName(strHostName);

              // Enumerate IP addresses
              int nIP = 0;

              Self_URL.Text = "";
              foreach (IPAddress ipaddress in iphostentry.AddressList)
              {
                   Self_URL.Text += "http://" + ipaddress.ToString() + ", ";
              }
              char[] charsToTrim = { ',', ' ' };
              Self_URL.Text = Self_URL.Text.TrimEnd(charsToTrim);
         }

         ReceivablesLink.HRef = String.Format("~/Accounting_LedgerItems/List.aspx?AccountId={0}&LedgerType={1}", LoggedInUser.OrganizationId.ToString(), LedgerType.Receivable.ToString());
         PayablesLink.HRef = String.Format("~/Accounting_LedgerItems/List.aspx?AccountId={0}&LedgerType={1}", LoggedInUser.OrganizationId.ToString(), LedgerType.Payable.ToString());
         TasksLink.HRef = String.Format("~/HR_Tasks/List.aspx?AssignedTo={0}", LoggedInUser.Id.ToString());

         //using (WeavverEntityContainer data = new WeavverEntityContainer())
         //{
         //     var accountContent = (from x in data.CMS_Pages
         //                     where x.Title == "Account/Default" &&
         //                     x.OrganizationId == SelectedOrganization.Id
         //                     select x).First();

         //     if (accountContent != null)
         //     {
         //          AccountContent.Text = accountContent.Page;
         //     }
         //}


         //Response.Write(HttpContext.Current.Items["rawurl"]);
         //DebugOut("Vanity URL: " + HttpContext.Current.Items["rawurl"]);
     }
//-------------------------------------------------------------------------------------------
     public void UpdatePage(string department)
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               if (LoggedInUser.OrganizationId == SelectedOrganization.Id)
               {
                    var tickets = (from x in data.CustomerService_Tickets
                                   where x.Status != "Closed"
                                   && x.OrganizationId == SelectedOrganization.Id
                                   select x);

                    OpenTickets.Text = tickets.Count().ToString();

                    var ticketstotal = (from x in data.CustomerService_Tickets
                                        where x.OrganizationId == SelectedOrganization.Id
                                        select x);

                    TotalTickets.Text = ticketstotal.Count().ToString();
               }
               else
               {
                    var tickets2 = (from x in data.CustomerService_Tickets
                                    where x.Status != "Closed"
                                    && x.CustomerId.Value == LoggedInUser.OrganizationId
                                    select x);

                    OpenTickets.Text = tickets2.Count().ToString();

                    var ticketstotal2 = (from x in data.CustomerService_Tickets
                                         where x.CustomerId.Value == LoggedInUser.OrganizationId
                                         select x);

                    TotalTickets.Text = ticketstotal2.Count().ToString();
               }
          }

          try
          {
               string freeswitchCS = ConfigurationManager.ConnectionStrings["freeswitch"].ConnectionString;
               MySqlConnection conn = new MySqlConnection(freeswitchCS);
               conn.Open();
               MySqlCommand command = new MySqlCommand("select * from voicemail_msgs where username=?username order by created_epoch desc;", conn);
               command.Parameters.AddWithValue("?username", LoggedInUser.Username);
               MySqlDataReader reader = command.ExecuteReader();
               VoicemailList.DataSource = reader;
               VoicemailList.DataBind();
               reader.Close();

               command.CommandText = "select distinct in_folder from voicemail_msgs where username=?username;";
               reader = command.ExecuteReader();
               VoicemailFolders.DataTextField = "in_folder";
               VoicemailFolders.DataSource = reader;
               VoicemailFolders.DataBind();
               reader.Close();

               conn.Close();

               Voicemail.Visible = (VoicemailFolders.Items.Count > 0);

               if (VoicemailList.Items.Count > 0)
               {
                    Voicemail.FindControlR<Literal>("NoVoicemails").Visible = true;
               }
          }
          catch (MySqlException ex)
          {
               Voicemail.FindControlR<Literal>("NoVoicemails").Text = "Could not load your voicemails, please try back later.";
               Voicemail.FindControlR<Literal>("NoVoicemails").Visible = true;
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Search_Click(object sender, EventArgs e)
     {
          Response.Redirect("/Search.aspx?q=" + HttpUtility.UrlEncode(Query.Text));
     }
////-------------------------------------------------------------------------------------------
//     protected void Sections_SelectedIndexChanged(object sender, EventArgs e)
//     {
//          // used this trick to get around a strange bug where browser would say "Object moved here."
//          Response.BufferOutput = true;
//          Response.Clear();
//          Response.Status = "301 Moved";
//          Response.AddHeader("Location", Sections.SelectedValue);
//          Response.Redirect(Sections.SelectedValue);
//     }
//-------------------------------------------------------------------------------------------
     protected void List_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
          {
               string epoch = e.Item.Cells[3].Text;
               System.DateTime epochDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
               epochDateTime = epochDateTime.AddSeconds(Double.Parse(epoch));

               e.Item.Cells[3].Text = Weavver.Utilities.DateTimeHelper.GetFriendlyDateString(epochDateTime.ToLocalTime());
               // Print the date and time
          }
     }
//-------------------------------------------------------------------------------------------
}