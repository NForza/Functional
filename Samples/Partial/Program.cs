using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NForza.Functional;

namespace Partial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Actions

            Action<string, string> write = (x, y) =>
            {
                Console.WriteLine(x);
                Console.WriteLine(y);
            };
            Action<string> write2 = write.ApplyPartial("One");

            write2("Two");

            // Functions

            Func<int, int, int> multiply = (x, y) => x * y;
            Func<int, int> triple = multiply.ApplyPartial(3);

            Console.WriteLine(triple(7));
        }
    }
}
