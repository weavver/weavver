<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Register.ascx.cs" Inherits="RegisterControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:UpdatePanel ID="RegistrationWizard" runat="server" ChildrenAsTrigger="false" UpdateMode="Conditional">
<ContentTemplate>
     <div id="RegisterBox" style="text-align: left; border: solid 1px lightgrey; background-color: #f5fafc; padding: 10px; overflow: none; max-width: 464px;">
          <h3><asp:Literal id="Title" runat="server" Text="Register your Weavver&reg; Account" /></h3><br />
          <asp:Wizard ID="Wizard1" runat="server" DisplaySideBar="false" ActiveStepIndex="0">
          <SideBarTemplate></SideBarTemplate>
          <WizardSteps>
               <asp:TemplatedWizardStep ID="UserInfoStep" runat="server">
               <ContentTemplate>
                    Get a free Weavver account and enable your business within minutes.<br />
                    <br />
                    <div style="float:left; max-width: 175px">
                         <cc1:TextBoxWatermarkExtender ID="FirstNameWatermark" runat="server" TargetControlID="FirstName" WatermarkText="first name" WatermarkCssClass="watermark"></cc1:TextBoxWatermarkExtender>
                         <asp:TextBox ID="FirstName" runat="server" Visible="true" ValidationGroup="RegisterInfo"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstName" ErrorMessage="First name is required." ToolTip="First name is required." ValidationGroup="RegisterInfo">*</asp:RequiredFieldValidator><br />
                         <cc1:FilteredTextBoxExtender ID="filteredFirstName" runat="server" TargetControlID="FirstName" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz' " />
                    </div>
                    <div style="float:left; max-width: 175px; padding-bottom: 10px;">
                         <cc1:TextBoxWatermarkExtender ID="LastNameWatermark" runat="server" TargetControlID="LastName" WatermarkText="last name" WatermarkCssClass="watermark"></cc1:TextBoxWatermarkExtender>
                         <asp:TextBox ID="LastName" runat="server" Visible="true" ValidationGroup="RegisterInfo"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="LastNameValidator" runat="server" ControlToValidate="LastName" ErrorMessage="Last name is required." ToolTip="Last name is required." ValidationGroup="RegisterInfo">*</asp:RequiredFieldValidator><br />
                         <cc1:FilteredTextBoxExtender ID="filteredLastName" runat="server" TargetControlID="LastName" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz' " />
                    </div><br />
                    <div style="padding-bottom: 10px;">
                         <asp:TextBox ID="OrganizationName" runat="server" Visible="true"></asp:TextBox>
                         <cc1:TextBoxWatermarkExtender ID="OrganizationWatermark" runat="server" TargetControlID="OrganizationName" WatermarkText="organization name" WatermarkCssClass="watermark"></cc1:TextBoxWatermarkExtender>
                         <cc1:FilteredTextBoxExtender ID="filteredOrganization" runat="server" TargetControlID="OrganizationName" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz. 0123456789" />
                    </div>
                    <div>
                         <asp:TextBox ID="EmailAddress" runat="server"></asp:TextBox>
                         <cc1:TextBoxWatermarkExtender ID="EmailAddressWatermark" runat="server" TargetControlID="EmailAddress" WatermarkText="e-mail address" WatermarkCssClass="watermark"></cc1:TextBoxWatermarkExtender>
                         <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="EmailAddress" ErrorMessage="E-mail address is required." ToolTip="E-mail address is required." ValidationGroup="RegisterInfo">*</asp:RequiredFieldValidator><br />
                         <cc1:FilteredTextBoxExtender ID="filteredEmailAddress" runat="server" TargetControlID="EmailAddress" ValidChars="0123456789abcdefghijklmnopqrstuvwxyz.@-_" />
                         <asp:CustomValidator ID="EmailAddressValidator" runat="server" ControlToValidate="EmailAddress" ValidationGroup="RegisterInfo" OnServerValidate="EmailValidation" ErrorMessage="Please enter a valid e-mail address." ForeColor="Red"></asp:CustomValidator>
                    </div>
                    <div>
                         <asp:TextBox ID="UserName" runat="server" Visible="true" ValidationGroup="RegisterInfo"></asp:TextBox>
                         <cc1:TextBoxWatermarkExtender ID="UserNameWatermark" runat="server" TargetControlID="UserName" WatermarkText="username" WatermarkCssClass="watermark"></cc1:TextBoxWatermarkExtender>
                         <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Username is required." ToolTip="Username is required." ValidationGroup="RegisterInfo">*</asp:RequiredFieldValidator>
                         <cc1:FilteredTextBoxExtender ID="filteredUsername" runat="server" TargetControlID="UserName" ValidChars="0123456789abcdefghijklmnopqrstuvwxyz." />
                         <asp:RegularExpressionValidator ID="UsernameMinimumLength" runat="server" ControlToValidate="UserName" ErrorMessage="Username needs to be more then 6 characters" ValidationExpression=".{6}.*" ValidationGroup="RegisterInfo" />
                    </div>
                    <div>
                         <asp:TextBox ID="Password" runat="server" TextMode="Password" ValidationGroup="RegisterInfo"></asp:TextBox>
                         <cc1:TextBoxWatermarkExtender ID="PasswordWatermark" runat="server" TargetControlID="Password" WatermarkText=" " WatermarkCssClass="watermarkPW"></cc1:TextBoxWatermarkExtender>
                         <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="RegisterInfo">*</asp:RequiredFieldValidator>
                    </div>
                    <div style="float:left; max-width: 175px">
                         <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" EnableViewState="False"></asp:Label>&nbsp;
                    </div>
               </ContentTemplate>
               <CustomNavigationTemplate>
                    <%--<asp:CheckBox ID="cbWeavverPrivacy" CausesValidation="true" ValidationGroup="OrderForm" runat="server" Text="I agree to the <a target='_blank' href='~/company/legal/termsofservice'>Weavver&reg; TOS</a>." /><br /> --%>
                    <div style="float:right; clear: both; margin-top: 15px;">
                         <asp:Button ID="Next" runat="server" Text="Next" Height="30px" Width="100px" ValidationGroup="RegisterInfo" OnClick="UserInfoNext_Click" />
                    </div>
               </CustomNavigationTemplate>
               </asp:TemplatedWizardStep>
               <asp:TemplatedWizardStep ID="CaptchaStep">
               <ContentTemplate>
                    Fill in the box below with the text in the image:
                    <div id="captchadiv"></div>
                    <span style="color: red"><asp:Literal id="CaptchaError" runat="server" /></span>
                    <asp:CustomValidator ID="CaptchaValidation" runat="server" ValidationGroup="RegisterInfo"></asp:CustomValidator>
                    <div style="margin-top: 10px;">
                         <asp:Button ID="MoveBack" runat="server" Text="Previous" ValidationGroup="RegisterInfo" CommandName="MovePrevious" />
                         <div style="float:right;">
                              <asp:Button ID="Register" runat="server" Text="Register" Height="30px" Width="100px" ValidationGroup="RegisterInfo" OnClick="CaptchaStepNext_Click" />
                         </div>
                    </div>
               </ContentTemplate>
               <CustomNavigationTemplate></CustomNavigationTemplate>
               </asp:TemplatedWizardStep>
               <asp:TemplatedWizardStep ID="ActivateStep">
               <ContentTemplate>
                    You have been sent an e-mail with your activation code. Please enter it below to continue.
                    <br />
                    <br />
                    <asp:TextBox ID="ActivationCode" runat="server" Width="200"></asp:TextBox>
                    <asp:Button ID="Activate" runat="server" Text="Activate" Height="30" OnClick="ActivateNext_Click" /><br />
                    <br />
                    <asp:Literal ID="ActivationSent" runat="server" Text="<span style='color: green; font-weight: bolder;'>Activation code sent.</a>" Visible="false"></asp:Literal><br />
                    <cc1:TextBoxWatermarkExtender ID="ActivationWatermark" runat="server" TargetControlID="ActivationCode" WatermarkText="activation code" WatermarkCssClass="watermark"></cc1:TextBoxWatermarkExtender>
                    <br />
                    <span style="color:Red;">
                         <asp:Literal ID="ActivationFailed" runat="server" Text="Activation failed, please check the code you entered or click resend.<br /><br />" Visible="false"></asp:Literal>
                    </span>
               </ContentTemplate>
               <CustomNavigationTemplate>
                    <asp:Button ID="ActivationSend" runat="server" Text="Resend Activation Code" Height="25" OnClick="SendActivationEmail_Click" />
               </CustomNavigationTemplate>
               </asp:TemplatedWizardStep>
               <asp:TemplatedWizardStep ID="ActivatedStep">
               <ContentTemplate>
                    Your account is activated. Go to your <a href="~/account/">home page</a>.<br />
                    <br />
               </ContentTemplate>
               <CustomNavigationTemplate></CustomNavigationTemplate>
               </asp:TemplatedWizardStep>
          </WizardSteps>
          </asp:Wizard>
     </div>
</ContentTemplate>
</asp:UpdatePanel>

<script type="text/javascript">
     function CreateCaptcha()
     {
          Recaptcha.create('6LdVur8SAAAAAOqDC6K--CIsFtLhzJkvCTsIb5mb', 'captchadiv',
              {
                   tabindex: 1,
                   theme: "clean",
                   callback: Recaptcha.focus_response_field
              }
            );
      }
</script>