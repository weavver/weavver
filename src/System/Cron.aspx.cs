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
using System.IO;
using System.Net;

public partial class System_Cron : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
     {
          try
          {
               string tmppath = Server.MapPath("~/About") + "/images/" + "cacti.png.tmp";
               string newpath = Server.MapPath("~/About") + "/images/" + "cacti.png";
               WebClient cron = new WebClient();
               cron.DownloadFile("http://192.168.5.8/cacti/weavver/Default_Tree/graphs/graph_161_1.png", tmppath);
               File.Move(tmppath, newpath);
          }
          catch { }
     }
}
