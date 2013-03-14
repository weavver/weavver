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
using System.DirectoryServices;

using Interop.QBFC7;


//using WebServicesSessionLocalService;

using Weavver.Vendors.ProcessOne;

public partial class System_Test : System.Web.UI.Page
{
     public string GetProperty(SearchResult searchResult, string PropertyName)
     {
          foreach (string key in searchResult.Properties.PropertyNames)
          {
               ICollection coll = null;

               string res = searchResult.Properties[key][0].ToString();

               //if (res != null && res != "")
               //     Response.Write(key + ": " + res + "<br />");
          }
          //Response.Write(searchResult.Properties.PropertyNames.ToString());
          if(searchResult.Properties.Contains(PropertyName))
          {
               return searchResult.Properties[PropertyName][0].ToString() + "<br />";
          }
          else
          {
               return string.Empty;
          }
     }

     protected void Send_Click(object sender, EventArgs e)
     {
          send_message_chat message = new send_message_chat();
          message.from = "weavver.com";
          message.to = ConfigurationManager.AppSettings["admin_address"];
          message.body = "User at " + Request.UserHostAddress + " says asdf asdf asfd";

          Weavver.Vendors.ProcessOne.ejabberdRPC rpc = new Weavver.Vendors.ProcessOne.ejabberdRPC();
          rpc.SendMessageChat(message);

          status s = new status();
          CookComputing.XmlRpc.XmlRpcStruct statResponse = rpc.Status(s);

          PrintStruct(statResponse);
     }

     private void PrintStruct(CookComputing.XmlRpc.XmlRpcStruct ejabberdStruct)
     {
          foreach (object x in ejabberdStruct.Keys)
          {
               Response.Write(x.ToString() + " :  " + ejabberdStruct[x] + "<br />");
          }
     }

     public static DirectoryEntry GetDirectoryEntry()
     {
          string activedirectory_domain = ConfigurationManager.AppSettings["activedirectory_domain"];
          string activedirectory_username = ConfigurationManager.AppSettings["activedirectory_username"];
          string activedirectory_password = ConfigurationManager.AppSettings["activedirectory_password"];

          DirectoryEntry entry = new DirectoryEntry("LDAP://" + activedirectory_domain, activedirectory_username, activedirectory_password);
          entry.AuthenticationType = AuthenticationTypes.Secure;
          return entry;
     }

