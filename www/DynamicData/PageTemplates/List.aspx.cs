using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;

namespace DynamicData
{
     public partial class List : SkeletonPage
     {
          protected void Page_PreInit(object sender, EventArgs e)
          {
               if (Request["IFrame"] == "true")
               {
                    MasterPageFile = "~/Blank.master";
               }
          }

          protected void Page_Init(object sender, EventArgs e)
          {
               IsPublic = true;
               
               WeavverMaster.FixedWidth = false;
               WeavverMaster.Width = "100%";
               //WeavverMaster.FormTitle = table.DisplayName;
               WeavverMaster.SetToolbarVisibility(true);
          }
     }
}


// e.Item.Attributes.Add("onclick", "javascript:__doPostBack" + "('" + e.Item.UniqueID + ", 'Select$" + e.Item.ItemIndex + "')");