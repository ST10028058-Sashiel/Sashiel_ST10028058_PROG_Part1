using static System.Formats.Asn1.AsnWriter;

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

        }
    }
}
        
   