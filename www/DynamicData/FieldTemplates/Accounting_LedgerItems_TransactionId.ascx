<%@ Control Language="C#" CodeFile="Accounting_LedgerItems_TransactionId.ascx.cs" Inherits="DynamicData.Accounting_LedgerItems_TransactionIdField" %>

<script type="text/javascript">
     function test(e) {
          createPopup('/Accounting_LedgerItems/List.aspx?TransactionId=e98ab7d2-55d3-40d8-be6c-0dad05dfc36e', '1000', '450');
          var evt = e ? e : window.event;
          if (evt.stopPropagation) evt.stopPropagation();
          if (evt.cancelBubble != null) evt.cancelBubble = true;
     }
</script>
<span title="<%# FieldValueString %>">
     <a href="#" onclick="javascript:test();"><asp:Literal runat="server" ID="Literal1" Text="TXN" /></a>
</span>

<%--href="?TransactionId=<%# FieldValueString %>" --%>