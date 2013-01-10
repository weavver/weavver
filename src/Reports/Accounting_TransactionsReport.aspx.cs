using System;
using org.pdfbox;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Weavver.Data;
using Weavver.Company.Accounting;

public partial class Company_Accounting_Transactions : SkeletonPage
{
     System.Collections.Specialized.NameValueCollection tagRules = new System.Collections.Specialized.NameValueCollection();
     public string transactionFolder = @"W:\Projects\Weavver\Main\Servers\web\c\Inetpub\www\Company\Accounting\Transactions\";
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          // if (accountype == checking then postive amounts are credits and negative are debits
          // if (accountype == credit then negative amounts are credits and postive amounts are debits
          //List.ItemDataBound += new DataGridItemEventHandler(List_ItemDataBound);

          WeavverMasterPage wMaster = (WeavverMasterPage)Master;
          wMaster.FixedWidth = false;
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          //Accounting.CreateTableStructures();

          //if (LoggedInUser.OrganizationId == new Guid ("0baae579-dbd8-488d-9e51-dd4dd6079e95"))
          //     transactionFolder = Path.Combine(transactionFolder, SelectedOrganization.Id.ToString());
          //else
          //     transactionFolder = Path.Combine(transactionFolder, LoggedInUser.OrganizationId.ToString());

          //if (!Directory.Exists(transactionFolder))
          //     Directory.CreateDirectory(transactionFolder);

          //if (!IsPostBack)
          //{
          //     LoadData();
          //     UpdatePage();
          //}
     }
//-------------------------------------------------------------------------------------------
     public void LoadData()
     {
          //foreach (string file in System.IO.Directory.GetFiles(transactionFolder))
          //{
          //     LoadTransactions(file);
          //}


          //ICriteria criteria = DatabaseHelper.Session.CreateCriteria(typeof(LedgerItem))
          //                    .Add(NHibernate.Criterion.Restrictions.Eq("OrganizationId", LoggedInUser.OrganizationId))
          //                    .Add(NHibernate.Criterion.Restrictions.Eq("AccountId", accountId))
          //                    .Add(NHibernate.Criterion.Restrictions.Eq("LedgerType", ledgerTypeFilter))
          //                    .AddOrder(NHibernate.Criterion.Order.Desc("PostAt"));
     }
