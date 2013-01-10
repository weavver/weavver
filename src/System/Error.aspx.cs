using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Text;
using System.Security.Cryptography;

using Weavver.Vendors.ProcessOne;

public partial class Error : Page
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          Random r = new Random();
          ErrorBanana.Src = "~/images/system/error" + (r.Next(3) + 1) + ".png";
          if (Request["aspxerrorpath"] != null)
          {
               if (Request["aspxerrorpath"] == "/company/services/xmpp/tests/")
               {
                    Response.Redirect("/company/services/chat/tests/");
               }
          }
          Error += new EventHandler(Error_Error);
          try
          {
               // Code that runs when an unhandled error occurs
               if (Session["error"] != null)
               {
                    Exception objErr = (Exception) Session["error"];
                    Session["error"] = null;
                    if (objErr != null)
                    {
                         string err = Weavver.Utilities.ErrorHandling.LogError(Request, Session["errorurl"].ToString(), objErr);
                         ErrorLabel.Text = err.Replace("\r\n", "<br />");
                         HiddenField.Text = err;
                    }
                    else
                    {
                         ErrorLabel.Text = "null";
                    }
               }
          }
          catch (Exception ex)
          {
               ErrorLabel.Text += "<br /><br />" + ex.ToString().Replace("\r\n", "<br />");
          }
     }
//-------------------------------------------------------------------------------------------
     public void Submit_Click(object sender, EventArgs e)
     {
          MailMessage message = new MailMessage("errors@weavver.com", ConfigurationManager.AppSettings["admin_address"]);
          message.Subject = "Feedback on a website error";
          message.Body = "From: " + EmailAddress.Text + "\r\n\r\nNotes: " + Notes.Text + "\r\n\r\n--------\r\n" + HiddenField.Text;
          SmtpClient sc = new SmtpClient();
          sc.Send(message);

          ErrorPan.Visible = false;
          ErrorSent.Visible = true;
     }
//-------------------------------------------------------------------------------------------
     void Error_Error(object sender, EventArgs e)
     {
          Response.Write("error!");
     }
//-------------------------------------------------------------------------------------------
    static RNGCryptoServiceProvider srng = new RNGCryptoServiceProvider();

    // 64 bytes is max size supported by ASP.NET
    const int validationKeyLength = 64;
    protected System.Web.UI.WebControls.TextBox TextBox1;
    protected System.Web.UI.WebControls.Label Label1;
    protected System.Web.UI.WebControls.Button Button1;

    // 24 bytes is max size supported by ASP.NET (3DES)
    const int decryptionKeyLength = 24;
//-------------------------------------------------------------------------------------------
    static string GenerateKey()
    {

         StringBuilder sb = new StringBuilder();
         sb.Append("<machineKey validationKey='");

         sb.Append(writeKeyAsHexDigits(getRandom(validationKeyLength)));

         sb.Append("'");
         sb.Append("   decryptionKey='");

         sb.Append(writeKeyAsHexDigits(getRandom(decryptionKeyLength)));

         sb.Append("'");
         sb.Append("   validation='SHA1'/>");
         return sb.ToString();
    }
//-------------------------------------------------------------------------------------------
    static byte[] getRandom(int cb)
    {
         byte[] randomData = new byte[cb];
         srng.GetBytes(randomData);
         return randomData;
    }
//-------------------------------------------------------------------------------------------
    static string writeKeyAsHexDigits(byte[] key)
    {
         StringBuilder sb = new StringBuilder();
         for (int i = 0; i < key.Length; ++i)
         {

              sb.Append(String.Format("{0:X2}", key[i]));

         }
         return sb.ToString();
    }
//-------------------------------------------------------------------------------------------
}
