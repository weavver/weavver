using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;

public partial class DynamicData_EntityTemplates_KnowledgeBases : System.Web.DynamicData.EntityTemplateUserControl
{
     protected void DynamicControl_Init(object sender, EventArgs e)
     {
          DynamicControl dynamicControl = (DynamicControl)sender;
          //dynamicControl.DataField = dynamicControl.Column.Name;
          dynamicControl.Mode = this.Mode;
     }
}