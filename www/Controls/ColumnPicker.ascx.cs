using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;

using Weavver.Data;

public partial class Controls_ColumnPicker : WeavverUserControl
{
     protected MetaTable table;
     protected FilteredFieldsManager _filteredFieldsManager;
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
          _filteredFieldsManager = new FilteredFieldsManager(table, PageTemplate.List);

          if (!IsPostBack)
          {
               var availableColumns = table.Columns
                                        .Where(x => Global.IsAuthorized(x) == true && x.Scaffold);
               //.OrderBy(x => x.DisplayName);
               foreach (MetaColumn col in availableColumns)
               {
                    // if (col.Scaffold)
                    ListItem item = new ListItem(col.DisplayName, col.Name);
                    if (Global.IsShown(col))
                         item.Selected = true;
                    Columns.Items.Add(item);
               }
          }
          else
          {
               SetSelectedColumns();
          }
     }
//-------------------------------------------------------------------------------------------
     public FilteredFieldsManager FieldManager
     {
          get
          {
               return _filteredFieldsManager;
          }
     }
//-------------------------------------------------------------------------------------------
     protected void SetColumns_Click(object sender, EventArgs e)
     {
          SetSelectedColumns();
          OnDataSaved(this, EventArgs.Empty);
          MPE.Hide();
     }
//-------------------------------------------------------------------------------------------
     private void SetSelectedColumns()
     {
          _filteredFieldsManager.SelectedColumns.Clear();
          foreach (ListItem listItem in Columns.Items)
          {
               if (listItem.Selected)
               {
                    var f = new DynamicField();
                    f.DataField = listItem.Value;
                    _filteredFieldsManager.SelectedColumns.Add(f);
               }
          }
     }
//-------------------------------------------------------------------------------------------
}