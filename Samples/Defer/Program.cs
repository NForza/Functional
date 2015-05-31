using System;
using System.Collections.Generic;
using System.Linq;

namespace Defer
{
    class Program
    {
        static void Main(string[] args)
        {
            // This code demonstrates how to defer execution of
            // an IEnumerable<> returning function until you know
            // the result is used or not.

            var data = new Data
            {
                Name = "TechDays",
                List = EnumerableEx.Defer(GetList)
            };

            // Report
            Console.WriteLine(data.Name);
            
            // Comment out this foreach to see the GetList() is not called.
            foreach (var item in data.List)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        static IEnumerable<int> GetList()
        {
            return new[] { 1, 2, 5, 7, 11, 13 };
        }
    }

    public class Data
    {
        public string Name { get; set; }

        public IEnumerable<int> List { get; set; }
    }
}

















// EnumerableEx.Defer(GetList)