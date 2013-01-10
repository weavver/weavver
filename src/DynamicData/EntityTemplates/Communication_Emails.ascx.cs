﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;

using Weavver.Data;

public partial class DynamicData_EntityTemplates_Communication_Emails : System.Web.DynamicData.EntityTemplateUserControl
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          if (ContainerType == System.Web.DynamicData.ContainerType.Item)
          {
               //ItemView.Visible = true;
               
          }
          else
          {
               //ItemView.Visible = false;
          }
     }
//-------------------------------------------------------------------------------------------
     protected void SetTitle(string title)
     {
          var master = Page.Master as WeavverMasterPageInterface;
          master.FormTitle = title;
     }
//-------------------------------------------------------------------------------------------
     protected void DynamicControl_Init(object sender, EventArgs e)
     {
          DynamicControl dynamicControl = (DynamicControl) sender;
          dynamicControl.Mode = this.Mode;
     }
//-------------------------------------------------------------------------------------------
}