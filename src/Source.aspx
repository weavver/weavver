<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Source.aspx.cs" Inherits="Source" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="Server">
     <asp:Literal ID="PageSource" runat="server"></asp:Literal><br /><br />
<div id="editor" style="height:500px;position: relative;"><asp:Literal ID="SourceCode" runat="server"></asp:Literal></div>
     <script type="text/javascript">
          window.onload = function () {
               var editor = ace.edit("editor");
               //editor.setTheme("ace/theme/twilight");

               var editMode = require("ace/mode/csharp").Mode;
               editor.getSession().setMode(new editMode());
          };
     </script>

<%--
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shCore.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushBash.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushCpp.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushCSharp.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushCss.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushDelphi.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushDiff.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushGroovy.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushJava.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushJScript.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushPhp.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushPlain.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushPython.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushRuby.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushScala.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushSql.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushVb.js"></script>
     <script type="text/javascript" src="~/Vendors/alexgorbatchev.com/scripts/shBrushXml.js"></script>
     <link type="text/css" rel="stylesheet" href="~/Vendors/alexgorbatchev.com/styles/shCore.css" />
     <link type="text/css" rel="stylesheet" href="~/Vendors/alexgorbatchev.com/styles/shThemeDefault.css" />
     <script type="text/javascript">
          SyntaxHighlighter.config.clipboardSwf = '~/scripts/clipboard.swf';
          SyntaxHighlighter.all();
     </script>
     The following code is the source for "<asp:Label ID="PageSource" runat="server"></asp:Label>".
     Our source code is provided under the GPLv2 and upon request under a proprietary
     commercial license.<br />
     <pre class="brush: c-sharp;">
          <%--<asp:Literal ID="SourceCode" runat="server"></asp:Literal>
     </pre>--%>
</asp:Content>
