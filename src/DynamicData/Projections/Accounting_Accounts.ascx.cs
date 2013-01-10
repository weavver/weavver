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
               decimal receivableTotal = 0.0m;
               decimal payableTotal = 0.0m;
               var receivableLedgerItems = sumQuery.Where(x => x.LedgerType == receivableLedger);
               if (receivableLedgerItems.Count() > 0)
               {
                    receivableTotal = receivableLedgerItems.Sum(x => x.Balance);
               }
               ReceivableTotal.Text = String.Format("{0:C}", receivableTotal);

               string payableLedger = LedgerType.Payable.ToString();
               var payableLedgerItems = sumQuery.Where(x => x.LedgerType == payableLedger);
               if (payableLedgerItems.Count() > 0)
               {
                    payableTotal = payableLedgerItems.Sum(x => x.Balance);
               }
               PayableTotal.Text = String.Format("{0:C}", payableTotal);

               Net.Text = String.Format("{0:C}", receivableTotal - payableTotal);

               var sumQuery2 = (from accounts in data.Accounting_Accounts
                                       where accounts.OrganizationId == BasePage.SelectedOrganization.Id
                                       select accounts);

               var balance = sumQuery2.Sum(x => x.Balance);
               Balance.Text = String.Format("{0:C}", balance);

               var projectedBalance = sumQuery2.Sum(x => x.AvailableBalance);
               ProjectedBalance.Text = String.Format("{0:C}", projectedBalance);
          }
     }
}