using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData
{
     public partial class DateField : System.Web.DynamicData.FieldTemplateUserControl
     {
//-------------------------------------------------------------------------------------------
          public string Format()
          {
               if (Mode == DataBoundControlMode.Insert)
                    return "";

               DateTime UtcDateTime = DateTime.SpecifyKind(((DateTime)FieldValue), DateTimeKind.Utc);
               DateTime LocalDateTime = TimeZoneInfo.ConvertTime(UtcDateTime, TimeZoneInfo.Local);
               Date.Attributes["title"] = "Database Value: " + FieldValueString + " UTC";
               if (ContainerType == ContainerType.List)
               {
                    return Weavver.Utilities.DateTimeHelper.GetFriendlyDateString(LocalDateTime);
               }
               return LocalDateTime.ToString();
               //return "commented out";
          }
//-------------------------------------------------------------------------------------------
          public string FormatTitle(string value)
          {
               if (ContainerType == ContainerType.List)
               {
                    if (value != null)
                    {
                         DateTime dateTime;
                         if (DateTime.TryParse(value, out dateTime))
                         {
                              //value = Weavver.Utilities.DateTimeHelper.GetFriendlyDateString(dateTime.ToLocalTime());
                              value = DateTime.Parse(value).ToString("G");
                         }
                    }
               }
               return value;
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
     }
}
