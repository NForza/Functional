using NForza.Console;
using NForza.Functional;
using System;
using System.Linq;

namespace Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            CreatingEnumerables();

            EnumerableInEnumerableOut();

            UsingEnumerables();

            Abstractions();
        }

        private static void EnumerableInEnumerableOut()
        {
            ConsoleExt.Header1("enumerable in, enumerable out");

            #region Shorter enumerable from longer enumerable

            ConsoleExt.Header2("Shorter enumerable from longer enumerable");

            ConsoleExt.WriteTitledSeq(
                "Distinct",
                "new[] { 1, 2, 2, 3, 3, 3, 2, 2, 1 }.Distinct()",
                new[] { 1, 2, 2, 3, 3, 3, 2, 2, 1 }.Distinct());
            // 1, 2, 3

            ConsoleExt.WriteTitledSeq(
                "DistinctUntilChanged [IX]",
                "new[] { 1, 2, 2, 3, 3, 3, 2, 2, 1 }.DistinctUntilChanged()",
                new[] { 1, 2, 2, 3, 3, 3, 2, 2, 1 }.DistinctUntilChanged());
            // 1, 2, 3, 2, 1

            ConsoleExt.WriteTitledSeq(
                "Where",
                "Enumerable.Range(1, 10).Where(x => x % 2 != 0)",
                Enumerable.Range(1, 10).Where(x => x % 2 != 0));
            // 1, 3, 5, 7, 9

            #endregion

            #region Longer enumerable from shorter enumerable

            ConsoleExt.Header2("Longer enumerable from shorter enumerable");

            ConsoleExt.WriteTitledSeq(
                "Concat",
                "new[] { 1, 2, 3 }.Concat(new[] { 4, 5, 6 })",
                new[] { 1, 2, 3 }.Concat(new[] { 4, 5, 6 }));
            // 1, 2, 3, 4, 5, 6

            ConsoleExt.WriteTitledSeq(
                "Concat [IX]",
                "EnumerableEx.Concat(new[] {new [] { 1, 2, 3 }, new [] { 4, 5, 6 }})",
                EnumerableEx.Concat(new[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 } }));
            // 1, 2, 3, 4, 5, 6

            ConsoleExt.WriteTitledSeq(
                "Cycle [NForza]",
                "new[] { 1, 2, 3 }.Cycle()",
                new[] { 1, 2, 3 }.Cycle());
            // 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3...

            ConsoleExt.WriteTitledSeq(
                "Interleave [NForza]",
                "new[] { 2, 2 }.Interleave(new[] { 3, 3, 3 }, new[] { 4, 4, 4, 4 })",
                new[] { 2, 2 }.Interleave(new[] { 3, 3, 3 }, new[] { 4, 4, 4, 4 }));
            // 2, 3, 4, 2, 3, 4

            ConsoleExt.WriteTitledSeq(
                "Interpose [NForza]",
                "new[] { 5, 5, 5, 5, 5 }.Interpose(1)",
                new[] { 5, 5, 5, 5, 5 }.Interpose(1));
            // 5, 1, 5, 1, 5, 1, 5, 1, 5

            #endregion

            #region Enumerable with head-items missing

            ConsoleExt.Header2("Enumerable with head-items missing");

            ConsoleExt.WriteTitledSeq(
                "Skip",
                "new[] { 1, 2, 3, 4, 5 }.Skip(2)",
                new[] { 1, 2, 3, 4, 5 }.Skip(2));
            // 3, 4, 5

            ConsoleExt.WriteTitledSeq(
                "SkipWhile",
                "new[] { 1, 2, 3, 4, 5 }.SkipWhile(x => x < 4)",
                new[] { 1, 2, 3, 4, 5 }.SkipWhile(x => x < 4));
            // 4, 5

            ConsoleExt.WriteTitledSeq(
                "TakeLast [IX]",
                "new[] { 1, 2, 3, 4, 5 }.TakeLast(3)",
                new[] { 1, 2, 3, 4, 5 }.TakeLast(3));
            // 3, 4, 5

            #endregion

            #region Enumerable with tail-items missing

            ConsoleExt.Header2("Enumerable with tail-items missing");

            ConsoleExt.WriteTitledSeq(
                "Take",
                "new[] { 1, 2, 3, 4, 5 }.Take(2)",
                new[] { 1, 2, 3, 4, 5 }.Take(2));
            // 1, 2

            ConsoleExt.WriteTitledSeq(
                "TakeNth [NForza]",
                "Enumerable.Range(1, 100).TakeNth(3)",
                Enumerable.Range(1, 100).TakeNth(3));
            // 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36...

            ConsoleExt.WriteTitledSeq(
                "TakeWhile",
                "new[] { 1, 2, 3, 4, 5 }.TakeWhile(x => x < 4)",
                new[] { 1, 2, 3, 4, 5 }.TakeWhile(x => x < 4));
            // 1, 2, 3

            ConsoleExt.WriteTitledSeq(
                "SkipLast [IX]",
                "new[] { 1, 2, 3, 4, 5 }.SkipLast(3)",
                new[] { 1, 2, 3, 4, 5 }.SkipLast(3));
            // 1, 2

            #endregion

            #region Rearrangment of a enumerable

            ConsoleExt.Header2("Rearrangment of a enumerable");

            ConsoleExt.WriteTitledSeq(
                "Order [NForza]",
                "new[] { 2, 4, 5, 1, 3 }.Order()",
                new[] { 2, 4, 5, 1, 3 }.Order());
            // 1, 2, 3, 4, 5

            ConsoleExt.WriteTitledSeq(
                "OrderBy",
                "new[] { 2, 4, 5, 1, 3 }.OrderBy(x => x)",
                new[] { 2, 4, 5, 1, 3 }.OrderBy(x => x));
            // 1, 2, 3, 4, 5

            ConsoleExt.WriteTitledSeq(
                "Reverse",
                "new[] { 1, 2, 3, 4, 5 }.Reverse()",
                new[] { 1, 2, 3, 4, 5 }.Reverse());
            // 5, 4, 3, 2, 1

            ConsoleExt.WriteTitledSeq(
                "Shuffle [NForza]",
                "new[] { 1, 2, 3, 4, 5 }.Shuffle(new Random(321))",
                new[] { 1, 2, 3, 4, 5 }.Shuffle(new Random(321)));
            // 3, 1, 4, 5, 2

            #endregion

            ConsoleExt.Header2("Create nested enumerables");

            // TODO
            // split-at split-with partition partition-all partition-by


            #region Process each item of a enumerable to create a new enumerable

            ConsoleExt.Header2("Process each item of a enumerable to create a new enumerable");

            ConsoleExt.WriteTitledSeq(
                "Aggregations [NForza]",
                "new[] { 1, 2, 3, 4, 5 }.Aggregations((x, y) => x + y)",
                new[] { 1, 2, 3, 4, 5 }.Aggregations((x, y) => x + y));
            // 1, 3, 6, 10, 15

            ConsoleExt.WriteTitledSeq(
                "Aggregations (with seed) [NForza]",
                "new[] { 1, 2, 3, 4, 5 }.Aggregations(100, (x, y) => x + y)",
                new[] { 1, 2, 3, 4, 5 }.Aggregations(100, (x, y) => x + y));
            // 100, 101, 103, 106, 110, 115

            ConsoleExt.WriteTitledSeq(
                "Scan [IX]",
                "new[] { 1, 2, 3, 4, 5 }.Scan((x, y) => x + y)",
                new[] { 1, 2, 3, 4, 5 }.Scan((x, y) => x + y));
            // 3, 6, 10, 15

            ConsoleExt.WriteTitledSeq(
                "Scan (with seed) [IX]",
                "new[] { 1, 2, 3, 4, 5 }.Scan(100, (x, y) => x + y)",
                new[] { 1, 2, 3, 4, 5 }.Scan(100, (x, y) => x + y));
            // 101, 103, 106, 110, 115

            ConsoleExt.WriteTitledSeq(
                "Select",
                "new[] { 1, 2, 3, 4, 5 }.Select(x => x + 2)",
                new[] { 1, 2, 3, 4, 5 }.Select(x => x + 2));
            // 3, 4, 5, 6, 7

            ConsoleExt.WriteTitledSeq(
                "Zip",
                "new[] { 1, 2, 3 }.Zip(new[] { \"A\", \"B\", \"C\" }, (x, y) => x + \": \" + y)",
                new[] { 1, 2, 3 }.Zip(new[] { "A", "B", "C" }, (x, y) => x + ": " + y));
            // 1: A, 2: B, 3: C

            #endregion

            #region Group each item of a enumerable to create a new enumerable

            ConsoleExt.Header2("Group each item of a enumerable to create a new enumerable");

            var persons = new[] {
                new Person("Alice", Sex.Female, 26000),
                new Person("Barry", Sex.Male, 32000),
                new Person("Clare", Sex.Female, 64000),
                new Person("Derk", Sex.Male, 40000),
                new Person("Eva", Sex.Female, 21000)
            };

            ConsoleExt.WriteTitledSeq(
                "CountBy [NForza]",
                "new[] { new Person(\"Alice\", Sex.Female, 26000), new Person(\"Barry\", Sex.Male, 32000), new Person(\"Clare\", Sex.Female, 64000), new Person(\"Derk\", Sex.Male, 40000), new Person(\"Eva\", Sex.Female, 21000) }.CountBy(x => x.Sex)",
                EnumerableExtensions.CountBy(persons, x => x.Sex)
                );
            // [Female, 3], [Male, 2]

            ConsoleExt.WriteTitledSeq(
                "AverageBy [NForza]",
                "new[] { new Person(\"Alice\", Sex.Female, 26000), new Person(\"Barry\", Sex.Male, 32000), new Person(\"Clare\", Sex.Female, 64000), new Person(\"Derk\", Sex.Male, 40000), new Person(\"Eva\", Sex.Female, 21000) }.AverageBy(x => x.Sex, x => x.Income)",
                EnumerableExtensions.AverageBy(persons, x => x.Sex, x => x.Income)
                );
            // [Female, 3], [Male, 2]

            ConsoleExt.WriteTitledSeq(
                "MaxBy [NForza]",
                "new[] { new Person(\"Alice\", Sex.Female, 26000), new Person(\"Barry\", Sex.Male, 32000), new Person(\"Clare\", Sex.Female, 64000), new Person(\"Derk\", Sex.Male, 40000), new Person(\"Eva\", Sex.Female, 21000) }.MaxBy(x => x.Sex, x => x.Income)",
                EnumerableExtensions.MaxBy(persons, x => x.Sex, x => x.Income)
                );
            // [Female, 64000], [Male, 40000]

            ConsoleExt.WriteTitledSeq(
                "MinBy [NForza]",
                "new[] { new Person(\"Alice\", Sex.Female, 26000), new Person(\"Barry\", Sex.Male, 32000), new Person(\"Clare\", Sex.Female, 64000), new Person(\"Derk\", Sex.Male, 40000), new Person(\"Eva\", Sex.Female, 21000) }.MinBy(x => x.Sex, x => x.Income)",
                EnumerableExtensions.MinBy(persons, x => x.Sex, x => x.Income)
                );
            // [Female, 21000], [Male, 32000]

            ConsoleExt.WriteTitledSeq(
                "SumBy [NForza]",
                "new[] { new Person(\"Alice\", Sex.Female, 26000), new Person(\"Barry\", Sex.Male, 32000), new Person(\"Clare\", Sex.Female, 64000), new Person(\"Derk\", Sex.Male, 40000), new Person(\"Eva\", Sex.Female, 21000) }.SumBy(x => x.Sex, x => x.Income)",
                EnumerableExtensions.SumBy(persons, x => x.Sex, x => x.Income)
                );
            // [Female, 111000], [Male, 72000]

            // TODO More

            #endregion
        }

        private static void UsingEnumerables()
        {
            ConsoleExt.Header1("Using enumerables");

            #region Extract a specific-numbered item from an enumerable

            ConsoleExt.Header2("Extract a specific-numbered item from an enumerable");

            ConsoleExt.WriteTitled(
                "First",
                "new[] { 1, 2, 3, 4, 5 }.First()",
                new[] { 1, 2, 3, 4, 5 }.First());
            // 1

            ConsoleExt.WriteTitled(
                "ElementAt",
                "new[] { 1, 2, 3, 4, 5 }.ElementAt(2)",
                new[] { 1, 2, 3, 4, 5 }.ElementAt(2));
            // 3

            ConsoleExt.WriteTitled(
                "Last",
                "new[] { 1, 2, 3, 4, 5 }.Last()",
                new[] { 1, 2, 3, 4, 5 }.Last());
            // 5

            #endregion

            // Construct a collection from a seq: zipmap into reduce set vec into-array to-array-2d frequencies group-by
            // Pass items of a seq as arguments to a function: apply
            // Compute a boolean from a seq: not-empty some reduce seq? every? not-every? not-any? empty? (any all contains SequenceEqual)
            // Search a seq using a predicate: some filter
            // Force evaluation of lazy seqs: doseq dorun doall
            // Check if lazy seqs have been forcibly evaluated: realized?

            ConsoleExt.Header2("Know if enumerator is done");

            ConsoleExt.WriteTitledSeq(
                "Finally [IX]",
                "EnumerableExtensions.Repeat<int>(1).Finally(() => Console.WriteLine(\"- Reached the end\"))",
                EnumerableExtensions.Repeat<int>(1).Finally(() => Console.WriteLine("- Reached the end")));
            // - Reached the end
            // 1, 1, 1, 1, 1

            
            // TODO Make lazy: Defer
            }

        private static void CreatingEnumerables()
        {
            ConsoleExt.Header1("Creating enumerables");

            #region From producer function

            ConsoleExt.Header2("From producer function");

            ConsoleExt.WriteTitledSeq(
                "Repeatedly (limited) [NForza]",
                "EnumerableExtensions.Repeatedly(5, () => { Console.WriteLine(\"- func-call\"); return 1; })",
                EnumerableExtensions.Repeatedly(5, () => { Console.WriteLine("- func-call"); return 1; }));
            /*
             * - func-call
             * - func-call
             * - func-call
             * - func-call
             * - func-call
             * 1, 1, 1, 1, 1
            */

            ConsoleExt.WriteTitledSeq(
                "Repeatedly (unlimited) [NForza]",
                "EnumerableExtensions.Repeatedly(() => { Console.WriteLine(\"- func-call\"); return 1; })",
                EnumerableExtensions.Repeatedly(() => { Console.WriteLine("- func-call"); return 1; }));
            /*
             * - func-call
             * - func-call
             * - func-call
             * - func-call
             * - func-call
             * - func-call
             * - func-call
             * - func-call
             * - func-call
             * - func-call
             * - func-call
             * - func-call
             * - func-call
             * - func-call
             * 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1...
             */

            ConsoleExt.WriteTitledSeq(
                "Iterate [NForza]",
                "EnumerableExtensions.Iterate(x => x + 1, 1)",
                EnumerableExtensions.Iterate(x => x + 1, 1));
            // 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12...

            #endregion

            #region From constant

            ConsoleExt.Header2("From constant");

            ConsoleExt.WriteTitledSeq(
                "Repeat (limited) [NForza]",
                "Enumerable.Repeat<int>(5, 1) or EnumerableExtensions.Repeat<int>(5, 1)",
                EnumerableExtensions.Repeat<int>(5, 1));
            // 1, 1, 1, 1, 1

            ConsoleExt.WriteTitledSeq(
                "Repeat (unlimited) [NForza]",
                "EnumerableExtensions.Repeat<int>(1)",
                EnumerableExtensions.Repeat<int>(1));
            // 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1...

            ConsoleExt.WriteTitledSeq(
                "Range",
                "Enumerable.Range(1, 5)",
                Enumerable.Range(1, 5));
            // 1, 2, 3, 4, 5

            #endregion
        }

        private static void Abstractions()
        {
            ConsoleExt.Header1("Abstractions");

            #region Abstractions

            Console.WriteLine("WeightedAverage [NForza]");
            Console.WriteLine("new[] { 1, 2, 3 }.WeightedAverage(x => x, x => (uint)x)");
            Console.WriteLine(new[] { 1, 2, 3 }.WeightedAverage(x => x, x => (uint)x).ToString());

            #endregion
        }

        private class Person
        {
            public Person(string name, Sex sex, int income)
            {
                Name = name;
                Sex = sex;
                Income = income;
            }

            public string Name { get; private set; }
            public Sex Sex { get; private set; }
            public int Income { get; private set; }
        }

        private enum Sex
        {
            Male,
            Female
        }
    }
}
