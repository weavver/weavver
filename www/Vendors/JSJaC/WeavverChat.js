if (typeof String.prototype.startsWith != 'function')
{
     // see below for better implementation!
     String.prototype.startsWith = function (str)
     {
          return this.indexOf(str) == 0;
     };
}


function chat_getPseudoGuid() {
     return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
          var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
          return v.toString(16);
     });
}

var chatHttpBindURI = "http://albert.weavver.com:5280/http-bind/";
var chatDisplayName = "Customer";
var chatDomain = "web.chat";
var chatUserName = chat_getPseudoGuid();
var chatResource = "WeavverWebChat";
var chatPassword = "askdjfhaskjdfalksjd";
var chatTopic = "Inquiry";
var chatRoomId = chatUserName + "@conference.web.chat";
var chatDisconnectMessage = null;
var chatSupportAgent = "mitcheloc@weavver.com";

$(document).ready(function () {
     var host = window.location.host;
     if (window.location.host != "www.weavver.local")
          host = "www.weavver.com";
     $(document).data("baseurl", parent.location.protocol + "//" + host);
     var baseurl = $(document).data("baseurl");
     //$('head').append($('<link rel="stylesheet" type="text/css" />').attr('href', baseurl + '/Vendors/JSJaC/WeavverChat.css'));

     var chatLinks = $('a[href^="xmpp:"]');
     chatLinks.each(function () {
          var elemId = $(this).attr("id");
          if (!elemId) {
               elemId = chat_getPseudoGuid();
               $(this).attr("id", elemId);
          }
          var originalHREF = $(this).attr("href");
          $(this).data("href", originalHREF);
          $(this).attr("href", "javascript:showChat('" + elemId + "')");
     }
     );

     $("#CommentUpdate").focus();

     $("#ChatTopic").text(chatTopic);
});

$(window).unload(function () {
     con.disconnect();
});

function getResource(jid) {
     jid = jid + ''; // conver to a string
     return jid.substring(jid.lastIndexOf("/") + 1);
}

function showChat(elemId) {
     chatUserName = elemId;
     var height = 370;
     var width = 550;
//     var left = (screen.width / 2) - (width / 2);
//     var top = (screen.height / 2) - (height / 2);
     var newwindow = window.open("/Vendors/JSJaC/WeavverChat.aspx", 'name', 'height='+height+', width='+width);
     if (window.focus) { newwindow.focus() }
}

//<a href="#" onclick="OpenChat('Chat.html')">Chat</a>

function addMyMessage()
{
     try {
          var message = $("#CommentUpdate").val();
          var oMsg = new JSJaCMessage();
          oMsg.setTo(new JSJaCJID(chatRoomId));
          oMsg.setBody(message);
          oMsg.setType('groupchat');

          con.send(oMsg);

          var groupchat = true;
          if (!groupchat) // we do this because we get the message forwarded back from the server anyways..
          {
               addMessage(message);
          }
          $("#CommentUpdate").val('');
          return true;
     } catch (e) {
          html = "<div class='msg error''>Error: " + e.message + "</div>";
          addMessage(html);
          return false;
     }
}

function setMUCRoomTopic(roomSubject) {
     var oMsg = new JSJaCMessage();
     oMsg.setTo(new JSJaCJID(chatRoomId));
     oMsg.setType('groupchat');
//     
//     var subject = oMsg.buildNode("subject");
//     subject.setAttribute("affiliation", "none");
//

     oMsg.setSubject(roomSubject);
     con.send(oMsg);
}

function addMessage($msg)
{
     if ($msg == "")
          return;
     $("#chatBox").append($msg + "<br />");
     ScrollBottom();
}

function ScrollBottom() {
     var objDiv = document.getElementById("chatBox");
     objDiv.scrollTop = objDiv.scrollHeight;
}


//function startHttpStream() {
//     var baseurl = $(document).data("baseurl");
//     var url = baseurl + "/Controls/ChatStream.ashx";
//     postRequest(url);
//}


function handleIQ(oIQ) {
     var html = "<div class='msg'>IN (raw): " + oIQ.xml().htmlEnc() + '</div>';
     addMessage(html);
     con.send(oIQ.errorReply(ERR_FEATURE_NOT_IMPLEMENTED));
}

// typing notification: <message xmlns="jabber:client" xmlns:stream="http://etherx.jabber.org/streams" from="mythicalbox@weavver.com/Laptop" to="mitcheloc@weavver.com" type="chat" id="purple20529fe1">
               //<composing xmlns="http://jabber.org/protocol/chatstates"/>
//</message>

