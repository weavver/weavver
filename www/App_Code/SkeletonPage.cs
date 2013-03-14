using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using Weavver.Data;
using Weavver.Security;
//using Weavver.Sys;
using Weavver.Vendors.ProcessOne;
using Weavver.Web;

using System.Linq;
using Weavver.Utilities;
using System.Reflection;
using System.Data.Objects.DataClasses;
using AjaxControlToolkit;

using System.Web.DynamicData;
using System.Data.Objects.DataClasses;

/// <summary>
/// Summary description for SkeletonPage
/// </summary>
public class SkeletonPage : Weavver.Web.SkeletonPage
{
//-------------------------------------------------------------------------------------------
     public TimeZoneInfo BrowserTZI = null;
     public GlobalSettings Settings = null;
     public bool RunCustomValidationJs = false;
     public string LogInURL = "~/account/login";
     private Logistics_Organizations _selectedOrganization = null;
     private bool _IsPublic = false;
     private bool _HasHeader = true;
     public bool ActivationRequired = true;
     private System_User _LoggedInUser = null;
     public string BaseURL { get { return Request.Url.Scheme + "://" + Request.Url.Host; } }
//-------------------------------------------------------------------------------------------
     public Sales_ShoppingCarts ShoppingCart
     {
          get
          {
               if (Session["ShoppingCart"] == null)
                    Session["ShoppingCart"] = new Sales_ShoppingCarts();

               return (Sales_ShoppingCarts) Session["ShoppingCart"];
          }
     }
//-------------------------------------------------------------------------------------------
     public WeavverMasterPageInterface WeavverMaster
     {
          get
          {
               return Master as WeavverMasterPageInterface;
          }
     }
//-------------------------------------------------------------------------------------------
     public enum AccessType
     {
          None, Read, Write, ReadWrite
     }
//-------------------------------------------------------------------------------------------
     /// <summary>
     /// Flipping this to true will immediately redirect the remote browser port 443.
     /// </summary>
     public bool RequiresSSL
     {
          set
          {
               if (value == true)
               {
                    if (Request.Url.Scheme == "http" && ConfigurationManager.AppSettings["require_ssl"] == "true")
                    // Request.UserHostAddress != "127.0.0.1")
                    {
                         string newurl = "https" + Request.Url.AbsoluteUri.Substring(4);
                         Response.Redirect(newurl, true);
                    }
               }
          }
     }
//-------------------------------------------------------------------------------------------
     public bool DiscussionEnabled
     {
          get
          {
               return this.FindControlR<Control>("CommentsModule").Visible;
          }
          set
          {
               this.FindControlR<Control>("CommentsModule").Visible = value;
          }
     }
//-------------------------------------------------------------------------------------------
     public System_User LoggedInUser
     {
          get
          {
               if (_LoggedInUser == null)
               {
                    WeavverMembershipUser memUser = null;
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                         memUser = (WeavverMembershipUser) Membership.GetUser();
                         _LoggedInUser = memUser.WeavverSysUser;
                    }
               }
               return _LoggedInUser;
          }
          set
          {
               _LoggedInUser = value;
          }
     }
//-------------------------------------------------------------------------------------------
     public Logistics_Organizations SelectedOrganization
     {
          get
          {
               return _selectedOrganization;
          }
          set
          {
               _selectedOrganization = value;
               Session["SelectedOrganizationId"] = value.Id;
               Roles.ApplicationName = value.Id.ToString();
          }
     }
//-------------------------------------------------------------------------------------------
     public bool IsPublic
     {
          get { return _IsPublic; }
          set
          {
               _IsPublic = value;
               if (_IsPublic == false && LoggedInUser == null)
                    Response.Redirect("~/", true);
          }
     }
//-------------------------------------------------------------------------------------------
     public bool HasHeader
     {
          get { return _HasHeader; }
          set { _HasHeader = value; }
     }
//-------------------------------------------------------------------------------------------
     public SkeletonPage()
     {
          PreInit += new EventHandler(SkeletonPage_PreInit);
          //Init  += new EventHandler(SkeletonPage_Init);
          //Load  += new EventHandler(SkeletonPage_Load);
          //Error += new EventHandler(SkeletonPage_Error);
          Unload += new EventHandler(SkeletonPage_Unload);


          // we disable this because http calls to remote webservices (like the OFX stuff does) is significantly slowed down by proxy detection
          System.Net.WebRequest.DefaultWebProxy = null;
     }
