using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DogFactsSamples.Models; 

namespace DogFactsSamples
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetItemsAsync();
        }
    }
}
