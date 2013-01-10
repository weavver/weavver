using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Reflection;

namespace DynamicData.DynamicData.Filters
{
     public partial class StringFilter : QueryableFilterUserControl
     {
          public override Control FilterControl
          {
               get { return this.textBox; }
          }

          protected void Page_Load(object sender, EventArgs e)
          {
               //this.textBox.ToolTip = this.Column.Description;
               //this.validator.ErrorMessage = "Invalid date specified for " + this.Column.DisplayName;
               //this.validator.ToolTip = this.validator.ErrorMessage;
          }

          public override IQueryable GetQueryable(IQueryable source)
          {
               if (Column.TypeCode != TypeCode.String)
                    return source;


               string searchString = textBox.Text;
               if (textBox.Text == "")
               {
                    searchString = String.Empty;
                    return source;
               }
               Type type = typeof(String);

               string searchProperty = Column.DisplayName;
               ConstantExpression searchFilter = Expression.Constant(searchString);


               ParameterExpression parameter = Expression.Parameter(source.ElementType);
               MemberExpression property = Expression.Property(parameter, this.Column.Name);
               if (Nullable.GetUnderlyingType(property.Type) != null)
               {
                    property = Expression.Property(property, "Value");

               }
               MethodInfo method = typeof(String).GetMethod("Contains", new[] { typeof(String) });

               var containsMethodExp = Expression.Call(property, method, searchFilter);
               var containsLambda = Expression.Lambda(containsMethodExp, parameter);


               var resultExpression = Expression.Call(typeof(Queryable), "Where", new Type[] { source.ElementType }, source.Expression, Expression.Quote(containsLambda));

               return source.Provider.CreateQuery(resultExpression);
          }

          protected void Validate(object sender, ServerValidateEventArgs e)
          {
               //System.DateTime value;
               //e.IsValid = System.DateTime.TryParse(e.Value, out value);
               e.IsValid = true;
          }
     }
}