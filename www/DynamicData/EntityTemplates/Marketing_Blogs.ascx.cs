using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;

public partial class DynamicData_EntityTemplates_Accounting_Checks : System.Web.DynamicData.EntityTemplateUserControl
{
     protected void Page_Init(object sender, EventArgs e)
     {
          if (ContainerType == System.Web.DynamicData.ContainerType.Item)
          {
               ItemView.Visible = true;
               DisqusJS.Text = "<script type='text/javascript'>var disqus_shortname = '" + System.Configuration.ConfigurationManager.AppSettings["disqus_shortname"].ToString() + "';</script>";
          }
          else
          {
               ItemView.Visible = false;
          }
     }

     protected void DynamicControl_Init(object sender, EventArgs e)
     {
          DynamicControl dynamicControl = (DynamicControl)sender;
          dynamicControl.Mode = this.Mode;
     }
}