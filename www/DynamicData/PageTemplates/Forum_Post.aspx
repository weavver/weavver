<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Forum_Post.aspx.cs" Inherits="Company_Products_Snap_Forum_Thread" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     <br />
     <br />
     <div style="border: solid 1px lightgray; padding: 15px; margin: 1px;">
          <div style="float:right"><asp:Literal ID="Created" runat="server"></asp:Literal></div>
          Posted by <asp:Literal ID="PostedBy" runat="server"></asp:Literal>
          <br />
          <br />
          <asp:Literal ID="Body" runat="server"></asp:Literal>
          <br />
     </div>
     <asp:DataList ID="List" runat="server" Width="100%">
     <ItemTemplate>
          <div style="border: solid 1px lightgray; padding: 15px;">
               <div style="float:right"><%# DataBinder.Eval(Container.DataItem, "Created") %></div>
               Reply posted by <%# DataBinder.Eval(Container.DataItem, "Alias") %><br />
               <br />
               <%# FormatBody(DataBinder.Eval(Container.DataItem, "Body").ToString()) %>
          </div>
     </ItemTemplate>
     </asp:DataList>
     <br />
     <br />
     <table style="padding-left: 30px; width: 100%; padding-left: 30px; padding-right: 60px;">
     <tr>
          <td colspan="2" style="padding-bottom: 15px;">
               <h4>Add a Reply</h4>
          </td>
     </tr>
     <tr>
          <td valign="top" style="width: 100px">Message:</td>
          <td>
               <asp:TextBox ID="ReplyBody" runat="server" TextMode="MultiLine" Width="100%" Height="150" style="width: 100%;"></asp:TextBox><br />
               <br />
               <asp:CheckBox ID="NotifyMe" runat="server" Text="Send me notifications" Checked="true" /><br />
               <br />
               <asp:Button ID="Reply" runat="server" Text="Send Reply" Height="30px" />
          </td>
     </tr>
     </table><br />
     <div style="height: 10px;">&nbsp;</div>
</asp:Content>