<%@ Control Language="C#" CodeFile="Code.ascx.cs" Inherits="DynamicData.Code" %>

<%# HTMLPurifierLib.Sanitize(Server.HtmlDecode(FieldValueString)) %><%-- //<asp:Literal runat="server" ID="Literal1" Text="" />--%>

<script type="text/javascript">
     window.onload = function () {
          var editor = ace.edit("editor");
          // $editor.resize();

          //editor.getSession().setUseWrapMode(true);

          var lines = editor.getSession().getValue().split("\n").length;
          var height = editor.getSession().getDocument().getLength() * editor.renderer.lineHeight + editor.renderer.scrollBar.getWidth();
          $('#editor').css('height', height);
          $('#editor').css('width', '100%');
          $('#editor').css('min-width', '200px');
          $('#editor').css('border', 'solid 1px black');

          //editor.setTheme("ace/theme/twilight");
          editor.session.setMode("ace/mode/c_cpp");
     };
</script>