//-------------------------------------------------------------------------------------------
     public void UpdatePage()
     {
          DateTime startDate = DateTime.MinValue;
          DateTime.TryParse(StartDate.Text, out startDate);
          DateTime endDate = DateTime.MaxValue;
          DateTime.TryParse(EndDate.Text, out endDate);
          //Output.Text = output;

//          transactions.DefaultView.RowFilter = "Date >= '" + startDate.ToString("MM-dd-yyyy") + "'";
////          taggedTransactions.DefaultView.RowFilter = "Date >= '" + DateTime.Parse(StartDate.Text).ToString("MM-dd-yyyy") + "'";

//          transactionRules.DefaultView.Sort = "Tag";
//          TagRulesList.DataSource = transactionRules;
//          TagRulesList.DataBind();

//          List.DataSource = transactions;
//          List.DataBind();

//          var byPayee = from row3 in Accounting.transactions.AsEnumerable()
//                        where ((DateTime)row3["Date"]) >= startDate && ((DateTime)row3["Date"]) <= endDate
//                        group row3 by new { Payee2 = (string)row3["Payee"] } into grp
//                        // group row3 by row3.Field<DateTime>("Date").ToString("yyyy/MM") + " " + row3.Field<string>("Tag") into grp
//                        orderby grp.Key.Payee2 ascending
//                        select new
//                        {
//                             //Payee = grp.Key.Payee,
//                             Payee = grp.Key.Payee2, //.Field<string>("Payee"),
//                             Sum = grp.Sum(r => r.Field<decimal>("Amount"))
//                        };
//          ByPayee.DataSource = byPayee;
//          ByPayee.DataBind();

//          Total.Text = transactions.Compute("SUM(Amount)", "").ToString();
//          Total.Text = transactions.Compute("SUM(Amount)", "Payee LIKE 'JOE%' or Payee LIKE 'SMARTNFINAL%'").ToString();


//          var byDay = from row2 in Accounting.transactions.AsEnumerable()
//                      where ((DateTime)row2["Date"]) >= startDate && ((DateTime)row2["Date"]) <= endDate
//                        group row2 by row2.Field<DateTime>("Date").ToString("MM/dd/yyyy") into grp
//                        orderby grp.Key descending
//                        select new
//                        {
//                             Date = grp.Key,
//                             //Tag = grp.Field<string>("Tag"),
//                             Sum = grp.Sum(r => r.Field<decimal>("Amount"))
//                        };
//          ExpensesByDay.DataSource = byDay;
//          ExpensesByDay.DataBind();

//          var byMonth = from row3 in Accounting.transactions.AsEnumerable()
//                      group row3 by row3.Field<DateTime>("Date").ToString("yyyy/MM") into grp
//                      orderby grp.Key descending
//                      select new
//                      {
//                           Key = grp.Key,
//                           //Tag = grp.Field<string>("Tag"),
//                           Sum = grp.Sum(r => r.Field<decimal>("Amount"))
//                      };
//          ExpensesByMonth.DataSource = byMonth;
//          ExpensesByMonth.DataBind();

//          DateTime yearGraphDate = DateTime.Now;
//          var x = Accounting.taggedTransactions.AsEnumerable()
//               .Where(r => ((DateTime)r["Date"]).Month >= 1 && ((DateTime)r["Date"]).Year == yearGraphDate.Year)
//               .GroupBy(r => r["Tag"])
//               .OrderBy(r => r.Key)
//               .Select(g => new {
//                    Tag = g.Key.ToString(),
//                    Jan = g.Where(r => ((DateTime)r["Date"]).Month == 1 && ((DateTime)r["Date"]).Year == yearGraphDate.Year).Sum(r => (decimal) r["Amount"]),
//                    Feb = g.Where(r => ((DateTime)r["Date"]).Month == 2 && ((DateTime)r["Date"]).Year == yearGraphDate.Year).Sum(r => (decimal)r["Amount"]),
//                    Mar = g.Where(r => ((DateTime)r["Date"]).Month == 3 && ((DateTime)r["Date"]).Year == yearGraphDate.Year).Sum(r => (decimal)r["Amount"]),
//                    Apr = g.Where(r => ((DateTime)r["Date"]).Month == 4 && ((DateTime)r["Date"]).Year == yearGraphDate.Year).Sum(r => (decimal)r["Amount"]),
//                    May = g.Where(r => ((DateTime)r["Date"]).Month == 5 && ((DateTime)r["Date"]).Year == yearGraphDate.Year).Sum(r => (decimal)r["Amount"]),
//                    Jun = g.Where(r => ((DateTime)r["Date"]).Month == 6 && ((DateTime)r["Date"]).Year == yearGraphDate.Year).Sum(r => (decimal)r["Amount"]),
//                    Jul = g.Where(r => ((DateTime)r["Date"]).Month == 7 && ((DateTime)r["Date"]).Year == yearGraphDate.Year).Sum(r => (decimal)r["Amount"]),
//                    Aug = g.Where(r => ((DateTime)r["Date"]).Month == 8 && ((DateTime)r["Date"]).Year == yearGraphDate.Year).Sum(r => (decimal)r["Amount"]),
//                    Sep = g.Where(r => ((DateTime)r["Date"]).Month == 9 && ((DateTime)r["Date"]).Year == yearGraphDate.Year).Sum(r => (decimal)r["Amount"]),
//                    Oct = g.Where(r => ((DateTime)r["Date"]).Month == 10 && ((DateTime)r["Date"]).Year == yearGraphDate.Year).Sum(r => (decimal)r["Amount"]),
//                    Nov = g.Where(r => ((DateTime)r["Date"]).Month == 11 && ((DateTime)r["Date"]).Year == yearGraphDate.Year).Sum(r => (decimal)r["Amount"]),
//                    Dec = g.Where(r => ((DateTime)r["Date"]).Month == 12 && ((DateTime)r["Date"]).Year == yearGraphDate.Year).Sum(r => (decimal)r["Amount"]),
//                    Totals = g.Sum(r => (decimal) r["Amount"])
//               });
//          TagsByMonthHorizontal.DataSource = x;
//          TagsByMonthHorizontal.DataBind();
     }
//-------------------------------------------------------------------------------------------
     protected void Apply_Click(object sender, EventArgs e)
     {
          LoadData();
          UpdatePage();
     }
//-------------------------------------------------------------------------------------------
     public void TagRuleAdd(string name, string val)
     {
          //DataRow row = Accounting.transactionRules.NewRow();
          //row[0] = name;
          //row[1] = val;
          //Accounting.transactionRules.Rows.Add(row);
     }
//-------------------------------------------------------------------------------------------
     void List_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
          {
               if (e.Item.Cells[3].Text != "0")
                    e.Item.ForeColor = System.Drawing.Color.Green;
               //for (int i = 0; i < List.Columns.Count; i++)
               //{
               //     if (List.Columns[i].HeaderText == "Tags" && e.Item.Cells[i].Text != "0")
               //     {
               //          e.Item.ForeColor = System.Drawing.Color.Green;
               //     }
               //}
          }
     }
//-------------------------------------------------------------------------------------------
}
