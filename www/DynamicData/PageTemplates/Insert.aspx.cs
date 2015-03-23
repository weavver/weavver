using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;

namespace DynamicData
{
     public partial class Insert : SkeletonPage
     {
          protected MetaTable table;

          protected void Page_Init(object sender, EventArgs e)
          {
               IsPublic = true;

               table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
               FormView1.SetMetaTable(table, table.GetColumnValuesFromRoute(Context));
               DetailsDataSource.EntityTypeFilter = table.EntityType.Name;

               Master.FormTitle = "Add new entry to " + table.DisplayName;

               DetailsDataSource.Inserted += DetailsDataSource_Inserted;
          }

          void DetailsDataSource_Inserted(object sender, Microsoft.AspNet.EntityDataSource.EntityDataSourceChangedEventArgs e)
          {
               if (e.Entity != null)
               {
                    Response.Redirect(table.GetActionPath(PageAction.Details, e.Entity));
               }
               else
               {
                    ShowError("Error: Your data could not be saved.");
               }
          }

          protected void Page_Load(object sender, EventArgs e)
          {
               Title = table.DisplayName;
          }

          protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
          {
               if (e.CommandName == DataControlCommands.CancelCommandName)
               {
                    Response.Redirect(table.ListActionPath);
               }
          }

          protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
          {
               //if (e.Exception == null || e.ExceptionHandled)
               //{
               //     e.Values
               //     //Response.Write("Linking to: " + Request["linkto"]);
               //     Response.Redirect(table.GetActionPath("Details", DataItem));
               //     //Response.Redirect("Details.aspx?id=asdf");
               //}
               //else
               //{
               //     ShowError(e.Exception.ToString());
               //}
          }

     }
}
