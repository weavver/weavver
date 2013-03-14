<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Navigation.ascx.cs" Inherits="Navigation" %>
<%@ Register src="NavigationButton.ascx" tagname="NavigationButton" tagprefix="uc1" %>

<!-- <a runat="server" id="DefaultButton" class="button" href="/Default.aspx" onclick="this.blur();"><span>Home</span></a>
-->
<div style="display: inline-block;">
     <a id="Products" runat="server" class="button" href="~/Logistics_Products/Showcase.aspx" onclick="this.blur();"><span>Products</span></a>
</div>
<div style="display: inline-block;">
     <a id="AboutUs" class="button" href="~/about/" onclick="this.blur();"><span>About Us</span></a>
</div>