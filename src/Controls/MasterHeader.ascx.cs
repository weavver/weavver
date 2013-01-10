using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Weavver.Data;

public partial class Controls_MasterHeader : WeavverUserControl
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          OrganizationsList.SelectedIndexChanged += new EventHandler(OrganizationsList_SelectedIndexChanged);

          ////// This prevents additional errors from occuring if the error page is triggered (possibly due to the database being unavailable.)
          ////if (Request.Url.PathAndQuery.StartsWith("/system/error"))
          ////{
          ////     BasePage.WeavverMaster.SetToolbarVisibility(false);
          ////     HtmlAnchor sLink = (HtmlAnchor)LoginView1.FindControl("SignInLink");
          ////     if (sLink != null)
          ////          sLink.HRef = "~/account/login";
          ////     else
          ////          SignInArea.Visible = false;
          ////     return;
          ////}

          if (HttpContext.Current.User.Identity.IsAuthenticated)
          {
               Label userName = (Label)LoginView1.FindControl("UsernameLabel");
               if (userName != null)
               {
                    userName.Text = HttpContext.Current.User.Identity.Name;
               }
          }

          Control regLink = RegisterLogInPanel.FindControl("LoginView1").FindControl("RegisterLink");
          if (regLink != null)
          {
               regLink.Visible = !(Request.Url.PathAndQuery.StartsWith("/account/register"));

               if (regLink.Visible && Request.Url.PathAndQuery.StartsWith("/default"))
                    regLink.Visible = false;
          }


//          if (BasePage != null)
//          {
//               HeaderLogo.Src = BasePage.GetLogoPath();
//               if (BasePage != null && BasePage.SelectedOrganization != null)
//               {
//                    if (HeaderLogo.Src.Contains("mycompany.png"))
//                    {
//                         //HeaderLogo.Style["margin-top"] = "15px";
//                         HeaderLogo.Style["margin"] = "15px";
//                    }
//               }

//               if (BasePage.ShoppingCart.Items.Count > 0 && !Request.Url.PathAndQuery.Contains("shoppingcart"))
//               {
//                    string txt = "Shopping Cart - " + BasePage.ShoppingCart.Items.Count + " item(s)<br /><br />";
//                    //if (BasePage.ShoppingCart.MonthlyTotal > 0)
//                    //     txt += "Monthly: " + BasePage.ShoppingCart.MonthlyTotal.ToString("C") + "<br /><br />";
//                    //txt += "Total: " + BasePage.ShoppingCart.Total.ToString("C");
// MasterPageAddAttachmentLink(txt, "~/workflows/sales_orderreview", "Shopping Cart");
//               }
//          }

          if (!IsPostBack)
          {
               UpdatePage();
          }
    }
//-------------------------------------------------------------------------------------------
     public void UpdatePage()
     {
          OrganizationsList.Visible = false;
          if (BasePage != null && BasePage.SelectedOrganization != null)
          {
               // User is Logged In
               if (BasePage.LoggedInUser != null
                    // && BasePage.LoggedInUser.Id == new Guid("6bb552e9-debb-40d3-a5a9-60329aedeaac")
                    && !Request.Path.ToLower().EndsWith("/account/logout.aspx"))
               {

                    OrganizationsList.Visible = true;

                    if (!IsPostBack && BasePage.LoggedInUser.OrganizationId != new Guid("0baae579-dbd8-488d-9e51-dd4dd6079e95"))
                    {
                         using (WeavverEntityContainer data = new WeavverEntityContainer())
                         {
                              var org = (from x in data.Logistics_Organizations
                                             where x.Id == BasePage.LoggedInUser.OrganizationId
                                             select x).First();

                              OrganizationsList.Items.Add(new ListItem(org.Name, org.Id.ToString()));

                              OrganizationsList.SelectedValue = BasePage.SelectedOrganization.Id.ToString();
                         }
                    }
               }
          }
     }
//-------------------------------------------------------------------------------------------
     void OrganizationsList_SelectedIndexChanged(object sender, EventArgs e)
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               var org = (from x in data.Logistics_Organizations
                              where x.Id == new Guid(OrganizationsList.SelectedValue)
                              select x).First();

               BasePage.SelectedOrganization = org;
               Response.Redirect("~/");
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Organizations_ItemSelected(string eventArgument)
     {
          // Response.Write("organization selected: " + eventArgument);
          Guid selectedOrgId = new Guid(eventArgument);
          if (BasePage.LoggedInUser.Id == new Guid("6bb552e9-debb-40d3-a5a9-60329aedeaac"))
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var org = (from x in data.Logistics_Organizations
                                   where x.Id == selectedOrgId
                                   select x).First();

                    if (org == null)
                    {
                         Response.Redirect("~/company/logistics/organization?id=" + org.Id.ToString());
                    }
                    else
                    {
                         Session["SelectedOrganizationId"] = eventArgument;
                         BasePage.SelectedOrganization = org;
                         Response.Redirect(Request.Url.ToString(), true);
                    }
               }
          }
     }
//-------------------------------------------------------------------------------------------
     protected void OrganizationEdit_Click(object sender, EventArgs e)
     {
          Response.Redirect("/company/logistics/organization?id=" + BasePage.SelectedOrganization.Id.ToString());
     }
//-------------------------------------------------------------------------------------------
}