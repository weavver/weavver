<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Voicemails.ascx.cs" Inherits="Vendors_freeswitch_Voicemails" %>

<asp:Panel ID="Voicemail" runat="server">
     <div style="float:right;">
          <asp:DropDownList ID="VoicemailFolders" runat="server">
          <asp:ListItem>Inbox</asp:ListItem>
          </asp:DropDownList>
     </div>
     Recent voicemails:<br />
     <br />
     <asp:ListView ID="VoicemailList" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="BurlyWood">
     <ItemTemplate>
          <%--<%# DataBinder.Eval(Container.DataItem, "uuid") %><br />--%>
          <span title="Tel Address: <%# DataBinder.Eval(Container.DataItem, "cid_number")%>"><%# DataBinder.Eval(Container.DataItem, "cid_name")%> </span>
          <%--<%# DataBinder.Eval(Container.DataItem, "uuid") %><br />--%><br />
     </ItemTemplate>
     </asp:ListView>
<%--
          <asp:BoundColumn DataField="uuid" Visible="false"></asp:BoundColumn>
          <asp:BoundColumn DataField="cid_name" HeaderText="Name"></asp:BoundColumn>
          <asp:BoundColumn DataField="cid_number" HeaderText="Number" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
          <asp:BoundColumn DataField="created_epoch" HeaderText="Received" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150"></asp:BoundColumn>
     </Columns>
     </asp:DataGrid>--%>
     <asp:Literal ID="NoVoicemails" runat="server" Visible="false">No voicemails.</asp:Literal>
</asp:Panel>