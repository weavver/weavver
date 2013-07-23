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

public partial class System_Debug : SkeletonPage
{
     protected void Page_Load(object sender, EventArgs e)
     {
          //Roles.ApplicationName = "Weavver";
          IsPublic = true;
          Master.FormTitle = "Debug";
          Master.Width = "100%";
          Master.MaxWidth = "800px";
          SelectedOrgId.Text = SelectedOrganization.Id.ToString();
          OrgName.Text = SelectedOrganization.Name;

          if (LoggedInUser != null)
          {
               SelectedUserId.Text = LoggedInUser.Id.ToString();
               SelectedUserOrganizationId.Text = LoggedInUser.OrganizationId.ToString();
          }

          MembershipUser user = Membership.GetUser();
          if (user != null)
          {
               Username.Text = user.UserName; // Membership.Provider.GetType().ToString();
               Provider.Text = Membership.Provider.Name;
          }
          InRoles.Text = String.Join(", ", Roles.GetRolesForUser());

          //Roles.CreateRole("Administrators");
          //Roles.CreateRole("User");
          //Roles.AddUserToRole("fatcat", "Administrators");
          //Roles.AddUserToRole("fatcat", "User");
          //Roles.RemoveUserFromRole("fatcat", "Accountants");
          //Roles.RemoveUserFromRole("fatcat", "Administrators");

          AuthenticationType.Text = HttpContext.Current.User.Identity.AuthenticationType;
          HttpIdentity.Text = HttpContext.Current.User.Identity.Name;

          RoleApplicationName.Text = Roles.ApplicationName;
     }
}