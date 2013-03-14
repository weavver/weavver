using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData
{
     public partial class TimeSpanField : System.Web.DynamicData.FieldTemplateUserControl
     {
          private const int MAX_DISPLAYLENGTH_IN_LIST = 40;

          public override string FieldValueString
          {
               get
               {
                    return base.FieldValueString;
               }
          }

          protected string Format(string durationStr)
          {
               double seconds = 0;
               if (Double.TryParse(durationStr, out seconds))
               {
                    TimeSpan duration = TimeSpan.FromSeconds(seconds);
                    string ret = "";
                    if (duration.Hours > 0)
                         ret += duration.Hours + " hours ";
                    else if (duration.Minutes > 0)
                         ret += duration.Minutes + " minutes";
                    return ret;
               }
               return durationStr;
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
