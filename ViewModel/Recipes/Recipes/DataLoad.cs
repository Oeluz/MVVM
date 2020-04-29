using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace Recipes
{
    public class DataLoad
    {
        //public static List<Recipe> list = new List<Recipe>();
        //public static List<RecipeCategory> categoryList = new List<RecipeCategory>();
        public static List<Recipe> list { get; set; }
        public static List<RecipeCategory> categoryList { get; set; }

        public DataLoad()
        {

        }
        public static void Categoring() //when a recipe is added, the method will be called to replace new RecipeCategory list
        {
            bool empty = false;

            List<Recipe> groupingList = new List<Recipe>();

            foreach (var item in list) //make seperate list, so the list contain all recipes wouldn't overwrite by this method
            {
                groupingList.Add(item);
            }

            categoryList = new List<RecipeCategory>();
            string listHeading = "";

            while (!empty) //if the copied list is not empty, keep looping
            {
                listHeading = groupingList[0].Category.ToUpper(); //get the header name
                var group = new RecipeCategory();
                group.Heading = listHeading;

                foreach (var item in groupingList.ToArray())
                {
                    if (listHeading == item.Category.ToUpper())//if the header name is matched with the recipe's category name
                    {
                        group.Add(item);
                        groupingList.Remove(item);
                    }
                }

                categoryList.Add(group); //assign the list of recipeCategory to the static list for other classes to use

                if (groupingList.Count == 0) //if the copied list is empty, stop the loop
                    empty = true;
            }
        }
    }
}