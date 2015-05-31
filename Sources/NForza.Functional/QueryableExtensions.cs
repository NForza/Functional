using System;
using System.Linq;
using System.Linq.Expressions;

namespace NForza.Functional
{
    public static class QueryableExtensions
    {
        //private static IDictionary<TKey, TAccumulate> AggregateBy<TSource, TKey, TValue, TAccumulate>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TValue>> valueSelector, Expression<Func<IQueryable<TValue>, TAccumulate>> func)
        //{
        //    return source
        //        .GroupBy(keySelector, (k, e) => new { Key = k, Accumulate = func(e.Select(valueSelector)) })
        //        .ToDictionary(x => x.Key, x => x.Accumulate);
        //}

        public static IQueryable<TSource> SkipWhile<TSource>(this IQueryable<TSource> source, params Expression<Func<TSource, bool>>[] predicates)
        {
            return source.SkipWhile(predicates.Aggregate());
        }

        public static IQueryable<TSource> TakeWhile<TSource>(this IQueryable<TSource> source, params Expression<Func<TSource, bool>>[] predicates)
        {
            return source.TakeWhile(predicates.Aggregate());
        }

        public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, params Expression<Func<TSource, bool>>[] predicates)
        {
            return predicates.Aggregate(source, (q, f) => Queryable.Where(q, f));
        }
    }
}
