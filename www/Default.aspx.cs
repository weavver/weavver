using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Weavver.Data;

public partial class WeavverDefault : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          Master.SetChatVisibility(true);
          Master.FindControlR<Control>("HeaderLogo").Visible = false;
          Master.FindControlR<Control>("NavigationBox").Visible = false;
          IsPublic = true;
          HasHeader = !true;
          Master.Width = "850px";

          RegisterControl regControl = (RegisterControl)LoginView1.FindControl("RegisterUser");
          if (regControl != null)
          {
               regControl.AccountActivated += new EventHandler(regControl_AccountActivated);
          }
     }
     //((HtmlControl)Master.FindControl("body")).Attributes["background-image"] = "asdf";
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          string msg = "querystring: " + System.Web.HttpUtility.UrlDecode(Request.QueryString.ToString());
          //Response.Write(msg + "<br />");

          //Products.Visible = (LoggedInUser != null && LoggedInUser.OrganizationId == new Guid("0baae579-dbd8-488d-9e51-dd4dd6079e95"));

          using (WeavverEntityContainer containers = new WeavverEntityContainer())
          {
               var pressrelease = (from x in containers.Marketing_PressReleases
                                   where x.OrganizationId == SelectedOrganization.Id
                                   orderby x.PublishAt descending
                                   select x).Take(1);

               NewsList.DataSource = pressrelease;
               NewsList.DataBind();
          }

          Logo.Src = GetLogoPath();

          if (Logo.Src.Contains("mycompany.png"))
               Logo.Style["max-width"] = "480px";

          if (Request.Url.Host != "www.weavver.local" &&
              Request.Url.Host != "www.weavver.local" &&
              Request.Url.Host != "www.weavver.com" &&
              Request.Url.Host != "weavver.com")
          {
               Notice.InnerHtml = "Weavver&reg; is a framework for building an open and transparent internet company. <a href='#' style='color:white; text-decoration:underline;'>Click here</a> to change this text.";
          }
     }
//-------------------------------------------------------------------------------------------
     void regControl_AccountActivated(object sender, EventArgs e)
     {
          Response.Redirect("~/", true);
     }
//-------------------------------------------------------------------------------------------
}