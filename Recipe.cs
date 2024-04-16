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


    }
}
