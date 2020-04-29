using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SortSearchPage : ContentPage
    {
        private bool sortDirection;

        private List<Recipe> sortList;

        public SortSearchPage()
        {
            this.BindingContext = DataLoad.list;
            sortDirection = false;
            sortList = DataLoad.list;
            InitializeComponent();
        }

        //Constantly raise if the text in searchbar is changed
        private void ListSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var list = new List<Recipe>();
            SearchBar searchBar = (SearchBar)sender;

            if (string.IsNullOrEmpty(searchBar.Text))//if empty or null, show all recipes
            {
                recipeListView.ItemsSource = DataLoad.list;
                list = DataLoad.list;
            }
            else
            {
                foreach (var item in DataLoad.list)
                {
                    if (item.Name.ToLower().Contains(searchBar.Text.ToLower()))
                    {
                        list.Add(item); //add the matched text in the recipe's name to the text in the searchbar
                    }
                }
            }
            sortList = list; //assigned the sorted list
            recipeListView.ItemsSource = list; //display
        }

        private void recipeListView_ItemTapped(object sender, ItemTappedEventArgs e) //Viewing the info of a recipe
        {
            var page = new RecipePage();
            page.BindingContext = (Recipe)e.Item;
            recipeListView.SelectedItem = null;

            Navigation.PushAsync(page);
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e) //if the user press "sort"
        {
            if (sortDirection)
            {
                sortList = sortList.OrderBy(o => o.Name).ToList(); //sort it from A to Z
                sortDirection = false;
            }
            else
            {
                sortList = sortList.OrderByDescending(o => o.Name).ToList(); //sort it from Z to A
                sortDirection = true;
            }

            recipeListView.ItemsSource = sortList;
        }
    }
}