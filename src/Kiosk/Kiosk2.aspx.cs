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

using Weavver.Data;

public partial class Company_Human_Resources_Kiosk2 : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          List.HeaderStyle.BackColor = System.Drawing.Color.BurlyWood;
          List.ItemDataBound += new DataGridItemEventHandler(List_ItemDataBound);

          IsPublic = false;

          //LoginName.Text = DatabaseHelper.GetName(Guid.Empty);

          //List.DataSource = HRHelper.TotalTime_ForPerson(SelectedOrganization.Id, LoggedInUser.Id);
          //List.DataKeyField = "Id";
          //List.DataBind();
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          UpdatePage();
     }
//-------------------------------------------------------------------------------------------
     private void UpdatePage()
     {
          //List.DataSource = HRHelper.TimeLogs_ForPerson(LoggedInUser.Id, 12);
          //List.DataBind();

          //LoginName.Text = DatabaseHelper.GetName(LoggedInUser.Id);
          //TotalTime.Text = HRHelper.TotalTime_ForPerson(LoggedInUser.Id, LoggedInUser.Id);

          //if (HRHelper.IsPunchedIn(SelectedOrganization, LoggedInUser.Id) != Guid.Empty)
          //{
          //     Punch.Text = "Punch Out";
          //}
          //else
          //{
          //     Punch.Text = "Punch In";
          //}
     }
//-------------------------------------------------------------------------------------------
     protected void TimeCardShow_Click(object sender, EventArgs e)
     {
          Mod.Show();
          TimeCard.Visible = true;
     }
//-------------------------------------------------------------------------------------------
     protected void TimeCardHide_Click(object sender, EventArgs e)
     {
          TimeCard.Visible = false;
     }
//-------------------------------------------------------------------------------------------
     void List_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
          {
               HR_TimeLogs tLog = (HR_TimeLogs)e.Item.DataItem;
               // Response.Write(tLog.DateTimeOut.ToString());
               if (tLog.End.ToString() == "1/1/2001 12:00:00 AM")
               {
                    e.Item.Cells[3].Text = "";
               }
          }
     }
//-------------------------------------------------------------------------------------------
     public void Punch_Click(object sender, EventArgs e)
     {
          //Guid timeLogId = HRHelper.IsPunchedIn(SelectedOrganization, LoggedInUser.Id);
          //if (timeLogId == Guid.Empty)
          //     HRHelper.PunchIn(SelectedOrganization.Id, LoggedInUser.Id);
          //else
          //     HRHelper.PunchOut(timeLogId);

          UpdatePage();
     }
//-------------------------------------------------------------------------------------------
     protected void LogOut_Click(object sender, EventArgs e)
     {
          FormsAuthentication.SignOut();
          Session.Clear();
          Response.Redirect("~/company/human_resources/kiosk");
     }
//-------------------------------------------------------------------------------------------
}