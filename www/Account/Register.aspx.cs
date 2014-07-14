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
          RequiresSelectedOrg = false;
          IsPublic = true;
          ActivationRequired = false;
          WeavverMaster.FormTitle = "Register for your Weavver Account";
          WeavverMaster.FixedWidth = false;
          WeavverMaster.Width = "100%";
          WeavverMaster.MaxWidth = "800px";
          WeavverMaster.SetToolbarVisibility(false);
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
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