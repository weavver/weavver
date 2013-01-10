<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrganizationTextField.ascx.cs" Inherits="Controls_OrganizationTextField" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:HiddenField ID="OrganizationCompleterId" runat="server" />
<asp:TextBox ID="tbOrganization" runat="server" Width="250px" AutoComplete="Off"></asp:TextBox>
<cc1:AutoCompleteExtender
     ID="OrganizationCompleter"
     runat="server"
     TargetControlID="tbOrganization"
     ServiceMethod="GetPayeeList"
     ServicePath="~/system/data/webservices.asmx"
     UseContextKey="true"
     ContextKey="0baae579-dbd8-488d-9e51-dd4dd6079e95"
     MinimumPrefixLength="2"
     CompletionInterval="1000"
     EnableCaching="true"
     CompletionSetCount="20"
     DelimiterCharacters=";, :"
     ShowOnlyCurrentWordInCompletionListItem="true"
     OnClientItemSelected="Organization_Selected">
     <Animations>
     </Animations>
</cc1:AutoCompleteExtender>