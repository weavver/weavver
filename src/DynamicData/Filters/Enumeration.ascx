<%@ Control Language="C#" CodeFile="Enumeration.ascx.cs" Inherits="DynamicData.EnumerationFilter" %>

<asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="True" CssClass="DDFilter"
    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="max-width: 150px;">
  <asp:ListItem Text="All" Value="" />
</asp:DropDownList>

