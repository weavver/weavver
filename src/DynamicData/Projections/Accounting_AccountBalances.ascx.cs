using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Weavver.Data;

public partial class DynamicData_Projections_Accounting_Accounts : WeavverUserControl
{
     protected void Page_Load(object sender, EventArgs e)
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               var sumQuery = (from balances in data.Accounting_AccountBalances
                               where balances.OrganizationId == BasePage.SelectedOrganization.Id
                               select balances);

               string receivableLedger = LedgerType.Receivable.ToString();
               var receivableTotal = sumQuery.Where(x => x.LedgerType == receivableLedger).Sum(x => x.Balance);
               receivableTotal = (receivableTotal == null) ? 0m : receivableTotal;
               ReceivableTotal.Text = String.Format("{0:C}", receivableTotal);

               string payableLedger = LedgerType.Payable.ToString();
               var payableTotal = sumQuery.Where(x => x.LedgerType == payableLedger).Sum(x => x.Balance);
               payableTotal = (payableTotal == null) ? 0m : payableTotal;
               PayableTotal.Text = String.Format("{0:C}", payableTotal);

               Net.Text = String.Format("{0:C}", receivableTotal - payableTotal);
          }
     }
}