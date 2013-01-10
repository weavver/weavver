<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PhoneNumbers.ascx.cs" Inherits="SmartTags_PhoneNumbers" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<cc1:ModalPopupExtender ID="Mod" BackgroundCssClass="modalPopup" TargetControlID="CallMe" runat="server" PopupControlID="PopupPanel" CancelControlID="Cancel">
</cc1:ModalPopupExtender>
<asp:Panel ID="PopupPanel" runat="server" BackColor="White" Width="400px" Height="" BorderColor="Black" BorderStyle="Solid" style="margin: 10px;">
     <asp:UpdatePanel ID="UpdatePan" runat="server">
     <ContentTemplate>
          <h3 style="background-color: #FF8040; padding: 5px;">We will call you!</h3>
          <div style="margin: 10px;">
               If you have a phone number in the United States we can connect your call.<br />
               <br />
               <div style="clear: both; padding: 5px;">
                    <div style="float:right; clear: both;">
                         <asp:TextBox ID="YourPhoneNumber" runat="server" Width="200px"></asp:TextBox><br />
                         ex. 17145551212<br />
                         <br />
                    </div>
                    Your phone number:
               </div>
               <div style="clear: both; padding-bottom: 10px;">
                    <asp:Label ID="Connecting" runat="server" Visible="false" Text="" ForeColor="Red"></asp:Label>
               </div>
               <div style="padding: 10px; clear: both; padding-bottom: 5px;">
                    <div>
                         <span style="float:right; clear: both;">
                              <asp:Button ID="Call" runat="server" onclick="Submit_Click" Text="Call me!" Height="30" Width="110" />
                         </span>
                         <%--<asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" Height="30px" Width="80px" />--%>
                    </div>
               </div>
          </div>
     </ContentTemplate>
     </asp:UpdatePanel>
</asp:Panel>
<%--
<div>
          <asp:Panel ID="Step1" runat="server">
               <div style="font-size: 14pt; font-weight: bolder;">Weavver Dialer</div>
               <div style="font-size: 12pt; text-align: center; background-color: White; padding: 10px; margin-bottom: 10pt;">
                    Calling <asp:Label ID="PhoneNumber" runat="server"></asp:Label>
               </div>
               Your phone number or extension:<br />
               <asp:TextBox ID="Extension" runat="server"></asp:TextBox>
               <asp:Button ID="Dial" OnClick="Dial_Click" runat="server" Text="Dial" Height="25px" Width="50px" />
          </asp:Panel>
          <asp:Panel ID="Step2" runat="server" Visible="false">
               <script type="text/javascript">
                    window.parent.document.getElementById('dialerWidget').style.height = '40px';
               </script>
               <div style="float:right">
                    <a href="javascript:window.parent.document.getElementById('dialerWidget').style.visibility='hidden';">Close</a>
               </div>
               Your call is now connecting...
          </asp:Panel>
    </div>
--%>