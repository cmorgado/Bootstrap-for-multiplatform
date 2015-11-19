using Bootstrap.MVVM.Interfaces;
using Bootstrap.MVVM.ViewModels;
using GalaSoft.MvvmLight.Ioc;
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

            var nav = (Services.NavigationService) SimpleIoc.Default.GetInstance<INavigationService>();
            nav.Initialize(firstPage);
        }

        static ViewModelLocator _locator;

        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());

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
