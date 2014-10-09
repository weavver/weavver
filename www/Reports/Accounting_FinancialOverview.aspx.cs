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

using System.Data.Common;

public partial class Company_Accounting_Reports_FinancialOverview : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_PreInit(object sender, EventArgs e)
     {
          if (Request["IFrame"] == "true")
          {
               MasterPageFile = "~/Blank.master";
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          WeavverMaster.FormTitle = "Financial Overview";
          if (Request["IFrame"] != "true")
          {
               Master.FixedWidth = false;
               Master.Width = "100%";
          }

          //List.ItemDataBound += new DataGridItemEventHandler(List_ItemDataBound);
          ARList.ItemDataBound += new DataGridItemEventHandler(ARList_ItemDataBound);
          APList.ItemDataBound += new DataGridItemEventHandler(APList_ItemDataBound);

          PreRender += new EventHandler(Company_Accounting_Reports_FinancialOverview_PreRender);
     }
//-------------------------------------------------------------------------------------------
     void Company_Accounting_Reports_FinancialOverview_PreRender(object sender, EventArgs e)
     {
          for (int i = 0; i < ARList.Items.Count; i++)
          {
               string newtext = ARList.Items[i].Cells[0].Text + "s";
               switch (newtext)
               {
                    case "Payments": newtext = "Payments"; break;
                    case "Reimbursements": newtext = "Reimbursements"; break;
                    case "Sales": newtext = "Sales"; break;
               }
               ARList.Items[i].Cells[0].Text = newtext;
          }
          for (int i = 0; i < APList.Items.Count; i++)
          {
               APList.Items[i].Cells[0].Text += "s";
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          UpdatePage();
     }
//-------------------------------------------------------------------------------------------
     private void UpdatePage()
     {
          BindAR();
          BindAP();
          BindCashFlow();
          BindNet();

          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               // get cash accounts
               // remove all receivabls
               //var avCash = from x in data.Accounting_Accounts
               //             where x.OrganizationId = 
               //             select x;

               //                  data.Total_ForLedger(null, LoggedInUser.OrganizationId, Guid.Empty, true, true, true);
               //AvailableCash.Text = String.Format("{0,10:C}", avCash); // Accounting.Balance(LoggedInUser.OrganizationId));
          }
     }
//-------------------------------------------------------------------------------------------
          //[System.Data.Objects.DataClasses.EdmFunction("SchoolModel.Store", "Total_ForLedger")]
          //public static decimal? Total_ForLedger(string ledgerType,
          //                                  Guid organizationId,
          //                                  Guid accountId,
          //                                  bool includeCredits,
          //                                  bool includeDebits,
          //                                  bool includeReservedFunds)
          //{
          //     throw new NotSupportedException("Direct calls are not supported.");
          //}
//-------------------------------------------------------------------------------------------
     private void BindAR()
     {
          string sums = @"
                    select code as 'Code',
                    'Jan' = (select abs(sum(l.amount)) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 1 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and l.LedgerType = @LedgerType),
                    'Feb' = (select abs(sum(l.amount)) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 2 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and l.LedgerType = @LedgerType),
                    'Mar' = (select abs(sum(l.amount)) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 3 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and l.LedgerType = @LedgerType),
                    'Apr' = (select abs(sum(l.amount)) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 4 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and l.LedgerType = @LedgerType),
                    'May' = (select abs(sum(l.amount)) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 5 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and l.LedgerType = @LedgerType),
                    'Jun' = (select abs(sum(l.amount)) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 6 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and l.LedgerType = @LedgerType),
                    'Jul' = (select abs(sum(l.amount)) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 7 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and l.LedgerType = @LedgerType),
                    'Aug' = (select abs(sum(l.amount)) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 8 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and l.LedgerType = @LedgerType),
                    'Sep' = (select abs(sum(l.amount)) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 9 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and l.LedgerType = @LedgerType),
                    'Oct' = (select abs(sum(l.amount)) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 10 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and l.LedgerType = @LedgerType),
                    'Nov' = (select abs(sum(l.amount)) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 11 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and l.LedgerType = @LedgerType),
                    'Dec' = (select abs(sum(l.amount)) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 12 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and l.LedgerType = @LedgerType),
                    'Tot' = (select abs(sum(l.amount)) from accounting_ledgeritems l where l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and l.LedgerType = @LedgerType),
                    'TD'  = (select abs(sum(l.amount)) from accounting_ledgeritems l where l.code = li.code and year(dbo.localizedt(l.postat)) <= @Year and l.organizationid = @OrganizationId and l.LedgerType = @LedgerType)
                    from Accounting_LedgerItems li
                    where year(dbo.localizedt(PostAt)) = @Year
                    and li.LedgerType = @LedgerType
                    and li.OrganizationId = @OrganizationId
                    and li.Code != 'Reserve'
                    group by code";

          using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["weavver"].ConnectionString))
          {
               SqlCommand command = new SqlCommand(sums, connection);
               command.Parameters.AddWithValue("OrganizationId", SelectedOrganization.Id);
               command.Parameters.AddWithValue("Year", Int32.Parse(YearFilter.Text));
               command.Parameters.AddWithValue("LedgerType", LedgerType.Receivable.ToString());
               command.CommandTimeout = 90;
               connection.Open();
               SqlDataReader reader = command.ExecuteReader();
               ARList.DataSource = reader;
               ARList.DataBind();
               reader.Close();
          }
     }
