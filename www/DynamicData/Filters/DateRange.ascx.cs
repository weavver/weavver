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
using System.Globalization;

using System.Web.DynamicData;
using CustomFilters;

namespace DynamicData
{
     public partial class DateRangeFilter : System.Web.DynamicData.QueryableFilterUserControl
     {
          private String DATE_FORMAT = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
//-------------------------------------------------------------------------------------------
          public string DateFrom
          {
               get { return txbDateFrom.Text; }
          }
//-------------------------------------------------------------------------------------------
          public string DateThrough
          {
               get { return txbDateThrough.Text; }
          }
//-------------------------------------------------------------------------------------------
          public override Control FilterControl
          {
               get { return txbDateFrom; }
          }
//-------------------------------------------------------------------------------------------
          protected void Page_Init(object sender, EventArgs e)
          {
               if (!IsPostBack)
               {
                    if (Request[Column.Name + "_Start"] != null)
                    {
                         txbDateFrom.Text = Request[Column.Name + "_Start"];
                    }
                    if (Request[Column.Name + "_End"] != null)
                    {
                         txbDateThrough.Text = Request[Column.Name + "_End"];
                    }
               }

               // set correct date time format
               txbDateFrom_CalendarExtender.Format = DATE_FORMAT;
               txbDateThrough_CalendarExtender.Format = DATE_FORMAT;

               if (!Column.ColumnType.Equals(typeof(DateTime)))
                    throw new InvalidOperationException(String.Format("A date range filter was loaded for column '{0}' but the column has an incompatible type '{1}'.",
                    Column.Name, Column.ColumnType));
          }
//-------------------------------------------------------------------------------------------
          public override IQueryable GetQueryable(IQueryable source)
          {
               if (String.IsNullOrEmpty(DateFrom) && String.IsNullOrEmpty(DateThrough))
                    return source;

               ParameterExpression parameterExpression = Expression.Parameter(source.ElementType, "item");
               Expression body = BuildQueryBody(parameterExpression);

               LambdaExpression lambda = Expression.Lambda(body, parameterExpression);
               MethodCallExpression whereCall = Expression.Call(typeof(Queryable), "Where", new Type[] { source.ElementType }, source.Expression, Expression.Quote(lambda));
               return source.Provider.CreateQuery(whereCall);
          }
//-------------------------------------------------------------------------------------------
          private Expression BuildQueryBody(ParameterExpression parameterExpression)
          {
               Expression propertyExpression = ExpressionHelper.GetValue(ExpressionHelper.CreatePropertyExpression(parameterExpression, Column.Name));
               TypeConverter converter = TypeDescriptor.GetConverter(Column.ColumnType);
               if (!String.IsNullOrEmpty(DateFrom) && String.IsNullOrEmpty(DateThrough))
               {
                    return BuildCompareExpression(propertyExpression, converter.ConvertFromString(DateFrom), Expression.GreaterThanOrEqual);
               }
               else if (String.IsNullOrEmpty(DateFrom) && !String.IsNullOrEmpty(DateThrough))
               {
                    return BuildCompareExpression(propertyExpression, converter.ConvertFromString(DateThrough), Expression.LessThanOrEqual);
               }
               else
               {
                    BinaryExpression minimumComparison = BuildCompareExpression(propertyExpression, DateTime.SpecifyKind((DateTime)converter.ConvertFromString(DateFrom), DateTimeKind.Local).ToUniversalTime(), Expression.GreaterThanOrEqual);
                    BinaryExpression maximumComparison = BuildCompareExpression(propertyExpression, DateTime.SpecifyKind((DateTime)converter.ConvertFromString(DateThrough), DateTimeKind.Local).ToUniversalTime(), Expression.LessThanOrEqual);
                    return Expression.AndAlso(minimumComparison, maximumComparison);
               }
          }
//-------------------------------------------------------------------------------------------
          private BinaryExpression BuildCompareExpression(Expression propertyExpression, object value, Func<Expression, Expression, BinaryExpression> comparisonFunction)
          {
               ConstantExpression valueExpression = Expression.Constant(value);
               BinaryExpression comparison = comparisonFunction(propertyExpression, valueExpression);
               return comparison;
          }
//-------------------------------------------------------------------------------------------
     }
}