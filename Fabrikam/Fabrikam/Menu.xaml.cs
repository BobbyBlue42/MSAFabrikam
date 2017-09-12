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
    public partial class Menu : ContentPage
    {
        ObservableCollection<Item> Appetisers { get; set; }
        ObservableCollection<Item> MainCourses { get; set; }
        ObservableCollection<Item> Desserts { get; set; }
        ObservableCollection<Item> Drinks { get; set; }

        //bool AppetisersVisible { get; set; }
        //bool MainCoursesVisible { get; set; }
        //bool DessertsVisible { get; set; }
        //bool DrinksVisible { get; set; }

        public Menu()
        {
            InitializeComponent();

            Appetisers = new ObservableCollection<Item>
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
            MainCoursesList.ItemsSource = MainCourses;
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