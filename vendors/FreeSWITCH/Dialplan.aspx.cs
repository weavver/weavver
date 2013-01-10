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

public partial class Vendors_FreeSWITCH_Dialplan : SkeletonPage
{
     protected void Page_Load(object sender, EventArgs e)
     {
          Weavver.Utilities.ErrorHandling.LogError(Request, "vendors/freeswitch/dialplan", new Exception("this page is reserved for future use and not expected to be called"));
          
          //IsPublic = true;        

          //Response.Clear();
          //Response.End();
          //Response.ContentType = "text/xml";
          //Response.Write("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>");
          //Response.End();
     }
}