using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData
{
     public partial class EmailAddressField : System.Web.DynamicData.FieldTemplateUserControl
     {
          protected override void OnDataBinding(EventArgs e)
          {
               string urlprefix = "javascript:createPopup('/Communication_Emails/Insert.aspx?To=";
               string url = FieldValueString;
               if (!url.StartsWith(urlprefix, StringComparison.OrdinalIgnoreCase))
               {
                    url = urlprefix + url;
               }
               HyperLink1.NavigateUrl = url + "')";
          }

          public override Control DataControl
          {
               get
               {
                    return HyperLink1;
               }
          }

     }
}
