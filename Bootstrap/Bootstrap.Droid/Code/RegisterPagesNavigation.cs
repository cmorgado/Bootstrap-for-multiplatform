using Bootstrap.Core.Code;
using Bootstrap.MVVM.Interfaces;
using Bootstrap.XForms.Services;
using GalaSoft.MvvmLight.Ioc;

namespace Bootstrap.Droid.Code
{
    public static class RegisterPagesNavigation
    {

        public static void Run()
        {
            var nav = new NavigationService();
            nav.Configure(MVVM.Code.PagesDefinitions.HomePage.ConvertToString(), typeof(XForms.Views.Home));
            nav.Configure(MVVM.Code.PagesDefinitions.SecondPage.ConvertToString(), typeof(XForms.Views.SecondPage));


            SimpleIoc.Default.Register<INavigationService>(() => nav);

        }
    }
}
