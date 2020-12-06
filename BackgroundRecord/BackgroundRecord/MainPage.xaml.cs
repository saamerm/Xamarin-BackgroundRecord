using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BackgroundRecord
{
    public partial class MainPage : ContentPage
    {
        static int counter;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NewPageButton.Clicked += Button_Clicked;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            NewPageButton.Clicked -= Button_Clicked;
        }
        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Console.WriteLine("asd");
            Navigation.PushAsync(new VideoPage());
        }
    }
}
