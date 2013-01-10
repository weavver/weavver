<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Forum_List.aspx.cs" Inherits="Company_Products_Snap_Forum_Default" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     The forums are coming shortly.
     <asp:DataList ID="List" runat="server">
     <ItemTemplate>
          <h4><a href="Forum.aspx?id=<%# DataBinder.Eval(Container.DataItem, "Id") %>"><%# DataBinder.Eval(Container.DataItem, "Name") %></a></h4>
          <%# DataBinder.Eval(Container.DataItem, "Description") %><br />
          <br />
     </ItemTemplate>
     </asp:DataList>
</asp:Content>