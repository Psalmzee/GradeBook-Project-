
using System;
using System.Collections.Generic;

namespace GradeBook
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************************WELCOME TO OKEJI SAMSON ADEIZA'S GRADEBOOK ANALYSIS SYSTEM!********************************\n\n");
            var book = new Book("SAMSON OKEJI'S GRADEBOOK");

            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();
            
            Console.WriteLine($"\n----->For the book named {book.Name}, we have the following Analysis:\n");
            Console.WriteLine($"----->The Average Score is: {stats.Average:N1} ");
            Console.WriteLine($"----->The Highest Score from the given list is: {stats.High}");
            Console.WriteLine($"----->The Lowest Score from the given list is: {stats.Low}\n\n");
            Console.WriteLine($"----->You Scored an/a '{stats.Letter}' Grade Average!\n\n");
            Console.WriteLine("----------Thank you for choosing Samson Okeji's Automated GradeBook Analysis system, Written in C# Language!");

            static void OnGradeAdded(object sender, EventArgs e)
            {
                Console.WriteLine("\nA Score was Added successfully!\n");
            }
        }

        private static void EnterGrades(Book book)
        {
            while (true)
            {
                Console.WriteLine("Enter a Score, click 'Enter' key to add score or click 'q' to Quit and view GradeBook Analysis....");
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
    }
}