//-------------------------------------------------------------------------------------------
     private void BindAP()
     {
          string sums = @"
                    select code as 'Code',
                    'Jan' = (select -1 * sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 1 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType)),
                    'Feb' = (select -1 * sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 2 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType)),
                    'Mar' = (select -1 * sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 3 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType)),
                    'Apr' = (select -1 * sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 4 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType)),
                    'May' = (select -1 * sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 5 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType)),
                    'Jun' = (select -1 * sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 6 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType)),
                    'Jul' = (select -1 * sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 7 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType)),
                    'Aug' = (select -1 * sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 8 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType)),
                    'Sep' = (select -1 * sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 9 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType)),
                    'Oct' = (select -1 * sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 10 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType)),
                    'Nov' = (select -1 * sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 11 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType)),
                    'Dec' = (select -1 * sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 12 and l.code = li.code and year(dbo.localizedt(l.postat)) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType)),
                    'Tot' = (select -1 * sum(l.amount) from accounting_ledgeritems l where l.code = li.code and year(l.postat) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType)),
                    'TD'  = (select -1 * sum(l.amount) from accounting_ledgeritems l where l.code = li.code and year(l.postat) <= @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType))
                    from accounting_ledgeritems li
                    where year(dbo.localizedt(postat)) = @Year
                    and li.LedgerType = @LedgerType
                    and li.organizationid = @OrganizationId
                    group by code";

          using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["weavver"].ConnectionString))
          {
               SqlCommand command = new SqlCommand(sums, connection);
               command.CommandTimeout = 90;
               command.Parameters.AddWithValue("OrganizationId", LoggedInUser.OrganizationId);
               command.Parameters.AddWithValue("Year", Int32.Parse(YearFilter.Text));
               command.Parameters.AddWithValue("LedgerType", LedgerType.Payable.ToString());
               connection.Open();
               SqlDataReader reader = command.ExecuteReader();
               APList.DataSource = reader;
               APList.DataBind();
               reader.Close();
          }
     }
