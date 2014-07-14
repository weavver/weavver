using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Navigation : SkeletonUserControl
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (Request.Url.AbsolutePath.ToLower() == "/Default.aspx" ||
              Request.Url.AbsolutePath == "/")
          {
               DefaultButton.Visible = false;
          }

          if (Page.GetType().BaseType.BaseType.FullName == "SkeletonPage")
          {
               SkeletonPage page = (SkeletonPage) Page;
               Products.Visible = (page.SelectedOrganization != null);
               Projects.Visible = (page.SelectedOrganization != null);
               Forum.Visible = (page.SelectedOrganization != null && page.SelectedOrganization.Id == new Guid("0baae579-dbd8-488d-9e51-dd4dd6079e95"));
               KnowledgeBase.Visible = (page.SelectedOrganization != null);
               AboutUs.Visible = (page.SelectedOrganization != null);
          }

          if (BasePage != null)
          {
               Products.HRef = BasePage.WeavverMaster.FormatURLs("~/Logistics_Products/Showcase.aspx");
               Projects.HRef = BasePage.WeavverMaster.FormatURLs("~/Logistics_Projects/Showcase.aspx");
               KnowledgeBase.HRef = BasePage.WeavverMaster.FormatURLs("~/KnowledgeBase/KnowledgeBase.aspx");
               Forum.HRef = BasePage.WeavverMaster.FormatURLs("~/forum/");
               AboutUs.HRef = BasePage.WeavverMaster.FormatURLs("~/about/");
          }
     }
//-------------------------------------------------------------------------------------------
}