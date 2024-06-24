using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display the title as the C# Calculator app
            Console.WriteLine("Console Calculator app\r");
            Console.WriteLine("----------------------\n");

            while (!endApp)
            {
                // Declare variables and set to empty
                // Use Nullable types (with ?)
                string? numInput1 = "";
                string? numInput2 = "";
                double result = 0;

                // Ask the user to type the first number
                Console.WriteLine("Type a number, then press Enter key: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.WriteLine("This is not a valid input. Please enter a numeric value: ");
                    numInput1 = Console.ReadLine();
                }

                //ask the user to type the second number
                Console.WriteLine("Type another number, then press Enter key: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2)) ;
                {
                    Console.WriteLine("This is not a valid input. Please Enter a numeric value: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the user to to choose an operator
                Console.WriteLine("Choose an operator from the following list: ");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");

                string? op = Console.ReadLine();

                // Validate input is not num, and matches the pattern
                if (op == null || Regex.IsMatch(op, "[a|s|m|d]"))
                {
                    Console.WriteLine("Error: Unrecognized input");
                }
                else
                {
                    try
                    {
                        result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("This operation will result in a mathematical error.\n");
                        }
                        else
                        {
                            Console.WriteLine("Your result: {0:0.##}\n", result);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Yikes! An exception occurred trying to do math.\n - Details: " + e.Message);
                    }
                }
                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing
                Console.WriteLine("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");

                if (Console.ReadLine() == "n")
                    endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}
