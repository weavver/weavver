using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nsoftware.InEBank;
using Weavver.Data;

public partial class Company_Accounting_BillPay : SkeletonPage
{
     Billpayment billPayment = new Billpayment();

     protected void Page_Load(object sender, EventArgs e)
     {
          ScheduledPayments.ItemDataBound += new DataGridItemEventHandler(ScheduledPayments_ItemDataBound);

          WeavverMaster.FormTitle = "OFX Bill Pay";
          Guid accountId = new Guid(Request["id"]);
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               Accounting_Accounts financialAccount = (from x in data.Accounting_Accounts
                                                       where x.Id == accountId
                                                       select x).FirstOrDefault();
               if (financialAccount.OrganizationId == LoggedInUser.OrganizationId)
               {
                    Accounting_OFXSettings ofxBank = financialAccount.GetOFXSettings();

                    Logistics_Addresses address = null;

                    billPayment.OFXAppId = "QWIN";
                    billPayment.OFXAppVersion = "1700";
                    billPayment.FIUrl = ofxBank.Url;
                    billPayment.FIId = ofxBank.FinancialInstitutionId.ToString();
                    billPayment.FIOrganization = ofxBank.FinancialInstitutionName;
                    billPayment.OFXUser = ofxBank.Username;
                    billPayment.OFXPassword = ofxBank.Password;

                    billPayment.Payment.FromBankId = ofxBank.BankId;
                    billPayment.Payment.FromAccountId = financialAccount.AccountNumber;
                    LedgerType lType = (LedgerType)Enum.Parse(typeof(LedgerType), financialAccount.LedgerType);
                    billPayment.Payment.FromAccountType = Accounting_OFXSettings.ConvertWeavverLedgerTypeToEbankingAccountType(lType);

                    billPayment.SynchronizePayments("REFRESH");
                    billPayment.SynchronizePayees("REFRESH"); // do these together so we can poll the info in ItemDataBound

                    var items = from x in billPayment.SyncPayments
                                orderby x.DateDue descending
                                select x;
                    ScheduledPayments.DataSource = items;
                    ScheduledPayments.DataBind();
                    Payees.DataSource = billPayment.SyncPayees;
                    Payees.DataBind();
               }
          }
    }

     void ScheduledPayments_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
          {
               PaymentDetail detail = (PaymentDetail) e.Item.DataItem;

               switch (detail.Status)
               {
                    case "PROCESSEDON":
                         e.Item.Cells[0].Text = "Mailed";
                         break;

                    case "CANCELEDON":
                         e.Item.Cells[0].Text = "Canceled";
                         break;

                    case "WILLPROCESSON":
                         e.Item.Cells[0].Text = "Pending";
                         break;
               }

               e.Item.Cells[1].Text = DateTime.Parse(detail.DateProcessed).ToString("MM/dd/yy");

               var payee = (from x in billPayment.SyncPayees
                            where x.ListId == detail.PayeeListId
                            select x).FirstOrDefault();

               if (payee != null)
                    e.Item.Cells[3].Text = payee.Name;

               string amount = e.Item.Cells[5].Text;
               decimal dAmount = 0m;
               Decimal.TryParse(amount, out dAmount);
               e.Item.Cells[5].Text = String.Format("{0:C}", dAmount);
          }
     }
}