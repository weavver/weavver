<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ColumnPicker.ascx.cs" Inherits="Controls_ColumnPicker" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/javascript">
     function show() {
          $("#ColumnPanel").dialog({
               title: "Choose columns",
               width: 275,
               position: 'center'
          });
     }
</script>
<a onclick='show()' href='#'>Choose Columns</a>
<div id="ColumnPanel" style="background-color: #f0f0f0; width: 275px; display: none;">
     <div style="padding: 10x;">
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
</div>