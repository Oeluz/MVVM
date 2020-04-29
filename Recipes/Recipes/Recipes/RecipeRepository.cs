using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/* Author:      Zhencheng Chen
 * Program:     Manage the SQLite connection
 * Date:        4/16/2020
 */

namespace Recipes
{
    public class RecipeRepository
    {
        private SQLiteAsyncConnection conn;

        public RecipeRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Recipe>().Wait();
        }

        public void WipeData()
        {
            conn.DropTableAsync<Recipe>().Wait();
            conn.CreateTableAsync<Recipe>().Wait();
        }

        public async void AddNewRecipe(Recipe recipe)
        {
            try
            {
                await conn.InsertAsync(recipe);
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<List<Recipe>> GetAllRecipe()
        {
            try
            {
                return await conn.Table<Recipe>().ToListAsync();
            }
            catch (Exception ex)
            {
            }

            return new List<Recipe>();
        }
    }
}