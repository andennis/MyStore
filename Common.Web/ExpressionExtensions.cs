using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Common.Web
{
    public static class ExpressionExtensions
    {
        public static string GetPropertyName<T, TReturn>(this Expression<Func<T, TReturn>> expression)
        {
            PropertyInfo pi = GetPropertyInfo(expression);
            return pi.Name;
        }

        private static PropertyInfo GetPropertyInfo<T, TReturn>(Expression<Func<T, TReturn>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException("Expression is not a property", "expression");

            var pi = member.Member as PropertyInfo;
            if (pi == null)
                throw new ArgumentException("Expression is not a property", "expression");

            return pi;
        }

    }
}
