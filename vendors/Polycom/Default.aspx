<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Vendors_Polycom_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Weavver Voice</title>
</head>
<body>
     <form id="form1" runat="server">
          <p></p>
          <table cellpadding="2" cellspacing="2" border="0">
          <tr>
               <td>You punched in at 7:30AM today.</td>
               <td><asp:Button ID="Punch" runat="server" Text="      Punch Out      " /></td>
          </tr>
          </table>
          <p></p>
          <p></p>
          <table cellpadding="2" cellspacing="2" border="0">
          <tr>
               <td><asp:Button ID="TimeLogs" runat="server" Text="      Time Logs       " style="width:250" OnClick="TimeLogs_Click" /></td>
               <td style="text-align:right"><asp:Button ID="SignOut" runat="server" Text="      Sign Out      " OnClick="SignOut_Click" /></td>
          </tr>
          </table>
          <br />
          <p></p>
          &nbsp;&nbsp;&nbsp;&nbsp;
          <p></p>
     </form>
</body>
</html>