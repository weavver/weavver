using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Weavver.Data;

namespace DynamicData
{
     public partial class Decimal : System.Web.DynamicData.FieldTemplateUserControl
     {
          protected void Page_Load(object sender, EventArgs e)
          {
          }


          public override string FieldValueString
          {
               get
               {
                    string value = base.FieldValueString;
                    if (ContainerType == ContainerType.List)
                    {
                         if (value.Contains("("))
                         {
                              Stylizer.Style.Add("color", "red");
                         }
                    }
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
