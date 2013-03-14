<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sales_ResellerApplication.aspx.cs" Inherits="Company_Sales_ResellerApplication" Title="Weavver :: Reseller Application" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <asp:HiddenField runat="server" ID="hidLastTab" Value="0" />
     <asp:Panel ID="Anonymous" runat="server">
          Becoming a reseller is very simple. You will need to create a <a href="~/account/register">Weavver&reg; ID</a> and obtain an Organization ID. After that you please sign in and use our <a href="application">online application form</a>
          to begin the process.<br />
          <br />
          If you already have a Weavver ID <a href="~/account/login">log in</a> now to continue.<br />
     </asp:Panel>
     <asp:Panel ID="ResellerApp" runat="server">
          Please fill out all of the required fields. While not all information is required, the more details you provide,
          the more quickly we can process your application.  Normally, applicants will hear back within 1-2 weeks.<br />
          <br />
          <style type="text/css">
               #tabs, #tabs.td, #tabs.tr
               {
                    font-size: 10pt;
                    vertical-align: top;
               }
          </style>
          <script type="text/javascript">
            $(document).ready(function() {
              $("#tabs").tabs( {
                    show: function() {
                     var sel = $('#tabs').tabs('option', 'selected');
                     $("#<%= hidLastTab.ClientID %>").val(sel);
                 },
                 selected: <%= hidLastTab.Value %>
                 });
            });
            </script>
          <div id="tabs">
               <ul>
                    <li><a href="#fragment-1"><span>Your Information</span></a></li>
                    <li><a href="#fragment-2"><span>Company Information</span></a></li>
                    <li><a href="#fragment-3"><span>References</span></a></li>
               </ul>
               <div id="fragment-1" style="background-color: #f1f1e1; padding: 15px;">
                    <table cellpadding="5">
                    <tr>
                         <td>First Name</td>
                         <td><asp:TextBox ID="OrgNameFirst" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Last Name</td>
                         <td><asp:TextBox ID="OrgNameLast" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Position</td>
                         <td><asp:TextBox ID="OrgPosition" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Your Job Function</td>
                         <td>
                              <asp:DropDownList ID="JobFunction" runat="server">
                                   <asp:ListItem>Administrative</asp:ListItem>
                                   <asp:ListItem>Engineering</asp:ListItem>
                                   <asp:ListItem>Executive</asp:ListItem>
                                   <asp:ListItem>Marketing</asp:ListItem>
                                   <asp:ListItem>Sales</asp:ListItem>
                                   <asp:ListItem>Tech Support</asp:ListItem>
                                   <asp:ListItem>Other</asp:ListItem>
                              </asp:DropDownList>
                         </td>
                    </tr>
                    <tr>
                         <td>Direct Phone (yours)</td>
                         <td><asp:TextBox ID="OrgDirectPhone" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Company Phone</td>
                         <td><asp:TextBox ID="OrgCompanyPhone" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Fax</td>
                         <td><asp:TextBox ID="OrgFax" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Company Website</td>
                         <td><asp:TextBox ID="OrgWebsite" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Address Line 1</td>
                         <td><asp:TextBox ID="OrgAddressLine1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Address Line 2</td>
                         <td><asp:TextBox ID="OrgAddressLine2" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>City</td>
                         <td><asp:TextBox ID="OrgCity" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>State</td>
                         <td><asp:TextBox ID="OrgState" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Country</td>
                         <td><asp:TextBox ID="OrgCountry" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Zip Code</td>
                         <td><asp:TextBox ID="OrgZipCode" runat="server"></asp:TextBox></td>
                    </tr>
                    </table>
               </div>
               <div id="fragment-2" style="background-color: #f1f1e1; padding: 15px;">
                    <table>
                    <tr>
                         <td style="width: 250px;">Company Name</td>
                         <td><asp:TextBox ID="OrgName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Company Type:</td>
                         <td>
                              <asp:DropDownList ID="OrgType" runat="server">
                              <asp:ListItem></asp:ListItem>
                              <asp:ListItem>Sole Proprietor</asp:ListItem>
                              <asp:ListItem>Partnership</asp:ListItem>
                              <asp:ListItem>Corporation</asp:ListItem>
                              <asp:ListItem>LLC</asp:ListItem>
                              <asp:ListItem>Other</asp:ListItem>
                              <asp:ListItem>Don't Know</asp:ListItem>
                              </asp:DropDownList>
                         </td>
                    </tr>
                    <tr>
                         <td>Company Founded (year)*:</td>
                         <td><asp:TextBox ID="OrgOfficeAddress" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Incorporated in (State/Country):</td>
                         <td><asp:TextBox ID="OrgIncorporatedIn" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Name of Company President/CEO*:</td>
                         <td><asp:TextBox ID="OrgLeader" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Number of full-time employees*:</td>
                         <td><asp:TextBox ID="FullTimeEmployees" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Number of full-time offices</td>
                         <td><asp:TextBox ID="OrgFullTimeOffices" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Approximate Total Company Revenue (gross sales):</td>
                         <td>
                              <asp:DropDownList ID="OrgRevenue" runat="server">
                              <asp:ListItem></asp:ListItem>
                              <asp:ListItem>Under $100K</asp:ListItem>
                              <asp:ListItem>$100-250K</asp:ListItem>
                              <asp:ListItem>$250K-$1M</asp:ListItem>
                              <asp:ListItem>$1M-$5M</asp:ListItem>
                              <asp:ListItem>$5M-$10M</asp:ListItem>
                              <asp:ListItem>$10M-$25M</asp:ListItem>
                              <asp:ListItem>$25M-$100</asp:ListItem>
                              <asp:ListItem>Over $100M</asp:ListItem>
                              <asp:ListItem>Don't Know</asp:ListItem>
                              </asp:DropDownList>
                         </td>
                    </tr>
                    <tr>
                         <td>Approximate percentage of revenue from Phone/Voice/VoIP products/services:</td>
                         <td>
                              <asp:DropDownList ID="OrgTelecomRevenue" runat="server">
                              <asp:ListItem></asp:ListItem>
                              <asp:ListItem>Less than 10%</asp:ListItem>
                              <asp:ListItem>10-25%</asp:ListItem>
                              <asp:ListItem>25-50%</asp:ListItem>
                              <asp:ListItem>50-75%</asp:ListItem>
                              <asp:ListItem>More than 75%</asp:ListItem>
                              <asp:ListItem>Don't know</asp:ListItem>
                              </asp:DropDownList>
                         </td>
                    </tr>
                    <tr>
                         <td valign="top">Company’s Primary business (check all that apply)*:</td>
                         <td>
                              <asp:CheckBoxList ID="OrgPrimaryBusiness" runat="server">
                              <asp:ListItem>Business phone systems provider</asp:ListItem>
                              <asp:ListItem>PBX reseller</asp:ListItem>
                              <asp:ListItem>Voice service provider</asp:ListItem>
                              <asp:ListItem>Phone systems installer</asp:ListItem>
                              <asp:ListItem>Internet service provider</asp:ListItem>
                              <asp:ListItem>Voice services integrator</asp:ListItem>
                              <asp:ListItem>Voice services consulting</asp:ListItem>
                              <asp:ListItem>Unified Communications reseller/provider</asp:ListItem>
                              <asp:ListItem>Data services provider</asp:ListItem>
                              <asp:ListItem>Mobile (cell) phone reseller</asp:ListItem>
                              <asp:ListItem>Mobile services reseller</asp:ListItem>
                              <asp:ListItem>Custom Software development services</asp:ListItem>
                              <asp:ListItem>Web/data services provider (hosting)</asp:ListItem>
                              <asp:ListItem>Web designer/integrator</asp:ListItem>
                              <asp:ListItem>Independent technical consultant</asp:ListItem>
                              <asp:ListItem>Other voice-related</asp:ListItem>
                              <asp:ListItem>Other internet-related</asp:ListItem>
                              <asp:ListItem>End User of Weavver Products/Services</asp:ListItem>
                              </asp:CheckBoxList>
                         </td>
                    </tr>
                    <tr>
                         <td>Which Weavver Products/Services do you want to Resell?*:</td>
                         <td><asp:TextBox ID="OrgInterestedIn" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Please describe why you believe your company would be a good fit as a Weavver Reseller*:</td>
                         <td><asp:TextBox ID="OrgWhyInterested" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Does your company provide technical support to end users?</td>
                         <td>
                              <asp:DropDownList ID="OrgEndUserTechSupport" runat="server">
                              <asp:ListItem></asp:ListItem>
                              <asp:ListItem>Yes</asp:ListItem>
                              <asp:ListItem>No</asp:ListItem>
                              <asp:ListItem>Sometimes</asp:ListItem>
                              <asp:ListItem>Don't know</asp:ListItem>
                              </asp:DropDownList>
                         </td>
                    </tr>
                    <tr>
                         <td valign="top">Please describe why you believe your company would be a good fit as a Weavver Reseller*:</td>
                         <td><asp:TextBox ID="Org" runat="server" Width="300px" Height="125px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Would you expect to provide tech support for Weavver products?</td>
                         <td>
                              <asp:DropDownList ID="OrgProvideWeavverEndUserSupport" runat="server">
                              <asp:ListItem></asp:ListItem>
                              <asp:ListItem>Yes</asp:ListItem>
                              <asp:ListItem>No</asp:ListItem>
                              <asp:ListItem>Maybe</asp:ListItem>
                              </asp:DropDownList>
                         </td>
                    </tr>
                    <tr>
                         <td>Do you resell other products as an authorized reseller?</td>
                         <td>
                              <asp:DropDownList ID="OrgOtherReseller" runat="server">
                              <asp:ListItem></asp:ListItem>
                              <asp:ListItem>Yes</asp:ListItem>
                              <asp:ListItem>No</asp:ListItem>
                              <asp:ListItem>Sometimes</asp:ListItem>
                              <asp:ListItem>Don't know</asp:ListItem>
                              </asp:DropDownList>
                         </td>
                    </tr>
                    <tr>
                         <td>If “Yes”, please list companies you represent:</td>
                         <td><asp:TextBox ID="OrgOtherSales" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>How many sales agents does your company have?</td>
                         <td><asp:TextBox ID="OrgSalesAgents" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>How many technical support agents does your company have?</td>
                         <td><asp:TextBox ID="OrgTechAgents" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Does your company resell Asterisk-related products/services?</td>
                         <td>
                              <asp:DropDownList ID="OrgAsteriskReseller" runat="server">
                              <asp:ListItem></asp:ListItem>
                              <asp:ListItem>Yes</asp:ListItem>
                              <asp:ListItem>No</asp:ListItem>
                              <asp:ListItem>Sometimes</asp:ListItem>
                              <asp:ListItem>Don't know</asp:ListItem>
                              </asp:DropDownList>
                         </td>
                    </tr>
                    <tr>
                         <td>If “Yes”, list:</td>
                         <td><asp:TextBox ID="OrgAsteriskResellerDetails" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Does your company provide other PBX/VoIP hardware/software?</td>
                         <td><asp:TextBox ID="OrgTelecomOtherReseller" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>If “Yes”, list:</td>
                         <td><asp:TextBox ID="OrgOtherList" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>List any networking or professional certifications you hold:</td>
                         <td><asp:TextBox ID="OrgCertifications" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Are any of your employees Asterisk certified (dCAP)?</td>
                         <td><asp:TextBox ID="OrgDCAPEmployees" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>Are any of your employees Microsoft certified?</td>
                         <td><asp:TextBox ID="OrgMicrosoftCertifications" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                         <td>List any other related technical certifications your employees have:</td>
                         <td><asp:TextBox ID="OrgTechnicalCertifications" runat="server"></asp:TextBox></td>
                    </tr>
                    </table>
               </div>
               <div id="fragment-3" style="background-color: #f1f1e1; padding: 15px;">
               <h3>Reference 1</h3><br />
               <table>
               <tr>
                    <td>Name:</td>
                    <td><asp:TextBox ID="Reference1Name" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Company:</td>
                    <td><asp:TextBox ID="Reference1Company" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Title:</td>
                    <td><asp:TextBox ID="Reference1Title" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Email Address:</td>
                    <td><asp:TextBox ID="Reference1EmailAddress" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Phone:</td>
                    <td><asp:TextBox ID="Reference1Phone" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Relationship to Reference:</td>
                    <td><asp:TextBox ID="Reference1Relationship" runat="server"></asp:TextBox></td>
               </tr>
               </table>
               <br />
               <h3>Reference 2</h3><br />
               <table>
               <tr>
                    <td>Name:</td>
                    <td><asp:TextBox ID="Name" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Company:</td>
                    <td><asp:TextBox ID="Reference2Company" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Title:</td>
                    <td><asp:TextBox ID="Reference2Title" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Email Address:</td>
                    <td><asp:TextBox ID="Reference2EmailAddress" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Phone:</td>
                    <td><asp:TextBox ID="Reference2Phone" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Relationship to Reference:</td>
                    <td><asp:TextBox ID="Reference2Relationship" runat="server"></asp:TextBox></td>
               </tr>
               </table>
               </div>
               </div>
               <br />
               Comments or Questions:<br />
               <br />
               <asp:TextBox ID="CommentsQuestions" runat="server" Width="800px" Height="75px" TextMode="MultiLine"></asp:TextBox><br />
               <br />
               Application Agreement & Release:<br />
               <br />
               I hereby certify that the above information is true and accurate to the best of my knowledge.  I hereby authorize Weavver,
               Inc. and its agents to use the information for the purpose of evaluating me and/or my company as a potential
               Weavver Reseller.  I also authorized Weavver to contact any of the persons I have named above to verify relevant
               information I have provided, and relevant background information about me and my company.  I hereby release Weavver and all
               of the above named references from any liability relating to information they provide about me to Weavver. 
               I understand that Weavver may reject my application for any reason.  If I am approved as a Reseller Candidate,
               I understand that I may be required undergo a background and/or credit check, and to sign a Weavver Reseller Agreement.<br />
               <br />
               <br />
               <div style="float:right;">
                    <asp:Button ID="Apply" runat="server" Text="Submit Application"  Height="30px" Width="140px" OnClick="Apply_Click" />
               </div>
               <div style="clear:both;">&nbsp;</div>
          </div>
     </asp:Panel>
     <asp:Panel ID="ResellerApplied" runat="server" Visible="false">
          Thank you for applying to the Weavver reseller program. We will review your application and notify you when
          once we are finished. Please expect to hear from us in 1-5 business days.<br />
          <br />
          <br />
          <div style="margin: auto;">
               <a href="~/">Return to the home page</a>
          </div>
     </asp:Panel>
     <br />
</asp:Content>