function handleMessage(packet) {
     var html = '';
     var messageFrom = packet.getFromJID().getNode();
     messageFrom = (packet.getType() == "groupchat") ? getResource(packet.getFromJID()) : messageFrom;

     var xNode = packet.getChild('x', 'http://jabber.org/protocol/muc#user');
     if (xNode && xNode.namespaceURI == "http://jabber.org/protocol/muc#user")
     {
          // <message xmlns='jabber:client' from='cb0ce8d2-da0e-4c44-9d77-0d224259b2cb@conference.web.chat' to='cb0ce8d2-da0e-4c44-9d77-0d224259b2cb@web.chat/WeavverWebChat' xml:lang='en'>
          //   <x xmlns='http://jabber.org/protocol/muc#user'>
          //        <decline from='mitcheloc@weavver.com'/>
          //   </x>
          // </message>

          if (xNode.getElementsByTagName("decline").length == 1) {
               chatDisconnectMessage = "A representative is not available at this time.. please try again later.<br /><br />";
               quit();
          }
     }
     var isTyping = packet.getChild("composing");
     if (isTyping) {
          html += '<span class="msg">' + messageFrom + ' is typing...</b>';
          html += packet.getBody().htmlEnc() + '</span>';
          addMessage(html);
     }
     else if (packet.getChild("body"))
     {
          html += '<span class="msg">' + messageFrom + ': ';
          html += packet.getBody().htmlEnc() + '</span>';
          addMessage(html);
     }
}


// MUC PRESENCE:  <body xmlns='http://jabber.org/protocol/httpbind'>
//                       <presence xmlns='jabber:client' from='test@conference.web.chat/mythicalbox' to='test@web.chat/WeavverWebChat'>
//                            <priority>1</priority>
//                            <c xmlns='http://jabber.org/protocol/caps' node='http://pidgin.im/' hash='sha-1' ver='I22W7CegORwdbnu0ZiQwGpxr0Go='/>
//                            <x xmlns='http://jabber.org/protocol/muc#user'>
//                            <item jid='mythicalbox@weavver.com/Laptop' affiliation='owner' role='moderator'/></x>
//                       </presence>
//                  </body>

function handlePresence(packet) {

     var isMucPresenceEvent = false;
     var jid = packet.getFromJID() + '';

     var xNode = packet.getChild('x', 'http://jabber.org/protocol/muc#user');
     if (xNode && xNode.namespaceURI == "http://jabber.org/protocol/muc#user") {
          isMucPresenceEvent = true;
          jid = getResource(jid);
     }

     var html = '<span class="msg">';
     if (!packet.getType() && !packet.getShow()) {

          if (isMucPresenceEvent) {
               html += jid + " has joined the chat";
          }
          else if (getResource(jid) == "WeavverWebChat") {
               return;
          }
          else
          {
               html += jid + ' has become available.</b>';
          }
     }
     else {
          if (isMucPresenceEvent) {
               html += jid + " has left the chat";
          }
          else
          {
               html += '' + packet.getFromJID() + ' has set his presence to ';
               if (packet.getType())
                    html += packet.getType() + '.</b>';
               else
                    html += packet.getShow() + '.</b>';
               if (packet.getStatus())
                    html += ' (' + packet.getStatus().htmlEnc() + ')';
          }
     }
     html += '</span>';

     addMessage(html);
}

function handleError(e) {
     var html = "An error occured: " + ("Code: " + e.getAttribute('code') + "\nType: " + e.getAttribute('type') + "\nCondition: " + e.firstChild.nodeName).htmlEnc();

     addMessage(html);

     if (con.connected())
          con.disconnect();
}

function handleStatusChanged(status) {
     updateStatus(status);
}

var lastStatus = "";
function updateStatus(newState) {
     lastStatus = newState;
     $("#status").html("status: " + newState + "...");

}

function handleConnected() {

     updateStatus("connected");
     con.send(new JSJaCPresence());

     setModeReady();

     if (joinMUC()) {
          addMessage("Please wait while we get a representative..");

          var message = $("#Inquiry").val();
          var oMsg = new JSJaCMessage();
          oMsg.setTo(new JSJaCJID(chatRoomId));
          oMsg.setBody(message);
          oMsg.setType('groupchat');
          con.send(oMsg);

          inviteMUCParticipant();
     }

     // PageMethods.LogLead(userDisplayName, userEmailAddress, userPhoneNumber, userDepartment, userInquiry);
}

function handleDisconnected() {
     $("#submit").removeAttr("disabled");
     //$("#preflight").fadeIn("fast");
}

function handleIqVersion(iq) {
     con.send(iq.reply([iq.buildNode('name', 'jsjac simpleclient'), iq.buildNode('version', JSJaC.Version), iq.buildNode('os', navigator.userAgent)]));
     return true;
}

function handleIqTime(iq) {
     var now = new Date();
     con.send(iq.reply([iq.buildNode('display', now.toLocaleString()), iq.buildNode('utc', now.jabberDate()), iq.buildNode('tz', now.toLocaleString().substring(now.toLocaleString().lastIndexOf(' ') + 1))]));
     return true;
}

