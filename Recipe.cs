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
        private string[] ingredientStoredNames;
        private double[] StoredIngredientQuantities;
        private string[] StoredingredientUnits;
        private string[] recordedIngredientsSteps;
        private double[] originalIngredientQuantities;

        // Method to input recipe details
        public void EnterRecipeDetails()
        {
            try
            {
                // Variable to store the number of ingredients
                int NumberOFIngredientsCount;

                // Input validation loop for the number of ingredients
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White; //setting the colour for the text to be white
                    Console.WriteLine("Please enter number of ingredients");
                    Console.ResetColor();// resets the texts color

                    if (!int.TryParse(Console.ReadLine(), out NumberOFIngredientsCount))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;//setting the colour for the text to be Magenta
                        Console.WriteLine("Invalid input, an error has occured. Please enter a number for the number of ingredients.");
                        Console.ResetColor();// resets the texts color
                    }
                    else if (NumberOFIngredientsCount <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;//setting the colour for the text to be Magenta
                        Console.WriteLine("Invalid input,an error has occured. The number of ingredients must be a positive integer.");
                        Console.ResetColor();// resets the texts color
                    }
                    else
                    {
                        break; // Exit the loop if input is valid
                    }
                }

                // Initialize arrays based on the number of ingredients
                ingredientStoredNames = new string[NumberOFIngredientsCount];
                StoredIngredientQuantities = new double[NumberOFIngredientsCount];
                StoredingredientUnits = new string[NumberOFIngredientsCount];

                // Loop to input details for each ingredient
                for (int D = 0; D < NumberOFIngredientsCount; D++)
                {
                    Console.WriteLine($"\n Please enter details for ingredient {D + 1}:");
                    Console.Write("Name of Ingredient: ");
                    ingredientStoredNames[D] = Console.ReadLine();

                    // Input validation loop for ingredient quantity
                    while (true)
                    {
                        Console.Write("Quantity of ingredients: ");
                        if (!double.TryParse(Console.ReadLine(), out double measurementQauntity))//parsing the variable double
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;//setting the colour for the text to be Magenta
                            Console.WriteLine("Invalid input an error has occured. Please enter a numeric value for quantity.");
                            Console.ResetColor();// resets the texts color
                        }
                        else if (measurementQauntity <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;//setting the colour for the text to be Magenta
                            Console.WriteLine("Invalid inputan error has occured. Quantity must be a positive number.");
                            Console.ResetColor();// resets the texts color
                        }
                        else
                        {
                            StoredIngredientQuantities[D] = measurementQauntity;
                            break; // Exit the loop if input is valid
                        }
                    }

                    Console.Write(" Please enter correct unit for that quantity: ");
                    StoredingredientUnits[D] = Console.ReadLine();
                }

                // Variable to store the number of steps
                int numberOfStepsCount;

                // Input validation loop for the number of steps
                while (true)
                {
                    Console.WriteLine("\n Please enter the number of steps:");

                    if (!int.TryParse(Console.ReadLine(), out numberOfStepsCount))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;//setting the colour for the text to be Magenta
                        Console.WriteLine("Invalid input an error has occured. Please enter a number for the number of steps.");
                        Console.ResetColor();// resets the texts color
                    }
                    else if (numberOfStepsCount <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;//setting the colour for the text to be Magenta
                        Console.WriteLine("Invalid inputan error has occured. The number of steps must be a positive integer.");
                        Console.ResetColor();// resets the texts color
                    }
                    else
                    {
                        break; // Exit the loop if input is valid
                    }
                }

                // Initialize array to store recipe steps
                recordedIngredientsSteps = new string[numberOfStepsCount];

                // Loop to input recipe steps
                for (int a = 0; a < numberOfStepsCount; a++)
                {
                    Console.WriteLine($"\n Please Enter step {a + 1}:");
                    recordedIngredientsSteps[a] = Console.ReadLine();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;//setting the colour for the text to be yellow
                Console.WriteLine("Recipe details entered were successful!");
                Console.ResetColor();// resets the texts color
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Set text color to red for error
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ResetColor(); // Reset text color
            }
        }




        //created a display recipe method to display the arrays stored information regarding the details of the user choosen to stored
        public void DisplayRecipe()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Set text color to darkyellow
                Console.WriteLine("\nRecipe Details:");
                Console.WriteLine("---------------");

                if (ingredientStoredNames == null || recordedIngredientsSteps == null)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta; // Set text color to Magenta
                    Console.WriteLine("Recipe details are not entered yet.");
                    Console.ResetColor(); // Reset text color
                    return;
                }

                // Display ingredients
                Console.WriteLine("\nIngredients:");
                for (int c = 0; c < ingredientStoredNames.Length; c++)
                {
                    Console.WriteLine($"{ingredientStoredNames[c]} - {StoredIngredientQuantities[c]} {StoredingredientUnits[c]}");
                }

                // Display steps
                Console.WriteLine("\n Steps:");
                for (int b = 0; b < recordedIngredientsSteps.Length; b++)
                {
                    Console.WriteLine($"{b + 1}. {recordedIngredientsSteps[b]}");
                }

                Console.ResetColor(); // Reset text color
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Set text color to red for error
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ResetColor(); // Reset text color
            }
        }




        // Scaling the quanity method and reseting the values to original values
        public void ScaleRecipe()
        {
            try
            {
                if (recordedIngredientsSteps == null || ingredientStoredNames == null)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta; // Set text color to Magenta
                    Console.WriteLine("Recipe details are not entered yet.");
                    Console.ResetColor(); // Reset text color
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Green; // Set text color to green
                Console.WriteLine("    Please enter the scaling factor (0.5, 2, or 3) to upscale the recipe, or 'reset' to revert to original values:");
                Console.ResetColor(); // Reset text color
                string input = Console.ReadLine();

                if (input.Equals("reset", StringComparison.OrdinalIgnoreCase))
                {
                    if (originalIngredientQuantities == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta; // Set text color to pMagenta
                        Console.WriteLine("Recipe has not been upscaled yet. Original values are already displayed.");
                        Console.ResetColor(); // Reset text color
                        return;
                    }

                    // Reset recipe to original values
                    StoredIngredientQuantities = originalIngredientQuantities.ToArray();

                    Console.ForegroundColor = ConsoleColor.Green; // Set text color to green
                    Console.WriteLine("\nRecipe reset to original values:");
                    Console.ResetColor(); // Reset text color
                    DisplayRecipe();
                    return;
                }

                if (!double.TryParse(input, out double scaleFactor) || (scaleFactor != 0.5 && scaleFactor != 2 && scaleFactor != 3)) //if statement with conditions
                {
                    Console.ForegroundColor = ConsoleColor.Magenta; // Set text color to Magenta
                    Console.WriteLine("Invalid input an error occured. Please enter 0.5, 2, 3, or 'reset'.");
                    Console.ResetColor(); // Reset text color
                    return;
                }

                // Store original ingredient quantities if not already stored
                if (originalIngredientQuantities == null)
                {
                    originalIngredientQuantities = StoredIngredientQuantities.ToArray();
                }

                // calling the ingredients array to scale 
                for (int a = 0; a < StoredIngredientQuantities.Length; a++)
                {
                    StoredIngredientQuantities[a] *= scaleFactor;
                }

                Console.WriteLine($"\nScaled Recipe (Factor: {scaleFactor}):");
                DisplayRecipe();

                Console.ForegroundColor = ConsoleColor.Cyan; // Set text color to cyan
                Console.WriteLine("Quantity scaled successfully!");
                Console.ResetColor(); // Reset text colors
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Set text color to red for error
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ResetColor(); // Reset text color
            }
        }


        //clear recipe method that uses try ,catch , if statements to check whether the user wants to clear the stored array information 
        // included validations to check whether they cleared , dont want to clear 
        public void ClearRecipe()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; // Set text color to darkRed
                Console.WriteLine("Are you sure you want to clear the recipe? (yes/no)");
                Console.ResetColor(); // Reset text color

                string confirmed = Console.ReadLine();

                if (confirmed.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    ingredientStoredNames = null;
                    StoredIngredientQuantities = null;
                    StoredingredientUnits = null;
                    recordedIngredientsSteps = null;

                    Console.ForegroundColor = ConsoleColor.Blue; // Set text color to blue
                    Console.WriteLine("Recipe cleared. You can now enter a new recipe.");
                    Console.ResetColor(); // Reset text color
                }
                else if (confirmed.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Blue; // Set text color to blue
                    Console.WriteLine("Clearing recipe canceled. Recipe data remains unchanged.");
                    Console.ResetColor(); // Reset text color
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta; // Set text color to Magenta
                    Console.WriteLine("Invalid input, an error occured. Please enter 'yes' or 'no'.");
                    Console.ResetColor(); // Reset text color
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Set text color to red for error
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ResetColor(); // Reset text color
            }
        }
    }
}


//Code Attribution
//W3Schools
