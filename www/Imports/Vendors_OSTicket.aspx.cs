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

using MySql.Data.MySqlClient;

using Weavver.Data;

public partial class Company_Support_Import : SkeletonPage
{
     DataSet ds = null;
     string connectionString = "";
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          //Response.Write(LoggedInUser.Id);
     }
//-------------------------------------------------------------------------------------------
     protected void ImportOSTicket_Click(object sender, EventArgs e)
     {
          ////if (PersonId.ToString() == "6bb552e9-debb-40d3-a5a9-60329aedeaac")
          //{
          //     WeavverDatabase db = new WeavverDatabase();
          //     connectionString = String.Format("host={0};user={1};password={2};database=weavversupport;Allow Zero Datetime=true", Host.Text, Username.Text, Password.Text);
          //     db.InitAsMySQL(connectionString);
          //     MySql.Data.MySqlClient.MySqlCommand command = new MySqlCommand("select * from ticket where status='open' order by created desc", db.MySqlDB);
          //     ds = db.GetData(command);

          //     foreach (DataRow row in ds.Tables[0].Rows)
          //     {
          //          Response.Write(row["ticket_id"]);
          //          Response.Write(row["email"]);

          //          Ticket ticket = new Ticket();
          //          ticket.Id = Guid.NewGuid();
          //          ticket.OrganizationId = SelectedOrganization.Id;
          //          ticket.Subject = (string) row["subject"];
          //          ticket.Source = (string) row["source"];
          //          ticket.Status = (string) row["status"];
          //          ticket.CreatedAt = DateTime.Parse(row["created"].ToString());
          //          ticket.Commit();
          //     }

          //     //List.DataSource = ds;
          //     //List.ItemDataBound += new DataListItemEventHandler(List_ItemDataBound);
          //     //List.DataBind();
          //}
          ////else
          //{
          //     ShowError("You are not authorized to import tickets.");
          //}
     }
//-------------------------------------------------------------------------------------------
     protected void List_ItemDataBound(object sender, DataListItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
          {
               LinkButton but = (LinkButton) e.Item.FindControl("Subject");
               but.Text = ds.Tables[0].Rows[e.Item.ItemIndex]["subject"].ToString();
               but.CommandArgument = ds.Tables[0].Rows[e.Item.ItemIndex]["ticket_id"].ToString();
               but.Click += new EventHandler(but_Click);
          }
     }
//-------------------------------------------------------------------------------------------
     void but_Click(object sender, EventArgs e)
     {
          LinkButton button = (LinkButton) sender;
          Response.Redirect("Issue.aspx?ticket_id=" + button.CommandArgument);
     }
//-------------------------------------------------------------------------------------------
     private void List2()
     {
          //string ticket_id = Request["ticket_id"];
          //WeavverDatabase db = new WeavverDatabase();
          //db.InitAsMySQL(connectionString);
          //MySqlCommand command = new MySqlCommand("select * from ticket_message where ticket_id = '" + ticket_id + "'", db.MySqlDB);
          ////MySql.Data.MySqlClient.MySqlDataReader reader = command.ExecuteReader();
          //// ds = db.GetData(command);

          ////List.DataSource = ds;
          ////List.ItemDataBound += new DataListItemEventHandler(List_ItemDataBound);
          ////List.DataBind();

          //MySqlCommand command2 = new MySqlCommand("select * from ticket_response where ticket_id = '" + ticket_id + "'", db.MySqlDB);
          //DataSet ds2 = db.GetData(command2);

          //Responses.DataSource = ds2;
          //Responses.ItemDataBound += new DataListItemEventHandler(List_ItemDataBound);
          //Responses.DataBind();

          //MySqlCommand command3 = new MySqlCommand("select * from ticket_note where ticket_id = '" + ticket_id + "'", db.MySqlDB);
          //DataSet ds3 = db.GetData(command3);

          //Notes.DataSource = ds3;
          //Notes.ItemDataBound += new DataListItemEventHandler(List_ItemDataBound);
          //Notes.DataBind();
     }
//-------------------------------------------------------------------------------------------
     //protected void List_ItemDataBound(object sender, DataListItemEventArgs e)
     //{
     //     if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
     //     {
     //          LinkButton but = (LinkButton) e.Item.FindControl("Subject");
               
     //          //but.Text = ds.Tables[0].Rows[e.Item.ItemIndex]["subject"].ToString();
     //          //but.CommandArgument = ds.Tables[0].Rows[e.Item.ItemIndex]["ticket_id"].ToString();
     //          //but.Click += new EventHandler(but_Click);
     //     }
     //}
//-------------------------------------------------------------------------------------------
     public string CleanUp(string text)
     {
          return text.Replace("\r\n", "<br />");
     }
//-------------------------------------------------------------------------------------------
}
