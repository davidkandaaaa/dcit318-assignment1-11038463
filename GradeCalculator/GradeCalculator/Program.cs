using System;

namespace GradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Grade Calculator ===");
            Console.WriteLine("Enter a numerical grade between 0 and 100:");

            try
            {
                // Get user input
                string input = Console.ReadLine();

                // Convert input to double to handle decimal grades
                double grade = Convert.ToDouble(input);

                // Validate grade range
                if (grade < 0 || grade > 100)
                {
                    Console.WriteLine("Error: Grade must be between 0 and 100.");
                    return;
                }

                // Determine letter grade using if-else statements
                string letterGrade;

                if (grade >= 90)
                {
                    letterGrade = "A";
                }
                else if (grade >= 80)
                {
                    letterGrade = "B";
                }
                else if (grade >= 70)
                {
                    letterGrade = "C";
                }
                else if (grade >= 60)
                {
                    letterGrade = "D";
                }
                else
                {
                    letterGrade = "F";
                }

                // Display the result
                Console.WriteLine($"Grade: {grade}");
                Console.WriteLine($"Letter Grade: {letterGrade}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid numerical grade.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}