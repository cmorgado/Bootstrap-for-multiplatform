﻿using Bootstrap.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Bootstrap.XForms
{
    public class App : Application
    {
        public App()
        {
          

            var firstPage = new NavigationPage(new XForms.Views.Home())
            {
                //BarBackgroundColor = Color.White,
                //BarTextColor = Color.Black
            };
            MainPage = firstPage;

          //  Locator.nav.Initialize(firstPage);
        }

        static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}