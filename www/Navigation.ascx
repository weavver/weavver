﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Navigation.ascx.cs" Inherits="Navigation" %>
<%@ Register src="NavigationButton.ascx" tagname="NavigationButton" tagprefix="uc1" %>

<!-- <a runat="server" id="DefaultButton" class="button" href="/Default.aspx" onclick="this.blur();"><span>Home</span></a>
-->
<div style="display: inline-block;">
     <a id="Products" runat="server" class="button" href="~/Logistics_Products/Showcase.aspx" onclick="this.blur();"><span>Products</span></a>
</div>
<div style="display: inline-block;">
          <a id="Projects" runat="server" class="button" href="~/Logistics_Projects/Showcase.aspx" onclick="this.blur();"><span>Projects</span></a>
     </div>
<div style="display: inline-block;">
          <a id="Forum" runat="server" class="button" href="~/forum/" onclick="this.blur();"><span>Forum</span></a>
     </div>
<div style="display: inline-block;">
          <a id="A1" runat="server" class="button" href="~/KnowledgeBase/KnowledgeBase.aspx" onclick="this.blur();"><span>Knowledge Base</span></a>
     </div>
<div style="display: inline-block;">
     <a id="AboutUs" class="button" href="~/about/" onclick="this.blur();"><span>About Us</span></a>
</div>