using System;

namespace NForza.Functional.Initialization
{
    public static class ObjectExtensions
    {
        public static T Initialize<T>(this T obj, Action<T> initialize)
        {
            if (initialize != null)
            {
                initialize(obj);
            }

            return obj;
        }
    }
}
