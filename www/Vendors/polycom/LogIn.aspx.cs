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

public partial class Vendors_Polycom_LogIn : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;
     }
//-------------------------------------------------------------------------------------------
     protected void LogIn_Click(object sender, EventArgs e)
     {
          //Weavver.Security.WeavverMembershipProvider userprov = new Weavver.Security.WeavverMembershipProvider();
          //bool loggedin = userprov.LogIn_byPhoneNumber(PhoneNumber.Text, Passcode.Text);
          //if (loggedin)
          //{
          //     Response.Redirect("default");
          //     //punchedin = (Request["punch"] != "out");
          //     //if (punchedin)
          //     //{
          //     //     PunchStatus.Text = "You punched in at " + DateTime.Now.ToString("t") + ".";
          //     //     PunchAction.Text = "Punch Out";
          //     //     PunchURL.Text = "http://192.168.5.31/Vendors/Cisco/PunchOut.aspx";
          //     //}
          //     //else
          //     //{
          //     //     PunchStatus.Text = "You are not punched in.";
          //     //     PunchAction.Text = "Punch In";
          //     //     PunchURL.Text = "http://192.168.5.31/Vendors/Cisco/PunchIn.aspx";
          //     //}
          //}
          //else
          //{
          //     Status.Text = "We could not find your account. Please try again.";
          //}
     }
//-------------------------------------------------------------------------------------------
}
