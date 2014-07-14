using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for SkeletonUserControl
/// </summary>
public class SkeletonUserControl : System.Web.UI.UserControl
{
     Guid SelectedOrganizationId;
//--------------------------------------------------------------------------------------------
     public SkeletonPage BasePage
     {
          get
          {
               if (Page.GetType().IsSubclassOf(typeof(SkeletonPage)))
               {
                    return (SkeletonPage)Page;
               }
               else
               {
                    return null;
               }
          }
     }
//--------------------------------------------------------------------------------------------
     public SkeletonUserControl()
     {
          Init += new EventHandler(SkeletonUserControl_Init);
     }
//--------------------------------------------------------------------------------------------
     void SkeletonUserControl_Init(object sender, EventArgs e)
     {
          if (Session["SelectedOrganizationId"] != null)
          {
               SelectedOrganizationId = new Guid(Session["SelectedOrganizationId"].ToString());
          }
     }
//--------------------------------------------------------------------------------------------
}