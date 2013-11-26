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
using System.Data.SqlClient;

public partial class Install_Default : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;

          if (Request.UserHostAddress != "127.0.0.1" || ConfigurationManager.AppSettings["install_mode"] == "false")
          {
               Response.Write("This page is unavailable to the general internet. Please visit from the server machine.");
               Response.End();
          }

          WeavverMaster.SetToolbarVisibility(false);
          WeavverMaster.FormTitle = "Weavver First-Time Set-Up";
          WeavverMaster.FormDescription = "This wizard will help you configure Weavver for your first use.";

          //"Notice: To deploy the schema you need to change your web.config setting 'install_mode' from false to true to install Weavver.";

          //NHibernate.Cfg.ConfigurationSchema.HibernateConfiguration cfg = (NHibernate.Cfg.ConfigurationSchema.HibernateConfiguration)ConfigurationManager.GetSection("hibernate-configuration");
          //string con1 = ConfigurationManager.ConnectionStrings["weavver"].ConnectionString;
          //string con2 = cfg.SessionFactory.Properties["connection.connection_string"];
          //if (con1 != con2)
          //{
          //     ShowError("Your connection strings are out of sync. Please fix this in the web.config file.");
          //}

          string connectionString = ConfigurationManager.ConnectionStrings["WeavverEntityContainer"].ConnectionString;
          var entityBuilder = new System.Data.EntityClient.EntityConnectionStringBuilder(connectionString);
          var sqlBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder(entityBuilder.ProviderConnectionString);
          DatabaseHost.Text = sqlBuilder.DataSource;
          DatabaseUsername.Text = sqlBuilder.UserID;
          DatabaseName.Text = sqlBuilder.InitialCatalog;
     }
//-------------------------------------------------------------------------------------------
     //Deprecated:
     //private string GetConnectionStringValue(string valuename)
     //{
     //     // extra security
     //     //DatabaseHost.Text = GetConnectionStringValue("server");
     //     //DatabaseUsername.Text = GetConnectionStringValue("user");
     //     //DatabaseName.Text = GetConnectionStringValue("initial catalog");
     //     string connString = ConfigurationManager.ConnectionStrings["weavver"].ConnectionString;
     //     string[] parts = Regex.Split(connString, ";");
     //     foreach (string part in parts)
     //     {
     //          if (part.StartsWith(valuename))
     //          {
     //               return part.Substring(part.IndexOf("=") + 1);
     //          }
     //     }
     //     return "";
     //}
//-------------------------------------------------------------------------------------------
     protected void Create_Click(object sender, EventArgs e)
     {
          try
          {
               ConfigureDatabase();
          }
          catch (Exception ex)
          {
               lblError.Text = ex.ToString().Replace("\r\n", "<br />\r\n");
          }
     }
//-------------------------------------------------------------------------------------------
     private void ConfigureDatabase()
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               // Run SQL Deploy script
               string connectionString = ConfigurationManager.ConnectionStrings["WeavverEntityContainer"].ConnectionString;
               var entityBuilder = new System.Data.EntityClient.EntityConnectionStringBuilder(connectionString);
               SqlConnection connection = new SqlConnection(entityBuilder.ProviderConnectionString);
               connection.Open();

               string script = System.IO.File.ReadAllText(Server.MapPath(@"\bin\Database.sql")); //data.CreateDatabaseScript();
               script = script.Replace("%dalpath%", Server.MapPath(@"\bin\Weavver.DAL.dll"));
               script = script.Replace("%databasename%", connection.Database);
               string[] blocks = System.Text.RegularExpressions.Regex.Split(script, "\nGO");
               foreach (string block in blocks)
               {
                    if (block.Trim() != String.Empty)
                    {
                         SqlCommand createDb = new SqlCommand(block, connection);
                         try
                         {
                              createDb.ExecuteNonQuery();
                         }
                         catch (Exception ex)
                         {
                              throw new Exception("Block: " + block, ex);
                         }


                    }
               }

               // CREATE INITIAL DATA
               Guid orgId = Guid.NewGuid();
               Session["SelectedOrganizationId"] = orgId;

               // deploy first org
               Weavver.Data.Logistics_Organizations org = new Weavver.Data.Logistics_Organizations();
               org.Id = orgId;
               org.OrganizationId = org.Id; // THIS IS OVERRIDDEN ANYWAY BY AUDITUTILITY AS A SECURITY PRECAUTION
               org.OrganizationType = "Personal";
               org.Name = Organization.Text;
               org.VanityURL = "default";
               org.EIN = "";
               org.Founded = DateTime.UtcNow;
               org.Bio = "This is a sample organization.";
               org.CreatedAt = DateTime.UtcNow;
               org.CreatedBy = Guid.Empty;
               org.UpdatedAt = DateTime.UtcNow;
               org.UpdatedBy = Guid.Empty;
               data.Logistics_Organizations.AddObject(org);
               data.SaveChanges();

               Weavver.Data.System_Users user = new Weavver.Data.System_Users();
               user.Id = orgId;
               user.OrganizationId = org.Id; // THIS IS OVERRIDDEN ANYWAY BY AUDITUTILITY AS A SECURITY PRECAUTION
               user.FirstName = "Enlightened";
               user.LastName = "User";
               user.Activated = true;
               user.Locked = false;
               user.Username = Username.Text;
               user.Password = Password.Text;
               user.CreatedAt = DateTime.UtcNow;
               user.CreatedBy = Guid.Empty;
               user.UpdatedAt = DateTime.UtcNow;
               user.UpdatedBy = Guid.Empty;
               data.System_Users.AddObject(user);
               data.SaveChanges();

               Roles.ApplicationName = orgId.ToString();
               string adminuser = user.Username;
               Roles.CreateRole("Administrators");
               Roles.AddUsersToRoles(new string[] { adminuser }, new string[] { "Administrators" });
               Roles.CreateRole("Accountants");
               Roles.AddUsersToRoles(new string[] { adminuser }, new string[] { "Accountants" });

               if (data.SaveChanges() > 0)
                    Response.Redirect("~/install/step2");
          }
     }
//-------------------------------------------------------------------------------------------
     protected void TestConnection_Click(object sender, EventArgs e)
     {
          try
          {
               string connectionString = ConfigurationManager.ConnectionStrings["WeavverEntityContainer"].ConnectionString;
               var entityBuilder = new System.Data.EntityClient.EntityConnectionStringBuilder(connectionString);
               SqlConnection data = new SqlConnection(entityBuilder.ProviderConnectionString);
               data.Open();

               if (data.State == ConnectionState.Open)
               {
                    DBStatus.Text = "The connection works.";
                    data.Close();

                    TestConnection.BackColor = System.Drawing.Color.LightGreen;
               }
               else
               {
                    DBStatus.Text = "Weavver can not connect to your DB. Please check the database settings again.";

                    TestConnection.BackColor = System.Drawing.Color.Coral;
               }
          }
          catch (Exception ex)
          {
               DBStatus.Text = "The connection failed with this message:<br /><br />" + ex.Message;
               TestConnection.BackColor = System.Drawing.Color.Coral;
          }
     }
//-------------------------------------------------------------------------------------------
}