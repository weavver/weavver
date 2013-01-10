using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using Weavver.Data;

public partial class LogOut : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          //WeavverMaster.DiscussionEnabled = false;
          WeavverMaster.FormTitle = "Thank you, please come again!";
          WeavverMaster.FixedWidth = true;
          ActivationRequired = false;
          IsPublic = true;
          Request.Cookies.Clear();
          FormsAuthentication.SignOut();
          Session.Clear();
          Session.Abandon();
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          Master.SetToolbarVisibility(false);
          Master.FindControlR<Control>("SignInArea").Visible = false;
          Master.FindControlR<Control>("OrganizationsList").Visible = false;

          HtmlMeta meta = new HtmlMeta();
          meta.HttpEquiv = "refresh";
          string url = Request.Url.Scheme + "://" + Request.Url.Host + Request.Path;
          url = url.Substring(0, url.LastIndexOf("/"));
          url = url.Substring(0, url.LastIndexOf("/"));
          meta.Content = "60;url=" + url;
          this.Header.Controls.Add(meta);
     }
//-------------------------------------------------------------------------------------------
}