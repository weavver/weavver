using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weavver.Data;
using System.Data.SqlTypes;

public partial class DynamicData_Projections_Accounting_LedgerItems : WeavverUserControl
{
     protected void Page_Load(object sender, EventArgs e)
     {
          if (Request["LedgerType"] == null)
          {
               Visible = false;
               return;
          }

          TextBox dateStart = BasePage.FindControlR<TextBox>("txbDateFrom");
          TextBox dateEnd = BasePage.FindControlR<TextBox>("txbDateThrough");

          Guid accountId = Guid.Empty;
          Guid.TryParse(Request["AccountId"], out accountId);
          if (accountId != Guid.Empty)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    string ledgerType = Request["LedgerType"];
                    DateTime? startAt = null;
                    DateTime startAt2;
                    DateTime? endAt = null;
                    DateTime endAt2;

                    if (DateTime.TryParse(dateStart.Text, out startAt2))
                         startAt = startAt2.ToUniversalTime();

                    if (DateTime.TryParse(dateEnd.Text, out endAt2))
                         endAt = endAt2.ToUniversalTime();

                    string x = data.GetName(Guid.Empty);
                    decimal credits = data.Total_ForLedger(BasePage.SelectedOrganization.Id, accountId, ledgerType, true, false, false, null, null, true);
                    decimal debits = data.Total_ForLedger(BasePage.SelectedOrganization.Id, accountId, ledgerType, false, true, false, null, null, true);
                    decimal balance = data.Total_ForLedger(BasePage.SelectedOrganization.Id, accountId, ledgerType, true, true, false, null, null, true);
                    FundsIn.Text = String.Format("{0,10:C}", credits);
                    FundsOut.Text = String.Format("{0,10:C}", debits);
                    Balance.Text = String.Format("{0,10:C}", balance);

                    AvailableBalance.Text = String.Format("{0,10:C}", data.Total_ForLedger(BasePage.SelectedOrganization.OrganizationId, accountId, ledgerType, true, true, true, null, null, true));

                    if (startAt != null || endAt != null)
                    {
                         FilteredTotals.Visible = true;

                         decimal filteredStartingBalance = data.Total_ForLedger(BasePage.SelectedOrganization.Id, accountId, ledgerType, true, true, true, null, startAt, false);
                         decimal filteredCredits = data.Total_ForLedger(BasePage.SelectedOrganization.Id, accountId, ledgerType, true, false, true, startAt, endAt.Value, true);
                         decimal filteredDebits = data.Total_ForLedger(BasePage.SelectedOrganization.Id, accountId, ledgerType, false, true, true, startAt, endAt, true);
                         decimal filteredBalance = data.Total_ForLedger(BasePage.SelectedOrganization.Id, accountId, ledgerType, true, true, true, startAt, endAt, true);
                         decimal filteredEndingBalance = data.Total_ForLedger(BasePage.SelectedOrganization.Id, accountId, ledgerType, true, true, true, null, endAt, true);

                         VisibleStartingBalance.Text = String.Format("{0,10:C}", filteredStartingBalance);
                         VisibleCredits.Text = String.Format("{0,10:C}", filteredCredits);
                         VisibleDebits.Text = String.Format("{0,10:C}", filteredDebits);
                         VisibleBalance.Text = String.Format("{0,10:C}", filteredBalance);
                         VisibleEndingBalance.Text = String.Format("{0,10:C}", filteredEndingBalance);

                         VisibleAvailableBalance.Text = String.Format("{0,10:C}", data.Total_ForLedger(BasePage.SelectedOrganization.Id, accountId, ledgerType, true, true, true, startAt, endAt, true));
                    }
              }
         }
    }
}