//-------------------------------------------------------------------------------------------
     void SkeletonPage_PreInit(object sender, EventArgs e)
     {
          //Roles.ApplicationName = SelectedOrganization.Id.ToString();
     }
//-------------------------------------------------------------------------------------------
     public Control FindControlRecursive(Control Root, string Id)
     {
          if (Root.ID == Id)
               return Root;

          foreach (Control Ctl in Root.Controls)
          {
               Control FoundCtl = FindControlRecursive(Ctl, Id);
               if (FoundCtl != null)
                    return FoundCtl;
          }

          return null;
     }
//-------------------------------------------------------------------------------------------
     protected override void OnPreInit(EventArgs e)
     {
          if (SelectedOrganization == null)
          {
               if (Session["SelectedOrganizationId"] == null)
               {
                    string vanityurl = (Request["org"] == null) ? "default" : Request["org"];
                    vanityurl = vanityurl.Replace("default,default", "default");
                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         SelectedOrganization = (from x in data.Logistics_Organizations
                                                  where x.VanityURL == vanityurl
                                                  select x).First();

                         data.Logistics_Organizations.Detach(_selectedOrganization);
                    }
               }
               else
               {
                    Guid selectedOrgId = new Guid(Session["SelectedOrganizationId"].ToString());
                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         SelectedOrganization = (from x in data.Logistics_Organizations
                                                  where x.Id == selectedOrgId
                                                  select x).First();
                    }
               }
          }
          base.OnPreInit(e);
     }
//-------------------------------------------------------------------------------------------
     protected override void OnInit(EventArgs e)
     {
          if (Request.Cookies["TimeZoneName"] != null)
               BrowserTZI = DateTimeHelper.OlsonTimeZoneToTimeZoneInfo(Request.Cookies["TimeZoneName"].Value);
          if (ConfigurationManager.AppSettings["install_mode"] == "true" &&
             !Request.Path.ToLower().StartsWith("/install/") &&
             !Request.Path.ToLower().StartsWith("/system/maintenance"))
          {
               if (Request.UserHostAddress == "127.0.0.1")
               {
                    Response.Redirect("~/install/", true);
               }
               else
               {
                    Response.Redirect("/system/maintenance", true);
               }
          }

          if (Form != null)
          {
               string actionpath = Request.PathInfo.Replace(".aspx", "");
               Form.Action = (actionpath.ToLower().EndsWith("default")) ? actionpath.Substring(0, actionpath.ToLower().IndexOf("default")) : actionpath;
          }
          string query = "";
          for (int i = 0; i < Request.QueryString.Keys.Count; i++)
          {
               string key = Request.QueryString.Keys[i];
               if (key != "org")
               {
                    query += key + "=" + Request.QueryString[key];

                    if (i < Request.QueryString.Keys.Count - 1)
                    {
                         query += "&";
                    }
               }
          }
          // append the query string
          if (Form != null && query != "")
               Form.Action += "?" + query;

          if (RunCustomValidationJs)
          {
               HtmlControl hControl = (HtmlControl) FindControlRecursive(Master, "Body");
               hControl.Attributes.Add("onsubmit", "return ValidateChecked();");
          }
          base.OnInit(e);
     }
//-------------------------------------------------------------------------------------------
     protected override void OnLoad(EventArgs e)
     {
          base.OnLoad(e);

          Literal a = (Literal) Page.FindControl("AccountLabel");
          if (a != null)
          {
               a.Text = Page.User.Identity.Name;
          }
          if (Master != null)
          {
               Control headerLogo = Master.FindControl("HeaderLogo");
               if (headerLogo != null)
               {
                    headerLogo.Visible = HasHeader;
               }
          }

          if (!User.Identity.IsAuthenticated && !IsPublic)
          {
               Response.Redirect(LogInURL, true);
          }

          if (LoggedInUser != null)
          {
               if (!LoggedInUser.Activated && ActivationRequired && !IsPublic)
               {
                    //DebugOut(Request.Url.LocalPath);
                    Response.Redirect("~/account/activate", true);
               }

               if (LoggedInUser.Activated && LoggedInUser.OrganizationId == Guid.Empty)
               {
                    if (!Request.Path.ToLower().StartsWith("/logistics_organizations")) //(LoggedInUser.Id != new Guid("6bb552e9-debb-40d3-a5a9-60329aedeaac") 
                    {
                         Response.Redirect("~/logistics_organizations", true);
                    }
               }
          }

          //Control Banner = Master.FindControl("Banner");
          //if (Banner != null)
          //{
          //     Control BannerWrapper = Banner.FindControl("BannerWrapper");
          //     if (BannerWrapper != null)
          //          BannerWrapper.Visible = HasHeader;
          //}



          if (Request.UrlReferrer != null)
          {
               DebugOut(Request.UrlReferrer.AbsoluteUri);
          }

          if (LoggedInUser != null &&
              LoggedInUser.Id == new Guid("6bb552e9-debb-40d3-a5a9-60329aedeaac"))
          {
               if (Session["ReferredBy"] != null)
               {
                    DebugOut("ReferredBy: " + Session["ReferredBy"]);
               }
          }

          if (Session["ReferredBy"] == null &&
              Request.UrlReferrer != null)
          {
               string myreferrer = Request.UrlReferrer.ToString();
               Session.Add("ReferredBy", myreferrer);
          }

     }
