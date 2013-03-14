using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class NavigationButton : System.Web.UI.UserControl
{
//-------------------------------------------------------------------------------------------
     public string ButtonText
     {
          get
          {
               return lblButtonText.Text;
          }
          set
          {
               lblButtonText.Text = value;
          }
     }
//-------------------------------------------------------------------------------------------
     public string ButtonURL
     {
          get
          {
               return NavigationButtonLayer.Attributes["onclick"];
          }
          set
          {
               NavigationButtonLayer.Attributes["onclick"] = "location.href = '" + value + "'";
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
     }
//-------------------------------------------------------------------------------------------
}