     protected void Page_Load(object sender, EventArgs e)
     {
          if (Request["testing"] == "true")
               return;
          //WeavverLib.JBilling.createUser cu = new WeavverLib.JBilling.createUser();
          //WeavverLib.JBilling.getUserId gui;
         // create the interface instance of the class.
          
          //WebServicesSessionSpringBeanService service = new WebServicesSessionSpringBeanService();
          //int xx;
          //bool ret;
          //service.Credentials = new System.Net.NetworkCredential("mythicalbox", "");
          //service.getUserId("mythicalbox", out xx, out ret);
          //itemDTOEx[] items = service.getAllItems();


          //userWS ws = new userWS();
          ////ws.creditCard = new creditCardDTO();
          ////ws.creditLimit = 0;
          ////ws.creditLimitSpecified = true;

          //ws.statusId = 1; // active
          //ws.statusIdSpecified = true;
          //ws.userName = "jdoe";
          //ws.languageId = 1;
          //ws.userIdBlacklisted = false;
          //ws.userIdBlacklistedSpecified = false;
          //ws.languageIdSpecified = true;
          //ws.role = "user";
          //ws.mainRoleId = 5; // customer
          //ws.contact = new contactWS();
          //ws.contact.address1 = "531 N. Mountain View Pl.";
          //ws.contact.city = "Fullerton";
          //ws.contact.email = "mitcheloc@gmail.com";
          //ws.contact.firstName = "John";
          //ws.contact.lastName = "Doe";
          //ws.mainRoleIdSpecified = true;
          //ws.currencyId = 1;
          //ws.currencyIdSpecified = true;
          //ws.createDatetime = DateTime.UtcNow;
          //ws.createDatetimeSpecified = true;
          //int xy;
          //bool rx;
          //service.createUser(ws, out xy, out rx);

          //foreach (itemDTOEx idto in items)
          //{
          //     Response.Write(idto.description);
          //}
          //if (xx > 0) {
          //     //WebServicesSessionLocalService.userWS userData = service.getUserWS(userId);
          //}
          //Response.Write(xx);
          //WeavverLib.JBilling.userWS us;
          
          
          //Interop.QBFC7.QBSessionManager sm = new QBSessionManager();
          //sm.OpenConnection("", "Weavver App");
          //sm.BeginSession("", ENOpenMode.omDontCare);
          DirectoryEntry entry = GetDirectoryEntry();
          //Response.Write("<html>");
          DirectorySearcher dSearch = new DirectorySearcher(entry);
          string username = "";
          dSearch.Filter = "(&(objectClass=user))";
          // get all entries from the active directory.
          // Last Name, name, initial, homepostaladdress, title, company etc..
          foreach (SearchResult sResultSet in dSearch.FindAll())
          {
               Response.Write(new Guid((byte[])sResultSet.Properties["objectguid"][0]) + "<br />");
               Response.Write(GetProperty(sResultSet, "cn"));
               Response.Write(GetProperty(sResultSet, "cn")); // Login Name
               Response.Write(GetProperty(sResultSet, "givenName")); // First Name
               Response.Write(GetProperty(sResultSet, "initials")); // Middle Initials
               Response.Write(GetProperty(sResultSet, "sn")); // Last Name

               string tempAddress = GetProperty(sResultSet, "homePostalAddress"); // Address

               if (tempAddress != string.Empty)
               {
                    string[] addressArray = tempAddress.Split(';');
                    string taddr1, taddr2;
                    taddr1 = addressArray[0];
                    Response.Write(taddr1);
                    taddr2 = addressArray[1];
                    Response.Write(taddr2);
               }

               Response.Write(GetProperty(sResultSet, "title")); // title
               Response.Write(GetProperty(sResultSet, "company")); // company
               Response.Write(GetProperty(sResultSet, "st")); // state
               Response.Write(GetProperty(sResultSet, "l")); // city
               Response.Write(GetProperty(sResultSet, "co")); // country
               Response.Write(GetProperty(sResultSet, "postalCode")); // postal code
               Response.Write("telephone number: " + GetProperty(sResultSet, "telephoneNumber")); // telephonenumber
               Response.Write(GetProperty(sResultSet, "otherTelephone")); // extension
               Response.Write(GetProperty(sResultSet, "facsimileTelephoneNumber")); // fax
               Response.Write(GetProperty(sResultSet, "mail")); // email address
               Response.Write(GetProperty(sResultSet, "extensionAttribute1")); // Challenge Question
               Response.Write(GetProperty(sResultSet, "extensionAttribute2")); // Challenge Response
               Response.Write(GetProperty(sResultSet, "extensionAttribute3")); // Member Company

               Response.Write(GetProperty(sResultSet, "extensionAttribute4")); // Company Relation ship Exits
               Response.Write(GetProperty(sResultSet, "extensionAttribute5")); //status
               Response.Write(GetProperty(sResultSet, "extensionAttribute6")); // Assigned Sales Person
               Response.Write(GetProperty(sResultSet, "extensionAttribute7")); // Accept T and C
               Response.Write(GetProperty(sResultSet, "extensionAttribute8")); // jobs
               String tEmail = GetProperty(sResultSet, "extensionAttribute9");

               // email over night
               if (tEmail != string.Empty)
               {
                    string em1, em2, em3;
                    string[] emailArray = tEmail.Split(';');
                    em1 = emailArray[0];
                    em2 = emailArray[1];
                    em3 = emailArray[2];
                    Console.Write(em1 + em2 + em3);
               }
               Response.Write(GetProperty(sResultSet, "extensionAttribute10")); // email daily emerging market
               Response.Write(GetProperty(sResultSet, "extensionAttribute11")); // email daily corporate market
               Response.Write(GetProperty(sResultSet, "extensionAttribute12")); // AssetMgt Range
               Response.Write(GetProperty(sResultSet, "whenCreated")); // date of account created
               Response.Write(GetProperty(sResultSet, "whenChanged")); // date of account 

               Response.Write("<hr />");
          }
     }
}
