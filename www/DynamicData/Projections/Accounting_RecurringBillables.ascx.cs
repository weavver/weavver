using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using Weavver.Data;

public partial class DynamicData_Projections_Accounting_RecurringBillables : WeavverUserControl
{
     protected void Page_Load(object sender, EventArgs e)
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               if (Request["id"] != null)
               {
                    Projection.Visible = true;

                    Guid itemId = new Guid(Request["Id"]);

                    var billable = (from x in data.Accounting_RecurringBillables
                                    where x.Id == itemId
                                    select x).FirstOrDefault();


                    if (billable != null)
                    {
                         var billables = billable.ProjectLedgerItems(billable.UnbilledPeriods.Value);
                         ProjectionList.ItemDataBound += new DataGridItemEventHandler(ProjectionList_ItemDataBound);
                         ProjectionList.DataSource = billables;
                         ProjectionList.DataBind();
                    }
               }
               else
               {
                    Totals.Visible = true;

                    var recurringRevenue = data.Accounting_RecurringBillables
                                             .Where(x => x.OrganizationId == BasePage.SelectedOrganization.Id)
                                             .Where(x => x.AccountTo == BasePage.SelectedOrganization.Id)
                                             .Sum(x=> (decimal?) x.Amount) ?? 0m;
                    
                    RecurringRevenue.Text = String.Format("{0,10:C}", recurringRevenue);

                    var recurringExpenses = data.Accounting_RecurringBillables
                                             .Where(x => x.OrganizationId == BasePage.SelectedOrganization.Id)
                                             .Where(x => x.AccountFrom == BasePage.SelectedOrganization.Id)
                                             .Sum(x=> (decimal?) x.Amount) ?? 0m;

                    RecurringExpenses.Text = String.Format("{0,10:C}", recurringExpenses);

                    Net.Text = String.Format("{0,10:C}", recurringRevenue - recurringExpenses);
               }
          }
    }

     void ProjectionList_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          string memo = e.Item.Cells[2].Text;
          memo = memo.Replace("\r\n", "<br />");
          memo = memo.Replace("\n", "<br />");
          e.Item.Cells[2].Text = memo;
     }
}