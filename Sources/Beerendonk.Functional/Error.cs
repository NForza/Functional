using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beerendonk.Functional
{
    internal static class Error
    {
        internal static Exception ArgumentNull(string paramName)
        {
            return new ArgumentNullException(paramName);
        }

        internal static Exception NoElements()
        {
            return new InvalidOperationException(Strings.NoElements);
        }
    }
}
