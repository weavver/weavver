using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using System.Data;
using System.Collections.Generic;
using Weavver.Data;
using System.IO;

namespace DynamicData
{
     public partial class Showcase : SkeletonPage
     {
          protected MetaTable table;
//-------------------------------------------------------------------------------------------
          protected void Page_Init(object sender, EventArgs e)
          {
               table = DynamicDataRouteHandler.GetRequestMetaTable(Context);

               //GridView1.SetMetaTable(table, table.GetColumnValuesFromRoute(Context));
               //GridView1.RowCreated += new GridViewRowEventHandler(GridView1_RowCreated);
               GridDataSource.EntityTypeFilter = table.EntityType.Name;
               GridDataSource.WhereParameters.Add(
                    new Parameter("OrganizationId", DbType.Guid, LoggedInUser.OrganizationId.ToString()));

               //GridDataSource.OrderBy = "Name";
               //GridDataSource.WhereParameters.Add(
               //     new Parameter("IsLab", DbType.Boolean, "false"));

               Master.FixedWidth = true;
               Master.FormTitle = table.DisplayName;

               //Master.FormTitle = "Professional Services";
               Master.FormDescription = "If you need help or would like to discuss a custom project please call us at +1-714-872-5920.";
          }
//-------------------------------------------------------------------------------------------
          void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
          {
               GridViewRow row = e.Row;
               // Intitialize TableCell list
               List<TableCell> columns = new List<TableCell>();
               //foreach (DataControlField column in GridView1.Columns)
               //{
               //     //Get the first Cell /Column
               //     TableCell cell = row.Cells[0];
               //     // Then Remove it after
               //     row.Cells.Remove(cell);
               //     //And Add it to the List Collections
               //     columns.Add(cell);
               //     cell.HorizontalAlign = HorizontalAlign.Center;
               //     cell.Width = Unit.Pixel(75);
               //}

               // Add cells
               row.Cells.AddRange(columns.ToArray());
          }
//-------------------------------------------------------------------------------------------
          protected void Page_Load(object sender, EventArgs e)
          {
               Title = table.DisplayName;
               GridDataSource.Include = table.ForeignKeyColumnsNames;
          }
//-------------------------------------------------------------------------------------------
          protected void Label_PreRender(object sender, EventArgs e)
          {
               Label label = (Label)sender;
               DynamicFilter dynamicFilter = (DynamicFilter)label.FindControl("DynamicFilter");
               QueryableFilterUserControl fuc = dynamicFilter.FilterTemplate as QueryableFilterUserControl;
               if (fuc != null && fuc.FilterControl != null)
               {
                    label.AssociatedControlID = fuc.FilterControl.GetUniqueIDRelativeTo(label);
               }
          }
//-------------------------------------------------------------------------------------------
          protected override void OnPreRenderComplete(EventArgs e)
          {
               base.OnPreRenderComplete(e);
          }
//-------------------------------------------------------------------------------------------
          public string GetLogo(Guid id)
          {
               string logopath = Server.MapPath("~/images/services/" + id.ToString() + ".png");
               if (File.Exists(logopath))
               {
                    return "<img border='0' src='~/images/services/" + id.ToString() + ".png' />";
               }
               return "";
          }
//-------------------------------------------------------------------------------------------
     }
}
