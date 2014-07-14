using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_HTTP404 : SkeletonPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
         WeavverMaster.FormTitle = "Whoops";
         WeavverMaster.Width = "100%";

         IsPublic = true;
         RequiresSelectedOrg = false;
    }
}