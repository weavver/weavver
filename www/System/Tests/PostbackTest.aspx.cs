using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Tests_PostbackTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Request["testing"] == "true")
              return;
         Weavver.Utilities.ErrorHandling.LogError(Request, "none", new Exception("PostbackTest"));
         //Response.StatusCode = (int) System.Net.HttpStatusCode.Forbidden;
         //Request.Files[0].SaveAs(@"W:\temp\postedVM.wav");
    }
}