using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
//using NotAClue.Web;
//using NotAClue.Web.DynamicData;
using System.Globalization;
using CustomFilters;

namespace DynamicData
{
    public partial class RangeFilter : System.Web.DynamicData.QueryableFilterUserControl
    {
        public string DateFrom
        {
            get { return txbFrom.Text; }
        }

        public string DateTo
        {
            get { return txbTo.Text; }
        }

        public override Control FilterControl
        {
            get { return txbFrom; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
        }


        public override IQueryable GetQueryable(IQueryable source)
        {
            if (String.IsNullOrEmpty(DateFrom) && String.IsNullOrEmpty(DateTo))
                return source;

            ParameterExpression parameterExpression = Expression.Parameter(source.ElementType, "item");
            Expression body = BuildQueryBody(parameterExpression);

            LambdaExpression lambda = Expression.Lambda(body, parameterExpression);
            MethodCallExpression whereCall = Expression.Call(typeof(Queryable), "Where", new Type[] { source.ElementType }, source.Expression, Expression.Quote(lambda));
            return source.Provider.CreateQuery(whereCall);
        }

        private Expression BuildQueryBody(ParameterExpression parameterExpression)
        {
            Expression propertyExpression = ExpressionHelper.GetValue(ExpressionHelper.CreatePropertyExpression(parameterExpression, Column.Name));
            TypeConverter converter = TypeDescriptor.GetConverter(Column.ColumnType);
            if (!String.IsNullOrEmpty(DateFrom) && String.IsNullOrEmpty(DateTo))
            {
                 return BuildCompareExpression(propertyExpression, converter.ConvertFromString(DateFrom), Expression.GreaterThanOrEqual);
            }
            else if (String.IsNullOrEmpty(DateFrom) && !String.IsNullOrEmpty(DateTo))
            {
                 return BuildCompareExpression(propertyExpression, converter.ConvertFromString(DateTo), Expression.LessThanOrEqual);
            }
            else
            {
                 BinaryExpression minimumComparison = BuildCompareExpression(propertyExpression, converter.ConvertFromString(DateFrom), Expression.GreaterThanOrEqual);
                 BinaryExpression maximumComparison = BuildCompareExpression(propertyExpression, converter.ConvertFromString(DateTo), Expression.LessThanOrEqual);
                 return Expression.AndAlso(minimumComparison, maximumComparison);
            }
        }

        private BinaryExpression BuildCompareExpression(Expression propertyExpression, object value, Func<Expression, Expression, BinaryExpression> comparisonFunction)
        {
            ConstantExpression valueExpression = Expression.Constant(value);
            BinaryExpression comparison = comparisonFunction(propertyExpression, valueExpression);
            return comparison;
        }
    }
}
