using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using SQLite;

namespace Recipes
{
    public class Recipe
    {
        [PrimaryKey]
        public int Key { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(150000)]
        public string Directions { get; set; }

        [Ignore]
        public List<string> Ingredients { get; set; }

        [MaxLength(150000)]
        public string IngredientText { get; set; }

        [MaxLength(150000)]
        public string Category { get; set; }

        public Recipe(int key, string name, string directions, List<string> ingredients, string category)
        {
            Key = key;
            Name = name;
            Directions = directions;
            Ingredients = ingredients;
            Category = category;

            string text = "";
            foreach (var var in Ingredients)
            {
                text = text + "," + var;
            }
            IngredientText = text;
        }

        public Recipe()
        {
            //default constructor
        }
    }
}