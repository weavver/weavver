using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Company_Accounting_Transaction : SkeletonPage
{
     protected void Page_Load(object sender, EventArgs e)
     {
          Master.FormTitle = "Transaction";
     }
//-------------------------------------------------------------------------------------------
//     public IEnumerable<LedgerItem> ByTransaction(Guid organizationId, Guid transactionId)
//     {
//          string sql = "select * from account_ledgeritems li, accounting_transactions t where t.ledgeritemid = li.id and t.transactionid = '@transactionid'";


//          ICriteria criteria = DatabaseHelper.Session.CreateCriteria(typeof(LedgerItem))
//               .Add(Restrictions.Eq("OrganizationId", organizationId))
//               .Add(Restrictions.Eq("TransactionId", transactionId));

//          return (List<LedgerItem>)criteria.List<LedgerItem>();
//     }
//-------------------------------------------------------------------------------------------
}