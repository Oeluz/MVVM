using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Recipes
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public INavigation Navigation { get { return App.Current.MainPage.Navigation; } }
		public List<RecipeCategory> data {get;set;}
		public MainViewModel()
		{
			if (!(DataLoad.list.Count == 0))
			{
				DataLoad.Categoring();
				data = DataLoad.categoryList;
			}
		}
		public List<RecipeCategory> Data
		{
			get { return data; }
			set 
			{ 
				data = value;
				NotifyPropertyChanged();
			}
		}

		public Command AddRecipeCommand
		{
			get
			{
				return new Command(async() =>
				{
					await Navigation.PushAsync(new EditRecipePage());
				});
			}
		}

		public Command SearchSortCommand
		{
			get
			{
				return new Command(async () =>
				{
					await Navigation.PushAsync(new SortSearchPage());
				});
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
