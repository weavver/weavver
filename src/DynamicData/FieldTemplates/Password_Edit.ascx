<%@ Control Language="C#" CodeFile="Password_Edit.ascx.cs" Inherits="DynamicData.Password_EditField" %>

<asp:TextBox ID="TextBox1" runat="server" TextMode="Password" CssClass="DDTextBox" style="max-width:250px"></asp:TextBox>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl" ControlToValidate="TextBox1" Display="Dynamic" Enabled="false" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" CssClass="DDControl" ControlToValidate="TextBox1" Display="Dynamic" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl" ControlToValidate="TextBox1" Display="Dynamic" />