using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Linq;

using System.Activities;
using System.Activities.DurableInstancing;
using System.Configuration;
using System.Threading;
using System.ServiceModel.Activities;
using System.Workflow.Runtime;

using Weavver.Workflows;
using Weavver.Data;
using System.Data.Entity.Infrastructure;

public partial class Global : System.Web.HttpApplication
{
//-------------------------------------------------------------------------------------------
     //private static WorkflowRuntime _wfRuntime = null;
     private static MetaModel s_defaultModel = null;
//-------------------------------------------------------------------------------------------
     //public static WorkflowRuntime WorkflowRuntime
     //{
     //     get
     //     {
     //          return _wfRuntime;
     //     }
     //}
//-------------------------------------------------------------------------------------------
     public static MetaModel DefaultModel
     {
          get
          {
               return s_defaultModel;
          }
     }
//-------------------------------------------------------------------------------------------
     void Application_Start(object sender, EventArgs e)
     {
          // Initialize the Dynamic Data Framework
          if (s_defaultModel == null)
          {
               s_defaultModel = new SecureMetaModel(GetVisibleColumns);
               RegisterDynamicDataRoutes(System.Web.Routing.RouteTable.Routes);
          }
     }
//-------------------------------------------------------------------------------------------
     public static IEnumerable<MetaColumn> GetVisibleColumns(IEnumerable<MetaColumn> columns)
     {
          var visibleColumns = from c in columns
                               where IsShown(c)
                               select c;
          return visibleColumns; // .OrderBy((IList) c =>);
     }
//-------------------------------------------------------------------------------------------
     public static Boolean IsAuthorized(MetaColumn column)
     {
          var securedColumns = column.GetColumnPermissions(System.Web.Security.Roles.GetRolesForUser());
          if (securedColumns.Contains(ColumnActions.DenyRead))
               return false;

          return true;
     }
//-------------------------------------------------------------------------------------------
     public static Boolean IsShown(MetaColumn column)
     {
          // need to get the current page template
          var page = (System.Web.UI.Page)System.Web.HttpContext.Current.CurrentHandler;
          var pageTemplate = page.GetPageTemplate();

          var hideIn = column.GetAttribute<HideColumnInAttribute>();
          if (hideIn != null && (hideIn.PageTemplates.Contains(pageTemplate)))
               return false;

          var hideIfFiltered = column.GetAttribute<HideIfFiltered>();
          if (hideIfFiltered != null &&
               (System.Web.HttpContext.Current.Request[column.Name] != null ||
                    (hideIfFiltered.FilterName != null &&
                     System.Web.HttpContext.Current.Request[hideIfFiltered.FilterName] != null))
               )
               return false;               

          var securedColumns = column.GetColumnPermissions(System.Web.Security.Roles.GetRolesForUser());
          if (securedColumns.Contains(ColumnActions.DenyRead))
               return false;

          //foreach (var secureColumn in securedColumns)
          //{
          //     if (securedColumn
          //}

          return true;
     }
//-------------------------------------------------------------------------------------------
     public static void RegisterDynamicDataRoutes(System.Web.Routing.RouteCollection routes)
     {
          DefaultModel.FieldTemplateFactory = new SecureFieldTemplateFactory();
          ContextConfiguration config = new ContextConfiguration() { ScaffoldAllTables = true };

          DefaultModel.RegisterContext(
                                        new Microsoft.AspNet.DynamicData.ModelProviders.EFDataModelProvider(() => new WeavverEntityContainer()),
                                        config
                                      );
          //DefaultModel.RegisterContext(typeof(Weavver.Workflows.WorkflowContainer), config);

          // separate page mode
          routes.Add(new DynamicDataRoute("{table}/{action}.aspx")
          {
               Constraints = new System.Web.Routing.RouteValueDictionary(new { action = "BlogRoll|PressRoll|StoreItem|Showcase|Page|XML|List|Details|Insert|ListDetails|CSV|Edit" }),
               RouteHandler = new SecureDynamicDataRouteHandler(),
               Model = DefaultModel
          });

          //routes.Add(new DynamicDataRoute("{table}/{action}.aspx")
          //{
          //     Constraints = new System.Web.Routing.RouteValueDictionary(new { action =  }),
          //     RouteHandler = new DynamicDataRouteHandler(),
          //     Model = DefaultModel
          //});

          // combined page mode
          routes.Add(new DynamicDataRoute("{table}/KnowledgeBase.aspx")
          {
               Action = PageAction.List,
               RouteHandler = new DynamicDataRouteHandler(),
               ViewName = "KnowledgeBase",
               Model = DefaultModel
          });

          //routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx")
          //{
          //     Action = PageAction.List,
          //     RouteHandler = new SecureDynamicDataRouteHandler(),
          //     ViewName = "ListDetails",
          //     Model = DefaultModel
          //});
     }
//-------------------------------------------------------------------------------------------
     void Session_Start(object sender, EventArgs e)
     {
          // Code that runs when a new session is started
     }
//-------------------------------------------------------------------------------------------
     void Session_End(object sender, EventArgs e)
     {
          if (ConfigurationManager.AppSettings["install_mode"] == "false")
          {
          // Code that runs when a session ends. 
          // Note: The Session_End event is raised only when the sessionstate mode
          // is set to InProc in the Web.config file. If session mode is set to StateServer 
          // or SQLServer, the event is not raised.

               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var cartItems = from item in data.Sales_ShoppingCartItems
                                    where item.SessionId == Session.SessionID
                                    select item;

                    foreach (Sales_ShoppingCartItems item in cartItems)
                    {
                         data.Sales_ShoppingCartItems.Remove(item);
                    }
                    data.SaveChanges();
               }
          }
     }
//-------------------------------------------------------------------------------------------
     void Application_Error(object sender, EventArgs e)
     {
          //// Code that runs when an unhandled error occurs
          // System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage("system@weavver.com", "mitchel@weavver.com");
          // msg.Subject = "Weavver System - Website Error";

          // Exception objErr = Server.GetLastError().GetBaseException();
          // string err = "Error Caught in Application_Error event\r\n\r\n" +
          //           "Error in: " + Request.Url.ToString() + "\r\n\r\n" +
          //           "Error Message:" + objErr.Message.ToString() + "\r\n\r\n" +
          //           "Stack Trace:" + objErr.StackTrace.ToString();

          // msg.Body = "Exception:\r\n" + err;
          // System.Net.Mail.SmtpClient sClient = new System.Net.Mail.SmtpClient("192.168.10.11");
          // sClient.Send(msg);
     }
//-------------------------------------------------------------------------------------------
     void Application_End(object sender, EventArgs e)
     {
          //Workflows.Unload();
     }
//-------------------------------------------------------------------------------------------
}