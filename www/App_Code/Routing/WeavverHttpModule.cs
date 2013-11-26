using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.DynamicData;

using Weavver.Data;
using Weavver.Vendors.ProcessOne;


/// <summary>
/// Summary description for WeavverHttpModule
/// </summary>
namespace Weavver.Web
{
     public class WeavverHttpModule : IHttpModule, IRequiresSessionState
     {
//-------------------------------------------------------------------------------------------
          public void Init(HttpApplication application)
          {
               application.PostAcquireRequestState += new EventHandler(Application_PostAcquireRequestState);
               application.PostMapRequestHandler += new EventHandler(Application_PostMapRequestHandler);
          }
//-------------------------------------------------------------------------------------------
          void Application_PostMapRequestHandler(object source, EventArgs e)
          {
               HttpApplication app = (HttpApplication)source;

               if (app.Context.Handler is IReadOnlySessionState || app.Context.Handler is IRequiresSessionState)
               {
                    // no need to replace the current handler
                    return;
               }

               // swap the current handler
               app.Context.Handler = new MyHttpHandler(app.Context.Handler);
          }
//-------------------------------------------------------------------------------------------
          void Application_PostAcquireRequestState(object source, EventArgs e)
          {
               HttpApplication app = (HttpApplication)source;

               MyHttpHandler resourceHttpHandler = HttpContext.Current.Handler as MyHttpHandler;

               if (resourceHttpHandler != null)
               {
                    // set the original handler back
                    HttpContext.Current.Handler = resourceHttpHandler.OriginalHandler;
               }

               // -> at this point session state should be available

               string url = app.Context.Request.Url.ToString(); // url: http://www.weavver.local/default.aspx
               string path = app.Context.Request.Path; // path: /default.aspx OR /org/default/company/services/hosting/
               string exten = System.IO.Path.GetExtension(app.Context.Request.Path);
               string newpath = path;
               string org = "default";

               // protects autocomplete
               if (url.Contains(".asmx/"))
                    return;

               string query = "";
               if (HttpContext.Current.Request.QueryString.HasKeys())
               {
                    query += HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString.ToString());
               }

               // checks for dynamic urls (pages/content that only lives in the database)
               if (app.Context.Session != null && app.Context.Session["SelectedOrganizationId"] != null)
               {
                    Guid selectedOrganizationId = (Guid)app.Context.Session["SelectedOrganizationId"];
                    if (ConfigurationManager.AppSettings["install_mode"] == "false")
                    {
                         using (WeavverEntityContainer data = new WeavverEntityContainer())
                         {
                              var dynamicUrl = (from x in data.System_URLs
                                                where x.Path == path &&
                                                     x.OrganizationId == selectedOrganizationId
                                                select x).FirstOrDefault();

                              if (dynamicUrl != null)
                              {
                                   query = "Id=" + dynamicUrl.ObjectId.ToString();
                                   HttpContext.Current.RewritePath("/" + dynamicUrl.TableName + "/" + dynamicUrl.PageTemplate + ".aspx", null, query, false);
                                   return;
                              }
                         }
                    }
               }

               if (exten == "" && !newpath.ToLower().Contains(".aspx/"))
               {
                    //string filepath = HttpContext.Current.Server.MapPath("~" + path + ".aspx");
                    //if (urlparts.Length >= 2)

                    if (path.Length > 5 && path.StartsWith("/org/"))
                    {
                         newpath = path.Substring(5);
                         if (newpath.Contains("/"))
                         {
                              org = newpath.Substring(0, newpath.IndexOf("/"));
                              newpath = newpath.Substring(newpath.IndexOf("/"));
                         }
                         if (newpath.Contains("?"))
                         {
                              newpath = newpath.Substring(0, newpath.IndexOf("?") + 1);
                         }
                    }

                    if (String.IsNullOrEmpty(HttpContext.Current.Request.QueryString["org"]))
                    {
                         query = "org=" + org + "&" + query;
                    }

                    if (newpath.EndsWith("/"))
                    {
                         newpath += "Default.aspx";
                    }
                    else if (!newpath.ToLower().EndsWith(".aspx"))
                    {
                         newpath += ".aspx";
                    }

                    if (ConfigurationManager.AppSettings["debug"] == "yes")
                    {
                         string logmsg = "WeavverHttpModule: Url: " + url + " Path: " + path + " New Path: " + newpath + " -- " + HttpContext.Current.Request.PathInfo;
                         Weavver.Utilities.ErrorHandling.SendError(new Exception(logmsg));
                    }

                    string filePath = HttpContext.Current.Server.MapPath(newpath);
                    if (!System.IO.File.Exists(filePath))
                         newpath = "/System/HTTP404.aspx";

                    HttpContext.Current.RewritePath(newpath, null, query, false);
               }

               Debug.Assert(app.Session != null, "it did not work :(");
          }
//-------------------------------------------------------------------------------------------
          public void Dispose()
          {

          }
//-------------------------------------------------------------------------------------------
          //void app_EndRequest(object sender, EventArgs e)
          //{
//               //send_message_chat message = new send_message_chat();
//               //message.from = "weavver.com";
//               //message.body = "WeavverHttpModule: EndRequest: " + HttpContext.Current.Items["vanityurl"];
//               //message.to = System.Configuration.ConfigurationManager.AppSettings.Get("admin_address");
//               //ejabberdRPC rpc = new ejabberdRPC();
//               //rpc.SendMessageChat(message);
//          }
////-------------------------------------------------------------------------------------------
          // from: http://stackoverflow.com/questions/276355/can-i-access-session-state-from-an-httpmodule/7400727
          // a temp handler used to force the SessionStateModule to load session state
          public class MyHttpHandler : IHttpHandler, IRequiresSessionState
          {
               internal readonly IHttpHandler OriginalHandler;

               public MyHttpHandler(IHttpHandler originalHandler)
               {
                    OriginalHandler = originalHandler;
               }

               public void ProcessRequest(HttpContext context)
               {
                    // do not worry, ProcessRequest() will not be called, but let's be safe
                    throw new InvalidOperationException("MyHttpHandler cannot process requests.");
               }

               public bool IsReusable
               {
                    // IsReusable must be set to false since class has a member!
                    get { return false; }
               }
          }
//-------------------------------------------------------------------------------------------
     }
}