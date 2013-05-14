<%@ Control Language="C#" CodeFile="DateRange.ascx.cs" Inherits="DynamicData.DateRangeFilter" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:TextBox ID="txbDateFrom" runat="server" CssClass="DDFilter" Width="60px"></asp:TextBox>
<cc1:CalendarExtender ID="txbDateFrom_CalendarExtender" runat="server" Enabled="True" TargetControlID="txbDateFrom" />
through
<asp:TextBox ID="txbDateThrough" runat="server" CssClass="DDFilter" Width="60px"></asp:TextBox>
<cc1:CalendarExtender ID="txbDateThrough_CalendarExtender" runat="server" Enabled="True" TargetControlID="txbDateThrough" />
