<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Vendors_Cisco_Default" %>
<asp:PlaceHolder id="LogIn" runat="server" visible="true">
<CiscoIPPhoneInput> 
    <Title>Weavver Voice :: Log In</Title> 
    <Prompt><asp:Literal id="Prompt" runat="server" text=""></asp:Literal></Prompt> 
    <URL>http://192.168.5.31/Vendors/Cisco/Default.aspx</URL> 
    <InputItem> 
          <DisplayName>Phone number</DisplayName> 
          <QueryStringParam>pn</QueryStringParam> 
          <InputFlags>N</InputFlags> 
          <DefaultValue /> 
    </InputItem>
    <InputItem> 
          <DisplayName>Passcode</DisplayName> 
          <QueryStringParam>pc</QueryStringParam> 
          <InputFlags>PN</InputFlags> 
          <DefaultValue /> 
    </InputItem>  
</CiscoIPPhoneInput>
</asp:PlaceHolder>
<asp:PlaceHolder id="HomeScreen" runat="server" visible="false">
<CiscoIPPhoneMenu>
    <Title>Weavver Voice</Title>
    <Prompt><asp:Literal id="PunchStatus" runat="server"></asp:Literal></Prompt>
    <MenuItem>
          <Name><asp:Literal id="PunchAction" runat="server"></asp:Literal></Name>
          <URL><asp:Literal id="PunchURL" runat="server"></asp:Literal></URL>
    </MenuItem>
    <MenuItem>
          <Name>Time Card</Name>
          <URL>http://192.168.5.31/Vendors/Cisco/TimeLogs.aspx</URL>
    </MenuItem>
    <MenuItem>
          <Name>Log Out</Name>
          <URL>http://192.168.5.31/Vendors/Cisco/Default.aspx?action=logout</URL>
    </MenuItem>
</CiscoIPPhoneMenu>
</asp:PlaceHolder>