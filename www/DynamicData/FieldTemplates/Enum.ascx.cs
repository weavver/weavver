using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.ComponentModel;

namespace DynamicData
{
     public partial class EnumField : System.Web.DynamicData.FieldTemplateUserControl
     {
          private const int MAX_DISPLAYLENGTH_IN_LIST = 40;
//-------------------------------------------------------------------------------------------
          public override string FieldValueString
          {
               get
               {
                    string value = base.FieldValueString;
                    string description = value;
                    if (ContainerType == ContainerType.List)
                    {
                         var enumDataType = Column.GetEnumType();
                         var values = Enum.GetValues(enumDataType);
                         foreach (var value2 in values)
                         {
                              if (value2.ToString() == value)
                              {
                                   FieldInfo fi = value2.GetType().GetField(value2.ToString());

                                   DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                                   if (attributes.Length > 0)
                                        return attributes[0].Description;
                                   break;
                              }
                         }

                         if (value != null && value.Length > MAX_DISPLAYLENGTH_IN_LIST)
                         {
                              value = value.Substring(0, MAX_DISPLAYLENGTH_IN_LIST - 3) + "...";
                         }
                    }
                    return value;
               }
          }
//-------------------------------------------------------------------------------------------
          public override Control DataControl
          {
               get
               {
                    return Literal1;
               }
          }
//-------------------------------------------------------------------------------------------
          protected override void OnPreRender(EventArgs e)
          {
               base.OnPreRender(e);
          }
//-------------------------------------------------------------------------------------------
     }
}