//-------------------------------------------------------------------------------------------
     private void BindCashFlow()
     {
          string sums = @"
                    select code as 'Code',
                    'Jan' = (select sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 1 and l.code = li.code and year(l.postat) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType1 or l.LedgerType = @LedgerType2)),
                    'Feb' = (select sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 2 and l.code = li.code and year(l.postat) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType1 or l.LedgerType = @LedgerType2)),
                    'Mar' = (select sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 3 and l.code = li.code and year(l.postat) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType1 or l.LedgerType = @LedgerType2)),
                    'Apr' = (select sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 4 and l.code = li.code and year(l.postat) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType1 or l.LedgerType = @LedgerType2)),
                    'May' = (select sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 5 and l.code = li.code and year(l.postat) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType1 or l.LedgerType = @LedgerType2)),
                    'Jun' = (select sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 6 and l.code = li.code and year(l.postat) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType1 or l.LedgerType = @LedgerType2)),
                    'Jul' = (select sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 7 and l.code = li.code and year(l.postat) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType1 or l.LedgerType = @LedgerType2)),
                    'Aug' = (select sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 8 and l.code = li.code and year(l.postat) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType1 or l.LedgerType = @LedgerType2)),
                    'Sep' = (select sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 9 and l.code = li.code and year(l.postat) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType1 or l.LedgerType = @LedgerType2)),
                    'Oct' = (select sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 10 and l.code = li.code and year(l.postat) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType1 or l.LedgerType = @LedgerType2)),
                    'Nov' = (select sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 11 and l.code = li.code and year(l.postat) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType1 or l.LedgerType = @LedgerType2)),
                    'Dec' = (select sum(l.amount) from accounting_ledgeritems l where month(dbo.localizedt(l.postat)) = 12 and l.code = li.code and year(l.postat) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType1 or l.LedgerType = @LedgerType2)),
                    'Tot' = (select sum(l.amount) from accounting_ledgeritems l where l.code = li.code and year(l.postat) = @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType1)),
                    'TD'  = (select sum(l.amount) from accounting_ledgeritems l where l.code = li.code and year(l.postat) <= @Year and l.organizationid = @OrganizationId and (l.LedgerType = @LedgerType1))
                    from accounting_ledgeritems li
                    where year(postat) = @Year
                    and li.LedgerType = @LedgerType1
                    and li.organizationid = @OrganizationId
                    group by code";


          using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["weavver"].ConnectionString))
          {
               SqlCommand command = new SqlCommand(sums, connection);
               command.Parameters.AddWithValue("OrganizationId", LoggedInUser.OrganizationId);
               command.Parameters.AddWithValue("Year", Int32.Parse(YearFilter.Text));
               command.Parameters.AddWithValue("LedgerType1", LedgerType.Checking.ToString());
               command.Parameters.AddWithValue("LedgerType2", LedgerType.Savings.ToString());
               command.CommandTimeout = 90;
               connection.Open();
               SqlDataReader reader = command.ExecuteReader();
               CashFlow.DataSource = reader;
               CashFlow.DataBind();
               reader.Close();
          }
     }
//-------------------------------------------------------------------------------------------
     private void BindNet()
     {
          string sql = @"select *,
                         YearTotal = (select SUM(balance) from Accounting_OrganizationPnL_ByMonth
                                        where Year=@Year and OrganizationId=@OrganizationId),
                         TD = (select SUM(balance) from Accounting_OrganizationPnL_ByMonth where OrganizationId=@OrganizationId
                               and Year <= @Year)
                         from Accounting_OrganizationPnL_ByMonth
                         Pivot(sum(Balance) FOR M in ([1],[2],[3],[4],[5],[6],[7],[8], [9], [10], [11], [12])) as Piv
                         where Year in (@Year)
                         and organizationid = @OrganizationId";

          using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["weavver"].ConnectionString))
          {
               SqlCommand command = new SqlCommand(sql, connection);
               command.Parameters.AddWithValue("OrganizationId", LoggedInUser.OrganizationId);
               command.Parameters.AddWithValue("Year", Int32.Parse(YearFilter.Text));
               command.CommandTimeout = 90;
               connection.Open();
               SqlDataReader reader = command.ExecuteReader();
               Net.DataSource = reader;
               Net.DataBind();
               reader.Close();
          }
     }
//-------------------------------------------------------------------------------------------
     void ARList_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          Linkify(ARList, e, "Receivable");
     }
     decimal jan = 0;
