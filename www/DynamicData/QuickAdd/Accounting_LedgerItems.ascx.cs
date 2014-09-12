using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Weavver.Data;
using System.Web.Security;

public partial class DynamicData_QuickAdd_Accounting_LedgerItems : WeavverUserControl
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (!Roles.IsUserInRole("Administrators") ||
              !Roles.IsUserInRole("Administrators"))
          {
               Visible = false;
               return;
          }

          if (Request["AccountId"] == null)
          {
               Visible = false;
               //Response.Redirect("~/Accounting_Accounts/List.aspx");
               return;
          }

          if (!IsPostBack)
          {
               LedgerItemPostAt.Text = DateTime.Now.ToString("MM/dd/yy");

               //CodeTypeList.DataSource = Enum.GetNames(typeof(CodeType));
               //CodeTypeList.DataBind();

               if (Request["LedgerType"] == LedgerType.CreditCard.ToString()
                    || Request["LedgerType"] == LedgerType.Savings.ToString()
                    || Request["LedgerType"] == LedgerType.Checking.ToString()
                    || Request["LedgerType"] == LedgerType.Holding.ToString())
               {
                    CodeTypeList.Items.Add(CodeType.Deposit.ToString());
                    CodeTypeList.Items.Add(CodeType.Reserve.ToString());
                    CodeTypeList.Items.Add(CodeType.Withdrawal.ToString());
               }

               if (Request["LedgerType"] == LedgerType.Payable.ToString())
               {
                    CodeTypeList.Items.Add(CodeType.Comission.ToString());
                    CodeTypeList.Items.Add(CodeType.Payment.ToString());
                    CodeTypeList.Items.Add(CodeType.Purchase.ToString());
                    CodeTypeList.Items.Add(CodeType.Reserve.ToString());
                    CodeTypeList.Items.Add(CodeType.Royalty.ToString());
               }
               
               if (Request["LedgerType"] == LedgerType.Receivable.ToString())
               {
                    CodeTypeList.Items.Add(CodeType.Comission.ToString());
                    CodeTypeList.Items.Add(CodeType.Payment.ToString());
                    CodeTypeList.Items.Add(CodeType.Reserve.ToString());
                    CodeTypeList.Items.Add(CodeType.Royalty.ToString());
                    CodeTypeList.Items.Add(CodeType.Sale.ToString());
               }
          }
     }
//-------------------------------------------------------------------------------------------
     protected void LedgerItemAdd_Click(object sender, EventArgs e)
     {
          //List.ShowFooter = true;
          //List.EditItemIndex = List.Items.Count;
          LedgerType ledgerType = (LedgerType)Enum.Parse(typeof(LedgerType), Request["ledgertype"], true);

          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               Accounting_LedgerItems item = new Accounting_LedgerItems();
               item.Id = Guid.NewGuid();
               item.OrganizationId = BasePage.SelectedOrganization.Id;
               item.LedgerType = ledgerType.ToString();
               item.Code = ((CodeType)Enum.Parse(typeof(CodeType), CodeTypeList.SelectedValue, true)).ToString();
               item.PostAt = DateTime.Parse(LedgerItemPostAt.Text).ToUniversalTime();
               item.AccountId = new Guid(Request["AccountId"]);
               item.Memo = LedgerItemName.Text;
               item.Amount = Decimal.Parse(LedgerItemAmount.Text);

               data.Accounting_LedgerItems.Add(item);

               try
               {
                    data.SaveChanges();
                    ErrorMsg.Text = "";

                    OnDataSaved(this, EventArgs.Empty);
               }
               catch (IValidatorException ex)
               {
                    ErrorMsg.Text = ex.Message;
               }
          }
     }
//-------------------------------------------------------------------------------------------
     public void LedgerItemCancel_Click(object sender, EventArgs e)
     {
          LedgerItemCancel.Visible = false;
          LedgerItemName.Text = "";
          LedgerItemAmount.Text = "";
          CodeTypeList.SelectedIndex = 0;
     }
//-------------------------------------------------------------------------------------------
}