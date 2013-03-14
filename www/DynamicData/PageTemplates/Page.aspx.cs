using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using System.Collections.Generic;
using System.Web.Security;

using System.Linq;
using System.Data.Linq;

using Weavver.Data;

using System.Data.Objects.DataClasses;
using System.IO;

namespace DynamicData
{
     public partial class Page : SkeletonPage
     {
          protected MetaTable table;
//-------------------------------------------------------------------------------------------
          protected void Page_PreInit(object sender, EventArgs e)
          {
               Guid pageId = Guid.Empty;
               if (Guid.TryParse(Request["id"], out pageId))
               {
                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         var page = (from x in data.CMS_Pages
                                     where x.Id == pageId
                                     select x).FirstOrDefault();

                         if (File.Exists(Server.MapPath(page.MasterPage)))
                         {
                              this.MasterPageFile = page.MasterPage;
                         }
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          protected void Page_Init(object sender, EventArgs e)
          {
               //if (Roles.IsUserInRole("Administrators"))
               //     AdminLinks.Visible = true;

               string pathBase = Request.Url.PathAndQuery;
               pathBase = pathBase.Substring(0, pathBase.LastIndexOf("/"));
               //EditLink.HRef = pathBase + "/Edit.aspx?Id=" + Request["Id"];

               table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
               FormView1.SetMetaTable(table);
               FormView1.ItemCreated += new EventHandler(FormView1_ItemCreated);
               DetailsDataSource.EntityTypeFilter = table.EntityType.Name;

               WeavverMaster.FormTitle = "Entry from table " + table.DisplayName;

               //WeavverMaster.FormDescription = "If you need help or would like to discuss your project please call us at +1-714-872-5920.";

               IsPublic = true;
               ActivationRequired = false;
               //Master.DiscussionEnabled = false;
          }
//-------------------------------------------------------------------------------------------
          protected void Page_Load(object sender, EventArgs e)
          {
               Title = table.DisplayName;
               DetailsDataSource.Include = table.ForeignKeyColumnsNames;

               if (!IsPostBack)
               {
                    //FormView1.DataItem
               }
          }
//-------------------------------------------------------------------------------------------
          void FormView1_ItemCreated(object sender, EventArgs e)
          {
               ICustomTypeDescriptor descriptor = FormView1.DataItem as ICustomTypeDescriptor;
               if (descriptor != null)
               {
                    EntityObject owner = (EntityObject) descriptor.GetPropertyOwner(null);
                    var rowStyle = owner as IRowStyle;
                    var page = owner as CMS_Pages;
                    WeavverMaster.FormTitle = page.Title;
               }
          }
//-------------------------------------------------------------------------------------------
          protected void FormView1_ItemDeleted(object sender, FormViewDeletedEventArgs e)
          {
               //if (e.Exception == null || e.ExceptionHandled)
               //{
               //     Response.Redirect(table.ListActionPath);
               //}
          }
//-------------------------------------------------------------------------------------------
     }
}
