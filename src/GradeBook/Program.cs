
using System;
using System.Collections.Generic;
namespace Gradebook
{
    class Program
    {

        static void Main(String[] args)
        {
            var book = new DiskBook("Meghana's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrade(book);

            var result = book.GetStatistics();

            Console.WriteLine(InMemoryBook.CATEGORY);
            Console.WriteLine($"For the book Named {book.Name}");
            Console.WriteLine($"The Lowest Grade is {result.low}");
            Console.WriteLine($"The Highest Grade is {result.high}");
            Console.WriteLine($"The Average Grade is {result.Average}");
            Console.WriteLine($"The Letter Grade is {result.Letter}");
        }

        private static void EnterGrade(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("Grade Added");
        }

    }
}
