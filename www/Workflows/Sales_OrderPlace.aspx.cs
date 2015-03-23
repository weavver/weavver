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
using System.Net.Mail;

using Weavver.Company.Accounting;
using Weavver.Sys;

using Weavver.Data;

public partial class Sales_Order_Place : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          // Register1.HideRegisterButtonRow();
          //if (LoggedInUser.Id != Guid.Empty)
          {
               //AccountInfo.Visible = false;
               //AccountInfoHeader.Visible = false;
          }

          Master.FixedWidth = true;
          Master.MaxWidth = "880px";
          WeavverMaster.SetToolbarVisibility(false);
          RequiresSSL = true;
          ActivationRequired = false;

          PrimaryContact.Title.Text = "Primary Contact";
          BillingContact.Title.Text = "Billing/Shipping Contact";

          if (ShoppingCart.Items.Count == 0)
          {
               ShowError("We could not find any items in your shopping cart. Please re-add them.");
               Response.Redirect("~/", true);
          }

          Deposit.Text = ShoppingCart.DepositTotal.ToString("C");
          Monthly.Text = ShoppingCart.MonthlyTotal.ToString("C");
          CartTotal.Text = ShoppingCart.Total.ToString("C");
          IsPublic = true;

          if (!IsPostBack)
          {
               UpdatePage();
          }
     }
//-------------------------------------------------------------------------------------------
     protected void ChkBillingTechnical_CheckedChanged(object sender, EventArgs e)
     {
          //if (ChkBillingTechnical.Checked == false)
          //{
          //     BillingNameFirst.Text = PrimaryFirstName.Text;
          //     BillingNameLast.Text = PrimaryLastName.Text;
          //     BillingAddressLine1.Text = PrimaryAddressLine1.Text;
          //     BillingAddressLine2.Text = PrimaryAddressLine2.Text;
          //     BillingZipCode.Text = PrimaryZipCode.Text;
          //}
          //BillingContactPanel.Visible = !ChkBillingTechnical.Checked;
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;
     }
