using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;

public partial class DynamicData_EntityTemplates_Logistics_Addresses : EntityTemplateUserControl
{
     protected void DynamicControl_Init(object sender, EventArgs e)
     {
          DynamicControl dynamicControl = (DynamicControl)sender;
          dynamicControl.Mode = this.Mode;
     }
}