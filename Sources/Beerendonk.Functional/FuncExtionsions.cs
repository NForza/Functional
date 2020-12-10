// Copyright (c) Beerendonk, Rick Beerendonk. All rights reserved.
// The use and distribution terms for this software are covered by the
// Eclipse Public License 1.0 (http://opensource.org/licenses/eclipse-1.0.php)
// which can be found in the file epl-v10.html at the root of this distribution.
// By using this software in any fashion, you are agreeing to be bound by
// the terms of this license.
// You must not remove this notice, or any other, from this software.

using System;
using System.Collections.Concurrent;

namespace Beerendonk.Functional
{
    /// <summary>
    /// Extension methods for Func types.
    /// </summary>
    public static class FuncExtionsions
    {
        /// <summary>
        /// Takes an function F1 and fewer than the normal arguments to F1, and returns an function F2 that takes the remaining 
        /// arguments to F1. When called, the returned function calls F1 with args + additional args and return the result.
        /// </summary>
        /// <example>
        ///     Func&lt;int, int, int&gt; multiply = (x, y) => x * y;
        ///     var triple = multiply.ApplyPartial(3);
        ///     Console.WriteLine(triple(7));  // 21
        /// </example>
        public static Func<T2, TResult> ApplyPartial<T1, T2, TResult>(this Func<T1, T2, TResult> target, T1 arg1)
        {
            return arg2 => target(arg1, arg2);
        }

        /// <summary>
        /// Takes an function F1 and fewer than the normal arguments to F1, and returns an function F2 that takes the remaining 
        /// arguments to F1. When called, the returned function calls F1 with args + additional args and return the result.
        /// </summary>
        // TODO Example
        public static Func<T2, T3, TResult> ApplyPartial<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> target, T1 arg1)
        {
            return target.Tuplify().ApplyPartial(arg1).Detuplify();
        }

        /// <summary>
        /// Takes an function F1 and fewer than the normal arguments to F1, and returns an function F2 that takes the remaining 
        /// arguments to F1. When called, the returned function calls F1 with args + additional args and return the result.
        /// </summary>
        // TODO Example
        public static Func<T3, TResult> ApplyPartial<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> target, T1 arg1, T2 arg2)
        {
            return target.Tuplify().ApplyPartial(arg1).Detuplify().ApplyPartial(arg2);
        }

        private static Func<T1, Tuple<T2, T3>, TResult> Tuplify<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> target)
        {
            return (t1, t23) => target(t1, t23.Item1, t23.Item2);
        }

        private static Func<T1, T2, TResult> Detuplify<T1, T2, TResult>(this Func<Tuple<T1, T2>, TResult> target)
        {
            return (arg1, arg2) => target(Tuple.Create(arg1, arg2));
        }
    }
}
