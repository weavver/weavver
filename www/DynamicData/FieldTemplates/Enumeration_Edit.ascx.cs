using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Linq.Expressions;
using System.Globalization;
using Weavver.Data;

namespace DynamicData
{
     public partial class Enumeration_EditField : System.Web.DynamicData.FieldTemplateUserControl
     {
          private Type _enumType;

          protected void Page_Load(object sender, EventArgs e)
          {
               DropDownList1.ToolTip = Column.Description;

               if (DropDownList1.Items.Count == 0)
               {
                    if (Mode == DataBoundControlMode.Insert || !Column.IsRequired)
                    {
                         DropDownList1.Items.Add(new ListItem("[Not Set]", String.Empty));
                    }
                    PopulateListControl2(DropDownList1);
               }

               SetUpValidator(RequiredFieldValidator1);
               SetUpValidator(DynamicValidator1);
          }

          protected override void OnDataBinding(EventArgs e)
          {
               base.OnDataBinding(e);

               if (Mode == DataBoundControlMode.Edit && FieldValue != null)
               {
                    string selectedValueString = GetSelectedValueString();
                    ListItem item = DropDownList1.Items.FindByValue(selectedValueString);
                    if (item != null)
                    {
                         DropDownList1.SelectedValue = selectedValueString;
                    }
               }
          }

          private Type EnumType
          {
               get
               {
                    if (_enumType == null)
                    {
                         _enumType = Column.GetEnumType();
                    }
                    return _enumType;
               }
          }

          protected override void ExtractValues(IOrderedDictionary dictionary)
          {
               string value = DropDownList1.SelectedValue;
               if (value == String.Empty)
               {
                    value = null;
               }
               dictionary[Column.Name] = ConvertEditedValue(value);
          }

          public override Control DataControl
          {
               get
               {
                    return DropDownList1;
               }
          }

          public new void PopulateListControl2(ListControl listControl)
          {
               var filterAttribute = Column.GetAttribute<FilterForeignKeyAttribute>();
               if (filterAttribute == null || Session[filterAttribute.SessionVariableName] == null)
               {
                    base.PopulateListControl(listControl);
                    return;
               }

               var context = Column.Table.CreateContext();
               var foreignKeyTable = ForeignKeyColumn.ParentTable;
               var filterColumn = foreignKeyTable.GetColumn(filterAttribute.FilterColumnName);
               var value = Convert.ChangeType(Session[filterAttribute.SessionVariableName].ToString(), filterColumn.TypeCode, CultureInfo.InvariantCulture);

               var query = foreignKeyTable.GetQuery(context); // Get Column Value query 
               var entityParam = Expression.Parameter(foreignKeyTable.EntityType, foreignKeyTable.Name); // get the table entity to be filtered 
               var property = Expression.Property(entityParam, filterColumn.Name); // get the property to be filtered 
               var equalsCall = Expression.Equal(property, Expression.Constant(value)); // get the equal call 
               var whereLambda = Expression.Lambda(equalsCall, entityParam); // get the where lambda 
               var whereCall = Expression.Call(typeof(Queryable), "Where", new Type[] { foreignKeyTable.EntityType }, query.Expression, whereLambda); // get the where call 
               var values = query.Provider.CreateQuery(whereCall);
               foreach (var row in values)
               {
                    listControl.Items.Add(new ListItem()
                    {
                         Text = foreignKeyTable.GetDisplayString(row),
                         Value = foreignKeyTable.GetPrimaryKeyString(row)
                    });
               }
          }

     }
}
