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

public partial class Account_Activate : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          RegisterUser.AccountActivated += new EventHandler(RegisterUser_AccountActivated);

          IsPublic = false;
          Master.FormTitle = "Account Activation";
          Master.FixedWidth = true;
          ActivationRequired = false;
          Master.SetToolbarVisibility(false);
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {

     }
//-------------------------------------------------------------------------------------------
     void RegisterUser_AccountActivated(object sender, EventArgs e)
     {
          ShowError("Your account has been activated.");
          Response.Redirect("~/account/");
     }
//-------------------------------------------------------------------------------------------
}