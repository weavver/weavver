using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using System.IO;

using Weavver.Data;

using System.Data.Objects.DataClasses;
using System.Data;
using System.Configuration;
using Weavver.Web;

namespace DynamicData
{
     public partial class Details : SkeletonPage
     {
//-------------------------------------------------------------------------------------------
          protected MetaTable table;
          private string RedirectURL;
//-------------------------------------------------------------------------------------------
          protected void Page_Init(object sender, EventArgs e)
          {
               IsPublic = true;

               table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
               FormView1.SetMetaTable(table);
               DetailsDataSource.EntityTypeFilter = table.EntityType.Name;

               if (User.IsInRole("Administrators"))
               {
                    string x = table.GetActionPath("Edit") + "?id=" + Request["id"];
                    WeavverMenuItem editItem = new WeavverMenuItem();
                    editItem.Name = "Edit";
                    editItem.Link = x;
                    Master.ToolBarMenuAdd(editItem);
               }

               if (LoggedInUser != null &&
                   LoggedInUser.OrganizationId != new Guid(ConfigurationManager.AppSettings["default_organizationid"]))
                    DetailsDataSource.WhereParameters.Add(new Parameter("OrganizationId", DbType.Guid, SelectedOrganization.Id.ToString()));

               Master.FormTitle = table.DisplayName + " entry";

               GenerateMenu(TableActions.Details, table.Provider.EntityType);

               string projectionPath = "~/DynamicData/Projections/" + table.EntityType.ToString().Replace("Weavver.Data.", "") + ".ascx";
               if (File.Exists(Server.MapPath(projectionPath)))
               {
                    Control projection = LoadControl(projectionPath);
                    Projections.Controls.Add(projection);
               }
          }
//-------------------------------------------------------------------------------------------
          protected void Page_Load(object sender, EventArgs e)
          {
               Title = table.DisplayName;
               DetailsDataSource.Include = table.ForeignKeyColumnsNames;
          }
//-------------------------------------------------------------------------------------------
          protected string SetTitle(object dataItem)
          {
               string title = "";
               try
               {
                    title = DataBinder.Eval(dataItem, "Title").ToString();
                    Master.FormTitle = title;
               }
               catch { }
               return "";
          }
//-------------------------------------------------------------------------------------------
          protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
          {
               if (e.CommandName == DataControlCommands.CancelCommandName)
               {
               }
          }
//-------------------------------------------------------------------------------------------
          protected void FormView1_ItemDeleting(object sender, FormViewDeleteEventArgs e)
          {
               FormView1.DataBind();
               ICustomTypeDescriptor descriptor = FormView1.DataItem as ICustomTypeDescriptor;
               if (descriptor != null)
               {
                    EntityObject owner = (EntityObject) descriptor.GetPropertyOwner(null);
                    var NavActions = owner as INavigationActions;
                    if (NavActions == null)
                         RedirectURL = table.ListActionPath;
                    else
                         RedirectURL = NavActions.CancelURL;
               }
          }
//-------------------------------------------------------------------------------------------
          protected void FormView1_ItemDeleted(object sender, FormViewDeletedEventArgs e)
          {
               if (e.Exception == null || e.ExceptionHandled)
               {
                    Response.Redirect(RedirectURL);
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
