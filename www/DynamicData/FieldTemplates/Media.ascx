<%@ Control Language="C#" CodeFile="Media.ascx.cs" Inherits="DynamicData.TextField" %>

<asp:Literal runat="server" ID="Literal1" Text="<%# FieldValueString %>" />

<script language="JavaScript" src="~/vendors/Martin Laine/audio_player/audio-player.js"></script>
<object type="application/x-shockwave-flash" data="~/vendors/Martin Laine/audio_player/player.swf" id="audioplayer1" height="24" width="290">
     <param name="movie" value="~/vendors/Martin Laine/audio_player/player.swf">
     <param name="FlashVars" value="playerID=1&amp;soundFile=http://apps.weavver.local/samples/sample.wav">
     <param name="quality" value="high">
     <param name="menu" value="false">
     <param name="wmode" value="transparent">
</object>