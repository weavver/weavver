<%@ Control Language="C#" AutoEventWireup="true" CodeFile="String.ascx.cs" Inherits="DynamicData.DynamicData.Filters.StringFilter" %>
<asp:DropDownList ID="dropDownList" runat="server" CssClass="DDFilter">
  <asp:ListItem Text="Like" Value="%" />
</asp:DropDownList> 

<asp:TextBox ID="textBox" runat="server" CssClass="DDTextBox" Columns="12" /> 

<asp:CustomValidator ID="validator" runat="server" ControlToValidate="textBox" OnServerValidate="Validate" Text="*" CssClass="DDValidator"/>