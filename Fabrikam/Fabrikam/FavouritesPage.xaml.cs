using Fabrikam.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fabrikam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritesPage : ContentPage
    {
        ObservableCollection<FavouriteModel> Favourites { get; set; }
        ObservableCollection<FavouriteModel> FilteredFavourites { get; set; }

        public string Username { get; set; }

        public FavouritesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PopulateList_Async();
        }

        async void PopulateList_Async()
        {
            List<FavouriteModel> favs = await AzureManager.AzureManagerInstance.GetFavourites();

            Favourites = new ObservableCollection<FavouriteModel>(favs);
        }

        private void UsernameBox_Completed(object sender, EventArgs e)
        {
            Username = ((Entry)sender).Text;

            FilteredFavourites = new ObservableCollection<FavouriteModel>();

            foreach (FavouriteModel fav in Favourites)
            {
                if (fav.User.Equals(Username))
                {
                    FilteredFavourites.Add(fav);
                }
            }
            
            FavouritesList.ItemsSource = FilteredFavourites;
            FavouritesList.IsVisible = true;
        }

        public async void AddFavourite(string item)
        {
            FavouriteModel newFav = new FavouriteModel
            {
                User = Username,
                FoodItem = item
            };
            FilteredFavourites.Add(newFav);
            Favourites.Add(newFav);

            await AzureManager.AzureManagerInstance.PostFavouritesInformation(newFav);
        }
    }
}