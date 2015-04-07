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

using Weavver.Data;

public partial class Vendors_Cisco_Default : SkeletonPage
{
     //bool punchedin = true;
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;
          Response.ContentType = "text/xml";
          //if (PersonId == null)
          //{
          //     Server.Transfer("LogIn.aspx", false);
          //}

          //if (Request["action"] == "logout")
          //{
          //     FormsAuthentication.SignOut();
          //}

          //if (User.Identity.IsAuthenticated)
          //{
          //     LogIn.Visible = false;
          //     HomeScreen.Visible = true;
          //}
          //else
          //{
          //     LogIn.Visible = true;
          //     HomeScreen.Visible = false;
          //}

          //if (Request["pn"] != null && Request["pc"] != null)
          //{
          //     string phonenumber = Request["pn"].ToString();
          //     //var phnum = db.Query("weavver.data.phonenumber", "all").Key(phonenumber).Limit(1).IncludeDocuments().GetResult().Document<PhoneNumber>();
          //     //if (phnum != null)
          //     //{
          //     //     var employee = DatabaseHelper.Session.Get<Employee>(phnum.ParentId);
          //     //     if (employee != null)
          //     //     {
          //     //          string passcode = Request["pc"];
          //     //          if (employee.Passcode == passcode)
          //     //          {
          //     //               FormsAuthentication.SetAuthCookie(employee.Username, true);
          //     //               //Response.Redirect("Default.aspx");
          //     //               LogIn.Visible = false;
          //     //               HomeScreen.Visible = true;
          //     //               punchedin = (Request["punch"] != "out");
          //     //               if (punchedin)
          //     //               {
          //     //                    PunchStatus.Text = "You punched in at " + DateTime.Now.ToString("t") + ".";
          //     //                    PunchAction.Text = "Punch Out";
          //     //                    PunchURL.Text = "http://192.168.5.31/Vendors/Cisco/PunchOut.aspx";
          //     //               }
          //     //               else
          //     //               {
          //     //                    PunchStatus.Text = "You are not punched in.";
          //     //                    PunchAction.Text = "Punch In";
          //     //                    PunchURL.Text = "http://192.168.5.31/Vendors/Cisco/PunchIn.aspx";
          //     //               }
          //     //               return;
          //     //          }
          //     //          else
          //     //          {
          //     //               Prompt.Text = "Invalid password, please start again.";
          //     //               return;
          //     //          }
          //     //     }
          //     //     else
          //     //     {
          //     //          Prompt.Text = "We could not find your information. Please try again.";
          //     //          return;
          //     //     }
          //     //}
          //     //else
          //     //{
          //     //     //ResetForm();
          //     //     Prompt.Text = "We could not find your information. Please try again.";
          //     //     return;
          //     //}
          //     //Response.Redirect("Default.aspx?ignore=true");
          //}
          //else
          //{
          //     Prompt.Text = "Press submit to finish.";
          //}
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