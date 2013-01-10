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

public partial class Vendors_Polycom_Default : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = false;
          LogInURL = "LogIn.aspx";
          //PhoneNumber.Text = Request.QueryString.Count.ToString();
     }
//-------------------------------------------------------------------------------------------
     protected void TimeLogs_Click(object sender, EventArgs e)
     {
          Response.Redirect("TimeLogs.aspx");
     }
//-------------------------------------------------------------------------------------------
     protected void SignOut_Click(object sender, EventArgs e)
     {
          Response.Redirect("LogIn.aspx", true);
     }
//-------------------------------------------------------------------------------------------
}
