using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vendors_OFX_API : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

         string postedOFXML = Request.Form.ToString();


         string RequestType = "";
    }



    private void WriteOFXResponse()
    {
         string ofxResponse = @"OFXHEADER:100
DATA:OFXSGML
VERSION:102
SECURITY:NONE
ENCODING:USASCII
CHARSET:1252
COMPRESSION:NONE
OLDFILEUID:NONE
NEWFILEUID:NONE";

    }

    private void SendPaySyncResponse()
    {
         string response = @"<OFX><SIGNONMSGSRSV1><SONRS><STATUS><CODE>0<SEVERITY>INFO
<MESSAGE>The operation succeeded.</STATUS><DTSERVER>20120804124158.380[-7:PDT]
<LANGUAGE>ENG<FI><ORG>OCTFCU<FID>17600</FI></SONRS></SIGNONMSGSRSV1>
<BILLPAYMSGSRSV1><PMTSYNCRS><TOKEN>-1<LOSTSYNC>N<BANKACCTFROM>
<BANKID>322282001<ACCTID>237347-S70<ACCTTYPE>CHECKING</BANKACCTFROM></PMTSYNCRS></BILLPAYMSGSRSV1></OFX>";



    }
}