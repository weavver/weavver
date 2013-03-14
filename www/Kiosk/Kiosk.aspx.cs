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

using Weavver.Data;

public partial class Company_Human_Resources_Kiosk : SkeletonPage
{
     private string stepone = "Please type in your <b>account code</b>:";
     private string steptwo = "Please type in your <b>passcode:</b>";
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;
          if (!IsPostBack)
          {
               ResetForm();
          }
          Logo.Src = GetLogoPath();
          OrgName.Text = SelectedOrganization.Name;
     }
//-------------------------------------------------------------------------------------------
     protected void Next_Click(object sender, EventArgs e)
     {
          if (Entry.Text == "")
          {
               Directions.ForeColor = System.Drawing.Color.Red;
               return;
          }
          if (Directions.Text.EndsWith(steptwo))
          {
               string userCode = Session["UserCode"].ToString();
               string passcode = Entry.Text;

               WeavverEntityContainer data = new WeavverEntityContainer();
               var user = (from x in data.System_Users
                           where x.OrganizationId == SelectedOrganization.Id &&
                              x.UserCode == userCode &&
                              x.PassCode == passcode
                           select x
                           ).FirstOrDefault();
                
               if (user != null)
               {
                    //FormsAuthentication.SetAuthCookie(user.Username, true);
                    Response.Redirect("~/kiosk/kiosk2");

                    Directions.Text = "Invalid password, please start again.";
               }
               else
               {
                    ResetForm();
                    Directions.Text = "Your usercode or passcode was incorrect. Please try again.";
                    return;
               }
          }
          PhoneNumber.Style.Add("font-size", "14pt");
          PhoneNumber.Style.Add("font-weight", "bold");
          PhoneNumber.Text = Entry.Text;
          Directions.Text  = steptwo;
          Session["UserCode"] = Entry.Text;
          Directions.ForeColor = System.Drawing.Color.Black;
          Entry.Text = "";
          Entry.TextMode = TextBoxMode.Password;
          Next.Text = "Log In";
     }
//-------------------------------------------------------------------------------------------
     public bool LogIn_byPhoneNumber(string phonenumber, string passcode)
     {
          //Weavver.Sys.User item = DatabaseHelper.Session.CreateCriteria(typeof(Weavver.Sys.User))
          //    .Add(NHibernate.Criterion.Restrictions.Eq("PhoneNumber", phonenumber))
          //    .Add(NHibernate.Criterion.Restrictions.Eq("PassCode", passcode))
          //    .SetCacheable(true)
          //    .UniqueResult<Weavver.Sys.User>();

          //if (item == null)
          //     return false;

          //item.Password = newPassword;
          //item.Commit();

          return false;
     }
//-------------------------------------------------------------------------------------------
     public bool LogIn_byPhoneNumber(string phonenumber, string passcode, out System_User user)
     {
          //Weavver.Sys.User item = DatabaseHelper.Session.CreateCriteria(typeof(Weavver.Sys.User))
          //    .Add(NHibernate.Criterion.Restrictions.Eq("PhoneNumber", phonenumber))
          //    .Add(NHibernate.Criterion.Restrictions.Eq("PassCode", passcode))
          //    .SetCacheable(true)
          //    .UniqueResult<Weavver.Sys.User>();

               ////if (item == null)
               ////     return false;

               ////item.Password = newPassword;
               ////item.Commit();
          //user = item;
          user = null;
          return false;
     }
//-------------------------------------------------------------------------------------------
     protected void Reset_Click(object sender, EventArgs e)
     {
          ResetForm();
     }
//-------------------------------------------------------------------------------------------
     private void ResetForm()
     {
          PhoneNumber.Text = "";
          Entry.Text = "";
          Entry.TextMode = TextBoxMode.SingleLine;
          Directions.Text = stepone;
          Directions.ForeColor = System.Drawing.Color.Black;
          Session.Clear();
     }
//-------------------------------------------------------------------------------------------
}