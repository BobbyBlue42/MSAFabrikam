using Fabrikam.Model;
using Microsoft.WindowsAzure.MobileServices;
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
    public partial class Menu : ContentPage
    {
        ObservableCollection<ItemModel> Appetisers { get; set; }
        ObservableCollection<ItemModel> MainCourses { get; set; }
        ObservableCollection<ItemModel> Desserts { get; set; }
        ObservableCollection<ItemModel> Drinks { get; set; }

        public Menu()
        {
            InitializeComponent();

            PopulateLists_Async();

            /*Appetisers = new ObservableCollection<Item>
            {
                new Item
                {
                    Name = "Caesar Salad",
                    Description = "A fresh, crunchy salad containing leafy things.",
                    Price = 3.29
                },
                new Item
                {
                    Name = "Spring Soup",
                    Description = "A light soup filled with delightful spring vegetables.",
                    Price = 4.79
                },
                new Item
                {
                    Name = "Caesar Salad",
                    Description = "A fresh, crunchy salad containing leafy things.",
                    Price = 3.29
                },
                new Item
                {
                    Name = "Spring Soup",
                    Description = "A light soup filled with delightful spring vegetables.",
                    Price = 4.79
                },
                new Item
                {
                    Name = "Caesar Salad",
                    Description = "A fresh, crunchy salad containing leafy things.",
                    Price = 3.29
                },
                new Item
                {
                    Name = "Spring Soup",
                    Description = "A light soup filled with delightful spring vegetables.",
                    Price = 4.79
                },
                new Item
                {
                    Name = "Caesar Salad",
                    Description = "A fresh, crunchy salad containing leafy things.",
                    Price = 3.29
                },
                new Item
                {
                    Name = "Spring Soup",
                    Description = "A light soup filled with delightful spring vegetables.",
                    Price = 4.79
                },
            };

            MainCourses = new ObservableCollection<Item>
            {
                new Item
                {
                    Name = "Caesar Salad",
                    Description = "A fresh, crunchy salad containing leafy things.",
                    Price = 3.29
                },
                new Item
                {
                    Name = "Spring Soup",
                    Description = "A light soup filled with delightful spring vegetables.",
                    Price = 4.79
                },
            };

            AppetiserList.ItemsSource = Appetisers;
            MainCoursesList.ItemsSource = MainCourses;*/
        }

        async void PopulateLists_Async()
        {
            List<ItemModel> items = await AzureManager.AzureManagerInstance.GetItems();

            Appetisers = new ObservableCollection<ItemModel>();
            MainCourses = new ObservableCollection<ItemModel>();
            Desserts = new ObservableCollection<ItemModel>();
            Drinks = new ObservableCollection<ItemModel>();

            foreach (ItemModel item in items)
            {
                switch (item.Type)
                {
                    case "Appetiser":
                        Appetisers.Add(item);
                        break;
                    case "Main Course":
                        MainCourses.Add(item);
                        break;
                    case "Dessert":
                        Desserts.Add(item);
                        break;
                    case "Drink":
                        Drinks.Add(item);
                        break;
                }
            }

            AppetiserList.ItemsSource = Appetisers;
            MainCoursesList.ItemsSource = MainCourses;
            DessertList.ItemsSource = Desserts;
            DrinkList.ItemsSource = Drinks;
        }

        private void AppetisersButton_OnClicked(object sender, EventArgs e)
        {
            AppetiserList.IsVisible = !AppetiserList.IsVisible;
            MainCoursesList.IsVisible = false;
            DessertList.IsVisible = false;
            DrinkList.IsVisible = false;
        }

        private void MainCoursesButton_OnClicked(object sender, EventArgs e)
        {
            AppetiserList.IsVisible = false;
            MainCoursesList.IsVisible = !MainCoursesList.IsVisible;
            DessertList.IsVisible = false;
            DrinkList.IsVisible = false;
        }

        private void DessertsButton_OnClicked(object sender, EventArgs e)
        {
            AppetiserList.IsVisible = false;
            MainCoursesList.IsVisible = false;
            DessertList.IsVisible = !DessertList.IsVisible;
            DrinkList.IsVisible = false;
        }

        private void DrinksButton_OnClicked(object sender, EventArgs e)
        {
            AppetiserList.IsVisible = false;
            MainCoursesList.IsVisible = false;
            DessertList.IsVisible = false;
            DrinkList.IsVisible = !DrinkList.IsVisible;
        }
    }
}