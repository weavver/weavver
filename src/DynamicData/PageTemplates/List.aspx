<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="List.aspx.cs" Inherits="DynamicData.List" ValidateRequest="False" %>
<%@ Register Src="~/DynamicData/DynamicList.ascx" TagName="DynamicList" TagPrefix="wvvr" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
     <wvvr:DynamicList ID="DList" runat="server" />
</asp:Content>
