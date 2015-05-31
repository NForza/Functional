using System;
using NForza.Functional.Initialization;

namespace ObjectInitialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Default C# initialization supports properties only.
            var data1 = new Data
            {
                Name = "Data 1"
            };


            // Initialize extension allows you use methods too.
            var data2 = new Data().Initialize(x =>
            {
                x.Name = "Data 2";
                x.SetDate(DateTime.Now);  // Methods!
            });

            Console.WriteLine(data1.Name);
            Console.WriteLine(data2.Name);
        }
    }

    public class Data
    {
        private DateTime date;

        public string Name { get; set; }

        public void SetDate(DateTime date)
        {
            this.date = date;
        }
    }
}
