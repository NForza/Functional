using System;

namespace Beerendonk.Functional
{
    /// <summary>
    /// Extension methods for Action types.
    /// </summary>
    public static class ActionExtensions
    {
        /// <summary>
        /// Takes an action A1 and fewer than the normal arguments to A1, and returns an action A2 that takes the remaining 
        /// arguments to A1. When called, the returned function calls A1 with args + additional args.
        /// </summary>
        /// <example>
        ///     Action&lt;string, string&gt; action = (a1, a2) =>
        ///     {
        ///         Console.WriteLine(a1);
        ///         Console.WriteLine(a2);
        ///     };
        ///
        ///     var action2 = action.ApplyPartial("test1");
        ///     action2("test2");
        /// </example>
        public static Action<T2> ApplyPartial<T1, T2>(this Action<T1, T2> target, T1 arg1)
        {
            return arg2 => target(arg1, arg2);
        }

        /// <summary>
        /// Takes an action A1 and fewer than the normal arguments to A1, and returns an action A2 that takes the remaining 
        /// arguments to A1. When called, the returned function calls A1 with args + additional args.
        /// </summary>
        /// <example>
        ///     Action&lt;string, string, string&gt; action = (a1, a2, a3) =>
        ///     {
        ///         Console.WriteLine(a1);
        ///         Console.WriteLine(a2);
        ///         Console.WriteLine(a3);
        ///     };
        ///
        ///     var action2 = action.ApplyPartial("test1");
        ///     action2("test2", "test3");
        /// </example>
        public static Action<T2, T3> ApplyPartial<T1, T2, T3>(this Action<T1, T2, T3> target, T1 arg1)
        {
            return target.Tuplify().ApplyPartial(arg1).Detuplify();
        }

        /// <summary>
        /// Takes an action A1 and fewer than the normal arguments to A1, and returns an action A2 that takes the remaining 
        /// arguments to A1. When called, the returned function calls A1 with args + additional args.
        /// </summary>
        /// <example>
        ///     Action&lt;string, string, string&gt; action = (a1, a2, a3) =>
        ///     {
        ///         Console.WriteLine(a1);
        ///         Console.WriteLine(a2);
        ///         Console.WriteLine(a3);
        ///     };
        ///
        ///     var action2 = action.ApplyPartial("test1", "test2");
        ///     action2("test3");
        /// </example>
        public static Action<T3> ApplyPartial<T1, T2, T3>(this Action<T1, T2, T3> target, T1 arg1, T2 arg2)
        {
            return target.Tuplify().ApplyPartial(arg1).Detuplify().ApplyPartial(arg2);
        }

        private static Action<T1, Tuple<T2, T3>> Tuplify<T1, T2, T3>(this Action<T1, T2, T3> target)
        {
            return (t1, t23) => target(t1, t23.Item1, t23.Item2);
        }

        private static Action<T1, T2> Detuplify<T1, T2>(this Action<Tuple<T1, T2>> target)
        {
            return (arg1, arg2) => target(Tuple.Create(arg1, arg2));
        }
    }
}