function doLogin(oForm) {
     //document.getElementById('err').innerHTML = '';
     // reset

     try {
          $("#submit").attr("disabled", "disabled");
          chatDisplayName = $("#UserName").val();
          //chatUserName = $("EmailAddress").val().replace("@");

          if (chatHttpBindURI.substr(0, 5) === 'ws://' || chatHttpBindURI.substr(0, 6) === 'wss://') {
               con = new JSJaCWebSocketConnection({
                    httpbase: chatHttpBindURI,
                    oDbg: new JSJaCConsoleLogger(4)
               });
          } else {
               con = new JSJaCHttpBindingConnection({
                    httpbase: chatHttpBindURI,
                    oDbg: new JSJaCConsoleLogger(4)
               });
          }

          setupCon(con);

          // setup args for connect method
          oArgs = new Object();
          oArgs.domain = chatDomain;
          oArgs.username = chatUserName;
          oArgs.resource = chatResource;
          oArgs.pass = chatPassword;
          //oArgs.register = oForm.register.checked;
          updateStatus("connecting..");
          con.connect(oArgs);

          updateStatus("connecting..");
     } catch (e) {
          addMessage("error: " + e.ToString());
          $("#submit").removeAttr("disabled");
     } finally {
          $("#submit").removeAttr("disabled");
          return false;
     }
}

function setupCon(oCon) {
     oCon.registerHandler('message', handleMessage);
     oCon.registerHandler('presence', handlePresence);
     oCon.registerHandler('iq', handleIQ);
     oCon.registerHandler('onconnect', handleConnected);
     oCon.registerHandler('onerror', handleError);
     oCon.registerHandler('status_changed', handleStatusChanged);
     oCon.registerHandler('ondisconnect', handleDisconnected);

     oCon.registerIQGet('query', NS_VERSION, handleIqVersion);
     oCon.registerIQGet('query', NS_TIME, handleIqTime);
}

function joinMUC() {
     //Set the JID with resource
     //Example: my_username@my_domain/my_chat_client
     var u_jid = chatUserName + "@" + chatDomain + "/" + chatResource;

     //Set the Full Room ID with your username as the resource
     //Example: room_name@conference.my_domain/my_username
     var full_room_id = chatUserName + "@conference.web.chat/" + chatDisplayName;

     var joinPacket = new JSJaCPresence();
     joinPacket.setTo(full_room_id);

     //Build item affiliation element
     var inode = joinPacket.buildNode("item");
     inode.setAttribute("affiliation", "none");
     inode.setAttribute("jid", u_jid);
     inode.setAttribute("role", "owner");

     //Build X Element (with item affiliation child)
     var xnode = joinPacket.buildNode("x", [inode]);
     xnode.setAttribute("xmlns", "http://jabber.org/protocol/muc#user");

     //Append new nodes to join packet
     joinPacket.appendNode(xnode);

     //Set status in room
     joinPacket.setStatus('available');

     var success = con.send(joinPacket, function (data) { console.log(data.getDoc()); })
     if (success) {
          setMUCRoomTopic("Inquiry");
          return true;
     }
}

// <message to="test@conference.weavver.com"><x xmlns="http://jabber.org/protocol/muc#user"><invite to="mythicalbox@weavver.com"/></x></message>
function inviteMUCParticipant() {
     var oMsg = new JSJaCMessage();
     oMsg.setTo(new JSJaCJID(chatUserName + "@conference.web.chat"));
     //oMsg.setBody("Customer Inquiry");
     var xReason = oMsg.buildNode("reason", "Customer Inquiry");

     var inviteNode = oMsg.buildNode("invite", [xReason]);
     //xInviteNode.setAttribute("password", "test");
     inviteNode.setAttribute("to", chatSupportAgent);

     var xNode = oMsg.buildNode("x", [inviteNode]);
     xNode.setAttribute("xmlns", "http://jabber.org/protocol/muc#user");
     oMsg.appendNode(xNode);

     var success = con.send(oMsg, function (data) { console.log(data.getDoc()); })
}

function quit() {
     var p = new JSJaCPresence();
     p.setType("unavailable");
     con.send(p);
     con.disconnect();

     $("#DisconnectMessage").html(chatDisconnectMessage);
     chatDisconnectMessage = "";

     updateStatus("disconnected");

     $("#CommentUpdater").fadeOut("fast", function () {
               $("#wrapup").fadeIn("fast");
          }
     );
}

function init() {
     try {// try to resume a session
          con = new JSJaCHttpBindingConnection({
               'oDbg': new JSJaCConsoleLogger(4)
          });

          setupCon(con);

          if (con.resume()) {
               updateStatus("connection resumed");
               setModeReady();
          }
          else {
               updateStatus("waiting on input");
          }
     } catch (e) {
     } // reading cookie failed - never mind

}

function setModeReady() {
     $("#preflight").fadeOut("fast", function () {
               $("#CommentUpdater").fadeIn("fast");
          }
     );
}

onload = init;

//onerror = function(e) {
//  document.getElementById('err').innerHTML = e;
//
//  document.getElementById('login_pane').style.display = '';
//  document.getElementById('sendmsg_pane').style.display = 'none';
//
//  if (con && con.connected())
//    con.disconnect();
//  return false;
//};

onunload = function () {
     if (typeof con != 'undefined' && con && con.connected()) {
          // save backend type
          if (con._hold)// must be binding
               (new JSJaCCookie('btype', 'binding')).write();
          else
               (new JSJaCCookie('btype', 'polling')).write();
          if (con.suspend) {
               con.suspend();
          }
     }
};