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

public partial class Controls_LogIn : WeavverUserControl
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          Login1.LoggedIn += new EventHandler(Login1_LoggedIn);
          Login1.LoginError += new EventHandler(Login1_LoginError);
     }
//-------------------------------------------------------------------------------------------
     protected void Login1_LoggedIn(object sender, EventArgs e)
     {
          RedirectLoggedInUser();
     }
//-------------------------------------------------------------------------------------------
     private void RedirectLoggedInUser()
     {
          if (Request["redirecturl"] != null)
          {
               Response.Redirect(Request["RedirectURL"].ToString());
          }
          else
          {
               ProfileCommon profile = Profile.GetProfile(Login1.UserName);

               if (profile.DefaultAccount == null || profile.DefaultAccount == Guid.Empty)
                    profile.DefaultAccount = new Guid(ConfigurationManager.AppSettings["default_organizationid"]);

               using (Weavver.Data.WeavverEntityContainer data = new Weavver.Data.WeavverEntityContainer())
               {
                    var orgs = from x in data.Logistics_Organizations
                               where x.Id == profile.DefaultAccount
                               select x;

                    string y = orgs.First().VanityURL;

                    Response.Redirect("~/" + y + "/");
               }
                    //FormsAuthentication.RedirectFromLoginPage(LoggedInUser.Username, Login1.RememberMeSet);
          }
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