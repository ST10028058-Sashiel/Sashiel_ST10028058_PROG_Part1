using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sashiel_PROG_Part1
{
    public class Ingredient
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public double InitialQuantity { get; set; } // Store the initial quantity
        public double Quantity { get; set; } // Quantity for scaling
    }

    public class Step
    {
        public string Description { get; set; }
    }

    public class Recipe
    {
        private Ingredient[] ingredients;
        private Step[] steps;

        public void SetIngredients(Ingredient[] ingredients)
        {
            this.ingredients = ingredients;
            foreach (var ingredient in this.ingredients)
            {
                // Store the initial quantity
                ingredient.InitialQuantity = ingredient.Quantity;
            }
        }

        public void SetSteps(Step[] steps)
        {
            this.steps = steps;
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("\nInstructions:");
            foreach (var step in steps)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(step.Description);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ScaleRecipe(double scale)
        {
            foreach (var ingredient in ingredients)
            {
                // Scale the quantity based on the initial value
                ingredient.Quantity = ingredient.InitialQuantity * scale;
            }
        }

        public void ReturnToBase()
        {
            foreach (var ingredient in ingredients)
            {
                // Set the quantity back to the initial value
                ingredient.Quantity = ingredient.InitialQuantity;
            }
        }

        public void ClearRecipe()
        {
            ingredients = null;
            steps = null;
        }

    }
}
