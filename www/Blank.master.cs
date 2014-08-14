using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weavver.Data;

public partial class Blank : MasterPage, WeavverMasterPageInterface
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          string js = "<script type='text/javascript'>var windowId = '{0}'; var parentId = '{1}';</script>";
          ScriptVars.Text = String.Format(js, Request["WindowId"], Request["ParentId"]);

          string url = Request.Url.PathAndQuery.ToString().Replace("?IFrame=true&", "?");
          PageLink.HRef = url;
          PageLink.HRef = FormatURLs("~" + url.Replace("&IFrame=true", ""));

          Page.Header.DataBind();
     }
//-------------------------------------------------------------------------------------------
     public string FormTitle
     {
          set
          {
               Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "formtitle",  @"
                    <script type='text/javascript'>
                    $(document).ready(function () {
                         var windowId = getParameterByName('WindowId');
                         window.parent.$('#' + windowId).dialog('option', 'title', '" + value + @"');
                    });
                    </script>");
          }
     }
//-------------------------------------------------------------------------------------------
     public string FormDescription
     {
          set
          {
               Description.Text = value;
               DescriptionLayer.Visible = (!String.IsNullOrEmpty(Description.Text));
          }
     }
//-------------------------------------------------------------------------------------------
     public void ActionsMenuAdd(Weavver.Web.WeavverMenuItem item)
     {
          //throw new NotImplementedException();
     }
//-------------------------------------------------------------------------------------------
     public void ViewsMenuAdd(Weavver.Web.WeavverMenuItem item)
     {
          //throw new NotImplementedException();
     }
//-------------------------------------------------------------------------------------------
     public void SetToolbarVisibility(bool visible)
     {
          //throw new NotImplementedException();
     }
//-------------------------------------------------------------------------------------------
     public bool FixedWidth
     {
          get
          {
               //throw new NotImplementedException();
               return true;
          }
          set
          {
          }
     }
//-------------------------------------------------------------------------------------------
     public void ToolBarMenuAdd(Weavver.Web.WeavverMenuItem item)
     {
     }
//-------------------------------------------------------------------------------------------
     public void SetChatVisibility(bool visible)
     {
     }
//-------------------------------------------------------------------------------------------
     public string Width
     {
          get
          {
               return Width;
          }
          set
          {
          }
     }
//-------------------------------------------------------------------------------------------
     public string MaxWidth
     {
          get
          {
               return null;
          }
          set
          {
          }
     }
//-------------------------------------------------------------------------------------------
     public SkeletonPage BasePage
     {
          get
          {
               if (Page.GetType().IsSubclassOf(typeof(SkeletonPage)))
               {
                    return (SkeletonPage) Page;
               }
               else
               {
                    return null;
               }
          }
     }
//-------------------------------------------------------------------------------------------
     /// <summary>
     /// Only call this instead of ResolveUrl if we want to make sure the organization name is in the url
     /// </summary>
     /// <param name="str"></param>
     /// <returns></returns>
     //DUPLICATED IN BLANK.MASTER - UPDATE THERE AS WELL 
     public string FormatURLs(string str)
     {
          //string appPath = HttpContext.Current.Request.ApplicationPath;

          //Ensure the app path ends w/ a slash
          //if (!appPath.EndsWith("/"))
          //   appPath += "/";

          string basepath = (BasePage == null || BasePage.SelectedOrganization == null) ? "~/" : "~/" + BasePage.SelectedOrganization.VanityURL + "/";
          //string orgname = (BasePage == null || BasePage.SelectedOrganization == null) ? BasePage.SelectedOrganization.VanityURL : "";
          return str.Replace("~/", Page.ResolveUrl(basepath)); //.Replace("%orgname%", orgname);
     }
//-------------------------------------------------------------------------------------------
}
