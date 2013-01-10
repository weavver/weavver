using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Xml;
using System.IO;

public partial class Vendors_FreeSWITCH_Extensions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         // subbing out an xml reader for the switch dialplan.xml file
         //string x = ConfigurationManager.AppSettings["freeswitch_confdirectory"];

         //StreamReader sr = File.OpenText(@"S:\dialplan\internal\dialplan.xml");
         //XmlDocument doc = new XmlDocument();
         //string xml = sr.ReadToEnd();
         //doc.LoadXml(xml);

         //Response.Write(xml);
    }
}