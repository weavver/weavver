using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData
{
     public partial class DateTime_EditField : System.Web.DynamicData.FieldTemplateUserControl
     {
          private static DataTypeAttribute DefaultDateAttribute = new DataTypeAttribute(DataType.DateTime);
          protected void Page_Load(object sender, EventArgs e)
          {
               TextBox1.ToolTip = Column.Description;

               SetUpValidator(RequiredFieldValidator1);
               SetUpValidator(RegularExpressionValidator1);
               SetUpValidator(DynamicValidator1);
               SetUpCustomValidator(DateValidator);
          }

          protected string Format(string value)
          {
               if (value != null)
               {
                    DateTime newDate;
                    if (DateTime.TryParse(value, out newDate))
                    {
                         if (Column.DataTypeAttribute != null)
                         {
                              switch (Column.DataTypeAttribute.DataType)
                              {
                                   case DataType.Date:
                                        return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(newDate, "UTC", "Pacific Standard Time").ToString("MM/dd/yy");
                              }
                              return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(newDate, "UTC", "Pacific Standard Time").ToString();
                         }
                    }
               }
               return value;
          }

          private void SetUpCustomValidator(CustomValidator validator)
          {
               if (Column.DataTypeAttribute != null)
               {
                    switch (Column.DataTypeAttribute.DataType)
                    {
                         case DataType.Date:
                         case DataType.DateTime:
                         case DataType.Time:
                              validator.Enabled = true;
                              DateValidator.ErrorMessage = HttpUtility.HtmlEncode(Column.DataTypeAttribute.FormatErrorMessage(Column.DisplayName));
                              break;
                    }
               }
               else if (Column.ColumnType.Equals(typeof(DateTime)))
               {
                    validator.Enabled = true;
                    DateValidator.ErrorMessage = HttpUtility.HtmlEncode(DefaultDateAttribute.FormatErrorMessage(Column.DisplayName));
               }
          }

          protected void DateValidator_ServerValidate(object source, ServerValidateEventArgs args)
          {
               DateTime dummyResult;
               args.IsValid = DateTime.TryParse(args.Value, out dummyResult);
          }

          protected override void ExtractValues(IOrderedDictionary dictionary)
          {
               DateTime enteredDateTime = DateTime.MinValue;
               if (DateTime.TryParse(TextBox1.Text, out enteredDateTime))
               {
                    dictionary[Column.Name] = enteredDateTime.ToUniversalTime();
               }
               else
               {
                    dictionary[Column.Name] = ConvertEditedValue(TextBox1.Text);
               }
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
