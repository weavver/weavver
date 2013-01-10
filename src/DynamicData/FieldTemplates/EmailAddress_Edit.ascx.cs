using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData
{
     public partial class EmailAddress_EditField : System.Web.DynamicData.FieldTemplateUserControl
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               TextBox1.ToolTip = Column.Description;

               SetUpValidator(RequiredFieldValidator1);
          }

          protected override void ExtractValues(IOrderedDictionary dictionary)
          {
               dictionary[Column.Name] = ConvertEditedValue(TextBox1.Text);
          }

          public override Control DataControl
          {
               get
               {
                    return TextBox1;
               }
          }

     }
}