//-------------------------------------------------------------------------------------------
     public string GetLogoPath()
     {
          if (SelectedOrganization != null)
          {
               if (SelectedOrganization.Id == new Guid("0baae579-dbd8-488d-9e51-dd4dd6079e95"))
                    return "/images/logo.png";

               string filename = SelectedOrganization.Id.ToString();
               if (File.Exists(Server.MapPath("~/uploads/" + filename + ".png")))
               {
                    return "~/uploads/" + filename + ".png";
               }
               if (File.Exists(Server.MapPath("~/uploads/" + filename + ".jpg")))
               {
                    return "~/uploads/" + filename + ".jpg";
               }
               //Response.Write(filename);
          }
          return "~/images/mycompany.png";
     }
//-------------------------------------------------------------------------------------------
     public void GenerateMenu(TableActions currentPage, Type type)
     {
          MetaTable table = DynamicDataRouteHandler.GetRequestMetaTable(Context);

          string[] roles = Roles.GetRolesForUser();
          if (roles.Length == 0)
               roles = new string[] { "Guest" };
          var tablePermissions = table.Attributes.OfType<SecureTableAttribute>();
          foreach (var att in tablePermissions)
          {
               if (att.HasAnyRole(roles))
               {
                    switch (att.Actions)
                    {
                         case TableActions.List:
                         case TableActions.Showcase:
                         case TableActions.PressRoll:
                              WeavverMenuItem mi = new WeavverMenuItem();
                              mi.Name = att.Actions.ToString();
                              mi.Link = "/" + table.EntityType.ToString().Replace("Weavver.Data.", "") + "/" + att.Actions.ToString() + ".aspx";
                              WeavverMaster.ViewsMenuAdd(mi);
                              break;

                         case TableActions.Edit:
                         case TableActions.Delete:
                              if (currentPage == TableActions.Details ||
                                  currentPage == TableActions.Page)
                              {
                                   WeavverMenuItem actionItem = new WeavverMenuItem();
                                   actionItem.Name = att.Actions.ToString();
                                   actionItem.Link = "/" + table.EntityType.ToString().Replace("Weavver.Data.", "") + "/" + att.Actions.ToString() + ".aspx?Id=" + Request["Id"];
                                   WeavverMaster.ActionsMenuAdd(actionItem);
                              }
                              break;
                    }
               }
          }


          MethodInfo[] methods = type.GetMethods();
          foreach (MethodInfo method in methods)
          {
               bool isWebAccessible = false;
               foreach (object attrib in method.GetCustomAttributes(true))
               {
                    if (attrib.GetType() == typeof(DynamicDataWebMethod))
                    {
                         LinkButton webMethod = new LinkButton();
                         webMethod.ID = "DynamicMethod_" + method.Name;
                         webMethod.Text = ((DynamicDataWebMethod)attrib).MethodName;
                         webMethod.CommandName = method.Name;
                         webMethod.Click += new EventHandler(DynamicWebMethod_Click);
                         webMethod.CssClass = "attachmentLink";

                         //WebMethods.Controls.Add(webMethod);
                         Master.FindControl("Attachments").Controls.Add(webMethod);
                         break;
                    }
               }
          }
     }
