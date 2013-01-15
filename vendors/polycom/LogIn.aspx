<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="Vendors_Polycom_LogIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Weavver Voice<br />Log In</title>
</head>
<body>
     <br />
     <br />
     <p></p>
     <form id="form1" runat="server">
     <div style="padding-top: 10px;">
          <table cellpadding="2" cellspacing="0" border="0">
          <tr>
               <td>Your phone number:</td>
               <td><asp:TextBox ID="PhoneNumber" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
               <td>Your passcode:</td>
               <td><asp:TextBox ID="Passcode" runat="server" TextMode="Password"></asp:TextBox></td>
          </tr>
          <tr>
               <td></td>
               <td></td>
          </tr>
          <tr>
               <td><asp:Label ID="Status" runat="server" Text="" /></td>
               <td><asp:Button ID="LogIn" runat="server" Text="      Log In       " style="width:250" OnClick="LogIn_Click" /></td>
          </tr>
          </table>
    </div>
    </form>
</body>
</html>
