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
          Guid selectedOrganizationId = Guid.Empty;
//-------------------------------------------------------------------------------------------
          public void Init(HttpApplication application)
          {
               application.BeginRequest += new EventHandler(Application_BeginRequest);
               application.AcquireRequestState += new EventHandler(application_AcquireRequestState);
               //this.app.EndRequest += new EventHandler(Application_EndRequest);
          }
//-------------------------------------------------------------------------------------------
          void application_AcquireRequestState(object sender, EventArgs e)
          {
               HttpApplication app = (HttpApplication)sender;
               if (HttpContext.Current.Session != null)
               {
                    if (HttpContext.Current.Items["SelectedOrganizationId"] != null)
                    {
                         HttpContext.Current.Session["test"] = "hello";
                         HttpContext.Current.Session["SelectedOrganizationId"] = HttpContext.Current.Items["SelectedOrganizationId"];
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          public void Application_BeginRequest(object sender, EventArgs e)
          {
               HttpApplication app = (HttpApplication)sender;

               string url = app.Context.Request.Url.ToString(); // url: http://www.weavver.local/default.aspx
               string path = app.Context.Request.Path; // path: /default.aspx OR /org/default/company/services/hosting/
               string exten = System.IO.Path.GetExtension(app.Context.Request.Path);
               string newpath = path;
               string query = "";
               string org = "default";
               if (url.Contains(".asmx/")) // protects autocomplete
                    return;

               if (HttpContext.Current.Request.QueryString.HasKeys())
               {
                    query += HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString.ToString());
               }
               if (ConfigurationManager.AppSettings["install_mode"] == "false")
               {
                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         var dynamicUrl = (from x in data.System_URLs
                                           where x.Path == path
                                           select x).FirstOrDefault();

                         if (dynamicUrl != null)
                         {
                              query = "Id=" + dynamicUrl.ObjectId.ToString();
                              HttpContext.Current.RewritePath("/" + dynamicUrl.TableName + "/" + dynamicUrl.PageTemplate + ".aspx", null, query, false);
                              return;
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

                    HttpContext.Current.RewritePath(newpath, null, query, false);
               }
          }
//-------------------------------------------------------------------------------------------
          void app_EndRequest(object sender, EventArgs e)
          {
               //send_message_chat message = new send_message_chat();
               //message.from = "weavver.com";
               //message.body = "WeavverHttpModule: EndRequest: " + HttpContext.Current.Items["vanityurl"];
               //message.to = System.Configuration.ConfigurationManager.AppSettings.Get("admin_address");
               //ejabberdRPC rpc = new ejabberdRPC();
               //rpc.SendMessageChat(message);
          }
//-------------------------------------------------------------------------------------------
          public void Dispose()
          {
          }
//-------------------------------------------------------------------------------------------
     }
}