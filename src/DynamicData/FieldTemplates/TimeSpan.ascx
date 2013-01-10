<%@ Control Language="C#" CodeFile="TimeSpan.ascx.cs" Inherits="DynamicData.TimeSpanField" %>

<span title="Database value: <%# FieldValueString %> seconds">
     <asp:Literal runat="server" ID="Literal1" Text="<%# Format(FieldValueString) %>" />
</span>