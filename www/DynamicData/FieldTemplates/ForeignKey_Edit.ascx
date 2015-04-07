<%@ Control Language="C#" CodeFile="ForeignKey_Edit.ascx.cs" Inherits="DynamicData.ForeignKey_EditField" %>

<asp:DropDownList ID="DropDownList1" runat="server" CssClass="DDDropDown" style="max-width:250px">
</asp:DropDownList>&nbsp;
<asp:LinkButton runat="server" href="" id="newObjectLink" style="color: #0094ff;">[New]</asp:LinkButton>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="DropDownList1" Display="Static" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="DropDownList1" Display="Static" />

