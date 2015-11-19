using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Bootstrap.MVVM.ViewModels
{
    public class ViewModelLocator
    {

        //public const string HomePage = "HomePage";
        //public Services.NavigationService nav = new Services.NavigationService();
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<Frame.Home>();
            SimpleIoc.Default.Register<Frame.SecondPage>();

        }


        public Frame.Home Home => ServiceLocator.Current.GetInstance<Frame.Home>();
        public Frame.SecondPage SecondPage => ServiceLocator.Current.GetInstance<Frame.SecondPage>();
    }
}
