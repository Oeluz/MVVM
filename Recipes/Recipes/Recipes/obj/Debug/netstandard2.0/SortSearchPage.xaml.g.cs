//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("Recipes.SortSearchPage.xaml", "SortSearchPage.xaml", typeof(global::Recipes.SortSearchPage))]

namespace Recipes {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("SortSearchPage.xaml")]
    public partial class SortSearchPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.SearchBar ListSearch;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ListView recipeListView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(SortSearchPage));
            ListSearch = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.SearchBar>(this, "ListSearch");
            recipeListView = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ListView>(this, "recipeListView");
        }
    }
}
