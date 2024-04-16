
namespace Sashiel_PROG_Part1


{
    class Program
    {
        static void Main(string[] args)
        {

            bool running = true;

            while (running)
            {
                Console.WriteLine("Welcome to the Recipe Application!");
                Console.WriteLine("1. Add a Recipe");
                Console.WriteLine("2. Exit");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRecipe();
                        break;
                    case "2":
                        running = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }

        static void AddRecipe()
        {
            Console.WriteLine("Enter the number of ingredients:");
            int ingredientCount;
            while (!int.TryParse(Console.ReadLine(), out ingredientCount) || ingredientCount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter the number of ingredients:");
            }

            Ingredient[] ingredients = new Ingredient[ingredientCount];
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter ingredient {i + 1} details (name, unit, quantity):");
                string[] details = Console.ReadLine().Split();
                double quantity;
                while (!double.TryParse(details[2], out quantity))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid quantity. Please enter a valid number.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Enter ingredient {i + 1} details (name, unit, quantity):");
                    details = Console.ReadLine().Split();
                }
                ingredients[i] = new Ingredient
                {
                    Name = details[0],
                    Unit = details[1],
                    Quantity = quantity
                };
            }

            Console.WriteLine("Enter the number of steps:");
            int stepCount;
            while (!int.TryParse(Console.ReadLine(), out stepCount) || stepCount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter the number of steps:");
            }

            Step[] steps = new Step[stepCount];
            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter step {i + 1} description:");
                string description = Console.ReadLine();
                steps[i] = new Step { Description = description };
            }

            Recipe recipe = new Recipe();
            recipe.SetIngredients(ingredients);
            recipe.SetSteps(steps);

            Console.WriteLine("\nFull Recipe:");
            recipe.DisplayRecipe();

            bool scaling = true;
            while (scaling)
            {
                Console.WriteLine("\nScale recipe by (e.g., 0.5, 2, 3) or enter '0' to return to the main menu:");
                double scale;
                while (!double.TryParse(Console.ReadLine(), out scale))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nScale recipe by (e.g., 0.5, 2, 3) or enter '0' to return to the main menu:");
                }

                if (scale == 0)
                {
                    scaling = false;
                }
                else
                {
                    recipe.ScaleRecipe(scale);
                    Console.WriteLine("\nScaled Recipe:");
                    recipe.DisplayRecipe();
                }
            }
        }

    }
}









   