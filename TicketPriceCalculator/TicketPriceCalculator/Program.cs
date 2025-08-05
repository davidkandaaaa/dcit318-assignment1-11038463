using System;

namespace TicketPriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Movie Theater Ticket Price Calculator ===");
            Console.WriteLine("Enter your age to calculate ticket price:");

            try
            {
                // Get user input
                string input = Console.ReadLine();

                // Convert input to integer
                int age = Convert.ToInt32(input);

                // Validate age (should be positive)
                if (age < 0)
                {
                    Console.WriteLine("Error: Age cannot be negative.");
                    return;
                }

                // Set ticket prices
                const decimal REGULAR_PRICE = 10.00m;
                const decimal DISCOUNTED_PRICE = 7.00m;

                // Determine ticket price based on age
                decimal ticketPrice;
                string customerType;

                if (age <= 12)
                {
                    ticketPrice = DISCOUNTED_PRICE;
                    customerType = "Child";
                }
                else if (age >= 65)
                {
                    ticketPrice = DISCOUNTED_PRICE;
                    customerType = "Senior Citizen";
                }
                else
                {
                    ticketPrice = REGULAR_PRICE;
                    customerType = "Regular";
                }

                // Display the result
                Console.WriteLine($"\nAge: {age}");
                Console.WriteLine($"Customer Type: {customerType}");
                Console.WriteLine($"Ticket Price: GHC{ticketPrice:F2}");

                // Display discount information if applicable
                if (ticketPrice == DISCOUNTED_PRICE)
                {
                    decimal savings = REGULAR_PRICE - DISCOUNTED_PRICE;
                    Console.WriteLine($"You saved: GHC{savings:F2}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid age (whole number).");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Age value is too large.");
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