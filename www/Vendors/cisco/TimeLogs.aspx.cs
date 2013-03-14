using System;
using System.Collections;
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

public partial class Vendors_Cisco_Logs : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          Response.ContentType = "text/xml";
          IsPublic = true;
     }
//-------------------------------------------------------------------------------------------
     protected void Home_Click(object sender, EventArgs e)
     {
          Response.Redirect("Default.aspx");
     }
//-------------------------------------------------------------------------------------------
}
