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
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Reflection;

using Weavver.Data;
using Weavver.Web;
using System.Web.Security;
using System.Data.Objects;

public partial class DynamicData_DynamicList : WeavverUserControl
{
          protected MetaTable table;
//-------------------------------------------------------------------------------------------
          protected override void  OnInit(EventArgs e)
          {
 	          base.OnInit(e);
               table = DynamicDataRouteHandler.GetRequestMetaTable(Context);

               Controls_ColumnPicker obj = (Controls_ColumnPicker) SecureContent.FindControl("ColumnPicker1");
               if (obj != null)
               {
                    obj.DataSaved += new DataSavedHandler(obj_DataSaved);
                    GridView1.ColumnsGenerator = obj.FieldManager;
               }

               ((IQueryableDataSource)this.GridDataSource).QueryCreated += new EventHandler<QueryCreatedEventArgs>(List_QueryCreated);
               GridView1.DataBound += new EventHandler(GridView1_DataBound);
               GridView1.PageIndexChanging += new GridViewPageEventHandler(GridView1_PageIndexChanging);
               GridView1.RowDataBound += new GridViewRowEventHandler(GridView1_RowDataBound);
               GridView1.RowCreated += new GridViewRowEventHandler(GridView1_RowCreated);

               GridDataSource.Selected += new EventHandler<EntityDataSourceSelectedEventArgs>(GridDataSource_Selected);

               GridView1.SetMetaTable(table, table.GetColumnValuesFromRoute(Context));
               //if (!IsPostBack)
               //{
                    GridDataSource.EntityTypeFilter = table.EntityType.Name;
               //}

               //GenerateMenu(TableActions.List, table.EntityType.GetType());

               GridDataSource.WhereParameters.Add(new Parameter("OrganizationId", DbType.Guid, BasePage.SelectedOrganization.Id.ToString()));

               if (Request["ObjectId"] != null)
                    GridDataSource.WhereParameters.Add(new Parameter("ObjectId", DbType.Guid, Request["ObjectId"]));

               if (Request["AccountId"] != null)
               {
                    GridDataSource.WhereParameters.Add(new Parameter("AccountId", DbType.Guid, Request["AccountId"]));

                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         string title = data.GetName(new Guid(Request["AccountId"]));

                         if (Request["LedgerType"] != null)
                         {
                              title += " - " + Request["LedgerType"];
                         }

                         //WeavverMaster.FormTitle = title;
                    }
               }

               if (Request["TransactionId"] != null)
                    GridDataSource.WhereParameters.Add(new Parameter("TransactionId", DbType.Guid, Request["TransactionId"]));

               string quickAddPath = "~/DynamicData/QuickAdd/" + table.EntityType.ToString().Replace("Weavver.Data.", "") + ".ascx";
               if (File.Exists(Server.MapPath(quickAddPath)))
               {
                    WeavverUserControl quickAdd = (WeavverUserControl) LoadControl(quickAddPath);
                    quickAdd.DataSaved += new DataSavedHandler(QuickAdd_DataSaved);
                    QuickAdd.Controls.Add(quickAdd);
               }

               string projectionPath = "~/DynamicData/Projections/" + table.EntityType.Name + ".ascx";
               if (File.Exists(Server.MapPath(projectionPath)))
               {
                    Control projection = LoadControl(projectionPath);
                    Projections.Controls.Add(projection);
               }

