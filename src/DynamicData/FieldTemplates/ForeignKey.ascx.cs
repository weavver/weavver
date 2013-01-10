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
     public partial class ForeignKeyField : System.Web.DynamicData.FieldTemplateUserControl
     {
          private bool _allowNavigation = true;

          private bool requiredCustomLookUp = false;

          public string NavigateUrl
          {
               get;
               set;
          }

          public bool AllowNavigation
          {
               get
               {
                    return _allowNavigation;
               }
               set
               {
                    _allowNavigation = value;
               }
          }

          protected string GetDisplayString()
          {
               object value = FieldValue;

               if (value == null)
               {
                    string fkey = FormatFieldValue(ForeignKeyColumn.GetForeignKeyString(Row));
                    if (fkey.Length == 36)
                    {
                         using (WeavverEntityContainer data = new WeavverEntityContainer())
                         {
                              fkey = data.GetName(new Guid(fkey));
                              requiredCustomLookUp = true;
                         }
                    }
                    return fkey;
               }
               else
               {
                    return FormatFieldValue(ForeignKeyColumn.ParentTable.GetDisplayString(value));
               }
          }

          protected string GetNavigateUrl()
          {
               if (!AllowNavigation || requiredCustomLookUp)
               {
                    return null;
               }

               if (String.IsNullOrEmpty(NavigateUrl))
               {
                    return ForeignKeyPath;
               }
               else
               {
                    return BuildForeignKeyPath(NavigateUrl);
               }
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
