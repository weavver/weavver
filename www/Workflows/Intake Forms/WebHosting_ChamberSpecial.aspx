<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WebHosting_ChamberSpecial.aspx.cs" Inherits="Company_Services_Hosting_ChamberSpecial" Title="Weavver :: Hosting :: Chamber Special" %>
<%@ Register src="~/Controls/Contact.ascx" tagname="Contact" tagprefix="wvvr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <div style="float:right;text-align: right;">
          210 N. Malden Ave., Fullerton, CA 92832<br />
          Office: +1-714-872-5920<br />
          <br />
          <br />
          <div style="margin-right: 30px; margin-bottom: 30px;">
               <img src="/images/vendors/fullertonchamber.png" alt="Proud member of the Fullerton Chamber of Commerce" width="150px" />
          </div>
     </div>
     <h2>Free Web Hosting</h2><br />
     Weavver is an IT Services & Software Design firm in Downtown Fullerton, CA. To help introduce our services to Fullerton
     we are providing free web hosting to members of the Fullerton Chamber of Commerce.<br />
     <br />
     <div>
          <table id="HostingSignUp" runat="server" width="600px">
          <tr>
               <td width="245px" valign="top" style="border: solid 1px lightgray; padding: 15px; width: 245px;  background-color: #f5f5f5;">
                    <h3>Fullerton Chamber Special</h3>
                    <br />
                    <table width="240px">
                    <tr>
                         <td valign="top" style="width:150px;">
                              Disk Space<br />
                              Transfer<br />
                              Domains<br />
                              Users<br />
                              Mailboxes<br />
                              MySQL Database(s)<br />
                              Mail Redirects<br />
                              Mailing Lists<br />
                              PHP (v5)<br />
                              <br />
                         </td>
                         <td valign="top" style="width:150px;">
                              1GB<br />
                              20GB<br />
                              Unlimited<br />
                              1<br />
                              1<br />
                              1<br />
                              1<br />
                              0<br />
                              YES<br />
                              $4.99/month<br />
                         </td>
                    </tr>
                    </table>
                    Limited to 1 per customer. Service valued at $60 per year.
               </td>
               <td style="padding-left: 20px;">
                    <div  style="padding-left: 15px; background-color: #fafafa; border: solid 1px lightgrey; width: 320px; padding: 10px; margin-bottom: 15px;">
                         <h3>Business Name</h3><br />
                         <asp:TextBox ID="BusinessName" runat="server" Width="300px"></asp:TextBox><br />
                    </div>
                    <wvvr:Contact ID="PrimaryContact1" runat="server" />
                    <br />
                    <div  style="padding-left: 15px; background-color: #fafafa; border: solid 1px lightgrey; width: 320px; padding: 10px; margin-bottom: 15px;">
                         <h3>Domain Name</h3><br />
                         <asp:TextBox ID="Domain" runat="server" Width="300px"></asp:TextBox><br />
                    </div>
                    <div  style="padding-left: 15px; background-color: #fafafa; border: solid 1px lightgrey; width: 320px; padding: 10px; margin-bottom: 15px;">
                         <h3>Username</h3><br />
                         <asp:TextBox ID="Username" runat="server" Width="300px"></asp:TextBox><br />
                    </div>
                    <div  style="padding-left: 15px; background-color: #fafafa; border: solid 1px lightgrey; width: 320px; padding: 10px; margin-bottom: 15px;">
                         <h3>Password</h3><br />
                         <asp:TextBox ID="Password" runat="server" Width="300px" TextMode="Password"></asp:TextBox><br />
                    </div>
                    <asp:Label ID="ErrorMSG" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <table  style="padding-left: 15px; width: 330px;">
                    <tr>
                         <td></td>
                         <td style="text-align: right;">
                              <asp:Button ID="SignUp" runat="server" Text="Sign Up" Height="30px" Width="100px" OnClick="SignUp_Click" ValidationGroup="OrderForm" />
                         </td>
                    </tr>
                    </table>
               </td>
          </tr>
          </table>
          <asp:Panel ID="HostingSignedUp" runat="server" Visible="false">
               <div style="font-size: 20px; font-weight: bold; margin-top: 30px; margin-bottom: 30px;"><asp:Label ID="WelcomeMSG" runat="server" Text="Thank you for signing up. Your account will be provisioned shortly."></asp:Label></div>
          </asp:Panel>
          <asp:TextBox ID="Debug" runat="server" TextMode="MultiLine" Visible="false"></asp:TextBox>
     </div>
     <br />
     Please call us at +1-714-872-5920 if you have any questions or would like to find out more about our services.
     <br />
</asp:Content>