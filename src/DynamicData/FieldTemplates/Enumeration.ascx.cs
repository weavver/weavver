using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData
{
     public partial class EnumerationField : System.Web.DynamicData.FieldTemplateUserControl
     {
          public override Control DataControl
          {
               get
               {
                    return Literal1;
               }
          }

          public string EnumFieldValueString
          {
               get
               {
                    if (FieldValue == null)
                    {
                         return FieldValueString;
                    }

                    Type enumType = Column.GetEnumType();
                    if (enumType != null)
                    {
                         string enumText = FieldValue.ToString();

                         int enumInt = 0;
                         if (Int32.TryParse(enumText, out enumInt))
                         {
                              object enumValue = System.Enum.ToObject(enumType, enumInt);
                              enumText = FormatFieldValue(enumValue);
                         }
                         return enumText;
                    }

                    return FieldValueString;
               }
          }

     }
}
