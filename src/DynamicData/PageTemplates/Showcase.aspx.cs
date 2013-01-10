using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;

using Weavver.Data;

namespace DynamicData
{
     public partial class Showcase : SkeletonPage
     {
          protected MetaTable table;
//-------------------------------------------------------------------------------------------
          protected void Page_Init(object sender, EventArgs e)
          {
               table = DynamicDataRouteHandler.GetRequestMetaTable(Context);

               Master.SetChatVisibility(true);
               Master.FixedWidth = true;
               Master.Width = "930px";

               //GridView1.SetMetaTable(table, table.GetColumnValuesFromRoute(Context));
               //GridView1.RowCreated += new GridViewRowEventHandler(GridView1_RowCreated);
               GridDataSource.EntityTypeFilter = table.EntityType.Name;

               // HACKED TOGETHER FOR NOW
               if (User.Identity.IsAuthenticated)
               {
                    GridDataSource.WhereParameters.Add(new Parameter("OrganizationId", DbType.Guid, SelectedOrganization.Id.ToString()));
               }
               else
               {
                    GridDataSource.WhereParameters.Add(new Parameter("OrganizationId", DbType.Guid, "0baae579-dbd8-488d-9e51-dd4dd6079e95"));
               }
               
               if (table.EntityType.FullName.Contains("Logistics_Products"))
                    GridDataSource.WhereParameters.Add(new Parameter("IsPublic", DbType.Boolean, "True"));

               GridDataSource.OrderBy = "it.Name";

               //Master.FixedWidth = false;
               Master.FormTitle = table.DisplayName;
               IsPublic = true;

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

               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var specials = (from x in data.CMS_Pages
                                    where x.Title == "Sales/Store Specials" &&
                                    x.OrganizationId == SelectedOrganization.Id
                                    select x).FirstOrDefault();

                    if (specials != null)
                    {
                         StoreSpecials.Text = specials.Page;
                    }
               }
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
          public string GetURL(object dataItem)
          {
               string x = "";
               try
               {
                    x = (string)DataBinder.Eval(dataItem, "URL");
               }
               catch { }
               if (String.IsNullOrEmpty(x))
                    x = "StoreItem.aspx?Id=" + DataBinder.Eval(dataItem, "Id").ToString();
               return x;
          }
//-------------------------------------------------------------------------------------------
     }
}
