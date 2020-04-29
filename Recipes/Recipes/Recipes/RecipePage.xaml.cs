using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.IO;

/* Author:      Zhencheng Chen
 * Program:     Display the info of a recipe on a page
 * Date:        4/18/2020
 */

namespace Recipes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        public RecipePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (this.BindingContext is Recipe) //Update the views after the user finish with editing
            {
                var obj = (Recipe)this.BindingContext;
                foreach (var var in DataLoad.list)
                {
                    if (var.Key == obj.Key)
                    {
                        name.Text = var.Name;
                        ingredListView.ItemsSource = null;
                        ingredListView.ItemsSource = var.Ingredients;
                        directionText.Text = var.Directions;
                        this.BindingContext = var;
                    }
                }
            }
        }

        private void editBtn_Clicked(object sender, EventArgs e) //Open a page that allow the user to edit the recipe
        {
            var page = new EditRecipePage();
            page.BindingContext = (Recipe)this.BindingContext;

            Navigation.PushModalAsync(new NavigationPage(page));
        }

        private void ingredListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ingredListView.SelectedItem = null;
        }

        private async void shareBtn_Clicked(object sender, EventArgs e) //allow the user to share the recipe's info
        {
            var name = "Recipe.txt";
            var file = Path.Combine(FileSystem.CacheDirectory, name);
            var recipe = (Recipe)this.BindingContext;

            var ingredText = "";
            foreach (var var in recipe.Ingredients)
            {
                ingredText = ingredText + "\t" + var + "\n";
            }

            string info = string.Format($"Name: {recipe.Name} -- ({recipe.Category}\n" +
                $"Ingredients:\n" +
                $"{ingredText}\n\n" +
                $"Direction:\n\n" +
                $"{recipe.Directions}");

            File.WriteAllText(file, info);

            await Share.RequestAsync(new ShareFileRequest
            {
                Title = $"Recipe: {recipe.Name}",
                File = new ShareFile(file)
            });
        }
    }
}