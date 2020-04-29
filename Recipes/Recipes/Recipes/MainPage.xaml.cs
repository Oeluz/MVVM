using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

/* Author:      Zhencheng Chen
 * Program:     Display the list of recipes
 * Date:        2/18/2020
 */

namespace Recipes
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            if (!(DataLoad.list.Count == 0))
            {
                DataLoad.Categoring();
            }
            this.BindingContext = DataLoad.categoryList;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            recipeListView.ItemsSource = null;
            recipeListView.ItemsSource = DataLoad.categoryList;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new EditRecipePage())); //Adding new recipe
        }

        private void recipeListView_ItemTapped(object sender, ItemTappedEventArgs e) //Viewing the info of a recipe
        {
            var page = new RecipePage();

            int count = e.ItemIndex;
            Recipe obj = new Recipe();
            //Using the for loop to find the specifix index because the number of indexes include the headers
            for (int i = 0; i < DataLoad.categoryList.Count; i++)
            {
                count--; //this subtraction count for the header
                foreach (var item in DataLoad.categoryList[i].Recipes)
                {
                    if (count == 0)
                    {
                        obj = item;
                    }
                    count--;
                }
            }

            //page.BindingContext = DataLoad.list[index];
            page.BindingContext = obj;
            recipeListView.SelectedItem = null;

            Navigation.PushAsync(page);
        }

        private void Button_Clicked(object sender, EventArgs e) //Changing the theme color
        {
            Button btn = (Button)sender;

            if (btn.BackgroundColor == Color.Red)
            {
                Application.Current.Resources["ThemeColor"] = Color.Red;
            }
            else if (btn.BackgroundColor == Color.OrangeRed)
            {
                Application.Current.Resources["ThemeColor"] = Color.OrangeRed;
            }
            else if (btn.BackgroundColor == Color.Purple)
            {
                Application.Current.Resources["ThemeColor"] = Color.Purple;
            }
            else if (btn.BackgroundColor == Color.DarkBlue)
            {
                Application.Current.Resources["ThemeColor"] = Color.DarkBlue;
            }
        }

        private async void SearchToolBar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SortSearchPage());
        }
    }
}