<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" Title="Weavver :: System :: Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
     <h2>System Error</h2>
     <br />
     <asp:Panel ID="ErrorPan" runat="server">
          <span style="color: Blue;">There has been an error, ack! We've logged it and will check on it. It may only be a temporary issue please try again later.</span>
          <br />
          <br />
          If this has happened before and/or if you have a moment, please help us figure out what happened. We'll even try and let you know once the issue has been resolved.<br />
          <br />
          <div style="float:right">
               <img id="ErrorBanana" runat="server" alt="" src="~/images/system/error1.png" style="height: 300px;" />
          </div>
          Email address:&nbsp;&nbsp;<asp:TextBox ID="EmailAddress" runat="server" Width="200"></asp:TextBox> (optional)<br />
          <br />
          What were you trying to do when the error occurred?<br />
          <br />
          <asp:TextBox ID="Notes" runat="server" Height="150" Width="350" TextMode="MultiLine"></asp:TextBox><br />
          Please be as descriptive as possible.<br />
          <br />
          <asp:TextBox ID="HiddenField" runat="server" TextMode="MultiLine" Visible="false"></asp:TextBox>
          <asp:Button ID="NotifyMe" runat="server" Text="Submit" OnClick="Submit_Click" Height="30px" Width="100px" /><br />
          <br />
     * Your e-mail address will only be used in reference to this issue.<br />
     </asp:Panel>
     <asp:Panel ID="ErrorSent" runat="server" Visible="false">
          Thank you for your feedback.
     </asp:Panel>
     <br />
     <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
</asp:Content>