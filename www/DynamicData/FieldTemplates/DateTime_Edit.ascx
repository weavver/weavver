<%@ Control Language="C#" CodeFile="DateTime_Edit.ascx.cs" Inherits="DynamicData.DateTime_EditField" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:TextBox ID="TextBox1" runat="server" CssClass="DDTextBox" Text='<%# Format(FieldValueEditString) %>' Columns="20"></asp:TextBox>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" />
<asp:CustomValidator runat="server" ID="DateValidator" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" EnableClientScript="false" Enabled="false" OnServerValidate="DateValidator_ServerValidate" />

<cc1:TextBoxWatermarkExtender ID="CheckNumWatermark" runat="server" TargetControlID="TextBox1" WatermarkText="MM/DD/YY"></cc1:TextBoxWatermarkExtender>
<cc1:CalendarExtender ID="PostAtExtender" runat="server" TargetControlID="TextBox1"></cc1:CalendarExtender>