//-------------------------------------------------------------------------------------------
     protected void UpdatePage()
     {
          CustomerInfo.Visible = true;
          btnOrder.Enabled = true;
          Message.Visible = false;
          if (ShoppingCart.Items.Count == 0)
          {
               Message.Visible = true;
               CustomerInfo.Visible = false;
               btnOrder.Enabled = false;
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Order_Click(object sender, EventArgs e)
     {
          if (Page.IsValid)
          {
               PlaceOrder();
          }
     }
//-------------------------------------------------------------------------------------------
     private void PlaceOrder()
     {
          if (Page.IsValid)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    Communication_MessageTemplates orderPlacedTemplate = (from x in data.Communication_MessageTemplates
                                                                   where x.Id == new Guid("f6df7db7-5efb-475d-8e32-3dd7e293ce3b")
                                                                   select x).First();
                    string msgBody = orderPlacedTemplate.Body.Replace("{cart}", ShoppingCart.ToString());
                    string placedat = DateTime.Now.ToString("MM/dd/yy"); // (ShoppingCart.CreatedAt.HasValue) ? ShoppingCart.CreatedAt.Value.ToString("MM/dd/yy") : "unknown";
                    string orderee = PrimaryContact.FirstName.Text + " " + PrimaryContact.LastName.Text;
                    string mPrimaryAddress = PrimaryContact.AddressLine1.Text + "\r\n" + PrimaryContact.AddressLine2.Text;
                    string mBillingAddress = BillingContact.AddressLine1.Text + "\r\n" + BillingContact.AddressLine2.Text;
                    msgBody = msgBody.Replace("{name}", orderee);
                    msgBody = msgBody.Replace("{placed}", placedat);
                    string primarycontact = "Name: " + orderee + "\r\n";
                    primarycontact += "Organization: " + PrimaryContact.Organization.Text + "\r\n";
                    primarycontact += "Address: " + mPrimaryAddress.Trim() + "\r\n";
                    primarycontact += "Zip Code: " + PrimaryContact.ZipCode.Text;
                    msgBody = msgBody.Replace("{primary_contact}", primarycontact.Trim());
                    string billingcontact = "Name: " + BillingContact.FirstName.Text + " " + BillingContact.LastName.Text + "\r\n";
                    billingcontact += "Organization: " + BillingContact.Organization.Text + "\r\n";
                    billingcontact += "Address: " + mBillingAddress.Trim() + "\r\n";
                    billingcontact += "Zip Code: " + BillingContact.ZipCode.Text;
                    msgBody = msgBody.Replace("{billing_contact}", billingcontact.Trim());

                    Logistics_Addresses primaryAddress = new Logistics_Addresses();
                    primaryAddress.OrganizationId = SelectedOrganization.Id;
                    primaryAddress.Id = Guid.NewGuid();
                    primaryAddress.Name = "Primary Address";
                    primaryAddress.Line1 = PrimaryContact.AddressLine1.Text;
                    primaryAddress.Line2 = PrimaryContact.AddressLine2.Text;
                    primaryAddress.City = "";
                    primaryAddress.State = "";
                    primaryAddress.ZipCode = PrimaryContact.ZipCode.Text;
                    data.Logistics_Addresses.Add(primaryAddress);

                    //   DatabaseHelper.Link(newOrder, primaryAddress);
                    // newOrder.PrimaryAddress = primaryAddress;

                    Logistics_Addresses billingAddress = new Logistics_Addresses();
                    billingAddress.OrganizationId = SelectedOrganization.Id;
                    billingAddress.Id = Guid.NewGuid();
                    billingAddress.Name = "Billing Address";
                    billingAddress.Line1 = BillingContact.AddressLine1.Text;
                    billingAddress.Line2 = BillingContact.AddressLine2.Text;
                    billingAddress.City = "";
                    billingAddress.State = "";
                    billingAddress.ZipCode = BillingContact.ZipCode.Text;
                    data.Logistics_Addresses.Add(billingAddress);

                    //   DatabaseHelper.Link(newOrder, billingAddress);
                    //   newOrder.BillingAddress = billingAddress;

                    Sales_Orders newOrder = new Sales_Orders();
                    newOrder.Id = Guid.NewGuid();
                    newOrder.OrganizationId = SelectedOrganization.Id;
                    if (LoggedInUser != null)
                         newOrder.Orderee = LoggedInUser.OrganizationId;
                    newOrder.Cart = msgBody;
                    newOrder.Status = "Placed";
                    newOrder.Total = ShoppingCart.Total;
                    newOrder.PrimaryContactEmail = PrimaryContact.EmailAddress.Text;
                    newOrder.PrimaryContactNameFirst = PrimaryContact.FirstName.Text;
                    newOrder.PrimaryContactNameLast = PrimaryContact.LastName.Text;
                    newOrder.PrimaryContactOrganization = PrimaryContact.Organization.Text;
                    newOrder.PrimaryContactPhoneNum = PrimaryContact.PhoneNumber.Text;
                    newOrder.PrimaryContactPhoneExt = PrimaryContact.PhoneExtension.Text;
                    newOrder.PrimaryContactAddress = primaryAddress.Id;
                    newOrder.BillingContactEmail = BillingContact.EmailAddress.Text;
                    newOrder.BillingContactNameFirst = BillingContact.FirstName.Text;
                    newOrder.BillingContactNameLast = BillingContact.LastName.Text;
                    newOrder.BillingContactOrganization = BillingContact.Organization.Text;
                    newOrder.BillingContactPhoneNum = BillingContact.PhoneNumber.Text;
                    newOrder.BillingContactPhoneExt = BillingContact.PhoneExtension.Text;
                    newOrder.BillingContactAddress = billingAddress.Id;
                    newOrder.Notes = SpecialInstructions.Text;
                    data.Sales_Orders.Add(newOrder);

                    Accounting_CreditCards card = new Accounting_CreditCards();
                    card.Id = Guid.NewGuid();
                    card.OrganizationId = SelectedOrganization.Id;
                    card.Number = PaymentMethod1.CardNumber.Text;
                    card.SecurityCode = PaymentMethod1.SecCode.Text;
                    card.ExpirationMonth = Int32.Parse(PaymentMethod1.ExpMonth.SelectedValue);
                    card.ExpirationYear = Int32.Parse(PaymentMethod1.ExpYear.SelectedValue);
                    data.Accounting_CreditCards.Add(card);
                 //   DatabaseHelper.Link(newOrder, card);

                    foreach (Sales_ShoppingCartItems item in ShoppingCart.Items)
                    {
                         item.SessionId = null;
                         item.OrderId = newOrder.Id;
                         data.Sales_ShoppingCartItems.Attach(item);

                         if (item.Monthly > 0m && item.Quantity > 0)
                         {
                              // Set up the ARB process
                              Accounting_RecurringBillables rBillable = new Accounting_RecurringBillables();
                              rBillable.Id = Guid.NewGuid();
                              rBillable.OrganizationId = SelectedOrganization.Id;
                              rBillable.Service = item.Id;
                              rBillable.BillingDirection = "Pre-Bill";
                              rBillable.BillingPeriod = BillingPeriodType.Monthly.ToString();
                              rBillable.Memo = item.Name + ", %timespan%\r\n" + item.Notes;
                              rBillable.StartAt = DateTime.UtcNow;
                              rBillable.Status = RecurringBillableStatus.Enabled.ToString();
                              rBillable.Position = DateTime.UtcNow.AddMonths(1);
                              rBillable.AccountFrom = LoggedInUser.OrganizationId;
                              rBillable.AccountTo = SelectedOrganization.Id;
                              rBillable.Amount = item.Monthly;
                              data.Accounting_RecurringBillables.Add(rBillable);
                              //DatabaseHelper.Link(newOrder, rBillable);
                         }
                         for (int i = 0; i < item.Quantity; i++)
                         {
                              // Insert the initial ledger items
                              Accounting_LedgerItems ledgerItemDebit = new Accounting_LedgerItems();
                              ledgerItemDebit.OrganizationId = SelectedOrganization.Id;
                              ledgerItemDebit.Id = Guid.NewGuid();
                              ledgerItemDebit.TransactionId = newOrder.Id;
                              ledgerItemDebit.PostAt = DateTime.UtcNow;
                              ledgerItemDebit.AccountId = newOrder.Id;
                              ledgerItemDebit.LedgerType = LedgerType.Receivable.ToString();
                              ledgerItemDebit.Code = CodeType.Sale.ToString();
                              ledgerItemDebit.Memo = item.Name + "\r\n" + item.Notes;
                              ledgerItemDebit.Amount = Math.Abs(item.UnitCost) * -1.0m;
                              data.Accounting_LedgerItems.Add(ledgerItemDebit);

                              // It is unnecessary to link these since we provide a link to the Receivable ledger.
                              //// DatabaseHelper.Link(newOrder, ledgerItemDebit);
                         }
                    }

                    AuthorizeNet.IGatewayResponse resp = card.Bill(data, newOrder, primaryAddress, billingAddress);
                    if (resp.Approved)
                    {
                         // Accounting.ProcessCommision(newOrder, SelectedOrganization.ReferredBy);

                         if (LoggedInUser != null && !LoggedInUser.Activated)
                         {
                              data.System_Users.Attach(LoggedInUser);
                              LoggedInUser.Activated = true;
                         }
                         data.SaveChanges();
                         ShoppingCart.Items.Clear();

                         // Send receipt
                         MailMessage msg = new MailMessage("Weavver Sales <sales@weavver.com>", PrimaryContact.EmailAddress.Text);
                         msg.Subject = orderPlacedTemplate.Subject;
                         msg.Body = msgBody;
                         SmtpClient sClient = new SmtpClient(ConfigurationManager.AppSettings["smtp_server"]);
                         try
                         {
                              sClient.Send(msg);
                              
                              var type = typeof(IOrderEvents);
                              var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
                                   .Where(y => y.FullName.Contains("WeavverExtension"))
                                   .SelectMany(s => s.GetTypes())
                                   .Where(p => type.IsAssignableFrom(p) && p.IsClass);

                              foreach (var interfacedClassType in types)
                              {
                                   foreach (Sales_ShoppingCartItems purchasedItem in ShoppingCart.Items)
                                   {
                                        if (purchasedItem.Quantity > 0)
                                        {
                                             object o = Activator.CreateInstance(interfacedClassType);
                                             var orderEvents = o as IOrderEvents;
                                             orderEvents.Provision(newOrder, purchasedItem);
                                        }
                                   }
                              }
                         }
                         catch (Exception ex)
                         {
                              Weavver.Utilities.ErrorHandling.LogError(Request, "/workflows/sales_orderplace", ex);
                              ShowError("Your order was placed but a receipt could not be sent due to a system error. Please contact customer service for further assistance.");
                              return;
                         }

                         Response.Redirect("~/CMS_Pages/Details.aspx?id=071c0768-84ed-4770-9519-a98806a87c68&OrderId=" + newOrder.Id.ToString());
                    }
                    else
                    {
                         ShowError("Your card did not go through because '" + resp.Message + "'. Please check the card number and try again.");
                         return;
                    }
               }
          }
     }
//-------------------------------------------------------------------------------------------
}