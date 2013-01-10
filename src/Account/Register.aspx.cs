using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Register : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          WeavverMaster.FormTitle = "Register for your Weavver Account";
          WeavverMaster.FixedWidth = true;
          WeavverMaster.SetToolbarVisibility(false);
          ActivationRequired = false;

          if (Request["checkingout"] == "true")
          {
               RegisterInfo.Visible = false;
               CheckOut.Visible = true;
          }
          else
          {
               RegisterControl regControl = (RegisterControl)RegisterUser;
               if (regControl != null)
               {
                    regControl.AccountActivated += new EventHandler(regControl_AccountActivated);
               }
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;
          MembershipUser mu = Membership.GetUser();
          if (HttpContext.Current.User.Identity.IsAuthenticated && LoggedInUser.Activated)
          {
               Response.Redirect("/account/");
               Response.End();
          }
     }
//-------------------------------------------------------------------------------------------
     void regControl_AccountActivated(object sender, EventArgs e)
     {
          Response.Redirect("~/", true);
     }
//-------------------------------------------------------------------------------------------
}