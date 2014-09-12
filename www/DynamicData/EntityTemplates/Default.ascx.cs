using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weavver.Data;
using System.Web.UI.HtmlControls;

namespace DynamicData
{
     public partial class DefaultEntityTemplate : System.Web.DynamicData.EntityTemplateUserControl
     {
          private MetaColumn currentColumn;
//-------------------------------------------------------------------------------------------
          protected override void OnLoad(EventArgs e)
          {
               IEnumerable<MetaColumn> columns = Table.GetScaffoldColumns(this.Mode, this.ContainerType);

               List<string> Groups = new List<string>();
               foreach (MetaColumn column in columns)
               {
                    this.currentColumn = column;

                    var groupattribute = column.GetAttribute<ColumnGroupAttribute>();
                    HtmlGenericControl tabContent = (HtmlGenericControl)GeneralControls;
                    if (groupattribute != null)
                    {
                         string groupId = groupattribute.GroupName.Replace(" ", "_");
                         if (!Groups.Contains(groupId))
                         {
                              Groups.Add(groupId);

                              var div = new HtmlGenericControl("div");
                              div.ID = groupId;
                              Tabs.Controls.Add(div);

                              LiteralControl tab = new LiteralControl();
                              tab.Text = "<li><a href=\"#" + div.ClientID + "\">" + groupattribute.GroupName + "</a></li>";
                              tabheader.Controls.Add(tab);
                         }
                         tabContent = (HtmlGenericControl)Tabs.FindControl(groupId);
                    }


                    HtmlGenericControl cellLine = new HtmlGenericControl("div");
                    cellLine.Attributes["class"] = "formLine";
                    tabContent.Controls.Add(cellLine);

                    HtmlGenericControl cellLabel = new HtmlGenericControl("div");
                    cellLabel.Attributes["class"] = "formLabel";
                    cellLabel.InnerText = column.DisplayName + ":";
                    cellLine.Controls.Add(cellLabel);

                    HtmlGenericControl cellData = new HtmlGenericControl("div");
                    cellData.Attributes["class"] = "formData";
                    var dynamicControl = new DynamicControl()
                    {
                         Mode = Mode,
                         DataField = column.Name,
                         ValidationGroup = this.ValidationGroup
                    };
                    cellData.Controls.Add(dynamicControl);
                    cellLine.Controls.Add(cellData);

                    HtmlGenericControl br = new HtmlGenericControl("div");
                    br.Style["clear"] = "both";
                    br.Style["height"] = "1px";
                    cellLine.Controls.Add(br);
               }


               var clearDiv = new HtmlGenericControl("div");
               clearDiv.InnerHtml = "&nbsp;";
               clearDiv.Style["clear"] = "both";
               GeneralControls.Controls.Add(clearDiv);

               //if (tabheader.Controls.Count == 1)
               //{
               //     tabheader.Controls.Clear();
               //}
               //else
               {
                    string script = "<script type='text/javascript'>$(document).ready(function () { $(\"#tableControl\").tabs(); });</script>";
                    ScriptManager.RegisterStartupScript(Page, GetType(), "TableControlInit", script, false);
               }
          }
//-------------------------------------------------------------------------------------------
          protected void Label_Init(object sender, EventArgs e)
          {
               Label label = (Label)sender;
               label.Text = this.currentColumn.DisplayName;
          }
//-------------------------------------------------------------------------------------------
          protected void Label_PreRender(object sender, EventArgs e)
          {
               Label label = (Label)sender;

               DynamicControl dynamicControl = (DynamicControl)label.FindControl("dynamicControl");

               FieldTemplateUserControl fieldTemplate = dynamicControl.FieldTemplate as FieldTemplateUserControl;
               if (fieldTemplate != null && fieldTemplate.DataControl != null)
               {
                    label.AssociatedControlID = fieldTemplate.DataControl.GetUniqueIDRelativeTo(label);
               }
          }
//-------------------------------------------------------------------------------------------
          protected void DynamicControl_Init(object sender, EventArgs e)
          {
               DynamicControl dynamicControl = (DynamicControl)sender;
               dynamicControl.DataField = this.currentColumn.Name;
               dynamicControl.Mode = this.Mode;
          }
//-------------------------------------------------------------------------------------------
          public class _NamingContainer : Control, INamingContainer { }
//-------------------------------------------------------------------------------------------
     }
}
