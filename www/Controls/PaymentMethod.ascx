<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentMethod.ascx.cs" Inherits="Controls_PaymentMethod" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Panel ID="PaymentOptions" runat="server">
     <table style="width: 100%; margin-top: 0px; margin-left: 0px;" cellpadding="0" cellspacing="0">
     <%--<tr>
          <td style="font-weight: bolder;" colspan="2">Display Name:
               <asp:TextBox ID="DisplayName" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DisplayName" ErrorMessage="*" ToolTip="Display name is required." ValidationGroup="OrderForm"></asp:RequiredFieldValidator>
               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="DisplayName" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" />
               <br />
               <br />
          </td>
     </tr>--%>
     <tr id="ExistingMethodRow" runat="server" visible="false" style="padding-bottom: 0px;">
          <td style="width: 125px;" colspan="2">On file:
               <asp:DropDownList ID="ExistingMethods" runat="server" AutoPostBack="true" Width="125px">
                    <asp:ListItem>None</asp:ListItem>
               </asp:DropDownList>
          </td>
     </tr>
     <tr>
          <td style="padding-top: 0px; padding-bottom: 0px;" valign="baseline" colspan="2">
               <%--<asp:Label ID="ChooseMethodLabel" runat="server" Text="Card Type"></asp:Label>
               <asp:RadioButtonList ID="Issuer" runat="server" RepeatDirection="Horizontal" CausesValidation="true">
                    <asp:ListItem Value="mastercard">Master Card</asp:ListItem>
                    <asp:ListItem Value="visa">Visa</asp:ListItem>
                    <%--<asp:ListItem Value="paypal">PayPal</asp:ListItem>--%>
               <%--</asp:RadioButtonList>--%>
               <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="Issuer" ErrorMessage="*" ToolTip="Please choose your card type." ValidationGroup="OrderForm"></asp:RequiredFieldValidator></nobr>--%>
          </td>
     </tr>
     </table>
</asp:Panel>
We accept Master Card, Lady Visa, and American Express:<br />
<br />
<table style="width: 100%; margin-left: 0px;" cellpadding="3" cellspacing="0">
<tr>
     <td>
          Card #:
     </td>
     <td>
          <asp:TextBox ID="CreditCard" runat="server" Width="150px" MaxLength="16"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="CreditCard" ErrorMessage="*" ToolTip="Card is required." ValidationGroup="OrderForm"></asp:RequiredFieldValidator>
          <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="CreditCard" ValidChars="0123456789" />
          <cc1:TextBoxWatermarkExtender ID="CCWatermark" runat="server" TargetControlID="CreditCard" WatermarkText="1234567891234567" WatermarkCssClass="WatermarkedField"></cc1:TextBoxWatermarkExtender>
     </td>
</tr>
<tr>
     <td>
          Sec Code: 
     </td>
     <td>
          <asp:TextBox ID="SecurityCode" runat="server" MaxLength="4" Width="50px"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="SecurityCode" ErrorMessage="*" ToolTip="Security code is required." ValidationGroup="OrderForm"></asp:RequiredFieldValidator>
          <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="SecurityCode" ValidChars="0123456789" />
          <cc1:TextBoxWatermarkExtender ID="SecCodeWatermark" runat="server" TargetControlID="SecurityCode" WatermarkText="123" WatermarkCssClass="WatermarkedField"></cc1:TextBoxWatermarkExtender>
     </td>
</tr>
<tr>
     <td>
          Expires:
     </td>
     <td>
          <asp:DropDownList ID="ExpirationMonth" runat="server" RepeatDirection="Horizontal">
               <asp:ListItem Value="01">January</asp:ListItem>
               <asp:ListItem Value="02">February</asp:ListItem>
               <asp:ListItem Value="03">March</asp:ListItem>
               <asp:ListItem Value="04">April</asp:ListItem>
               <asp:ListItem Value="05">May</asp:ListItem>
               <asp:ListItem Value="06">June</asp:ListItem>
               <asp:ListItem Value="07">July</asp:ListItem>
               <asp:ListItem Value="08">August</asp:ListItem>
               <asp:ListItem Value="09">September</asp:ListItem>
               <asp:ListItem Value="10">October</asp:ListItem>
               <asp:ListItem Value="11">November</asp:ListItem>
               <asp:ListItem Value="12">December</asp:ListItem>
          </asp:DropDownList>
          <asp:DropDownList ID="ExpirationYear" runat="server" RepeatDirection="Horizontal">
               <asp:ListItem Value="10">2010</asp:ListItem>
               <asp:ListItem Value="11">2011</asp:ListItem>
               <asp:ListItem Value="12">2012</asp:ListItem>
               <asp:ListItem Value="13">2013</asp:ListItem>
               <asp:ListItem Value="14">2014</asp:ListItem>
               <asp:ListItem Value="15">2015</asp:ListItem>
               <asp:ListItem Value="16">2016</asp:ListItem>
               <asp:ListItem Value="17">2017</asp:ListItem>
               <asp:ListItem Value="18">2018</asp:ListItem>
               <asp:ListItem Value="19">2019</asp:ListItem>
          </asp:DropDownList>
     </td>
</tr>
</table>