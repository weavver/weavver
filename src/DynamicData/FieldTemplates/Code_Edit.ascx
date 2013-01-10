<%@ Control Language="C#" CodeFile="Code_Edit.ascx.cs" Inherits="DynamicData.Code_EditField" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:UpdatePanel ID="updatePanel1" runat="server">
<ContentTemplate>
     <asp:PlaceHolder ID="HTMLEditor" runat="server" Visible="true">
          <CKEditor:CKEditorControl ID="TextBox1" runat="server" Height="200px" EnterMode="BR" ToolbarStartupExpanded="false" Text="<%# FieldValueEditString %>"></CKEditor:CKEditorControl>
          <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
          <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
          <asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" />
     </asp:PlaceHolder>
     <div style="float:right;clear:both;">
          <asp:LinkButton ID="EditSource" runat="server" Text="Source Viewer" OnClick="EditSource_Click"></asp:LinkButton>
     </div>
     <asp:Panel ID="SourceEditor" runat="server" Visible="false">
          <div id="editor" style="height:250px;position: relative; width: 100%; border: 1px solid black;">
               <%# Server.HtmlEncode(FieldValueEditString) %>
          </div>
     </asp:Panel>

     <script type="text/javascript">
          function LoadEditor() {
               var editor = ace.edit("editor");
               //editor.setTheme("ace/theme/twilight");

               var editMode = require("ace/mode/csharp").Mode;
               editor.getSession().setMode(new editMode());
               editor.getSession().setUseWrapMode(true);
               editor.getSession().setWrapLimitRange(120, 120); 
          }
     
          window.onload = function () {
               CKEditor.EditorWindow.parent.FCK.ToolbarSet._ChangeVisibility(true);
               //LoadEditor();
          };
     </script>
</ContentTemplate>
</asp:UpdatePanel>