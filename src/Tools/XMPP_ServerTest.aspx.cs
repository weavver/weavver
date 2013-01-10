using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LumiSoft.Net.Dns.Client;

public partial class Company_Services_XMPP_Tests_Default : SkeletonPage
{
     bool fail = false;
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (Request["testing"] == "true")
               return;
          Master.FormTitle = "XMPP Testing Tool";
          IsPublic = true;
          Response.Buffer = false;
          if (!IsPostBack)
          {
               if (Request["domainname"] != null)
               {
                    Domain.Text = Request["domainname"];
                    DomainLookup_Click(null, EventArgs.Empty);
               }
          }
     }
//-------------------------------------------------------------------------------------------
     protected void DomainLookup_Click(object sender, EventArgs e)
     {
          string response1 = LookupSRV("_xmpp-client._tcp.", Domain.Text, "<br /><br />XMPP client SRV records for " + "_xmpp-client._tcp." + Domain.Text + " point to:<br><br>");
          string response2 = LookupSRV("_xmpp-server._tcp.", Domain.Text, "<br />XMPP SRV server records for " +"_xmpp-server._tcp." + Domain.Text + " point to:<br><br>");
          string response3  = LookupA(Domain.Text, "<br /><br />While this tool does not check this, please keep in mind that some XMPP clients and servers may try to connect on ports 5222, 5223, 5269, and 5270 on the following A records for " + Domain.Text + ":<br><br>");

          Results.Text = response1 + response2 + response3;
          if (fail)
          {
               Results.Text += "<br />This domain does not have correctly configured XMPP records.<br /><br />";
          }
     }
//-------------------------------------------------------------------------------------------
     private string LookupA(string recordname, string sectiontext)
     {
          Dns_Client          dc      = new LumiSoft.Net.Dns.Client.Dns_Client();
          DnsServerResponse   dsr     = null;
          try
          {
          dsr = dc.Query(recordname, LumiSoft.Net.Dns.Client.QTYPE.A);
          }
          catch (Exception ex)
          {
               throw new Exception("DNS A record query for " + recordname + " failed.", ex);
          }
          DNS_rr_A[]        records = dsr.GetARecords();

          string response = sectiontext;
          if (records.Length < 1)
               fail = true;
          for (int i = 0; i < records.Length; i++)
          {
               response += (i + 1) + ".&nbsp;&nbsp;&nbsp;";
               response += records[i].IP + " with a TTL of " + records[i].TTL + "<br>";
               response += CheckPort(records[i].IP.ToString(), 5222);
               response += CheckPort(records[i].IP.ToString(), 5223);
               response += CheckPort(records[i].IP.ToString(), 5269);
               response += CheckPort(records[i].IP.ToString(), 5270);
          }
          return response;
     }
//-------------------------------------------------------------------------------------------
     private string CheckPort(string address, int port)
     {
          return "";
          string response = "";
          try
          {
               TcpClient client = new TcpClient();
               client.Connect(address, port);
               if (client.Connected)
               {
                    response += "&nbsp;&nbsp;---->&nbsp;Port " + port + " is reachable.<br />";
                    client.Close();
               }
          }
          catch
          {
               Response.Write("&nbsp;&nbsp;---->&nbsp;NOT Connected<br />");
               fail = true;
          }
          return response;
     }
//-------------------------------------------------------------------------------------------
     private string LookupSRV(string recordname, string domain, string sectiontext)
     {
          recordname                 += domain;
          Dns_Client          dc      = new LumiSoft.Net.Dns.Client.Dns_Client();
          DnsServerResponse   dsr     = null;
          try
          {
               dsr = dc.Query(recordname, LumiSoft.Net.Dns.Client.QTYPE.SRV);
          }
          catch (Exception ex)
          {
               return "<span style='color:red'>DNS SRV record query for " + recordname + domain + " timed out.</span>";
          }
          DNS_rr_SRV[]        records = dsr.GetSRVRecords();

          string response = sectiontext;
          if (records.Length < 1)
               fail = true;
          for (int i = 0; i < records.Length; i++)
          {
               DnsServerResponse dsr2;
               try
               {
                    dsr2 = dc.Query(records[i].Target, QTYPE.A);
               }
               catch (Exception ex)
               {
                    throw new Exception("DNS sub A record query for " + domain + " failed.", ex);
               }
               DNS_rr_A[] aRecs = dsr2.GetARecords();

               response += (i + 1) + ".&nbsp;&nbsp;&nbsp;";
               response += records[i].Target + " on port " + records[i].Port + " with a TTL of " + records[i].TTL + " and a priority of " + records[i].Priority + "<br />";

               for (int x = 0; x < aRecs.Length; x++)
               {
                    response += "&nbsp;&nbsp;---->&nbsp;Resolves to " + aRecs[x].IP + "<br />";
                    response += CheckPort(aRecs[x].IP, records[i].Port);
                    response += CheckPort(aRecs[x].IP, 5223);
               }
               

          }
          return response;
     }
//-------------------------------------------------------------------------------------------
     private string CheckPort(System.Net.IPAddress host, int port)
     {
          string response = "";
          if (host.ToString() == "205.134.225.18") // used to resolve correctly for internal weavver servers
               host = System.Net.IPAddress.Parse("192.168.10.111");

          TcpClient client = new TcpClient();
          try
          {
               client.Connect(host, port);
          }
          catch (Exception e)
          {
          }
          if (client.Connected)
          {
               if (port == 5223)
                    response += "&nbsp;&nbsp;-------->&nbsp;<span style='color:green'>Port " + port + " (old style ssl) is reachable.</span>";
               else
                    response += "&nbsp;&nbsp;-------->&nbsp;<span style='color:green'>Port " + port + " is reachable.</span>";
               client.Close();
          }
          else
          {
               if (port == 5223)
                    response += "&nbsp;&nbsp;-------->&nbsp;<span style='color:red'>We can not connect to port " + port + " (old style ssl).</span>";
               else
                    response += "&nbsp;&nbsp;-------->&nbsp;<span style='color:red'>We can not connect to port " + port + ".</span>";
               fail = true;
          }

          response += "<br />";
          return response;
     }
//-------------------------------------------------------------------------------------------
}