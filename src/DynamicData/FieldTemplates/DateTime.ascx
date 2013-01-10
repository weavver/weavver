<%@ Control Language="C#" CodeFile="DateTime.ascx.cs" Inherits="DynamicData.DateTimeField" %>

<span id="Date" runat="server">
     <asp:Literal runat="server" ID="Literal1" Text="<%# Format() %>" />
</span>