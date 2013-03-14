<%@ Control Language="C#" CodeFile="Date.ascx.cs" Inherits="DynamicData.DateField" %>

<div id="Date" runat="server" style="text-align: center;">
     <asp:Literal runat="server" ID="Literal1" Text="<%# Format() %>" />
</div>