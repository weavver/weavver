using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Weavver.Data;
using System.Web.Security;

public partial class Controls_MasterHeader : WeavverUserControl
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          HeaderLogoLink.HRef = Page.ResolveUrl("~/");

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


          // Projects.Visible = (BasePage.LoggedInUser != null && BasePage.LoggedInUser.OrganizationId == new Guid("0baae579-dbd8-488d-9e51-dd4dd6079e95"));

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
          // hide it in case the user is not logged in
          OrganizationsList.Visible = (HttpContext.Current.User.Identity.IsAuthenticated && !Request.Path.ToLower().EndsWith("/account/logout.aspx"));

          if (BasePage != null &&
              !Request.Path.ToLower().EndsWith("/account/logout.aspx"))
          {
               // User is Logged In
               if (BasePage.LoggedInUser != null)
               {
                    string defaultOrgId = System.Configuration.ConfigurationManager.AppSettings["default_organizationid"];
                    Guid orgId = Guid.Empty;
                    if (Guid.TryParse(defaultOrgId, out orgId))
                    {
                         AddOrganizationListChoice(orgId);
                    }

                    if (BasePage.LoggedInUser.OrganizationId != orgId)
                    {
                         AddOrganizationListChoice(BasePage.LoggedInUser.OrganizationId);
                    }

                    if (BasePage.SelectedOrganization != null)
                    {
                         foreach (ListItem x in OrganizationsList.Items)
                         {
                              x.Selected = false;
                         }
                         foreach (ListItem x in OrganizationsList.Items)
                         {
                              if (x.Value == BasePage.SelectedOrganization.Id.ToString())
                              {
                                   x.Selected = true;
                                   break;
                              }
                         }
                    }
               }
          }
     }
//-------------------------------------------------------------------------------------------
     private void AddOrganizationListChoice(Guid orgId)
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               var org = (from x in data.Logistics_Organizations
                          where x.Id == orgId
                          select x).First();

               OrganizationsList.Items.Add(new ListItem(org.Name, org.Id.ToString()));
          }
     }
//-------------------------------------------------------------------------------------------
     void OrganizationsList_SelectedIndexChanged(object sender, EventArgs e)
     {
          if (OrganizationsList.SelectedValue == "Choose")
          {
               Response.Redirect("~/");
               return;
          }

          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               string selectedOrgId = OrganizationsList.SelectedValue;
               var org = (from x in data.Logistics_Organizations
                              where x.Id == new Guid(selectedOrgId)
                              select x).First();

               if (org == null)
               {
                    Response.Redirect("~/");
               }
               else
               {
                    Session["SelectedOrganizationId"] = selectedOrgId;
                    BasePage.SelectedOrganization = org;

                    string url = Request.Url.Scheme + "://" + Request.Url.Authority + BasePage.WeavverMaster.FormatURLs("~/");
                    Response.Redirect(url, true);
               }
          }
     }
//-------------------------------------------------------------------------------------------
}