               if (!IsPostBack)
               {
                    // set default sort
                    if (table.SortColumn != null)
                    {
                         var order = new OrderByExpression()
                         {
                              DataField = table.SortColumn.Name,
                              Direction = table.SortDescending ? SortDirection.Descending : SortDirection.Ascending,
                         };
                         GridQueryExtender.Expressions.Add(order);
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          void GridDataSource_Selected(object sender, EntityDataSourceSelectedEventArgs e)
          {
               int x = e.TotalRowCount;
               SetResults(x);
          }
//-------------------------------------------------------------------------------------------
          protected void Page_Load(object sender, EventArgs e)
          {
               //Title = table.DisplayName;
               //GridDataSource.Include = table.ForeignKeyColumnsNames;

               // Disable various options if the table is readonly
               if (table.IsReadOnly)
               {
                    GridView1.Columns[0].Visible = false;
                    //InsertHyperLink.Visible = false;
                    GridView1.EnablePersistedSelection = false;
               }
          }
//-------------------------------------------------------------------------------------------
          void GridView1_DataBound(object sender, EventArgs e)
          {
               //SetResults();
          }
//-------------------------------------------------------------------------------------------
          void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
          {
               //SetResults();
          }
//-------------------------------------------------------------------------------------------
          public void SetResults(int rowCount)
          {
               string startPos = String.Format("{0}", GridView1.PageIndex * GridView1.PageSize + 1);
               int maxPageCount = GridView1.PageIndex * GridView1.PageSize + GridView1.PageSize;
               RowSummary.Text = "Showing " + startPos + " to " + Math.Min(maxPageCount, rowCount) + " of " + rowCount.ToString();
          }
//-------------------------------------------------------------------------------------------
          void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
          {
               GridViewRow row = e.Row;
               // Intitialize TableCell list
               List<TableCell> columns = new List<TableCell>();
               foreach (DataControlField column in GridView1.Columns)
               {
                    //Get the first Cell /Column
                    TableCell cell = row.Cells[0];
                    // Then Remove it after
                    row.Cells.Remove(cell);
                    //And Add it to the List Collections
                    columns.Add(cell);
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.Width = Unit.Pixel(75);
               }

               // Add cells
               row.Cells.AddRange(columns.ToArray());
          }
//-------------------------------------------------------------------------------------------
          void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
          {
               if (e.Row.RowType == DataControlRowType.DataRow)
               {
                    string rowCss = (e.Row.RowState == DataControlRowState.Alternate) ? "AlternatingRowStyle" : "RowStyle";
                    string hoverCss = "HoverRowStyle";

                    ICustomTypeDescriptor descriptor = e.Row.DataItem as ICustomTypeDescriptor;
                    if (descriptor != null)
                    {
                         EntityObject owner = (EntityObject) descriptor.GetPropertyOwner(null);
                         var rowStyle = owner as IRowStyle;
                         if (rowStyle != null)
                              rowStyle.GetRowStyle(out rowCss, out hoverCss);

                         //alternating: f4f7f9
                         e.Row.CssClass = rowCss;
                         e.Row.Attributes.Add("onMouseOut", String.Format("mouseOut(this, '{0}')", rowCss));
                         e.Row.Attributes.Add("onMouseOver", String.Format("mouseOver(this, '{0}')", hoverCss));
                         e.Row.Attributes.Add("onContextMenu", String.Format("mouseDown(this, '{0}')", hoverCss));

                         string url = null;

                         var navigationActions = owner as INavigationActions;
                         if (navigationActions != null && navigationActions.DetailURL != null)
                              url = navigationActions.DetailURL;

                         var auditableRow = owner as IAuditable;
                         if (auditableRow != null)
                              url = "/" + table.EntityType.Name + "/Details.aspx?id=" + auditableRow.Id;


                         object[] atts = owner.GetType().GetCustomAttributes(typeof(CSSAttribute), true);
                         string css = "";
                         if (atts.Count() > 0)
                         {
                              CSSAttribute css2 = (CSSAttribute) atts[0];
                              css = css2._CSS;
                         }

                         if (url != null)
                              e.Row.Attributes["onClick"] = String.Format("javascript:createPopup(\"" + url + "\", \"" + css + "\");"); // old: "location.href='{0}'", url);

                         var columnStyle = owner as IColumnStyle;
                         if (columnStyle != null)
                         {
                              for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
                              {
                                   columnStyle.GetColumnStyle(GridView1.HeaderRow.Cells[i], e.Row.Cells[i], out rowCss, out hoverCss);
                              }
                         }
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          private void AddControl(Random rnd)
          {
               int x = rnd.Next(10000);

               //EntityDataSource eds = new EntityDataSource();
               //eds.ID = "DetailsDataSource" + x.ToString();
               //eds.EnableUpdate = true;
               //eds.EntityTypeFilter = table.EntityType.Name;

               ////eds.EntitySetName = "Accounting_Accounts";
               ////eds.ContextTypeName = "WeavverEntityContext";
               ////eds.Where = "it.id = @id";
               ////eds.WhereParameters.Add("id", DbType.Guid, "3d322c57-2b4a-4b27-8187-2094931eb2ca");
               //AddedControls.Controls.Add(eds);


               //DynamicDataManager ddm = new DynamicDataManager();
               //ddm.ID = "DynamicDataManager3";
               //ddm.AutoLoadForeignKeys = true;
               //DataControlReference ddr = new DataControlReference();
               //ddr.ControlID = "FormView3";
               //ddm.DataControls.Add(ddr);


               //AddedControls.Controls.Add(ddm);

               FormView fv = new FormView();
               fv.ID = "FormView" + x.ToString();
               fv.DataSourceID = "GridDataSource";
               YourTemplate yt = new YourTemplate();
               fv.ItemTemplate = yt;


               //fv.ItemTemplate.Controls.Add(de);

               AddedControls.Controls.Add(fv);

               DynamicDataManager1.RegisterControl(fv);

               EntityControls.Update();
          }
//-------------------------------------------------------------------------------------------
          protected void TestAddControl_Click(object sender, EventArgs e)
          {
               Random rnd = new Random();
               AddControl(rnd);
               AddControl(rnd);
               //fv.DataBind();
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
          //protected override void OnPreRenderComplete(EventArgs e)
          //{
          //     RouteValueDictionary routeValues = new RouteValueDictionary(GridView1.GetDefaultValues());
          //     //InsertHyperLink.NavigateUrl = table.GetActionPath(PageAction.Insert, routeValues);
          //     base.OnPreRenderComplete(e);
          //}
//-------------------------------------------------------------------------------------------
          protected void DynamicFilter_FilterChanged(object sender, EventArgs e)
          {
               GridView1.PageIndex = 0;

               UpdatePanel1.Update();
          }
//-------------------------------------------------------------------------------------------
          protected void SearchButton_Click(object sender, EventArgs e)
          {
               ((IQueryableDataSource)this.GridDataSource).RaiseViewChanged();
               ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(string), "ScrollUp", "$x = setInterval('scroll(0,0); clearInterval($x)', 1)", true);

               UpdatePanel1.Update();
          }
//-------------------------------------------------------------------------------------------
          void List_QueryCreated(object sender, QueryCreatedEventArgs e)
          {
               if (export)
               {
                    Response.Clear();
                    //XmlSerializer serializer = new XmlSerializer(typeof(Logistics_Products));
                    //TextWriter writer = new StreamWriter(Response.OutputStream);

                    Response.AddHeader("Content-Disposition", "attachment; filename=Data.csv");
                    Response.ContentType = "text/plain";


                    var query = (ObjectQuery)e.Query;

                    bool outputHeader = true;
                    foreach (var res in query)
                    {
                         //serializer.Serialize(writer, rec);

                         PropertyInfo[] props = res.GetType().GetProperties();
                         if (outputHeader)
                         {
                              for (int i = 0; i < props.Length; i++)
                              {
                                   PropertyInfo Prop = props[i];
                                   Response.Write("\"" + Prop.Name + "\",");
                              }
                              outputHeader = false;
                              Response.Write("\r\n");
                         }

                         for (int i = 0; i < props.Length; i++)
                         {
                              PropertyInfo Prop = props[i];
                              object propValue = Prop.GetValue(res, null);
                              //Response.Write(Prop.Name);
                              if (propValue != null)
                              {
                                   string val = propValue.ToString();
                                   val = val.Replace("\"", "\"\"");

                                   Response.Write("\"" + val + "\"");
                              }
                              Response.Write(",");
                         }
                         Response.Write("\r\n");
                    }
                    Response.End();
               }
          }
//-------------------------------------------------------------------------------------------
          void QuickAdd_DataSaved(object sender, EventArgs e)
          {
               ((IQueryableDataSource)this.GridDataSource).RaiseViewChanged();
          }
//-------------------------------------------------------------------------------------------
          protected void DownloadCSV_Click(object sender, EventArgs e)
          {
               export = true;
               ((IQueryableDataSource)this.GridDataSource).RaiseViewChanged();
          }
//-------------------------------------------------------------------------------------------
          void obj_DataSaved(object sender, EventArgs e)
          {
               Controls_ColumnPicker obj = (Controls_ColumnPicker)SecureContent.FindControl("ColumnPicker1");
               GridView1.ColumnsGenerator = obj.FieldManager;
               GridView1.DataBind();
          }
//-------------------------------------------------------------------------------------------
          bool export = false;
}

public class YourTemplate : ITemplate
{
     public void InstantiateIn(Control container)
     {
          HtmlGenericControl div = new HtmlGenericControl("div");
          div.InnerText = "sample text, other controls";
          container.Controls.Add(div);

          DynamicEntity de = new DynamicEntity();
          container.Controls.Add(de);
     }
}