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
using System.IO;

public partial class WeavverDefault : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          RequiresSelectedOrg = false;
          Master.SetChatVisibility(true);
          //Master.FindControlR<Control>("HeaderLogo").Visible = false;
          //Master.FindControlR<Control>("NavigationBox").Visible = false;
          IsPublic = true;
          //HasHeader = !true;
          Master.FixedWidth = false;

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
          if (LoggedInUser != null)
          {
               var orgURL = (from x in Data.Logistics_Organizations
                          where x.OrganizationId == LoggedInUser.OrganizationId
                          select x).First().VanityURL;

               //Response.Redirect("~/" + orgURL + "/dashboard.aspx");
          }

          //Logo.Src = GetHomeLogoPath();

          if (Logo.Src.Contains("mycompany.png"))
               Logo.Style["max-width"] = "480px";

          if (Request.Url.Host != "www.weavver.local" &&
              Request.Url.Host != "www.weavver.local" &&
              Request.Url.Host != "www.weavver.com" &&
              Request.Url.Host != "weavver.com")
          {
               WeavverMaster.FormDescription = "Weavver&reg; is a framework for building an open and transparent internet company. <a href='#' style='color:white; text-decoration:underline;'>Click here</a> to change this text.";
          }
          else
          {
               WeavverMaster.FormDescription = "Weavver&reg; is an <a href=\"/weavver/source/\" style=\"text-decoration: underline;\">open source</a> biodigital organism. The intelligence is programmed in by you and is therefore constantly updated and evolved. <a href='/weavver/products/weavver/'>[learn more]</a>";
               //WeavverMaster.FixedWidth = true;
               //WeavverMaster.MaxWidth = "960px";
          }
          WeavverMaster.Width = "100%";
     }
//-------------------------------------------------------------------------------------------
     void regControl_AccountActivated(object sender, EventArgs e)
     {
          Response.Redirect("~/", true);
     }
//-------------------------------------------------------------------------------------------
}