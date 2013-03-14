using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SmartTags_PhoneNumbers : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

//          Call.Attributes.Add("OnClick", 
//               string.Format("this.disabled = true; this.value = 'Trying..'; {0};",
//               ClientScript.GetPostBackEventReference(Call, null)));

//          Bio.Text = SelectedOrganization.Bio;
//          //Bio.Text = String.Format("Please visit the <a href=\"~/company/logistics/organization?id={0}\">Organization details page</a> to edit this description.", org.Id.ToString());
//     }
////-------------------------------------------------------------------------------------------
//     public void PopUp_Click(object sender, EventArgs e)
//     {
//          Mod.Show();
//     }
//-------------------------------------------------------------------------------------------
     public void Submit_Click(object sender, EventArgs e)
     {
//          string phnumber = YourPhoneNumber.Text;
//          phnumber = phnumber.Replace("-", "").Replace(".", "");
//          //if (phnumber.Length == 11 && phnumber.StartsWith("1"))
//          //{
//          //     Weavver.Company.InformationTechnology.AsteriskPhoneSystem callserver = DatabaseHelper.Session.Get<Weavver.Company.InformationTechnology.AsteriskPhoneSystem>(new Guid("8ecbd493-3cdf-4c56-9013-a2a9e740e6ec"));
//          //     AsteriskConnection phonesystem = new AsteriskConnection();
//          //     phonesystem.Connect(callserver.ManagerUsername, callserver.ManagerPassword, callserver.Host);
//          //     AsteriskPackets asteriskPacket = new AsteriskPackets();
//          //     string packet = AsteriskPackets.OriginatePacket("DAHDI/g1/" + phnumber, "5920", "weavver", "17148725920");
//          //     phonesystem.SendPacket(packet);
//          //     phonesystem.Disconnect();

//          //     Connecting.Text = "We are connecting your call. Please wait a moment while the system connects to your phone.";
//          //     Connecting.ForeColor = System.Drawing.Color.Green;
//          //     Connecting.Visible = true;
//          //     Call.Text = "Retry";
//          //}
//          //else
//          {
//               //Connecting.Text = "Please enter an eleven digit phone number in the United States!";
//               Connecting.Text = "This feature is disabled temporarily";
//               Connecting.ForeColor = System.Drawing.Color.Red;
//               Connecting.Visible = true;
//          }
     }
}
