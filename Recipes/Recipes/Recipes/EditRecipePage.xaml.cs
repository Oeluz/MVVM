using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/* Author:      Zhencheng Chen
 * Program:     Editing/Adding a recipe
 * Date:        4/18/2020
 */

namespace Recipes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditRecipePage : ContentPage
    {
        private List<string> list;

        public EditRecipePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (this.BindingContext != null)
            {
                Recipe recipe = (Recipe)this.BindingContext;
                list = recipe.Ingredients;
            }
            else
            {
                list = new List<string>();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            string name = "";
            List<string> list = new List<string>();
            string direction = "";
            string category = "";

            int index = 0;
            bool sameKey = false;

            if (titleEntry.Text != null) //make sure the title entry is not null
            {
                name = titleEntry.Text;

                //if the listview have no source, will add a blank string to it due to NullException
                if (ingredListView.ItemsSource != null)
                {
                    foreach (var var in ingredListView.ItemsSource)
                    {
                        list.Add(var.ToString());
                    }
                }

                direction = directionEdit.Text;

                category = categoryEntry.Text;

                if (String.IsNullOrEmpty(category))
                {
                    category = "OTHER";
                }

                Recipe obj = new Recipe();

                obj = new Recipe(-1, name, direction, list, category);

                if (this.BindingContext is Recipe) // determine if this page is "Add" page or "Edit" page
                {
                    var a = (Recipe)this.BindingContext;
                    obj = a;
                }

                foreach (var var in DataLoad.list)
                {
                    if (obj.Key == var.Key)
                    {
                        index = DataLoad.list.IndexOf(var);
                        sameKey = true; //if there are two objects that share same key, replace the old one

                        DataLoad.list[index] = obj; //Replace

                        DataLoad.Categoring();
                        await DisplayAlert("Saved!", "The recipe is saved to the list of recipes", "ok");
                        await Navigation.PopModalAsync();

                        return;
                    }
                }

                int key = 0;
                foreach (var var in DataLoad.list) //Add new Recipe with new Key
                {
                    key = var.Key + 1; //Generate new key
                }

                obj.Key = key;
                DataLoad.list.Add(obj);

                DataLoad.Categoring();

                await DisplayAlert("Saved!", "The recipe is saved to the list of recipes", "ok");
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Title", "Please enter a title", "Ok");
            }
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e) //if the user press "cancel"
        {
            await Navigation.PopModalAsync(true);
        }

        private async void addBtn_Clicked(object sender, EventArgs e) //add new ingredient into the list
        {
            if (ingredientAdd.Text != null)
            {
                ingredListView.ItemsSource = null; //"update" the list
                list.Add(ingredientAdd.Text);
                ingredListView.ItemsSource = list;
            }
            else
            {
                await DisplayAlert("Blank Text", "Please do not add blank text to ingredient list", "Ok");
            }
        }

        private void ingredListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ingredListView.SelectedItem = null;
        }
    }
}