using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Weavver.Data;

public partial class Workflows_Accounting_EnterPayment : SkeletonPage
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
     protected void Page_Load(object sender, EventArgs e)
     {
          WeavverMaster.FormTitle = "Quick Payment Entry";

          if (!Roles.IsUserInRole("Accountants"))
               Response.Redirect("~/", true);

          if (!IsPostBack)
          {
               UpdatePage();
          }
     }
//-------------------------------------------------------------------------------------------
     private void UpdatePage()
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               //Guid fromGuid = new Guid(FromAccount.SelectedValue);

               var fAccounts = (from orgs in data.Logistics_Organizations
                               where orgs.OrganizationId == SelectedOrganization.Id
                               orderby orgs.Name
                               select orgs);

               FromAccount.DataSource = fAccounts;
               FromAccount.DataTextField = "Name";
               FromAccount.DataValueField = "Id";
               FromAccount.DataBind();

               var cAccounts = (from accounts in data.Accounting_Accounts
                               where accounts.OrganizationId == SelectedOrganization.Id
                               select accounts);

               ToAccount.DataSource = cAccounts;
               ToAccount.DataTextField = "Name";
               ToAccount.DataValueField = "Id";
               ToAccount.DataBind();
          }
     }
//-------------------------------------------------------------------------------------------
     protected void MakePayment_Click(object sender, EventArgs e)
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               DateTime postAtDate = DateTime.UtcNow;
               if (DateTime.TryParse(PostAt.Text, out postAtDate))
                    postAtDate = postAtDate.ToUniversalTime();

               Logistics_Organizations accountFrom = (from accounts in data.Logistics_Organizations
                                                      where accounts.Id == new Guid(FromAccount.SelectedValue)
                                                      select accounts).FirstOrDefault();

               Accounting_Accounts accountTo = (from toAccounts in data.Accounting_Accounts
                                                where toAccounts.Id == new Guid(ToAccount.SelectedValue)
                                                select toAccounts).FirstOrDefault();

               Guid transactionId = Guid.NewGuid();

               Accounting_LedgerItems creditFinancialAccount = new Accounting_LedgerItems();
               creditFinancialAccount.OrganizationId = SelectedOrganization.Id;
               creditFinancialAccount.TransactionId = transactionId;
               creditFinancialAccount.PostAt = postAtDate;
               creditFinancialAccount.AccountId = accountFrom.Id;
               creditFinancialAccount.LedgerType = LedgerType.Receivable.ToString();
               creditFinancialAccount.Code = CodeType.Deposit.ToString();
               creditFinancialAccount.Memo = String.Format("Check {0} to {1}", CheckNum.Text, accountTo.Name);
               creditFinancialAccount.Amount = Decimal.Parse(Amount.Text);
               data.Accounting_LedgerItems.Add(creditFinancialAccount);

               Accounting_LedgerItems creditReceivableAccount = new Accounting_LedgerItems();
               creditReceivableAccount.OrganizationId = SelectedOrganization.Id;
               creditReceivableAccount.TransactionId = transactionId;
               creditReceivableAccount.PostAt = postAtDate;
               creditReceivableAccount.LedgerType = accountTo.LedgerType;
               creditReceivableAccount.AccountId = new Guid(ToAccount.SelectedValue);
               creditReceivableAccount.Code = CodeType.Payment.ToString();
               creditReceivableAccount.Memo = String.Format("Check {0} from {1}", CheckNum.Text, accountFrom.Name);
               creditReceivableAccount.Amount = Decimal.Parse(Amount.Text);
               data.Accounting_LedgerItems.Add(creditReceivableAccount);

               data.SaveChanges();

               Response.Redirect("~/Accounting_LedgerItems/List.aspx?TransactionId=" + transactionId.ToString());
          }
     }
//-------------------------------------------------------------------------------------------
}