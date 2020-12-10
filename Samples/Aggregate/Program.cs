using Beerendonk.Console;
using Beerendonk.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Aggregate
{
    class Program
    {
        static void Main(string[] args)
        {
            // This code demonstrate you can not only use
            // Aggregate for numbers, but also for functions.

            //AggregateNumbers();
            AggregateFuncs();
        }

        static void AggregateNumbers()
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 8);

            var result1 = numbers.Aggregate((x, y) => x + y);
            Console.WriteLine(result1.ToString());

            var result2 = numbers.Aggregate(100, (x, y) => x + y);
            Console.WriteLine(result2.ToString());
        }

        static void AggregateFuncs()
        {
            IQueryable<int> numbers = Enumerable.Range(1, 20).AsQueryable();

            Expression<Func<int, bool>> even = x => x % 2 == 0;
            Expression<Func<int, bool>> higher10 = x => x > 10;
            Expression<Func<int, bool>> multiplication3 = x => x % 3 == 0;

            // 1
            // Chaining Where calls (design time only)
            IQueryable<int> query1 = numbers.Where(even).Where(higher10).Where(multiplication3);
            ConsoleExt.WriteSeq(query1);

            var filters = new[] { even, higher10, multiplication3 };


            // 2
            // Using foreach (runtime option)
            IQueryable<int> query2 = numbers;
            foreach (var filter in filters)
            {
                query2 = query2.Where(filter);
            }
            ConsoleExt.WriteSeq(query2);


            // 3
            // Make it functional with Aggregate
            IQueryable<int> query3 = filters.Aggregate(numbers, (q, filter) => q.Where(filter));
            ConsoleExt.WriteSeq(query3);


            // 4
            // Hide the ugly Aggregate syntax and allow Where to have multiple arguments
            IQueryable<int> query4 = numbers.Where(even, higher10, multiplication3);
            ConsoleExt.WriteSeq(query4);


            // 5
            // Or better, let Where receive and IEnumerable<>
            IQueryable<int> query5 = numbers.Where(filters);
            ConsoleExt.WriteSeq(query5);
        }
    }
}
