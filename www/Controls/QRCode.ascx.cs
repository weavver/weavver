using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_QRCode : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
         QRURL.Src = "/Controls/QRCode.ashx?URL=" + HttpUtility.UrlEncode(Request.Url.ToString());
    }
}