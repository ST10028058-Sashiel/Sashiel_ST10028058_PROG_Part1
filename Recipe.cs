using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sashiel_PROG_Part1
{
    class Recipe
    {

        //Arrays storing Recipe Details
        private string[] ingredientNamesOFArray;
        private double[] QuantitiesArray;
        private string[] UnitsStored;
        private string[] recordedIngredientsSteps;
        private double[] firstQuantitiesStored;

        // Method to store the input of the recipe details
        public void EnterRecipeDetails()
        {
            try
            {
                // number of ingredients variable to store the 
                int NumbIngreCount;

                // Input validation loop for the number of ingredients
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Red; //setting the colour for the text
                    Console.WriteLine("Enter  the number of ingredients");
                    Console.ResetColor();// Resets the color of text

                    if (!int.TryParse(Console.ReadLine(), out NumbIngreCount))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;//setting the colour for the text
                        Console.WriteLine("Invalid.Enter a number of ingredients.");
                        Console.ResetColor();// Resets the color of text
                    }
                    else if (NumbIngreCount <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;//setting the colour for the text 
                        Console.WriteLine("Invalid input. The number of ingredients must be a positive integer.");
                        Console.ResetColor();// Resets the color of text
                    }
                    else
                    {
                        break; // Exit the loop if input is valid
                    }
                }

                // Initialize arrays based on the number of ingredients
                ingredientNamesOFArray = new string[NumbIngreCount];
                QuantitiesArray = new double[NumbIngreCount];
                UnitsStored = new string[NumbIngreCount];

                // Loop to input details for each ingredient
                for (int i = 0; i < NumbIngreCount; i++)
                {
                    Console.WriteLine($"\n Enter the details for ingredient {i + 1}:");
                    Console.Write("Name of Ingredient is : ");
                    ingredientNamesOFArray[i] = Console.ReadLine();

                    // Input validation loop for ingredient quantity
                    while (true)
                    {
                        Console.Write("Quantity of ingredients is: ");
                        if (!double.TryParse(Console.ReadLine(), out double measurementQauntity))//parsing the variable as a double
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;//setting the colour of text
                            Console.WriteLine("Invalid.Enter a numeric value for quantity.");
                            Console.ResetColor();// Resets the color of text
                        }
                        else if (measurementQauntity <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;//setting the colour for the text
                            Console.WriteLine("Invalid input. Quantity must be a positive number.");
                            Console.ResetColor();// Resets the color of text
                        }
                        else
                        {
                            QuantitiesArray[i] = measurementQauntity;
                            break; // Exiting the loop if the input is valid
                        }
                    }

                    Console.Write("Enter a unit for that quantity: ");
                    UnitsStored[i] = Console.ReadLine();
                }


                int numberOfStepsCount;

              
                while (true)
                {
                    Console.WriteLine("\n Enter number of steps:");

                    if (!int.TryParse(Console.ReadLine(), out numberOfStepsCount))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;//setting the colour for the text 
                        Console.WriteLine("Invalid. Please enter a number for the number of steps.");
                        Console.ResetColor();// Resets the color of text
                    }
                    else if (numberOfStepsCount <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;//setting the colour for the text 
                        Console.WriteLine("Invalid. The number of steps must be a positive integer.");
                        Console.ResetColor();// Resets the color of text
                    }
                    else
                    {
                        break; // Exit the loop if input is valid
                    }
                }

                // Initialize array to store recipe steps
                recordedIngredientsSteps = new string[numberOfStepsCount];

                // Loop to input recipe steps
                for (int i = 0; i < numberOfStepsCount; i++)
                {
                    Console.WriteLine($"\n Please Enter step {i + 1}:");
                    recordedIngredientsSteps[i] = Console.ReadLine();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;//setting the colour for the text
                Console.WriteLine(" Successful Stored!");
                Console.ResetColor();// Resets the color of text
            }
            catch (Exception exMessage)
            {
                Console.ForegroundColor = ConsoleColor.Green; // Set text color  for error
                Console.WriteLine($"An error occurred: {exMessage.Message}");
                Console.ResetColor(); // Resets the color of text
            }
        }




        //createing  a  method to display information  of the details of the user choosen
        public void DisplayRecipe()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue; // Set text color to darkyellow
                Console.WriteLine("\nRecipe Details:");
                Console.WriteLine("---------------");

                if (ingredientNamesOFArray == null || recordedIngredientsSteps == null) //if statement if the  values are null
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Set text color to Magenta
                    Console.WriteLine("No  entered  Recipe details yet.");//displayed message
                    Console.ResetColor(); // Resets the color of text
                    return;
                }

                // Display ingredients
                Console.WriteLine("\nIngredients:");
                for (int c = 0; c < ingredientNamesOFArray.Length; c++)
                {
                    Console.WriteLine($"{ingredientNamesOFArray[c]} - {QuantitiesArray[c]} {UnitsStored[c]}");//ouputting the stored ingredients in a format
                }

                // Display steps
                Console.WriteLine("\n Steps:");
                for (int b = 0; b < recordedIngredientsSteps.Length; b++)
                {
                    Console.WriteLine($"{b + 1}. {recordedIngredientsSteps[b]}"); // display the text in order of the stored array
                }

                Console.ResetColor(); // Resets the color of text
            }
            catch (Exception exMessage)
            {
                Console.ForegroundColor = ConsoleColor.Blue; // Set text color to red for error
                Console.WriteLine($"An error occurred: {exMessage.Message}");
                Console.ResetColor(); // Resets the color of text
            }
        }




        // Scaling the quanity method and reseting the values to original values
        public void ScaleRecipe()
        {
            try
            {
                if (recordedIngredientsSteps == null || ingredientNamesOFArray == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Set text color 
                    Console.WriteLine("Recipe details are not entered yet.");//message ouput for no details in arrays
                    Console.ResetColor(); // Resets the color of text
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Blue; // Set text color 
                Console.WriteLine("   Choose scaling choice (0.5, 2, or 3) to upscale the recipe, or 'reset' to reset back to  original values:");
                Console.ResetColor(); // Resets the color of text
                string input = Console.ReadLine();

                if (input.Equals("reset", StringComparison.OrdinalIgnoreCase))
                {
                    if (firstQuantitiesStored == null) //check if the users have put a value when upscaling
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // Set text color
                        Console.WriteLine("Recipe isnt upscaled yet. Original values are already displayed.");
                        Console.ResetColor(); // Resets the color of text
                        return;
                    }

                    // Reset recipe to original values
                    QuantitiesArray = firstQuantitiesStored.ToArray();

                    Console.ForegroundColor = ConsoleColor.Red; // Set text color 
                    Console.WriteLine("\nRecipe reset to original values:");
                    Console.ResetColor(); // Resets the color of text
                    DisplayRecipe(); //calling to display the recipe
                    return;
                }

                if (!double.TryParse(input, out double scaleFactor) || (scaleFactor != 0.5 && scaleFactor != 2 && scaleFactor != 3)) //if statement with factor choices
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Set text color
                    Console.WriteLine("Invalid input.Enter 0.5, 2, 3, or 'reset'.");
                    Console.ResetColor();  // Resets the color of text
                    return;
                }

                // Store original ingredient quantities if not already stored
                if (firstQuantitiesStored == null)
                {
                    firstQuantitiesStored = QuantitiesArray.ToArray();
                }

                // calling the ingredients array to scale 
                for (int i = 0;i < QuantitiesArray.Length; i++) //incrementing the array to output all values in the array
                {
                    QuantitiesArray[i] *= scaleFactor;
                }

                Console.WriteLine($"\nScaled Recipe (Factor: {scaleFactor}):");
                DisplayRecipe();

                Console.ForegroundColor = ConsoleColor.White; // Set text color to 
                Console.WriteLine(" Scaled Quatity successful!");
                Console.ResetColor(); // Resets the color of text
            }
            catch (Exception exMessage)
            {
                Console.ForegroundColor = ConsoleColor.Blue; // Set text color to red for error
                Console.WriteLine($"An error occurred: {exMessage.Message}");
                Console.ResetColor(); // Resets the color of text
            }
        }


        //clear recipe method that uses try ,catch , if statements to check whether the user wants to clear the stored array information 
        // included validations to check whether they cleared , dont want to clear 
        public void ClearRecipe()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan; // Set text color to darkRed
                Console.WriteLine("Are you sure you want to clear the recipe? (yes/no)");
                Console.ResetColor(); // Resets the color of text

                string confirmed = Console.ReadLine();

                if (confirmed.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    ingredientNamesOFArray = null;
                    QuantitiesArray = null;
                    UnitsStored = null;
                    recordedIngredientsSteps = null;

                    Console.ForegroundColor = ConsoleColor.Red; // Set text color to blue
                    Console.WriteLine("Recipe cleared.Enter new recipe.");
                    Console.ResetColor(); // Resets the color of text
                }
                else if (confirmed.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Set text color to blue
                    Console.WriteLine("Canceled clearing of recipe. Recipe  remains unchanged.");
                    Console.ResetColor(); // Resets the color of text
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Set text color to Magenta
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                    Console.ResetColor(); // Resets the color of text
                }
            }
            catch (Exception exMessage)
            {
                Console.ForegroundColor = ConsoleColor.Green; // Set text color to red for error
                Console.WriteLine($"An error occurred: {exMessage.Message}");
                Console.ResetColor(); // Resets the color of text
            }
        }
    }
}



