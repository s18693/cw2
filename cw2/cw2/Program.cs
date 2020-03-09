using System;
using System.IO;

namespace cw2
{
    class Program
    {
        //Podajemy 3 argumenty
        //Zrobić do końca piątku
        //hashSet zeby nie było duplikatów
        //jaison
        //IEnumerable -> ICollection -> Ilist
        //IEnumerable -> IQueryable INHERITANCE
        static void Main(string[] args)
        {
            //var path = @"C:\Users\jd\Desktop\dane.csv";
            var path = @"C:\Users\s18693\Desktop\dane.csv";
            //var path = @"C:\Users\s18693\Desktop";

            var lines = File.ReadLines(path);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            var parsedDate = DateTime.Parse("9.03.2020");
            Console.WriteLine(parsedDate);
            var now = DateTime.UtcNow;
            Console.WriteLine(now);
            var today = DateTime.Today;
            Console.WriteLine(today);
            Console.WriteLine(today.ToShortDateString());
        }
    }
}
