using System;
using System.Collections.Generic;
using System.Linq;

namespace Beerendonk.Functional
{
    public static class EnumerableExtensions
    {
        // TODO NullArgumentExceptions

        private static IDictionary<TKey, TAccumulate> AggregateBy<TSource, TKey, TValue, TAccumulate>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector, Func<IEnumerable<TValue>, TAccumulate> func)
        {
            return source
                .GroupBy(keySelector, (k, e) => new { Key = k, Accumulate = func(e.Select(valueSelector)) })
                .ToDictionary(x => x.Key, x => x.Accumulate);
        }

        public static IEnumerable<TSource> Aggregations<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            if (!source.Any())
            {
                return new TSource[0];
            }
            else
            {
                return Aggregations(source.Skip(1), source.First(), func);
            }
        }

        public static IEnumerable<TAccumulate> Aggregations<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            var accumulate = seed;

            yield return accumulate;

            foreach (var item in source)
            {
                accumulate = func(accumulate, item);
                yield return accumulate;
            }

            yield break;
        }

        public static IDictionary<TKey, double> AverageBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, int> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Average);
        }

        public static IDictionary<TKey, double?> AverageBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, int?> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Average);
        }

        public static IDictionary<TKey, float> AverageBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, float> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Average);
        }

        public static IDictionary<TKey, float?> AverageBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, float?> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Average);
        }

        public static IDictionary<TKey, double> AverageBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, long> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Average);
        }

        public static IDictionary<TKey, double?> AverageBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, long?> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Average);
        }

        public static IDictionary<TKey, double> AverageBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, double> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Average);
        }

        public static IDictionary<TKey, double?> AverageBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, double?> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Average);
        }

        public static IDictionary<TKey, decimal> AverageBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, decimal> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Average);
        }

        public static IDictionary<TKey, decimal?> AverageBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, decimal?> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Average);
        }

        public static IDictionary<TKey, int> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            return source.AggregateBy(keySelector, x => x, Enumerable.Count);
        }

        public static IDictionary<TKey, long> LongCountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            return source.AggregateBy(keySelector, x => x, Enumerable.LongCount);
        }

        public static IDictionary<TKey, TResult> MaxBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TResult> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Max);
        }

        public static IDictionary<TKey, TResult> MinBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TResult> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Min);
        }

        public static IDictionary<TKey, int> SumBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, int> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Sum);
        }

        public static IDictionary<TKey, int?> SumBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, int?> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Sum);
        }

        public static IDictionary<TKey, float> SumBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, float> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Sum);
        }

        public static IDictionary<TKey, float?> SumBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, float?> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Sum);
        }

        public static IDictionary<TKey, long> SumBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, long> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Sum);
        }

        public static IDictionary<TKey, long?> SumBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, long?> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Sum);
        }

        public static IDictionary<TKey, double> SumBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, double> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Sum);
        }

        public static IDictionary<TKey, double?> SumBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, double?> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Sum);
        }

        public static IDictionary<TKey, decimal> SumBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, decimal> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Sum);
        }

        public static IDictionary<TKey, decimal?> SumBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, decimal?> valueSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }

            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }

            return source.AggregateBy(keySelector, valueSelector, Enumerable.Sum);
        }


        // TODO Documentation
        public static IEnumerable<TSource> Order<TSource>(this IEnumerable<TSource> source)
        {
            return source.OrderBy(x => x);
        }

        // TODO Documentation
        public static IEnumerable<TSource> TakeNth<TSource>(this IEnumerable<TSource> source, int n)
        {
            return source.Where((x, i) => (i + 1) % n == 0);
        }

        // TODO Documentation
        // http://stackoverflow.com/questions/1287567/is-using-random-and-orderby-a-good-shuffle-algorithm
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            T[] elements = source.ToArray();
            for (int i = elements.Length - 1; i >= 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
            }
        }


        // TODO Documentation
        public static double WeightedAverage<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector, Func<TSource, uint> weightSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
            }

            if (weightSelector == null)
            {
                throw Error.ArgumentNull("weightSelector");
            }

            long num = 0L;
            ulong num2 = 0L;

            checked
            {
                foreach (TSource current in source)
                {
                    long currentValue = (long)selector(current);
                    ulong currentWeight = (ulong)weightSelector(current);

                    num += unchecked(currentValue * (long)currentWeight);
                    num2 += currentWeight;
                }

                if (num2 > 0L)
                {
                    return (double)num / (double)num2;
                }

                throw Error.NoElements();
            }
        }



        /// <summary>
        /// Generates a lazy (infinite) sequence of repetitions of the items in the enumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <returns>
        /// A lazy (infinite) sequence of repetitions of the items in the enumerable.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <example>
        /// new[] { 1, 2, 3 }.Cycle());
        /// 
        /// // Result:
        /// // 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3...
        /// </example>
        public static IEnumerable<TSource> Cycle<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            while (true)
            {
                foreach (var item in source)
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Generates a lazy sequence of value, func(value), func(func(value)) etc.
        /// </summary>
        /// <typeparam name="T">Type of the value.</typeparam>
        /// <param name="func">The function.</param>
        /// <param name="value">The start value.</param>
        /// <returns>A lazy sequence of value, func(value), func(func(value)) etc.</returns>
        public static IEnumerable<T> Iterate<T>(Func<T, T> func, T value)
        {
            T next = value;
            while (true)
            {
                yield return next;
                next = func(next);
            }
        }

        /// <summary>
        /// Generates a lazy sequence of the first item in each collection, then the second etc.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="collections">The other collections.</param>
        /// <returns>A lazy sequence of the first item in each collection, then the second etc.</returns>
        public static IEnumerable<TSource> Interleave<TSource>(this IEnumerable<TSource> source, params IEnumerable<TSource>[] collections)
        {
            var lists = new List<IEnumerable<TSource>>(collections);
            lists.Insert(0, source);

            while (lists.All(x => x.Any()))
            {
                for (int i = 0; i < lists.Count; i++)
                {
                    yield return lists[i].First();
                    lists[i] = lists[i].Skip(1);
                }
            }

            yield break;
        }

        /// <summary>
        /// Generates a lazy sequence of the elements of the collection separated by separator.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>A lazy sequence of the elements of the collection separated by separator.</returns>
        public static IEnumerable<TSource> Interpose<TSource>(this IEnumerable<TSource> source, TSource separator)
        {
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    yield return enumerator.Current;

                    while (enumerator.MoveNext())
                    {
                        yield return separator;
                        yield return enumerator.Current;
                    }
                }
            }

            yield break;
        }

        /// <summary>
        /// Generates a lazy (infinite) enumerable of elements.
        /// </summary>
        /// <typeparam name="TResult">The type of the elements.</typeparam>
        /// <param name="element">The element to repeat.</param>
        /// <returns>Lazy (infinite) enumerable of elements.</returns>
        public static IEnumerable<TResult> Repeat<TResult>(TResult element)
        {
            while (true)
            {
                yield return element;
            }
        }

        /// <summary>
        /// Generates a lazy enumerable (length count) of elements.
        /// </summary>
        /// <typeparam name="TResult">The type of the elements.</typeparam>
        /// <param name="count">The length of the returned sequence.</param>
        /// <param name="element">The element to repeat.</param>
        /// <returns>
        /// Lazy (length count) enumerable of elements.
        /// </returns>
        public static IEnumerable<TResult> Repeat<TResult>(int count, TResult element)
        {
            return System.Linq.Enumerable.Repeat(element, count);
        }

        /// <summary>
        /// Generates a lazy (infinite) enumerable of calls to func.
        /// Argument func can have side effects.
        /// </summary>
        /// <typeparam name="TResult">The type of the function results.</typeparam>
        /// <param name="func">The function to call.</param>
        /// <returns>
        /// Lazy (infinite) enumerable of function results.
        /// </returns>
        public static IEnumerable<TResult> Repeatedly<TResult>(Func<TResult> func)
        {
            while (true)
            {
                yield return func();
            }
        }

        /// <summary>
        /// Generates a lazy enumerable (length count) of calls to func.
        /// Argument func can have side effects.
        /// </summary>
        /// <typeparam name="TResult">The type of the function results.</typeparam>
        /// <param name="count">The length of the returned sequence.</param>
        /// <param name="func">The function to call.</param>
        /// <returns>
        /// Lazy (length count) enumerable of function results.
        /// </returns>
        public static IEnumerable<TResult> Repeatedly<TResult>(int count, Func<TResult> func)
        {
            return Repeatedly(func).Take(count);
        }
    }
}
