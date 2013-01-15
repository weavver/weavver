using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using Weavver.Sys;

public partial class Account_LogIn : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          IsPublic = true;

          Master.FixedWidth = true;
          Master.SetToolbarVisibility(false);

          if (LoggedInUser != null)
          {
               Response.Redirect("~/account/");
          }

          //AuthenticationProvider item = DatabaseHelper.Session.CreateCriteria(typeof(AuthenticationProvider))
          //              .Add(NHibernate.Criterion.Restrictions.Eq("Url", Request.Url.Host.ToLower()))
          //              .SetCacheable(true)
          //              .UniqueResult<AuthenticationProvider>();

          //if (item != null)
          //{
          //     Login1.MembershipProvider = item.AuthenticationType;
          //     Session["Provider"] = item.AuthenticationType;
          //}
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (Request["action"] != null && Request["action"] == "reset" && !IsPostBack)
          {
               ForgotPass_Click(null, EventArgs.Empty);
          }
     }
//-------------------------------------------------------------------------------------------
     protected void SignIn_Click(object sender, EventArgs e)
     {
          MultiView1.SetActiveView(LogInView);
          Toggle.Visible = true;
     }
//-------------------------------------------------------------------------------------------
     protected void Login1_LoggedIn(object sender, EventArgs e)
     {
          if (LoggedInUser != null)
          {
               FormsAuthentication.RedirectFromLoginPage(LoggedInUser.Username, Login1.RememberMeSet);
          }
     }
//-------------------------------------------------------------------------------------------
     protected void ForgotPass_Click(object sender, EventArgs e)
     {
          if (Toggle.Text == "sign in")
          {
               MultiView1.SetActiveView(LogInView);
               Toggle.Text = "reset your password";
          }
          else
          {
               MultiView1.SetActiveView(ForgotPassView);
               Toggle.Text = "sign in";
          }
     }
//-------------------------------------------------------------------------------------------
}