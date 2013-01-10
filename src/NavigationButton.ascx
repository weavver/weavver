<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationButton.ascx.cs" Inherits="NavigationButton" %>
<li id="NavigationButtonLayer" runat="server" visible="false" class="navigation-button" style="" onclick="location.href='Default.aspx';">
</li>

<div style="display:table-column">
     <div class="navigation-button navigation-button-text" />
     
     <asp:Literal ID="lblButtonText" runat="server">Lorem Ipsum</asp:Literal></div>
     <div class="navigation-button" style="background-image: url('/images/button-nav-right.png'); width: 22px;" /></div>
</div>