<%@ Control Language="C#" CodeFile="Accounting_LedgerItems_TransactionId.ascx.cs" Inherits="DynamicData.Accounting_LedgerItems_TransactionIdField" %>

<span title="<%# FieldValueString %>">
     <a href="?TransactionId=<%# FieldValueString %>"><asp:Literal runat="server" ID="Literal1" Text="TXN" /></a>
</span>