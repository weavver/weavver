using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Navigation : System.Web.UI.UserControl
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
               //Products.Visible = (page.SelectedOrganization != null && page.SelectedOrganization.Id == new Guid("0baae579-dbd8-488d-9e51-dd4dd6079e95"));
               Projects.Visible = (page.SelectedOrganization != null && page.SelectedOrganization.Id == new Guid("0baae579-dbd8-488d-9e51-dd4dd6079e95"));
               Forum.Visible = (page.SelectedOrganization != null && page.SelectedOrganization.Id == new Guid("0baae579-dbd8-488d-9e51-dd4dd6079e95"));
          }
     }
//-------------------------------------------------------------------------------------------
}