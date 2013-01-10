﻿using System;
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
using System.Web.Security;

namespace DynamicData
{
     public partial class XML : SkeletonPage
     {
          protected MetaTable table;
//-------------------------------------------------------------------------------------------
          protected void Page_Init(object sender, EventArgs e)
          {
               EnableViewState = false;
               table = DynamicDataRouteHandler.GetRequestMetaTable(Context);

               //GridView1.SetMetaTable(table, table.GetColumnValuesFromRoute(Context));
               //GridView1.RowCreated += new GridViewRowEventHandler(GridView1_RowCreated);
               GridDataSource.EntityTypeFilter = table.EntityType.Name;

               // HACKED TOGETHER FOR NOW
               if (User.Identity.IsAuthenticated)
               {
                    GridDataSource.WhereParameters.Add(new Parameter("OrganizationId", DbType.Guid, LoggedInUser.OrganizationId.ToString()));
               }
               else
               {
                    GridDataSource.WhereParameters.Add(new Parameter("OrganizationId", DbType.Guid, "0baae579-dbd8-488d-9e51-dd4dd6079e95"));
               }

               // GridDataSource.OrderBy = "it.PublishAt desc";

               IsPublic = true;
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

//Response.ContentType = "application/rss+xml";
//Uri couchdbPath = new Uri(System.Configuration.ConfigurationManager.AppSettings.Get("couchdb_path"));
//CouchServer server = new CouchServer(couchdbPath.Host, couchdbPath.Port);
//ICouchDatabase db = server.GetDatabase(couchdbPath.PathAndQuery);
//string view = "weavver.company.marketing.pressrelease";
//var docs = db.Query(view, "all").IncludeDocuments().GetResult().Documents<Weavver.Company.Marketing.PressRelease>();

//RssTemplate rt = new RssTemplate(Response.OutputStream, System.Text.Encoding.ASCII);
//rt.WriteStartDocument();
//rt.WriteStartChannel("Weavver Press Stream", "http://www.weavver.com/", "A press stream from Weavver to help keep you up to date.");
//foreach (Weavver.Company.Marketing.PressRelease pressrelease in docs)
//{
//     rt.WriteItem(pressrelease.Title, "Weavver, Inc.", "http://www.weavver.com/company/press.aspx?id=" + pressrelease.Id, pressrelease.HTMLBody, pressrelease.PublishAt);
//}
//rt.WriteEndChannel();
//rt.WriteEndDocument();
//Response.Write("</rss>");