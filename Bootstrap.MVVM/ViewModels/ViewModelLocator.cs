using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
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

            //nav.Configure(HomePage, typeof(Views.Home));

            SimpleIoc.Default.Register<ViewModels.Frame.Home>();
            //SimpleIoc.Default.Register<INavigationService>(() => nav);
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public ViewModels.Frame.Home Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ViewModels.Frame.Home>();
            }
        }

    }
}
