using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_HTTP401 : SkeletonPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
         WeavverMaster.FormTitle = "Whoops, You need more permission to access that";
    }
}