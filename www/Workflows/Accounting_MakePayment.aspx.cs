using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Weavver.Data;

public partial class Company_Accounting_Payment : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = false;
          Master.FormTitle = "Account Payment";
          Master.FormDescription = "Use this tool to make payments or add funds to your account.";
          Master.FixedWidth = true;

          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               

          }

          if (!IsPostBack)
          {
               UpdatePage();
          }
     }
//-------------------------------------------------------------------------------------------
     public void UpdatePage()
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               decimal balance = data.Total_ForLedger(SelectedOrganization.Id, LoggedInUser.OrganizationId, LedgerType.Receivable.ToString(), true, true, false, null, null, true);

               // data.Total_ForLedger(LoggedInUser.OrganizationId);

               var cards = (from items in data.Accounting_CreditCards
                            where items.OrganizationId == SelectedOrganization.Id
                            select items);

               CreditCards.DataSource = cards;
               CreditCards.DataTextField = "CensoredAccountNumber";
               CreditCards.DataValueField = "Id";
               CreditCards.DataBind();

               if (balance < 0)
               {
                    decimal amount = balance * -1;
                    MinimumPaymentDue.Text = "$" + amount.ToString();
                    Balance.Text = "$" + amount.ToString();
                    PayBalanceAmount.Text = "$" + amount.ToString();
               }
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Payment_Click(object sender, EventArgs e)
     {
          string paymentAmountText = (PayBalance.Checked) ? PayBalanceAmount.Text : PayOtherAmount.Text;
          paymentAmountText = paymentAmountText.Replace("$", "");
          decimal paymentAmount = 0;
          if (Decimal.TryParse(paymentAmountText, out paymentAmount))
          {
               //paymentAmountText.ToString();
          }
          else
          {
               ShowError("Please enter a valid payment amount.");
          }
     }
//-------------------------------------------------------------------------------------------
}
