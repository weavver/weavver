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

public partial class Company_HumanResources_Reports_TimeLogs : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          Staff.SelectedIndexChanged += new EventHandler(Staff_SelectedIndexChanged);
          ReportByDay.ItemDataBound += new DataGridItemEventHandler(ReportByDay_ItemDataBound);
          ReportByMonth.ItemDataBound += new DataGridItemEventHandler(ReportByMonth_ItemDataBound);
          EarnedByDay.ItemDataBound += new DataGridItemEventHandler(EarnedByDay_ItemDataBound);
          EarnedByMonth.ItemDataBound += new DataGridItemEventHandler(EarnedByMonth_ItemDataBound);

          IsPublic = false;
          Master.FormTitle = "Time Log Breakdown";
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (!IsPostBack)
          {
               //Staff.DataValueField = "Id";
               //Staff.DataTextField = "Name";
               //Staff.DataSource = HRHelper.StaffLimitToActive_ForOrganization(LoggedInUser.OrganizationId);
               //Staff.DataBind();

               //foreach (ListItem item in Staff.Items)
               //{
               //     if (item.Value == LoggedInUser.Id.ToString())
               //     {
               //          item.Selected = true;
               //     }
               //}

               //UpdatePage();
          }
     }
//-------------------------------------------------------------------------------------------
     void Staff_SelectedIndexChanged(object sender, EventArgs e)
     {
          UpdatePage();
     }
//-------------------------------------------------------------------------------------------
     public void UpdatePage()
     {
          Guid showPersonId = new Guid(Staff.SelectedValue);

          //ReportByDay.DataSource = HRHelper.TotalTime_ForPerson_ByDay(showPersonId, DateTime.Now.Subtract(TimeSpan.FromDays(999)), DateTime.Now);
          //ReportByDay.DataBind();

          //ReportByMonth.DataSource = HRHelper.TotalTime_ForPerson_ByMonth(showPersonId, DateTime.Now.Subtract(TimeSpan.FromDays(999)), DateTime.Now);
          //ReportByMonth.DataBind();

          //EarnedByDay.DataSource = HRHelper.TotalEarned_ForPerson_ByDay(showPersonId, DateTime.Now.Subtract(TimeSpan.FromDays(999)), DateTime.Now);
          //EarnedByDay.DataBind();

          //EarnedByMonth.DataSource = HRHelper.TotalEarned_ForPerson_ByMonth(showPersonId, DateTime.Now.Subtract(TimeSpan.FromDays(999)), DateTime.Now);
          //EarnedByMonth.DataBind();
     }
//-------------------------------------------------------------------------------------------
     void ReportByMonth_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
          {
               TimeSpan duration = TimeSpan.FromSeconds(Double.Parse(e.Item.Cells[1].Text));
               //e.Item.Cells[1].Text = TimeSpanString(duration);
          }
     }
//-------------------------------------------------------------------------------------------
     void ReportByDay_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
          {
               TimeSpan duration = TimeSpan.FromSeconds(Double.Parse(e.Item.Cells[1].Text));
               //e.Item.Cells[1].Text = TimeSpanString(duration);
          }
     }
//-------------------------------------------------------------------------------------------
     void EarnedByDay_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
          {
               decimal earned = Decimal.Parse(e.Item.Cells[1].Text);
               e.Item.Cells[1].Text = "$" + Math.Round(earned, 2) + "&nbsp;";
          }
     }
//-------------------------------------------------------------------------------------------
     void EarnedByMonth_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
          {
               decimal earned = Decimal.Parse(e.Item.Cells[1].Text);
               e.Item.Cells[1].Text = "$" + Math.Round(earned, 2) + "&nbsp;";
          }
     }
//-------------------------------------------------------------------------------------------
}
