using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Net.Mail;

using Weavver.Data;

public partial class Vendors_FreeSWITCH_Directory : Page
{
     protected void Page_Load(object sender, EventArgs e)
     {
          if (Request.UserHostAddress != "127.0.0.1" &&
              Request.UserHostAddress != ConfigurationManager.AppSettings["freeswitch_server"])
          {
               Response.StatusCode = 403; // forbidden
               Response.SubStatusCode = 6; // ip address blocked
               Response.End();
          }

          Response.ContentType = "text/xml";
          Response.Write("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>\r\n");

          string notFoundXML = "<document type=\"freeswitch/xml\">"
                                 + "<section name=\"result\">"
                                 + "<result status=\"not found\" />"
                                 + "</section>"
                                 + "</document>";

          string output = "";
          switch (Request["action"])
          {
               case "sip_auth":
               case "message-count":
               case "voicemail-lookup":
                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         string sipUser = Request["sip_auth_username"] ?? Request["user"];
                         string sipAuthRealm = Request["sip_auth_realm"] ?? Request["domain"];

                         var results = from x in data.System_Users
                                       select x;

                         double userCode;
                         if (Double.TryParse(sipUser, out userCode))
                         {
                              results = results.Where(x => x.UserCode == sipUser);
                         }
                         else
                         {
                              results = results.Where(x => x.Username == sipUser);
                         }

                         var result = results.FirstOrDefault();

                         if (result != null)
                         {
                              output = "<document type=\"freeswitch/xml\">"
                                           + "<section name=\"directory\">"
                                           + "    <domain name=\"{0}\">"
                                           + "        <user id=\"{1}\">"
                                           + "             <params>"
                                           + "                   <param name=\"a1-hash\" value=\"{2}\" />"
                                           + "                   <param name=\"vm-a1-hash\" value=\"{3}\" />"
                                           + "                   <param name=\"vm-mailto\" value=\"{4}\" />"
                                           //+ "                   <param name=\"vm-email-all-messages\" value=\"true\" />"
                                           + "             </params>"
                                           + "             <variables>"
                                           + "                   <variable name=\"user_context\" value=\"internal\" />"
                                           + "             </variables>"
                                           + "        </user>"
                                           + "    </domain>"
                                           + "</section>"
                                           + "</document>";

                              string passwordHash = Weavver.Utilities.Common.MD5(sipUser + ":" + sipAuthRealm + ":" + result.Password);
                              string passcodeHash = Weavver.Utilities.Common.MD5(sipUser + ":" + sipAuthRealm + ":" + result.PassCode);
                              output = String.Format(output, Request["domain"], sipUser, passwordHash.ToLower(), passcodeHash, result.EmailAddress);
                              Response.Write(output);
                         }
                         else
                         {
                              Response.Write(notFoundXML);
                         }
                    }
                    break;

               default:
                    Response.Write(notFoundXML);
                    break;
          }

          Weavver.Utilities.ErrorHandling.LogError(Request, "vendors/freeswitch/directory", new Exception(output));
     }
}