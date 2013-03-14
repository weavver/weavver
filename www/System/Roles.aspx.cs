using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;

public partial class System_Roles : SkeletonPage
{
//-------------------------------------------------------------------------------------------
    protected void Page_Load(object sender, EventArgs e)
    {
         RolesList.SelectedIndexChanged += new EventHandler(RolesList_SelectedIndexChanged);

         Master.FormTitle = "Role Management";

         if (!Roles.RoleExists("Administrators"))
              Roles.CreateRole("Administrators");
         
         string adminuser = ConfigurationManager.AppSettings["administrator"];
         if (!String.IsNullOrEmpty(adminuser) &&
             !Roles.IsUserInRole(adminuser, "Administrators"))
              Roles.AddUserToRole(adminuser, "Administrators");

         if (!Roles.IsUserInRole("Administrators"))
              Response.Redirect("~/", true);
              
         if (!IsPostBack)
         {
              UpdatePage();
         }
    }
//-------------------------------------------------------------------------------------------
    private void UpdatePage()
    {
         RolesList.DataSource = Roles.GetAllRoles();
         RolesList.DataBind();
    }
//-------------------------------------------------------------------------------------------
    void RolesList_SelectedIndexChanged(object sender, EventArgs e)
    {
         //if (RolesList.SelectedItem == null)
         {
              // RolesList.SelectedItem.Text
              UserList.DataSource = Roles.GetUsersInRole(RolesList.SelectedItem.Text);
              UserList.DataBind();
         }
    }
//-------------------------------------------------------------------------------------------
    protected void AddRole_Click(object sender, EventArgs e)
    {
         if (!Roles.RoleExists(RoleName.Text))
               Roles.CreateRole(RoleName.Text);
    }
//-------------------------------------------------------------------------------------------
    protected void AddUserToRole_Click(object sender, EventArgs e)
    {
         Roles.AddUserToRole(Username.Text, RolesList.SelectedItem.Text);

         UpdatePage();
    }
//-------------------------------------------------------------------------------------------
    protected void RemoveRole_Click(object sender, EventArgs e)
    {
         Roles.DeleteRole(RolesList.SelectedItem.Text, false);

         UpdatePage();
    }
//-------------------------------------------------------------------------------------------
    protected void RemoveUserFromRole_Click(object sender, EventArgs e)
    {
         Roles.RemoveUserFromRole(UserList.SelectedItem.Text, RolesList.SelectedItem.Text);

         UpdatePage();
    }
//-------------------------------------------------------------------------------------------
}