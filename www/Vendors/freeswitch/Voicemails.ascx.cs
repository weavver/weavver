using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;

public partial class Vendors_freeswitch_Voicemails : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
         try
         {
              string freeswitchCS = ConfigurationManager.ConnectionStrings["freeswitch"].ConnectionString;
              MySqlConnection conn = new MySqlConnection(freeswitchCS);
              conn.Open();
              MySqlCommand command = new MySqlCommand("select * from voicemail_msgs where username=?username order by created_epoch desc;", conn);
              command.Parameters.AddWithValue("?username", LoggedInUser.Username);
              MySqlDataReader reader = command.ExecuteReader();
              VoicemailList.DataSource = reader;
              VoicemailList.DataBind();
              reader.Close();

              command.CommandText = "select distinct in_folder from voicemail_msgs where username=?username;";
              reader = command.ExecuteReader();
              VoicemailFolders.DataTextField = "in_folder";
              VoicemailFolders.DataSource = reader;
              VoicemailFolders.DataBind();
              reader.Close();

              conn.Close();

              Voicemail.Visible = (VoicemailFolders.Items.Count > 0);

              if (VoicemailList.Items.Count > 0)
              {
                   Voicemail.FindControlR<Literal>("NoVoicemails").Visible = true;
              }
         }
         catch (MySqlException ex)
         {
              Voicemail.FindControlR<Literal>("NoVoicemails").Text = "Could not load your voicemails, please try back later.";
              Voicemail.FindControlR<Literal>("NoVoicemails").Visible = true;
         }
    }
}