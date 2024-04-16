
namespace Sashiel_PROG_Part1


{
    public class Program
    {
        static void Main(string[] args)
        {

            // calling the recipe class
            Recipe recipe = new Recipe();
            // while loop to ask the user for their choice with switch case for choices
            //methods brought from recipe class to program clas
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe / Reset to Original");
                Console.WriteLine("4. Clear Recipe");
                Console.WriteLine("5. Exit");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        // Set text color to green
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nEnter Recipe Details:");
                        Console.ResetColor();

                        // Call the method to enter recipe details
                        recipe.EnterRecipeDetails();
                        break;


                    case 2:
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        recipe.ScaleRecipe();
                        break;
                    case 4:
                        recipe.ClearRecipe();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the Recipe App.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

    }
}










   