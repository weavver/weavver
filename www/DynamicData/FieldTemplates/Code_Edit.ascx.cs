using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;

namespace DynamicData
{
     public partial class Code_EditField : System.Web.DynamicData.FieldTemplateUserControl
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               TextBox1.BasePath = "~/vendors/ckeditor/";
               if (Column.MaxLength < 20)
               {
                    TextBox1.Columns = Column.MaxLength;
               }
               TextBox1.ToolTip = Column.Description;
               TextBox1.FilebrowserUploadUrl = "/Vendors/ckeditor/Uploader.ashx";
               TextBox1.EnterMode = CKEditor.NET.EnterMode.BR;

               SetUpValidator(RequiredFieldValidator1);
               SetUpValidator(RegularExpressionValidator1);
               SetUpValidator(DynamicValidator1);

               EditSource.Visible = (Roles.IsUserInRole("Administrators"));
          }

          protected override void OnDataBinding(EventArgs e)
          {
               base.OnDataBinding(e);
               if (Column.MaxLength > 0)
               {
                    TextBox1.MaxLength = Math.Max(FieldValueEditString.Length, Column.MaxLength);
               }
          }

          protected override void ExtractValues(IOrderedDictionary dictionary)
          {
               dictionary[Column.Name] = ConvertEditedValue(HTMLPurifierLib.Sanitize(TextBox1.Text));
          }

          public override Control DataControl
          {
               get
               {
                    return TextBox1;
               }
          }

          protected void EditSource_Click(object sender, EventArgs e)
          {
               if (EditSource.Text == "Source Viewer")
               {
                    HTMLEditor.Visible = false;
                    SourceEditor.Visible = true;
                    EditSource.Text = "WYSYWIG Editor";
                    ScriptManager.RegisterStartupScript(updatePanel1, updatePanel1.GetType(), "key", "LoadEditor();", true);
               }
               else
               {
                    HTMLEditor.Visible = true;
                    SourceEditor.Visible = false;
                    EditSource.Text = "Source Viewer";
               }

          }
     }
}
