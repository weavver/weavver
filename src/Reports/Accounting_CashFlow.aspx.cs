using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Weavver.Data;
using Weavver.Company.Accounting;

public partial class Accounting_CashFlowReport : SkeletonPage
{
     SqlConnection connection;
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          ByDay.ItemDataBound += new DataGridItemEventHandler(ByDay_ItemDataBound);
          ByWeek.ItemDataBound += new DataGridItemEventHandler(ByWeek_ItemDataBound);
          ByMonth.ItemDataBound += new DataGridItemEventHandler(ByMonth_ItemDataBound);
          YearFilter.SelectedIndexChanged += new EventHandler(YearFilter_SelectedIndexChanged);
          Accounts.DataBound += new EventHandler(Accounts_DataBound);

          connection = new SqlConnection(ConfigurationManager.ConnectionStrings["weavver"].ConnectionString);
          connection.Open();
     }
//-------------------------------------------------------------------------------------------
     void Accounts_DataBound(object sender, EventArgs e)
     {
          for (int i = 0; i < Accounts.Items.Count; i++)
          {
               string txt = Accounts.Items[i].Text;
               if (txt.Length > 8)
                    Accounts.Items[i].Text = txt.Substring(0, 8) + "..";
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          Master.FormTitle = "Cash Flow";

          // by month:
          //select year(postat) as 'Year', month(postat) as 'Month', sum(amount) as 'Total'
          //from accounting_ledgeritems where accountid = '63F1948C-4FB9-47D9-9333-E4593B5D6CFA'
          //GROUP BY Year(postat), Month(postat)

          if (!IsPostBack)
          {
               UpdatePage();
          }
     }
//-------------------------------------------------------------------------------------------
     protected void UpdatePage()
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               var accounts = from x in data.Accounting_Accounts
                              where x.OrganizationId == SelectedOrganization.Id
                              orderby x.Name
                              select x;

               Accounts.DataTextField = "Name";
               Accounts.DataValueField = "Id";
               //Accounts.DataSource = accounts;
               //Accounts.DataBind();
          }

          Accounts.Items.Insert(0, "All");

          //BindByDay();
          //BindByWeek();
          //BindByMonth();
     }
//-------------------------------------------------------------------------------------------
     void YearFilter_SelectedIndexChanged(object sender, EventArgs e)
     {
          UpdatePage();
     }
//-------------------------------------------------------------------------------------------
     private void BindByDay()
     {
          string expensesByDay = @"select year(postat) as 'Year',
               month(postat) as 'Month',
               day(postat) as 'Day',
               Sum(Amount) as 'Total'
               from Accounting_LedgerItems
               where
                    OrganizationId = @OrganizationId and                    
                    LedgerType != @Receivable and
                    LedgerType = @CreditCard and
                    Year(postat) = @Year
               Group By Year(PostAt), Month(PostAt), Day(PostAt)
               Order By Year(PostAt) desc, Month(PostAt) desc, Day(PostAt) desc";

          {
               SqlCommand command = new SqlCommand(expensesByDay, connection);
               command.Parameters.AddWithValue("OrganizationId", SelectedOrganization.Id);
               command.Parameters.AddWithValue("Year", Int32.Parse(YearFilter.Text));
               command.Parameters.AddWithValue("Receivable", (byte) LedgerType.Receivable);
               command.Parameters.AddWithValue("CreditCard", (byte) LedgerType.CreditCard);
               SqlDataReader reader = command.ExecuteReader();
               ByDay.DataSource = reader;
               ByDay.DataBind();
               reader.Close();
          }
     }
//-------------------------------------------------------------------------------------------
     private void BindByWeek()
     {
          string sql = @"select datepart(week, postat) as 'Week', sum(amount) as 'Total'
               from Accounting_LedgerItems
               where
                    OrganizationId = @OrganizationId and
                    LedgerType = @CreditCard and
                    LedgerType != @Receivable and
                    Year(postat) = @Year
               Group By DatePart(week, PostAt)
               Order By DatePart(week, PostAt) desc";

          //using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["weavver"].ConnectionString))
          //{
               SqlCommand command = new SqlCommand(sql, connection);
               command.Parameters.AddWithValue("OrganizationId", LoggedInUser.OrganizationId);
               command.Parameters.AddWithValue("Year", Int32.Parse(YearFilter.Text));
               command.Parameters.AddWithValue("Receivable", (byte)LedgerType.Receivable);
               command.Parameters.AddWithValue("CreditCard", (byte)LedgerType.CreditCard);
               SqlDataReader reader = command.ExecuteReader();
               ByWeek.DataSource = reader;
               ByWeek.DataBind();
               reader.Close();
          //}
     }
