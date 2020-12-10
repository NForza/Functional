using System;
using System.Collections.Generic;

namespace Beerendonk.Console
{
    /// <summary>
    /// Helper functions to write Headers and Enumerables to the console.
    /// </summary>
    public static class ConsoleExt
    {
        public static void Header1(string header)
        {
            Header2(header.ToUpper() + "\n" + new String('-', header.Length));
        }

        public static void Header2(string header)
        {
            System.Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine(header);
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine();
        }

        public static void WriteSeq<TSource>(IEnumerable<TSource> source, int count = 12)
        {
            var result = String.Empty;
            var i = 0;

            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext() && i < count)
                {
                    result = enumerator.Current.ToString();
                    i++;
                }

                while (enumerator.MoveNext() && i < count)
                {
                    result += ", " + enumerator.Current.ToString();
                    i++;
                }

                if (enumerator.MoveNext())
                {
                    result += "...";
                }
            }

            System.Console.WriteLine(result);
        }

        public static void WriteTitled<T>(string title, string code, T value)
        {
            System.Console.WriteLine(title);

            if (!String.IsNullOrEmpty(code))
            {
                ConsoleColor oldColor = System.Console.ForegroundColor;
                System.Console.ForegroundColor = ConsoleColor.Gray;
                System.Console.WriteLine(code);
                System.Console.ForegroundColor = oldColor;
            }

            System.Console.WriteLine(value);
            System.Console.WriteLine();
        }

        public static void WriteTitledSeq<TSource>(string title, string code, IEnumerable<TSource> source, int count = 12)
        {
            System.Console.WriteLine(title);

            if (!String.IsNullOrEmpty(code))
            {
                ConsoleColor oldColor = System.Console.ForegroundColor;
                System.Console.ForegroundColor = ConsoleColor.Gray;
                System.Console.WriteLine(code);
                System.Console.ForegroundColor = oldColor;
            }

            WriteSeq(source, count);
            System.Console.WriteLine();
        }
    }
}
