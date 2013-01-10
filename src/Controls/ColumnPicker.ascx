<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ColumnPicker.ascx.cs" Inherits="Controls_ColumnPicker" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:HyperLink ID="ChooseColumns" runat="server" Text="Choose Columns" Height="30px" />
<cc1:ModalPopupExtender ID="MPE" runat="server" PopupControlID="ColumnPanel" TargetControlID="ChooseColumns" BackgroundCssClass="modalPopup" />

<asp:Panel ID="ColumnPanel" runat="server" BackColor="#f0f0f0" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Width="275px">
     <div style="padding: 10px;">
          Choose columns:<br />
          <div style="max-height: 300px; overflow-y: scroll; margin-top: 10px; margin-bottom: 10px; border: solid 1px black; background-color: #FFFFFF;">
               <asp:CheckBoxList ID="Columns" runat="server"></asp:CheckBoxList>
               <%--
                    <td valign="top">
                         <asp:Button ID="DownloadCSV" runat="server" OnClick="DownloadCSV_Click" Text="Download CSV" Height="30px" Width="150px" />
               </td>--%>
          </div>
          <div style="text-align: center; padding-bottom: 0px;">
               <asp:Button ID="SetColumns" runat="server" Text="OK" Width="100%" Height="30px" OnClick="SetColumns_Click" /><br />
          </div>
     </div>
</asp:Panel>