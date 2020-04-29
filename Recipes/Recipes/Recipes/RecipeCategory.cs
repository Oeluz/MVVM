using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes
{
    public class RecipeCategory : List<Recipe>
    {
        public string Heading { get; set; }
        public List<Recipe> Recipes => this;
    }
}