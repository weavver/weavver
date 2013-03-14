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

[ValidationPropertyAttribute("Text")]
public partial class Controls_OrganizationTextField : WeavverUserControl
{
//--------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (!Page.IsClientScriptBlockRegistered("orgselected"))
          {
               string script = "<script type='text/javascript'>function Organization_Selected(source, eventArgs) { var elemName = source._id + 'Id'; var elem = document.getElementById(elemName); elem.value = eventArgs.get_value(); }</script>";
               Page.RegisterClientScriptBlock("orgselected", script); // .Replace("%0%", hfOrganizationId.ClientID)
          }
          OrganizationCompleter.ContextKey = BasePage.LoggedInUser.OrganizationId.ToString();
     }
//--------------------------------------------------------------------------------------------
     public Guid OrganizationId
     {
          get
          {
               try
               {
                    return new Guid(OrganizationCompleterId.Value);
               }
               catch { }
               return Guid.Empty;
          }
          set
          {
               OrganizationCompleterId.Value = value.ToString();
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
     public string Text
     {
          get
          {
               return Organization.Text;
          }
     }
//--------------------------------------------------------------------------------------------
}