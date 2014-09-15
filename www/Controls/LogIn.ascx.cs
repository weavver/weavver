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
               using (Weavver.Data.WeavverEntityContainer data = new Weavver.Data.WeavverEntityContainer())
               {
                    ProfileCommon profile = Profile.GetProfile(Login1.UserName);
                    if (profile.DefaultAccount == null || profile.DefaultAccount == Guid.Empty)
                    {
                         var user = (from users in data.System_Users
                                     where users.Username == Login1.UserName
                                     select users).First();

                         profile.DefaultAccount = user.OrganizationId;
                         profile.Save();
                    }

                    var orgs = from x in data.Logistics_Organizations
                               where x.Id == profile.DefaultAccount
                               select x;

                    string y = orgs.First().VanityURL;

                    Response.Redirect("~/" + y + "/");
               }
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
     }
//-------------------------------------------------------------------------------------------
}