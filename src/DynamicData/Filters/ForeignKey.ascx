<%@ Control Language="C#" CodeFile="ForeignKey.ascx.cs" Inherits="DynamicData.ForeignKeyFilter" %>

<asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="True" CssClass="DDFilter"
    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="max-width: 200px;">
    <asp:ListItem Text="All" Value="" />
</asp:DropDownList>

