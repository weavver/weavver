<%@ Page Title="Weavver :: Forum :: Import Tool" Language="C#" AutoEventWireup="true" CodeFile="Vendors_DNNForum.aspx.cs" Inherits="Company_Products_Snap_Forum_Import" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     Weavver can import basic data from other forums. Please note that not everything is imported. In order to understand the exact support it would be best to read the
     source code used to import the data from the link at the bottom of this page. If you would like features added or other products supported then please
     read up on our contribution and bounty system.
     <br />
     <br />
     <table>
     <tr>
          <td width="250px">Forum Type:</td>
          <td>
               <asp:DropDownList ID="ForumType" runat="server">
               <asp:ListItem>DOTNETNUKE Forum</asp:ListItem>
               <asp:ListItem>PHPBB (not implemented)</asp:ListItem>
               </asp:DropDownList>
          </td>
     </tr>
     <tr>
          <td>Host:</td><td><asp:TextBox ID="Host" runat="server" Text="192.168.10.111"></asp:TextBox></td>
     </tr>
     <tr>
          <td>DB Name:</td><td><asp:TextBox ID="DBName" runat="server" Text="snapweb"></asp:TextBox></td>
     </tr>
     </table>
     <br />
     SQL Credentials<br />
     <hr />
     <table>
     <tr>
          <td width="250px">Username:</td><td><asp:TextBox ID="Username" runat="server" Text="sa"></asp:TextBox></td>
     </tr>
     <tr>
          <td>Password:</td><td><asp:TextBox ID="Password" runat="server" Text="" TextMode="Password"></asp:TextBox></td>
     </tr>
     </table>
     <br />
     <br />
     <asp:Button ID="Delete" runat="server" Text="Delete All Forum Data" Width="200" Height="25"></asp:Button>&nbsp;
     <div style="float:right;">
          <asp:Label ID="Status" runat="server"></asp:Label>&nbsp;
          <asp:Button ID="Import" runat="server" Text="Import" Width="125" Height="25"></asp:Button>&nbsp;
          <asp:Button ID="Convert" runat="server" Text="Convert" Width="125" Height="25"></asp:Button>
     </div>
     <br />
     <asp:DataGrid ID="ForumList" runat="server"></asp:DataGrid><br />
     <asp:DataGrid ID="List" runat="server"></asp:DataGrid>
</asp:Content>