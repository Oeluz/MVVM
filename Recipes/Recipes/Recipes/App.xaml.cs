using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Media;
using System.Collections.Generic;

namespace Recipes
{
    public partial class App : Application
    {
        public static RecipeRepository repo;

        public App(string dbPath)
        {
            repo = new RecipeRepository(dbPath);

            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected async override void OnStart()
        {
            DataLoad.list = await repo.GetAllRecipe();

            foreach (var var in DataLoad.list)
            {
                var objs = var.IngredientText.Split(',');
                var.Ingredients = new List<string>(objs);
            }

            if (DataLoad.list.Count != 0) //if the list is empty, will not categorize to avoid null exception
            {
                DataLoad.Categoring();
            }
        }

        protected override void OnSleep()
        {
            repo.WipeData();
            foreach (var var in DataLoad.list)
            {
                repo.AddNewRecipe(var);
            }
        }

        protected override void OnResume()
        {
        }
    }
}