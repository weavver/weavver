using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public delegate void DataSavedHandler(object sender, EventArgs e);
/// <summary>
/// Summary description for WeavverUserControl
/// </summary>
public class WeavverUserControl : UserControl
{
//-------------------------------------------------------------------------------------------
     public enum MyEditMode
     {
          MutlipartForm,
          Edit,
          Read,
          New
     }
     public MyEditMode EditMode = MyEditMode.New;
     public event DataSavedHandler DataSaved;
//-------------------------------------------------------------------------------------------
     //public Guid DataSourceId
     //{
     //}
//-------------------------------------------------------------------------------------------
     public SkeletonPage BasePage
     {
          get
          {
               if (Page.GetType().IsSubclassOf(typeof(SkeletonPage)))
               {
                    return (SkeletonPage) Page;
               }
               else
               {
                    return null;
               }
          }
     }
//-------------------------------------------------------------------------------------------
     public WeavverUserControl()
     {
     }
//-------------------------------------------------------------------------------------------
     public void OnDataSaved(object sender, EventArgs e)
     {
          if (DataSaved != null)
               DataSaved(sender, e);
     }
//-------------------------------------------------------------------------------------------
}