//-------------------------------------------------------------------------------------------
     private void BindByMonth()
     {
          string sql = @"select 
               month(postat) as 'Month',
               Sum(Amount) as 'Total'
               from Accounting_LedgerItems
               where
                    OrganizationId = @OrganizationId and
                    LedgerType != @Receivable and
                    LedgerType = @CreditCard and
                    Year(PostAt) = @Year
               Group By Year(PostAt), Month(PostAt)
               Order By Year(PostAt) desc, Month(PostAt) desc";

          SqlCommand command = new SqlCommand(sql, connection);
          command.Parameters.AddWithValue("OrganizationId", SelectedOrganization.Id);
          command.Parameters.AddWithValue("Year", Int32.Parse(YearFilter.Text));
          command.Parameters.AddWithValue("Receivable", (byte)LedgerType.Receivable);
          command.Parameters.AddWithValue("CreditCard", (byte)LedgerType.CreditCard);
          SqlDataReader reader = command.ExecuteReader();
          ByMonth.DataSource = reader;
          ByMonth.DataBind();
          reader.Close();
     }
//-------------------------------------------------------------------------------------------
     void ByDay_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
          {
               System.Data.Common.DbDataRecord rd = (System.Data.Common.DbDataRecord)e.Item.DataItem;
               DateTime date = new DateTime(rd.GetInt32(0), rd.GetInt32(1), rd.GetInt32(2));
               e.Item.Cells[0].Text = date.ToString("MM/dd/yy");
               if (date > DateTime.Now)
               {
                    e.Item.Cells[0].Font.Italic = true;
                    e.Item.Cells[0].ForeColor = System.Drawing.Color.Gray;
               }
          }
     }
//-------------------------------------------------------------------------------------------
     void ByWeek_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
          {
               System.Data.Common.DbDataRecord rd = (System.Data.Common.DbDataRecord)e.Item.DataItem;
               DateTime weekStart = GetDatesForWeek(rd.GetInt32(0), Int32.Parse(YearFilter.Text));
               e.Item.Cells[0].Text = weekStart.ToString("MM/dd/yy") + "-" + weekStart.AddDays(7).ToString("MM/dd/yy");
               e.Item.Cells[0].ToolTip = rd.GetInt32(0).ToString();
               if (weekStart > DateTime.Now)
               {
                    e.Item.Cells[0].Font.Italic = true;
                    e.Item.Cells[0].ForeColor = System.Drawing.Color.Gray;
               }
          }
     }
//-------------------------------------------------------------------------------------------
     void ByMonth_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
          {
               System.Data.Common.DbDataRecord rd = (System.Data.Common.DbDataRecord)e.Item.DataItem;
               DateTime monthCalc = new DateTime(Int32.Parse(YearFilter.Text), rd.GetInt32(0), 1);
               e.Item.Cells[0].Text = monthCalc.ToString("MMMM");
               if (monthCalc > DateTime.Now)
               {
                    e.Item.Cells[0].Font.Italic = true;
                    e.Item.Cells[0].ForeColor = System.Drawing.Color.Gray;
               }
          }
     }
//-------------------------------------------------------------------------------------------
     private DateTime GetDatesForWeek(int weekNum, int year)
     {
          DateTime jan1 = new DateTime(year, 1, 1);
          int daysOffset = DayOfWeek.Sunday - jan1.DayOfWeek;
          DateTime firstMonday = jan1.AddDays(daysOffset);
          var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
          int firstWeek = cal.GetWeekOfYear(jan1, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
          if (firstWeek <= 1)
          {
               weekNum -= 1;
          }
          DateTime result = firstMonday.AddDays(weekNum * 7 + 1 - 1);
          return result;
     }
//-------------------------------------------------------------------------------------------
//     private string GetMonthName(int monthNum, bool abbreviate)
//     {
//          if (monthNum < 1 || monthNum > 12)
//               throw new ArgumentOutOfRangeException("monthNum");
//          DateTime date = new DateTime(1, monthNum, 1);
//          if (abbreviate)
//               return date.ToString("MMM");
//          else
//               return date.ToString("MMMM");
//     }
//-------------------------------------------------------------------------------------------
}