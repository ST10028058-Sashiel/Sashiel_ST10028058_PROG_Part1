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


        }
    }
}
        
   