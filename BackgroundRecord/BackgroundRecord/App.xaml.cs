﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BackgroundRecord
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new VideoPage();
            //MainPage = new AudioPage();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
