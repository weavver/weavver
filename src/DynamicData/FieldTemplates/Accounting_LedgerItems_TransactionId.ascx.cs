using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData
{
     public partial class Accounting_LedgerItems_TransactionIdField : System.Web.DynamicData.FieldTemplateUserControl
     {
          private const int MAX_DISPLAYLENGTH_IN_LIST = 40;

          public override string FieldValueString
          {
               get
               {
                    string value = base.FieldValueString;
                    if (ContainerType == ContainerType.List)
                    {
                         if (value != null && value.Length > MAX_DISPLAYLENGTH_IN_LIST)
                         {
                              value = value.Substring(0, MAX_DISPLAYLENGTH_IN_LIST - 3) + "...";
                         }
                    }
                    Literal1.Visible = (!String.IsNullOrEmpty(value));
                    return value;
               }
          }

          public override Control DataControl
          {
               get
               {
                    return Literal1;
               }
          }

          protected override void OnPreRender(EventArgs e)
          {
               base.OnPreRender(e);
          }

     }
}
