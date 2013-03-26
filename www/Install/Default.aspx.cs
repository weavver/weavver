using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Weavver.Data;

public partial class Install_Default : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;

          if (Request.UserHostAddress != "127.0.0.1")
          {
               Response.Write("This page is unavailable to the general internet. Please visit from the server machine.");
               Response.End();
          }

          WeavverMaster.SetToolbarVisibility(false);
          WeavverMaster.FormTitle = "Weavver First-Time Set-Up";
          WeavverMaster.FormDescription = "This wizard will help you configure Weavver for your first use.";
          //IsPublic = true;
          // extra security
          DatabaseHost.Text = GetConnectionStringValue("server");
          DatabaseUsername.Text = GetConnectionStringValue("user");
          DatabaseName.Text = GetConnectionStringValue("initial catalog");


          //NHibernate.Cfg.ConfigurationSchema.HibernateConfiguration cfg = (NHibernate.Cfg.ConfigurationSchema.HibernateConfiguration)ConfigurationManager.GetSection("hibernate-configuration");
          //string con1 = ConfigurationManager.ConnectionStrings["weavver"].ConnectionString;
          //string con2 = cfg.SessionFactory.Properties["connection.connection_string"];
          //if (con1 != con2)
          //{
          //     ShowError("Your connection strings are out of sync. Please fix this in the web.config file.");
          //}
     }
//-------------------------------------------------------------------------------------------
     private string GetConnectionStringValue(string valuename)
     {
          string connString = ConfigurationManager.ConnectionStrings["weavver"].ConnectionString;
          string[] parts = Regex.Split(connString, ";");
          foreach (string part in parts)
          {
               if (part.StartsWith(valuename))
               {
                    return part.Substring(part.IndexOf("=") + 1);
               }
          }
          return "";
     }
//-------------------------------------------------------------------------------------------
     protected void Create_Click(object sender, EventArgs e)
     {
          ////Weavver.Sys.Views v = new Weavver.Sys.Views();
          ////string log = v.DeployAll(db);

          //if (System.Configuration.ConfigurationManager.AppSettings["install_mode"] == "true")
          //{
          //     lblError.Text = "";

          //     DatabaseHelper.InitializeSession();
          //     DatabaseHelper.DeploySchema();

          //     // deploy first org
          //     Weavver.Company.Logistics.Organization org = new Weavver.Company.Logistics.Organization();
          //     org.DatabaseHelper = DatabaseHelper;
          //     org.Id = Guid.NewGuid();
          //     org.OrganizationType = Weavver.Company.Logistics.OrganizationTypes.Personal;
          //     org.Name = "Sample Organization";
          //     org.VanityURL = "default";
          //     org.EIN = "";
          //     org.Founded = DateTime.UtcNow;
          //     org.Bio = "This is a sample organization.";
          //     org.CreatedAt = DateTime.UtcNow;
          //     org.CreatedBy = Guid.Empty;
          //     org.UpdatedAt = DateTime.UtcNow;
          //     org.UpdatedBy = Guid.Empty;
          //     org.Commit();

          //     Response.Write(org.Id.ToString());

          //     Weavver.Sys.User user = new Weavver.Sys.User();
          //     user.DatabaseHelper = DatabaseHelper;
          //     user.Id = Guid.NewGuid();
          //     user.OrganizationId = org.Id;
          //     user.Name = "Administrator";
          //     user.FirstName = "Super";
          //     user.LastName = "User";
          //     user.Activated = true;
          //     user.Locked = false;
          //     user.Username = Username.Text;
          //     user.Password = "t3mp1234";
          //     user.CreatedAt = DateTime.UtcNow;
          //     user.CreatedBy = Guid.Empty;
          //     user.UpdatedAt = DateTime.UtcNow;
          //     user.UpdatedBy = Guid.Empty;
          //     user.Commit();

          //     // Response.Redirect("~/company/logistics/organization");
          //     Response.Redirect("~/install/step2");
          //}
          //else
          //{
          //     lblError.Text = "Notice: To deploy the schema you need to change your web.config setting 'install_mode' from false to true to install Weavver.";
          //}
     }
//-------------------------------------------------------------------------------------------
     protected void TestConnection_Click(object sender, EventArgs e)
     {
          //try
          //{
          //     DatabaseHelper.InitializeSession();
          //}
          //catch (Exception ex)
          //{
          //     ClearError();
          //     ShowError("The connection failed with this message:<br /><br />" + ex.Message + "<br /><br />");
          //}
          //if (DatabaseHelper.IsConnected)
          //{
          //     ShowError("The connection works.");
          //     DatabaseHelper.Session.Disconnect();
          //}
          //else
          //{
          //     ShowError("Weavver can not connect to your DB. Please check the database settings again.");
          //}
     }
//-------------------------------------------------------------------------------------------
}