<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WeavverChat.aspx.cs" Inherits="Controls_Chat" %>
<%@ Register src="~/Controls/Comments.ascx" tagname="Comments" tagprefix="wvvr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Weavver Chat</title>
     <link rel="icon" href="/Vendors/JSJaC/WeavverChat.png" sizes="64x64" type="image/png" />
     <link rel="apple-touch-icon-precomposed" href="/Vendors/JSJaC/WeavverChat.png" />
     <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;" />
     <link rel="stylesheet" type="text/css" href="/Vendors/JSJaC/WeavverChat.css" />
     <script type="text/javascript" src="/Vendors/jQuery/jquery-1.8.3.min.js"></script>
     <script type="text/javascript" src="/Vendors/JSJaC/src/JSJaC.js"></script>
     <script type="text/javascript" src="/Vendors/JSJaC/WeavverChat.js"></script>
     <script type="text/javascript">

          $(document).ready(function () {
               $("#CommentUpdate").keyup(function (ev) {
                    if (ev.which === 13) { // user presses ENTER
                         addMyMessage();
                    }
               });
          });

          function startOver() {
               $("#wrapup").fadeOut("fast", function () {
                         $("#preflight").fadeIn("fast");
                    }
               );

               }

               function beginChat() {
                    if (!Page_ClientValidate("")) {
                         alert("Please fill out the required fields.");
                         return;
                    }

                    PageMethods.LogInquiry($("#UserName").val(),
                                           $("#EmailAddress").val(),
                                           $("#PhoneNumber").val(),
                                           $('form input[type=radio]:checked').val(),
                                           $("#Inquiry").val(),
                                           onSucceed,
                                           onError);

                    doLogin(null);
               }
               
               function onSucceed(results, currentContext, methodName) {
                    //alert(results);
               }

               function onError(results, currentContext, methodName) {
                    // alert(results);
               }
     </script>
</head>
<body>
     <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
          <div id="preflight">
               <div id="intaketitle">Please fill out the following form to get started:</div>
               <div id="intakeform">
                    <div class="intakeFieldLabel" style="padding-bottom: 3px;">
                         What department would you like to speak to?
                         <asp:RequiredFieldValidator ID="DepartmentValidator" ControlToValidate="Department" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="intakeFieldData">
                         <asp:RadioButtonList ID="Department" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow">
                              <asp:ListItem>Sales</asp:ListItem>
                              <asp:ListItem>Customer Service</asp:ListItem>
                         </asp:RadioButtonList>
                    </div>
                    <div class="intakeFieldLabel">
                         Your Name: <asp:RequiredFieldValidator ID="UserNameValidator" ControlToValidate="UserName" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="intakeFieldData">
                         <asp:TextBox ID="UserName" runat="server" style="width:200px;" />
                    </div>
                    <div class="intakeFieldLabel">
                         E-mail Address: <asp:RequiredFieldValidator ID="EmailValidator" ControlToValidate="EmailAddress" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="intakeFieldData">
                         <asp:TextBox ID="EmailAddress" runat="server" style="width:200px;" />
                    </div>
                    <div class="intakeFieldLabel">
                         Phone Number: <asp:RequiredFieldValidator ID="PhoneNumberValidator" ControlToValidate="PhoneNumber" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="intakeFieldData">
                         <asp:TextBox ID="PhoneNumber" runat="server" style="width:200px;" />
                    </div>
                    <div style="clear: both;">
                         What are you inquiring about? <asp:RequiredFieldValidator ID="InquiryValidator" ControlToValidate="Inquiry" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <textarea id="Inquiry" runat="server" style="width: 100%; height: 50px;"></textarea>
               </div>
               <div style="clear: both; padding-bottom: 20px;">
                    <input id="submit" type="button" value="Begin Chat" onclick="beginChat();">
               </div>
               <div id="status" runat="server">
                    status: placeholder...
               </div>
          </div>
          <asp:UpdatePanel ID="CommentUpdater" runat="server" RenderMode="Block" ChildrenAsTriggers="true" UpdateMode="Conditional" Visible="true">
          <ContentTemplate>
               <div id="topBar">
                    <div style="float:right; margin-right: 10px; padding-top: 7px;">
                         <input id="EndChat" type="button" value="End Chat" onclick="quit();" style="padding-left: 15px; padding-right: 15px; height: 30px; font-size: 15px;" />
                    </div>
                    <div id="ChatTopic" style="float:left; vertical-align: middle; overflow: hidden; height: 30px; padding-top: 7px;">Chat:</div>
               </div>
               <div id="topPanel">
                    <div id="chatBox">
                    <asp:PlaceHolder ID="CommentPanel" runat="server">
                              <asp:DataList ID="List" runat="server" Visible="false">
                              <HeaderTemplate>
                                   <table cellpadding="0" cellspacing="0" style="">
                              </HeaderTemplate>
                              <ItemTemplate>
                                   <tr>
                                        <td valign="top" style="padding-left: 8px; padding-right: 5px;">
                                             <%# GetName((Guid)DataBinder.Eval(Container.DataItem, "CreatedBy")) %>:&nbsp;
                                             <%# DataBinder.Eval(Container.DataItem, "Body") %>
                                        </td>
                                        <td valign="top" style="background-color: #CCCCCC; margin-right: 8px; width: 100px; text-align: center;">
                                             <%# Weavver.Utilities.DateTimeHelper.GetFriendlyDateString(((DateTime) DataBinder.Eval(Container.DataItem, "CreatedAt")).ToLocalTime()) %>
                                        </td>
                                   </tr>
                              </ItemTemplate>
                              <AlternatingItemTemplate>
                                   <tr>
                                        <td valign="top" style="padding-left: 8px; padding-right: 5px;">
                                             <%# GetName((Guid) DataBinder.Eval(Container.DataItem, "CreatedBy")) %>:&nbsp;
                                             <%# DataBinder.Eval(Container.DataItem, "Body") %>
                                        </td>
                                        <td valign="top" style="background-color: #CCCCCC; margin-right: 8px; width: 100px; text-align: center;"><%# Weavver.Utilities.DateTimeHelper.GetFriendlyDateString(((DateTime)DataBinder.Eval(Container.DataItem, "CreatedAt")).ToLocalTime())%></td>
                                   </tr>
                              </AlternatingItemTemplate>
                              <FooterTemplate>
                                   </table>
                              </FooterTemplate>
                              </asp:DataList>
                    </asp:PlaceHolder>
                    </div>
               </div>
               <div id="bottomPanel">
                    <div id="messageBox">
                         <table width="100%">
                         <tr>
                              <td>
                                   <asp:TextBox ID="CommentUpdate" runat="server" Height="30px" Width="100%" BorderWidth="0"></asp:TextBox>
                              </td>
                              <td style="width: 30px;">
                                   <%--<asp:Button ID="Post" runat="server" OnClick="Save_Click" Text="send" Height="30px" OnClientClick="javascript:addMessage();" />--%>
                                   <input type="button" value="send" onclick="javascript:addMyMessage();" style="height: 30px;" />
                              </td>
                         </tr>
                         </table>
                    </div>
               </div>
          </ContentTemplate>
          </asp:UpdatePanel>        
          <div id="wrapup">
               <div id="thankyou">
                    <span id="DisconnectMessage">
                         "test"
                    </span>
                    Thank you for contacting us<br />
                    <br />
                    <br />
                    <a id="thankyoustartover" href="#" onclick="startOver();">Click here to start over</a>
               </div>
          </div>
    </form>
</body>
</html>