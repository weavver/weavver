<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DateTime.ascx.cs" Inherits="DynamicData.DynamicData.Filters.DateFilter" %>
<asp:DropDownList ID="dropDownList" runat="server" CssClass="DDFilter">
  <asp:ListItem Text="Equals" Value="==" />
  <asp:ListItem Text="Before" Value="<" />
  <asp:ListItem Text="After" Value=">" />
</asp:DropDownList> 

<asp:TextBox ID="textBox" runat="server" CssClass="DDTextBox" Columns="12" /> 

<asp:CustomValidator ID="validator" runat="server" ControlToValidate="textBox"
  OnServerValidate="Validate" Text="*" CssClass="DDValidator"/>