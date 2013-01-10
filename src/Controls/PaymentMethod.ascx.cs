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

using Weavver.Company.Accounting;
using Weavver.Sys;
using Weavver.Data;

public partial class Controls_PaymentMethod : WeavverUserControl
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          //Issuer.SelectedIndexChanged += new EventHandler(Issuer_SelectedIndexChanged);
          if (BasePage.LoggedInUser != null)
               ExistingMethodRow.Visible = true;
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (!IsPostBack)
          {
               UpdatePage();
          }
     }
//-------------------------------------------------------------------------------------------
     public void UpdatePage()
     {
          if (BasePage.LoggedInUser != null)
          {
               //ExistingMethods.DataValueField = "Id";
               //ExistingMethods.DataTextField = "Name";
               //ExistingMethods.DataSource = BasePage.Accounting.PaymentMethods_ForOrganization(BasePage.LoggedInUser.OrganizationId);
               //ExistingMethods.DataBind();

               //if (ExistingMethods.Items.Count <= 1)
               //{
               //     ExistingMethodRow.Visible = false;
               //     // ChooseMethodLabel.Text = "Choose a payment method:";
               //}
          }
          ExistingMethodRow.Visible = false;
     }
//-------------------------------------------------------------------------------------------
     protected void Issuer_SelectedIndexChanged(object sender, EventArgs e)
     {
          //PaymentMethod item = BasePage.DatabaseHelper.Session.Get<PaymentMethod>(new Guid(ExistingMethods.SelectedValue));
          //if (item.OrganizationId == BasePage.LoggedInUser.OrganizationId)
          //{
          //     if (item.CCNumber.Length > 4)
          //     {
          //          CreditCard.Text = item.CCNumber.Substring(item.CCNumber.Length - 4, 4);
          //     }
          //}

          //CardData.Visible = (Issuer.SelectedValue != "paypal");
          //PaypalData.Visible = !CardData.Visible;
     }
//--------------------------------------------------------------------------------------------
     public TextBox CardNumber
     {
          get
          {
               return CreditCard;
          }
     }
//--------------------------------------------------------------------------------------------
     public TextBox SecCode
     {
          get
          {
               return SecurityCode;
          }
     }
//-------------------------------------------------------------------------------------------
     public DropDownList ExpMonth
     {
          get
          {
               return ExpirationMonth;
          }
     }
//-------------------------------------------------------------------------------------------
     public DropDownList ExpYear
     {
          get
          {
               return ExpirationYear;
          }
     }
//-------------------------------------------------------------------------------------------
}
