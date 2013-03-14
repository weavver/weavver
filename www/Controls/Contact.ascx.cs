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

public partial class Controls_Contact : WeavverUserControl
{
//--------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (!IsPostBack
               && Visible
               && BasePage != null
               && BasePage.LoggedInUser != null)
          {
               FirstName.Text = BasePage.LoggedInUser.FirstName;
               LastName.Text = BasePage.LoggedInUser.LastName;
               EmailAddress.Text = BasePage.LoggedInUser.EmailAddress;
          }
     }
//--------------------------------------------------------------------------------------------
     public Literal Title
     {
          get
          {
               return lTitle;
          }
     }
//--------------------------------------------------------------------------------------------
     public TextBox FirstName
     {
          get
          {
               return tbFirstName;
          }
     }
//--------------------------------------------------------------------------------------------
     public TextBox LastName
     {
          get
          {
               return tbLastName;
          }
     }
//--------------------------------------------------------------------------------------------
     public TextBox Organization
     {
          get
          {
               return tbOrganization;
          }
     }
//--------------------------------------------------------------------------------------------
     public TextBox EmailAddress
     {
          get
          {
               return tbEmailAddress;
          }
     }
//--------------------------------------------------------------------------------------------
     public TextBox AddressLine1
     {
          get
          {
               return tbAddressLine1;
          }
     }
//--------------------------------------------------------------------------------------------
     public TextBox AddressLine2
     {
          get
          {
               return tbAddressLine2;
          }
     }
//--------------------------------------------------------------------------------------------
     public TextBox ZipCode
     {
          get
          {
               return tbZipCode;
          }
     }
//--------------------------------------------------------------------------------------------
     public TextBox PhoneNumber
     {
          get
          {
               return tbPhoneNumber;
          }
     }
//--------------------------------------------------------------------------------------------
     public TextBox PhoneExtension
     {
          get
          {
               return tbPhoneExtension;
          }
     }
//--------------------------------------------------------------------------------------------
}