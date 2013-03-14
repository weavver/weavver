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

public partial class Controls_Log_In : WeavverUserControl
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          Login1.LoginError += new EventHandler(Login1_LoginError);
     }
//-------------------------------------------------------------------------------------------
     protected void Login1_LoggedIn(object sender, EventArgs e)
     {
          if (BasePage.LoggedInUser != null)
               FormsAuthentication.RedirectFromLoginPage(BasePage.LoggedInUser.Username, Login1.RememberMeSet);
     }
//-------------------------------------------------------------------------------------------
     public void Show()
     {
          LogInBox.Style["visibility"] = "visible";
     }
//-------------------------------------------------------------------------------------------
     void Login1_LoginError(object sender, EventArgs e)
     {
          //Login1.FindControl("ResetPass").Visible = true;
     }
//-------------------------------------------------------------------------------------------
}