using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<int>();
            items.Add(12);

            var book = new Book("Book");
            book.GradeAdded += Program.OnGradeAdded;

            book.SetGrades(new List<double>() { 80, 70 });
            book.AddGrade(100);
            book.AddGrade('A');

            book.ShowStatistic();

            Console.WriteLine(book.DoSomething());
            Console.WriteLine(book.DoAnotherThing());

            Console.WriteLine(book.Title);

            book.Title = "New book";
            
            Console.WriteLine(book.Title);
            Console.WriteLine(book.Name);

            Console.WriteLine(Book.CATEGORY);
        }

        static void OnGradeAdded(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("A grade was added!");
        }
    }
}