//-------------------------------------------------------------------------------------------
     protected void DynamicWebMethod_Click(object sender, EventArgs e)
     {
          FormView DataForm = Page.FindControlR<FormView>("FormView1");
          if (DataForm.DataItem == null)
               DataForm.DataBind();

          LinkButton lButton = (LinkButton) sender;
          var obj = Weavver.Data.EntityDataSourceExtensions.GetItemObject<EntityObject>(DataForm.DataItem);
          MethodInfo method = obj.GetType().GetMethod(lButton.CommandName);
          var methodDefinition = (DynamicDataWebMethod) method.GetCustomAttributes(true)[0]; // typeof(DynamicDataWebMethod));
          bool authorized = false;
          foreach (string role in methodDefinition.Roles)
          {
               if (Roles.IsUserInRole(role))
               {
                    authorized = true;
                    break;
               }
          }

          string messageTitle = "";
          string messageBody = "";
          string redirectUrl = null;
          if (authorized)
          {
               try
               {
                    var ret = (DynamicDataWebMethodReturnType)method.Invoke(obj, null);
                    if (ret == null)
                    {
                         messageTitle = "Error";
                         messageBody = "This method has not been fully implemented.";
                    }
                    else
                    {
                         if (ret.FilePath != null && File.Exists(ret.FilePath))
                         {
                              Response.ContentType = ret.FileMimeType;
                              Response.AddHeader("Content-Disposition", String.Format("attachment;filename=\"{0}\"", ret.FileName));
                              Response.WriteFile(ret.FilePath);
                              Response.End();
                         }

                         if (ret.Status != null)
                         {
                              messageTitle = ret.Status;
                              messageBody = ret.Message.Replace("\r\n", "<br />");

                              if (ret.RedirectRequest)
                              {
                                   redirectUrl = ret.RedirectURL;
                              }
                         }
                         else if (ret.RedirectRequest)
                         {
                              Response.Redirect(ret.RedirectURL);
                         }
                    }
               }
               catch (Exception ex)
               {
                    Weavver.Utilities.ErrorHandling.LogError(Request, Request.RawUrl, ex);
                    messageTitle = "Exception";
                    messageBody = ex.ToString();
               }
          }
          else
          {
               messageTitle = "Unauthorized";
               messageBody = "You are not authorized to access this command.";
          }

          string escapedTitle = messageTitle.Replace("'", @"\'");
          string escapedBody = messageBody.Replace("'", @"\'");
          string escapedURL = (redirectUrl == null) ? "null" : "'" + redirectUrl + "'";

          string popUpJS = "<script type='text/javascript'>"
                          + String.Format("showMessage('{0}', '{1}', {2});\r\n", escapedTitle, escapedBody, escapedURL)
                          + "</script>";


          Page.RegisterStartupScript("notification", popUpJS);
     }
//-------------------------------------------------------------------------------------------
     protected override void OnError(EventArgs e)
     {
          Session["error"] = Server.GetLastError();
          Session["errorurl"] = Request.Url.ToString();
          Response.Redirect("~/system/error.aspx");

          base.OnError(e);
     }
//-------------------------------------------------------------------------------------------
     public void ShowError(Exception ex, string friendlyError)
     {
          Response.Write(friendlyError);
     }
//-------------------------------------------------------------------------------------------
     public void ShowError(string errormessage)
     {
          MasterPage master = Master;
          if (Master.Master != null)
               master = Master.Master;
          HtmlControl divErrorLayer = (HtmlControl) master.FindControl("ErrorLayer");
          Literal litErrorMessage = (Literal) master.FindControl("ErrorMessage");
          divErrorLayer.Visible = true;
          if (litErrorMessage.Text != errormessage)
               litErrorMessage.Text += errormessage;
     }
//-------------------------------------------------------------------------------------------
     public void ClearError()
     {
          MasterPage master = Master;
          if (Master.Master != null)
               master = Master.Master;
          HtmlControl divErrorLayer = (HtmlControl) master.FindControl("ErrorLayer");
          Literal litErrorMessage = (Literal) master.FindControl("ErrorMessage");
          divErrorLayer.Visible = false;
          litErrorMessage.Text = "";
     }
//-------------------------------------------------------------------------------------------
     public void DebugOut(string output)
     {
          DebugOut(output, (ConfigurationManager.AppSettings["debug"] == "yes"));
     }
//-------------------------------------------------------------------------------------------
     public void DebugOut(string output, bool debug)
     {
          if (debug)
          {
               Weavver.Utilities.ErrorHandling.LogError(Request, Request.RawUrl, new Exception(output));
          }
     }
//-------------------------------------------------------------------------------------------
     private void SkeletonPage_Unload(object sender, EventArgs e)
     {
     }
//-------------------------------------------------------------------------------------------
}
