<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="System_Tests_Report" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<form runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
 
     <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="860px" Height="80%">
     </rsweb:ReportViewer>

</form>