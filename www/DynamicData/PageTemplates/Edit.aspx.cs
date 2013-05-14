using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using System.Web.Security;
using System.Web.UI.WebControls;

using Weavver.Data;
using System.Data.Objects.DataClasses;
using System.Reflection;

using Weavver.Web;
using System.IO;

namespace DynamicData
{
     public partial class Edit : SkeletonPage
     {
          protected MetaTable table;
//-------------------------------------------------------------------------------------------
          protected void Page_Init(object sender, EventArgs e)
          {
               IsPublic = true;

               if (!Roles.IsUserInRole("Administrators"))
                    Response.Redirect("~/", true);

               table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
               FormView1.SetMetaTable(table);

               DetailsDataSource.EntityTypeFilter = table.EntityType.Name;

               WeavverMaster.FormTitle = "Edit entry from " + table.DisplayName;

               //FormView1.DataBind();

               //var obj = Weavver.Data.EntityDataSourceExtensions.GetItemObject<Weavver.Data.IT_Servers>(FormView1.DataItem);
               //GenerateMenu(TableActions.Edit, table.Provider.EntityType);

               WeavverMenuItem auditTrail = new WeavverMenuItem();
               auditTrail.Name = "Audit Trails";
               auditTrail.Link = "~/Data_AuditTrails/List.aspx?Id=" + Request.QueryString["Id"];
               WeavverMaster.ToolBarMenuAdd(auditTrail);

               WeavverMenuItem urlList = new WeavverMenuItem();
               urlList.Name = "URLs";
               urlList.Link = "~/System_URLs/List.aspx?ObjectId=" + Request.QueryString["Id"];
               WeavverMaster.ToolBarMenuAdd(urlList);

               WeavverMenuItem urlNew = new WeavverMenuItem();
               urlNew.Name = "New URL";
               urlNew.Link = "~/System_URLs/Insert.aspx?ObjectId=" + Request.QueryString["Id"] + "&TableName=" + table.Provider.EntityType.ToString().Replace("Weavver.Data.", "");
               WeavverMaster.ToolBarMenuAdd(urlNew);

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
               // DetailsDataSource.Include = table.ForeignKeyColumnsNames;
               //  ShowError(table.ForeignKeyColumnsNames);

               //if (!IsPostBack)
               //{
               //     FormView1.DataBind();
               //}
          }
//-------------------------------------------------------------------------------------------
          protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
          {
               if (e.CommandName == DataControlCommands.CancelCommandName)
               {
                    FormView1.DataBind();

                    string redirectUrl = table.GetActionPath("Details", FormView1.DataItem);
                    Response.Redirect(redirectUrl);

                    //ICustomTypeDescriptor descriptor = FormView1.DataItem as ICustomTypeDescriptor;
                    //if (descriptor != null)
                    //{
                    //     EntityObject owner = (EntityObject) descriptor.GetPropertyOwner(null);
                    //     var NavActions = owner as INavigationActions;
                    //     if (NavActions == null)
                    //          Response.Redirect(table.ListActionPath);
                    //     else
                    //          Response.Redirect(NavActions.CancelURL);
                    //}
               }
          }
//-------------------------------------------------------------------------------------------
          protected void FormView1_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
          {
               if (e.Exception == null || e.ExceptionHandled)
               {
                    FormView1.DataBind();

                    ShowError("Hellow");
                    string redirectUrl = table.GetActionPath("Details", FormView1.DataItem);
                    Response.Redirect(redirectUrl);
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "temp", "<script type='text/javascript'>showMessage('Item Saved!', '" + redirectUrl + "');</script>", false);
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
