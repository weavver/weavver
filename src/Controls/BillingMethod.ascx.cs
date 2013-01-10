using System;

using Weavver.Data;
using Weavver.Company.Accounting;

public partial class Controls_BillingMethod : WeavverUserControl
{
     public Accounting_CreditCards BillingMethodData;
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (!IsPostBack
               && Visible
               && BasePage != null
               && BasePage.LoggedInUser != null)
          {
               tbFirstName.Text = BasePage.LoggedInUser.FirstName;
               tbLastName.Text = BasePage.LoggedInUser.LastName;
               tbEmailAddress.Text = BasePage.LoggedInUser.EmailAddress;
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Back_Click(object sender, EventArgs e)
     {
          //PaymentOptions.Visible = true;
          //// PaymentNew.Visible = false;
     }
//-------------------------------------------------------------------------------------------
     protected void PayPal_Click(object sender, EventArgs e)
     {
          //PaymentOptions.Visible = false;
          //PaypalData.Visible = true;
          // PaymentNew.Visible = true;
     }
//-------------------------------------------------------------------------------------------
     public Accounting_CreditCards GetPaymentMethod(string DisplayName)
     {
          Accounting_CreditCards item = new Accounting_CreditCards();
          item.Id = Guid.NewGuid();
          //item.Name = DisplayName;
          //item.OrganizationId = BasePage.SelectedOrganization.Id;
          //item.Issuer = Issuer.Text;
          //item.NameFirst = tbFirstName.Text;
          //item.NameLast = tbLastName.Text;
          //item.CCNumber = CreditCard.Text;
          //item.SecurityCode = SecurityCode.Text;
          //item.ExpirationMonth = Int32.Parse(ExpirationMonth.SelectedValue);
          //item.ExpirationYear = Int32.Parse(ExpirationYear.SelectedValue);
          //item.CreatedAt = DateTime.UtcNow;
          //item.CreatedBy = BasePage.LoggedInUser.Id;
          //item.UpdatedAt = DateTime.UtcNow;
          //item.UpdatedBy = BasePage.LoggedInUser.Id;
          return item;
     }
//-------------------------------------------------------------------------------------------
}
