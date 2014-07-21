<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LogIn.ascx.cs" Inherits="Controls_LogIn" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="LogInBox" class="LogInBox" runat="server" style="display: none;">
     <div style="background-color: #f6f8e8; padding: 10px 10px 10px 10px; margin-bottom: 5px;">
          <div style="float:right;">
               <asp:LinkButton ID="Close" runat="server">Close</asp:LinkButton>
          </div>
          <h3 style="">LOG IN</h3>
     </div>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
     <ContentTemplate>
          <asp:Login ID="Login1" runat="server" TextLayout="TextOnTop" Orientation="Horizontal" RememberMeSet="True" Font-Names="Verdana" Font-Size="0.8em" FailureText="<span style='color: red; margin: 4px;'>Please try again.</span>" RenderOuterTable="false">
          <LayoutTemplate>
               <div style="margin: auto; text-align: center; padding-bottom: 5px;">
                    <asp:TextBox ID="UserName" runat="server" Font-Size="1.25em" Width="150px" ValidationGroup="LogInControl" Height="30px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                    <cc1:TextBoxWatermarkExtender ID="UsernameWatermark" runat="server" TargetControlID="UserName" WatermarkCssClass="watermark" WatermarkText="Username"></cc1:TextBoxWatermarkExtender>
               </div>
               <div style="margin: auto; text-align: center; padding-bottom: 5px;">
                    <asp:TextBox ID="Password" runat="server" Font-Size="1.25em" Width="150px" TextMode="Password" ValidationGroup="LogInControl" Height="30px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                    <cc1:TextBoxWatermarkExtender ID="PasswordWatermark" runat="server" TargetControlID="Password" WatermarkCssClass="watermarkPW" WatermarkText=" "></cc1:TextBoxWatermarkExtender>
               </div>
               <div style="margin: auto; text-align: center; padding-bottom: 25px;">
                    <asp:CheckBox ID="RememberMe" runat="server" Checked="True" Text="Remember me" /><br />
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
               </div>
               <div style="margin: auto; text-align: center; padding-bottom: 10px;">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Font-Names="Verdana" Font-Size="9pt" Text="Log In" ValidationGroup="LogInControl" Height="30px" Width="100px" /><br />
               </div>
          </LayoutTemplate>
          </asp:Login>
     </ContentTemplate>
     </asp:UpdatePanel>
     <br />
     <div style="text-align: center; padding-bottom: 10px;">
          <a href="~/account/login?action=reset">Reset Password</a>
     </div>
</div>
<asp:HiddenField ID="MPERequiredButton" runat="server" Value="Ignore" />
<cc1:ModalPopupExtender ID="MPELogIn" runat="server" RepositionMode="RepositionOnWindowResizeAndScroll" BackgroundCssClass="modalPopup" TargetControlId="MPERequiredButton" PopupControlID="LoginBox" CancelControlID="Close" />