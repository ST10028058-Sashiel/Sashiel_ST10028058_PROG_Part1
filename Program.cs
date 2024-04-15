
namespace Sashiel_PROG_Part1


{
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
    }

    class RecipeStep
    {
        public string Description { get; set; }
    }

    class Recipe
    {
        public List<Ingredient> Ingredients { get; set; }
        public List<RecipeStep> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<RecipeStep>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            Recipe recipe = new Recipe();

            Console.WriteLine("Enter the number of ingredients:");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit: ");
                string unit = Console.ReadLine();

                recipe.Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit });
            }
            Console.WriteLine("Enter the number of steps:");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                string step = Console.ReadLine();

                recipe.Steps.Add(new RecipeStep { Description = step });
            }

            DisplayRecipe(recipe);

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Scale recipe");
                Console.WriteLine("2. Reset quantities");
                Console.WriteLine("3. Clear recipe");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter scaling factor (0.5, 2, or 3):");
                        double factor = double.Parse(Console.ReadLine());
                        ScaleRecipe(recipe, factor);
                        DisplayRecipe(recipe);
                        break;
                    case 2:
                        ResetQuantities(recipe);
                        DisplayRecipe(recipe);
                        break;
                    case 3:
                        recipe = new Recipe();
                        Console.WriteLine("Recipe cleared.");
                        break;
                    case 4:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void DisplayRecipe(Recipe recipe)
        {
            Console.WriteLine("\nRecipe:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine("Steps:");
            int stepNumber = 1;
            foreach (var step in recipe.Steps)
            {
                Console.WriteLine($"{stepNumber}. {step.Description}");
                stepNumber++;
            }
        }

        static void ScaleRecipe(Recipe recipe, double factor)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        static void ResetQuantities(Recipe recipe)
        {
            // Reset quantities to original values
            foreach (var ingredient in recipe.Ingredients)
            {
                // Assuming the original quantities are 1 for simplicity
                ingredient.Quantity = 1;
            }
        }
    } 

    } 



    



        
   