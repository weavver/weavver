<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="Account_LogIn" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/Controls/LogIn.ascx" tagname="LogIn" tagprefix="wvvr" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
     <div style="width: auto; max-width: 400px; margin: auto; z-index: -10; text-align: center; padding: 5px; border: solid 1px lightgrey; text-align: center; padding-bottom: 15px;">
          <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
          <asp:View ID="LogInView" runat="server">
               <div style="text-align:left; background-color: #fbfbfb; border-bottom: solid 1px lightgrey; padding: 5px; padding-left: 10px;">
                    <h4>Sign in with your Weavver&reg; ID</h4>
               </div>
               <br />
               <asp:Login ID="Login1" runat="server" OnLoggedIn="Login1_LoggedIn" style="margin: auto;" TitleText="" RenderOuterTable="false">
               <LayoutTemplate>
               <div style=" margin: auto; margin-bottom: 10px; text-align: center;">
                    <asp:TextBox ID="UserName" runat="server" Height="20px" Font-Size="" Width="175px" ValidationGroup="LogInControl"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                    <cc1:TextBoxWatermarkExtender ID="UsernameWatermark" runat="server" TargetControlID="UserName" WatermarkCssClass="watermark" WatermarkText="Username"></cc1:TextBoxWatermarkExtender>
               </div>
               <div style="margin: auto; margin-bottom: 10px; text-align: center;">
                    <asp:TextBox ID="Password" runat="server" Height="20px" Font-Size="" Width="175px" TextMode="Password" ValidationGroup="LogInControl"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                    <cc1:TextBoxWatermarkExtender ID="PasswordWatermark" runat="server" TargetControlID="Password" WatermarkCssClass="watermarkPW" WatermarkText=" "></cc1:TextBoxWatermarkExtender>
               </div>
               <div style="margin: auto; margin-bottom: 10px;text-align: center;">
                    <asp:CheckBox ID="RememberMe" runat="server" Checked="True" Text="Remember me" /><br />
                    <br />
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
               </div>
               <div style="margin: auto; text-align: center;">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Font-Names="Verdana" Font-Size="9pt" Text="Log In" ValidationGroup="LogInControl" Height="25px" Width="100px" />
               </div>
               </LayoutTemplate>
                    <LoginButtonStyle Height="30px" Width="75px" />
               </asp:Login>
          </asp:View>
          <asp:View ID="ForgotPassView" runat="server">
               <div style="text-align:left; background-color: #fbfbfb; border-bottom: solid 1px lightgrey; padding: 5px; padding-left: 10px;"><h4>Password Recovery</h4></div>
               <br />
               <asp:PasswordRecovery ID="PassRec" runat="server" style="margin: auto" SubmitButtonText="Send me my password" QuestionTitleText="">
                    <SubmitButtonStyle Height="30px" />
                    <UserNameTemplate>
                         <div style="padding-bottom: 15px; text-align: center;">
                              <asp:TextBox ID="UserName" runat="server" Width="150px" Height="20px"></asp:TextBox>
                              <cc1:TextBoxWatermarkExtender ID="PasswordWatermark" runat="server" TargetControlID="UserName" WatermarkCssClass="watermark" WatermarkText="Username"></cc1:TextBoxWatermarkExtender>
                         </div>
                         <div>
                              <asp:Button ID="SubmitButton" runat="server" Text="Send me my password" CommandName="Submit" Height="30px" />
                         </div>
                    </UserNameTemplate>
               </asp:PasswordRecovery>
          </asp:View>
          </asp:MultiView>
          <wvvr:LogIn ID="LogIn" runat="server" />
     </div>
     <div style="padding-top: 10px; padding-bottom: 10px; text-align: left; clear:both; margin: auto; max-width: 400px;">
          Other options:<br />
          <a href="register">Register a new account</a> or
          <asp:LinkButton ID="Toggle" runat="server" Text="reset your password" style="color: Blue;" OnClick="ForgotPass_Click"></asp:LinkButton>
     </div>
</asp:Content>