using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weavver.Data;

namespace DynamicData
{
     public partial class Enum_EditField : System.Web.DynamicData.FieldTemplateUserControl
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               DropDownList1.ToolTip = Column.Description;
               var enumDataType = Column.GetAttribute<EnumDataTypeAttribute>();

               if (!IsPostBack)
               {
                    var type = enumDataType.EnumType;
                    var values = Enum.GetValues(enumDataType.EnumType);
                    foreach (var value in values)
                    {
                         var memInfo = type.GetMember(value.ToString());
                         var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                         if (attributes.Length > 0)
                         {
                              var description = ((DescriptionAttribute)attributes[0]).Description;
                              DropDownList1.Items.Add(new ListItem(description, description));
                         }
                         else
                         {
                              DropDownList1.Items.Add(new ListItem(value.ToString(), value.ToString()));
                         }
                    }

                    //DropDownList1.DataSource = Enum.GetValues(enumDataType.EnumType);
                    //DropDownList1.DataBind();
               }

               //SetUpValidator(RequiredFieldValidator1);
               //SetUpValidator(RegularExpressionValidator1);
               //SetUpValidator(DynamicValidator1);
          }

          protected override void OnDataBinding(EventArgs e)
          {
               string x = FieldValueEditString.ToString();
               foreach (ListItem item in DropDownList1.Items)
               {
                    if (item.Value == x)
                    {
                         //DropDownList1.SelectedValue = x;
                         DropDownList1.SelectedValue = item.Value;
                         break;
                    }
               }

               base.OnDataBinding(e);
          }

          public override Control DataControl
          {
               get
               {
                    return DropDownList1;
               }
          }

          protected override void ExtractValues(IOrderedDictionary dictionary)
          {
               dictionary[Column.Name] = ConvertEditedValue(DropDownList1.SelectedValue);
          }
     }
}
