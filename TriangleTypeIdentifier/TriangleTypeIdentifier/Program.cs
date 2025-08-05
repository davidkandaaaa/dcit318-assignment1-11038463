using System;

namespace TriangleTypeIdentifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Triangle Type Identifier ===");
            Console.WriteLine("Enter the lengths of the three sides of a triangle:");

            try
            {
                // Get the three sides from user
                Console.Write("Enter side 1: ");
                string input1 = Console.ReadLine();
                double side1 = Convert.ToDouble(input1);

                Console.Write("Enter side 2: ");
                string input2 = Console.ReadLine();
                double side2 = Convert.ToDouble(input2);

                Console.Write("Enter side 3: ");
                string input3 = Console.ReadLine();
                double side3 = Convert.ToDouble(input3);

                // Validate that all sides are positive
                if (side1 <= 0 || side2 <= 0 || side3 <= 0)
                {
                    Console.WriteLine("Error: All sides must be positive numbers.");
                    return;
                }

                // Validate triangle inequality theorem
                if (!IsValidTriangle(side1, side2, side3))
                {
                    Console.WriteLine("Error: These sides cannot form a valid triangle.");
                    Console.WriteLine("The sum of any two sides must be greater than the third side.");
                    return;
                }

                // Determine triangle type
                string triangleType = DetermineTriangleType(side1, side2, side3);

                // Display the result
                Console.WriteLine($"\nSide 1: {side1}");
                Console.WriteLine($"Side 2: {side2}");
                Console.WriteLine($"Side 3: {side3}");
                Console.WriteLine($"Triangle Type: {triangleType}");

                // Display additional information
                DisplayTriangleInfo(triangleType);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid numerical values for all sides.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Method to check if three sides can form a valid triangle
        static bool IsValidTriangle(double side1, double side2, double side3)
        {
            return (side1 + side2 > side3) &&
                   (side1 + side3 > side2) &&
                   (side2 + side3 > side1);
        }

        // Method to determine triangle type based on side lengths
        static string DetermineTriangleType(double side1, double side2, double side3)
        {
            // Check for equilateral triangle (all sides equal)
            if (AreEqual(side1, side2) && AreEqual(side2, side3))
            {
                return "Equilateral";
            }
            // Check for isosceles triangle (two sides equal)
            else if (AreEqual(side1, side2) || AreEqual(side1, side3) || AreEqual(side2, side3))
            {
                return "Isosceles";
            }
            // Scalene triangle (no sides equal)
            else
            {
                return "Scalene";
            }
        }

        // Method to compare two double values for equality (handles floating point precision)
        static bool AreEqual(double a, double b)
        {
            const double tolerance = 1e-9;
            return Math.Abs(a - b) < tolerance;
        }

        // Method to display additional information about the triangle type
        static void DisplayTriangleInfo(string triangleType)
        {
            Console.WriteLine("\nTriangle Information:");
            switch (triangleType)
            {
                case "Equilateral":
                    Console.WriteLine("- All three sides are equal");
                    Console.WriteLine("- All angles are 60 degrees");
                    break;
                case "Isosceles":
                    Console.WriteLine("- Two sides are equal");
                    Console.WriteLine("- Two angles are equal");
                    break;
                case "Scalene":
                    Console.WriteLine("- No sides are equal");
                    Console.WriteLine("- All angles are different");
                    break;
            }
        }
    }
}