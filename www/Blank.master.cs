using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weavver.Data;

public partial class Blank : MasterPage, WeavverMasterPageInterface
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string FormTitle
    {
         set { Response.Write(value); }
    }

    public string FormDescription
    {
         set { Response.Write(value); }
    }

    public void ActionsMenuAdd(Weavver.Web.WeavverMenuItem item)
    {
         //throw new NotImplementedException();
    }

    public void ViewsMenuAdd(Weavver.Web.WeavverMenuItem item)
    {
         //throw new NotImplementedException();
    }

    public void SetToolbarVisibility(bool visible)
    {
         //throw new NotImplementedException();
    }

    public bool FixedWidth
    {
         get
         {
              //throw new NotImplementedException();
              return true;
         }
         set
         {
              
         }
    }

    #region WeavverMasterPageInterface Members


    public void ToolBarMenuAdd(Weavver.Web.WeavverMenuItem item)
    {
         throw new NotImplementedException();
    }

    #endregion
}
