using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData
{
     public partial class DateTimeField : System.Web.DynamicData.FieldTemplateUserControl
     {
//-------------------------------------------------------------------------------------------
          protected void Page_Init(object sender, EventArgs e)
          {
               if (Mode == DataBoundControlMode.ReadOnly)
               {
                    Date.Style["text-align"] = "center";
               }
          }
//-------------------------------------------------------------------------------------------
          public string Format()
          {
               if (FieldValue == null)
                    return "";

               DateTime UtcDateTime = DateTime.SpecifyKind(((DateTime)FieldValue), DateTimeKind.Utc);
               DateTime LocalDateTime = TimeZoneInfo.ConvertTime(UtcDateTime, TimeZoneInfo.Local);
               Date.Attributes["title"] = "Database Value: " + UtcDateTime.ToString() + " UTC";
               return Weavver.Utilities.DateTimeHelper.GetFriendlyDateString(LocalDateTime);
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
