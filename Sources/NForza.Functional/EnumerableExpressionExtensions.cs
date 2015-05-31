using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NForza.Functional
{
    internal static class EnumerableExpressionExtensions
    {
        /// <summary>
        /// Aggregates the specified predicate expressions.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicateExpressions">The predicate expressions.</param>
        /// <returns>The aggregate expression.</returns>
        internal static Expression<Func<T, bool>> Aggregate<T>(this IEnumerable<Expression<Func<T, bool>>> predicateExpressions)
        {
            return predicateExpressions.Aggregate((expr1, expr2) =>
            {
                var body = Expression.AndAlso(expr1.Body, expr2.Body);
                return Expression.Lambda<Func<T, bool>>(body, expr1.Parameters[0]);
            });
        }
    }

}
