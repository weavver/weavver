using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using System.Linq.Expressions;
using System.Diagnostics;

namespace DynamicData.DynamicData.Filters
{
     public partial class DateFilter : QueryableFilterUserControl
     {
          public override Control FilterControl
          {
            get { return this.textBox; }
          }

          protected void Page_Load(object sender, EventArgs e)
          {
            this.textBox.ToolTip = this.Column.Description;
            this.validator.ErrorMessage = "Invalid date specified for " +
                this.Column.DisplayName;
            this.validator.ToolTip = this.validator.ErrorMessage;
          }

          public override IQueryable GetQueryable(IQueryable source)
          {
            if (string.IsNullOrEmpty(this.textBox.Text) || !this.validator.IsValid)
            {
              return source;
            } 

            System.DateTime date = System.DateTime.Parse(this.textBox.Text);
            ConstantExpression value = Expression.Constant(date); 

            ParameterExpression parameter = Expression.Parameter(source.ElementType);
            MemberExpression property = Expression.Property(parameter, this.Column.Name);
            if (Nullable.GetUnderlyingType(property.Type) != null)
            {
              property = Expression.Property(property, "Value");
            } 

            BinaryExpression comparison;
            switch (this.dropDownList.SelectedValue)
            {
              case "==":
                comparison = Expression.Equal(property, value);
                break;
              case ">":
                comparison = Expression.GreaterThan(property, value);
                break;
              case "<":
                comparison = Expression.LessThan(property, value);
                break;
              default:
                Debug.Fail("Unexpected operator");
                return source;
            } 

            LambdaExpression lambda = Expression.Lambda(comparison, parameter); 

            MethodCallExpression where = Expression.Call(
              typeof(Queryable),
              "Where",
              new Type[] { source.ElementType },
              new Expression[] { source.Expression, Expression.Quote(lambda) }); 

            return source.Provider.CreateQuery(where);
          }

          protected void Validate(object sender, ServerValidateEventArgs e)
          {
               System.DateTime value;
               e.IsValid = System.DateTime.TryParse(e.Value, out value);
          }
     }
}