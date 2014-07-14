using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.DynamicData;

using Weavver.Data;
using Weavver.Data.ExtensionMethods;
using Weavver.Vendors.ProcessOne;

namespace Weavver.Web
{
     public class WeavverHttpModule : IHttpModule, IReadOnlySessionState
     {
//-------------------------------------------------------------------------------------------
          public void Init(HttpApplication application)
          {
               application.BeginRequest += new EventHandler(application_BeginRequest);
          }
//-------------------------------------------------------------------------------------------
          void application_BeginRequest(object sender, EventArgs e)
          {
               HttpApplication app = (HttpApplication)sender;

               string url = app.Context.Request.Url.ToString(); // url: http://www.weavver.local/default.aspx
               string path = app.Context.Request.Path; // path: /default.aspx OR /org/default/company/services/hosting/
               string exten = System.IO.Path.GetExtension(app.Context.Request.Path);
               string newpath = path;

               string[] pathparts = path.Split('/');

               string query = "";
               if (HttpContext.Current.Request.QueryString.HasKeys())
               {
                    query += HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString.ToString());
               }

               // examples to process:
               //        /system/http404.aspx
               //        /images/x.jpg
               //        /weavver/Marketing_PressReleases/
               //        /weavver/Logistics_Organizations.aspx?id=
               //        /Default.aspx
               //        /
               if (exten == ".axd" || System.IO.File.Exists(path))
               {
                    return;
               }

               if (path.StartsWith("_"))
               {
                    HttpContext.Current.RewritePath(newpath, null, query, false);
                    newpath = path.Substring(1);
                    return;
               }

               if (newpath.EndsWith("/"))
               {
                    newpath += "Default.aspx";
                    exten = ".aspx";
               }
               
               if (exten == "")
               {
                    if (!newpath.ToLower().EndsWith(".aspx"))
                    {
                         newpath += ".aspx";
                    }
               }

               string filePath = HttpContext.Current.Server.MapPath(newpath);
               if (System.IO.File.Exists(filePath))
               {
                    HttpContext.Current.RewritePath(newpath, null, query, false);
                    return;
               }

               // if the url ends with no extension like so: http://weavver.local/this/page
               // then we add the .aspx page extension so we can check if there is actually an aspx page we should forward to

               if (System.Configuration.ConfigurationManager.AppSettings["debug"] == "yes")
               {
                    string logmsg = "WeavverHttpModule: Url: " + url + " Path: " + path + " New Path: " + newpath + " -- " + HttpContext.Current.Request.PathInfo;
                    Weavver.Utilities.ErrorHandling.SendError(new Exception(logmsg));
               }

               if (pathparts.Length > 1)
               {
                    // checks for dynamic urls (pages/content that only lives in the database)
                    using (Weavver.Data.WeavverEntityContainer data = new Weavver.Data.WeavverEntityContainer())
                    {
                         int startIndex = (newpath.NthIndexOf("/", 2) > 0) ? newpath.NthIndexOf("/", 2) : 0; // starts with: /weavver/about/example/url
                         string orgName = pathparts[1]; // grabs: weavver/about/example/url
                         string orgSubPath = newpath.Substring(startIndex); // grabs: about/example/url

                         if (String.IsNullOrEmpty(query))
                              query = "org=" + pathparts[1];
                         else
                              query = "org=" + pathparts[1] + "&" + query;

                         // catch cases where the path could be:
                         //        /weavver/ or
                         //        /weavver/somefolder/
                         if (orgSubPath.EndsWith("/"))
                         {
                              orgSubPath += "Default.aspx";
                         }

                         if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(orgSubPath)))
                         {
                              HttpContext.Current.RewritePath(orgSubPath, null, query, false);
                              return;
                         }

                         var selectedOrg = (from y in data.Logistics_Organizations
                                             where y.VanityURL == orgName
                                             select y).FirstOrDefault();

                         if (selectedOrg != null)
                         {
                              var rawSubPath = path.Substring(path.NthIndexOf("/", 2));
                              var dynamicUrl = (from x in data.System_URLs
                                                where x.Path == rawSubPath &&
                                                       x.OrganizationId == selectedOrg.Id
                                                  select x).FirstOrDefault();

                              if (dynamicUrl != null)
                              {
                                   query += "&Id=" + dynamicUrl.ObjectId.ToString();
                                   HttpContext.Current.RewritePath("~/" + dynamicUrl.TableName + "/" + dynamicUrl.PageTemplate + ".aspx", null, query, false);
                                   return;
                              }
                              else
                              {
                                   // might be a path into the DynamicData folder
                                   HttpContext.Current.RewritePath("~"+ orgSubPath, null, query, false);
                              }
                         }
                    }
                    //newpath = "~/System/HTTP404.aspx";
               }
          }
//-------------------------------------------------------------------------------------------
          public void Dispose()
          {

          }
//-------------------------------------------------------------------------------------------
     }
}