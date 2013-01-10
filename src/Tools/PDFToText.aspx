<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PDFToText.aspx.cs" Inherits="Tools_PDFToText" Title="Weavver Tools :: PDF to Text Converter" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <br />
     <table>
     <tr>
          <td>
               <asp:FileUpload ID="PDFUpload1" runat="server" />
          </td>
          <td>
               <asp:Button ID="Convert" runat="server" Text="Extract Text" Height="30px" OnClick="Convert_Click" />
          </td>
     </tr>
     </table>
     <br />
     Textual output:<br />
     <br />
     <asp:TextBox ID="Output" runat="server" TextMode="MultiLine" Width="800px" Height="500px"></asp:TextBox><br />
     <br />
</asp:Content>