//-------------------------------------------------------------------------------------------
     void APList_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          Linkify(APList, e, "Payable");
          if (e.Item.DataItem != null)
          {
               decimal res = 0;
               Decimal.TryParse(e.Item.Cells[1].Text.Replace("$", "").Replace("(", "").Replace(")", ""), out res);
               jan += res;
          }
          if (e.Item.ItemType == ListItemType.Footer)
          {
               e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#C6DEFF");
               e.Item.Cells[0].Text = "Total Expenses";
               e.Item.Cells[1].Text = String.Format("{0,10:C}", jan * -1);
          }
     }
//-------------------------------------------------------------------------------------------
     private void Linkify(DataGrid grid, DataGridItemEventArgs e, string ledgerType)
     {
          string code = e.Item.Cells[0].Text;
          for (int i = 0; i < e.Item.Cells.Count; i++)
          {
               if (e.Item.ItemType == ListItemType.Item ||
                   e.Item.ItemType == ListItemType.AlternatingItem)
               {
                    if (i >= DateTime.Now.Month &&
                        i < 13 &&
                        Int32.Parse(YearFilter.Text) >= DateTime.Now.Year &&
                        (e.Item.Cells[0].Text == "Sale" ||
                         e.Item.Cells[0].Text == "Purchase"))
                    {
                         decimal entered = 0.0m; // Decimal.Parse(e.Item.Cells[i].Text);
                         DbDataRecord rec = (DbDataRecord) e.Item.DataItem;
                         entered = (rec == null || rec[i].GetType() == typeof(DBNull)) ? entered : rec.GetDecimal(i);

                         //LedgerType ledger = (e.Item.Cells[0].Text == "Sale") ? LedgerType.Receivable : LedgerType.Payable;
                         //decimal projection = Accounting.ProjectedBillings(SelectedOrganization, ledger, i, Int32.Parse(YearFilter.Text));
                         //projection = (e.Item.Cells[0].Text == "Sale") ? projection : projection * -1;
                         decimal total = entered; // TODO +projection;
                         //e.Item.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#E3E4FA");
                         //e.Item.Cells[i].ToolTip = "Posted: " + entered.ToString("C") + "\r\n";
                         //e.Item.Cells[i].ToolTip += "Not-posted (ARB): " + projection.ToString("C") + "\r\n";
                         //e.Item.Cells[i].ToolTip += "Total: " + total.ToString("C");
                         e.Item.Cells[i].Text = total.ToString("C");
                    }

                    string text = e.Item.Cells[i].Text.Trim();
                    if (i > 0 && i < 13 && text != "" && text != "&nbsp;")
                    {
                         int month = GetMonthNum(grid.Columns[i].HeaderText);
                         int year = Int32.Parse(YearFilter.SelectedValue);
                         string startDate = month + "/01/" + year;
                         string endDate = month + "/" + DateTime.DaysInMonth(year, month) + "/" + year;
                         // int ledgerTypeNum = (int) (LedgerType) Enum.Parse(typeof(LedgerType), ledgerType);
                         string url = "~/Accounting_LedgerItems/List.aspx?LedgerType=" + ledgerType + "&PostAt_Start=" + startDate + "&PostAt_End=" + endDate + "&Code=" + code;
                         url = WeavverMaster.FormatURLs(url);
                         e.Item.Cells[i].Text = "<a href=\"javascript:createPopup('" + url + "')\">" + text + "</a>";
                    }
               }
          }
     }
//-------------------------------------------------------------------------------------------
     public int GetMonthNum(string month)
     {
          switch (month)
          {
               case "January": return 1;
               case "February": return 2;
               case "March": return 3;
               case "April": return 4;
               case "May": return 5;
               case "June": return 6;
               case "July": return 7;
               case "August": return 8;
               case "September": return 9;
               case "October": return 10;
               case "November": return 11;
               case "December": return 12;
               default: return 0;
          }
     }
//-------------------------------------------------------------------------------------------
}
