using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Weavver.Data;
using System.Web.Security;

public partial class DynamicData_QuickAdd_Accounting_Accounts_QuickTransfer : WeavverUserControl
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          Visible = false;
          return;

          if (!Roles.IsUserInRole("Administrators") ||
              !Roles.IsUserInRole("Accountants"))
          {
               Visible = false;
               return;
          }

          if (!IsPostBack)
          {
               PostAt.Text = DateTime.Now.ToString("MM/dd/yy");

               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    //Guid fromGuid = new Guid(FromAccount.SelectedValue);

                    var fAccounts = (from orgs in data.Accounting_Accounts
                                        where orgs.OrganizationId == BasePage.SelectedOrganization.Id
                                        orderby orgs.Name
                                        select orgs);

                    FromAccount.DataSource = fAccounts;
                    FromAccount.DataTextField = "Name";
                    FromAccount.DataValueField = "Id";
                    FromAccount.DataBind();

                    var cAccounts = (from accounts in data.Accounting_Accounts
                                     where accounts.OrganizationId == BasePage.SelectedOrganization.Id
                                        select accounts);

                    ToAccount.DataSource = cAccounts;
                    ToAccount.DataTextField = "Name";
                    ToAccount.DataValueField = "Id";
                    ToAccount.DataBind();
               }
          }
     }
//-------------------------------------------------------------------------------------------
     protected void TransferFunds_Click(object sender, EventArgs e)
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               DateTime postAtDate = DateTime.UtcNow;
               if (DateTime.TryParse(PostAt.Text, out postAtDate))
                    postAtDate = postAtDate.ToUniversalTime();

               Accounting_Accounts accountFrom = (from accounts in data.Accounting_Accounts
                                                  where accounts.Id == new Guid(FromAccount.SelectedValue)
                                                  select accounts).FirstOrDefault();

               Accounting_Accounts accountTo = (from toAccounts in data.Accounting_Accounts
                                                where toAccounts.Id == new Guid(ToAccount.SelectedValue)
                                                select toAccounts).FirstOrDefault();

               Guid transactionId = Guid.NewGuid();

               Accounting_LedgerItems debitAccount1 = new Accounting_LedgerItems();
               debitAccount1.OrganizationId = BasePage.SelectedOrganization.Id;
               debitAccount1.TransactionId = transactionId;
               debitAccount1.PostAt = postAtDate;
               debitAccount1.AccountId = accountFrom.Id;
               debitAccount1.LedgerType = accountFrom.LedgerType;
               debitAccount1.Code = CodeType.Withdrawal.ToString();
               debitAccount1.Memo = String.Format("Transfer to {0}", accountTo.Name);
               debitAccount1.Amount = Decimal.Parse(Amount.Text) * -1.0m;
               data.Accounting_LedgerItems.Add(debitAccount1);

               Accounting_LedgerItems creditAccount2 = new Accounting_LedgerItems();
               creditAccount2.OrganizationId = BasePage.SelectedOrganization.Id;
               creditAccount2.TransactionId = transactionId;
               creditAccount2.PostAt = postAtDate;
               creditAccount2.AccountId = new Guid(ToAccount.SelectedValue);
               creditAccount2.LedgerType = accountTo.LedgerType;
               creditAccount2.Code = CodeType.Deposit.ToString();
               creditAccount2.Memo = String.Format("Transfer from {0}", accountFrom.Name);
               creditAccount2.Amount = Decimal.Parse(Amount.Text);
               data.Accounting_LedgerItems.Add(creditAccount2);

               data.SaveChanges();
               // Response.Redirect("~/Accounting_LedgerItems/List.aspx?TransactionId=" + transactionId.ToString());
          }

          OnDataSaved(this, EventArgs.Empty);
     }
//-------------------------------------------------------------------------------------------
     public void LedgerItemCancel_Click(object sender, EventArgs e)
     {
          //LedgerItemCancel.Visible = false;
          //LedgerItemName.Text = "";
          //LedgerItemAmount.Text = "";
          //CodeTypeList.SelectedIndex = 0;
     }
//-------------------------------------------------------------------------------------------
}