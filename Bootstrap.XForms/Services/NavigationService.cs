
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bootstrap.MVVM.Interfaces;
using Xamarin.Forms;


namespace Bootstrap.XForms.Services
{

    public class NavigationService : MVVM.Interfaces.INavigationService
    {
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private NavigationPage _navigation;

        public string CurrentPageKey
        {
            get
            {
                lock (_pagesByKey)
                {
                    if (_navigation.CurrentPage == null)
                    {
                        return null;
                    }

                    var pageType = _navigation.CurrentPage.GetType();

                    return _pagesByKey.ContainsValue(pageType)
                        ? _pagesByKey.First(p => p.Value == pageType).Key
                        : null;
                }
            }
        }

        private object _parameters;
      

        public void GoBack()
        {
            _navigation.PopAsync();
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {

           
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    var type = _pagesByKey[pageKey];


                    _parameters = parameter;
                    var constructor = type.GetTypeInfo()
                        .DeclaredConstructors
                        .FirstOrDefault();

                    var parameters = new object[]
                    {
                    };

                   

                    if (constructor == null)
                    {
                        throw new InvalidOperationException(
                            "No suitable constructor found for page " + pageKey);
                    }

                    var page = constructor.Invoke(parameters) as Page;
                    _navigation.PushAsync(page);
                }
                else
                {
                    throw new ArgumentException(
                        $"No such page: {pageKey}. Did you forget to call NavigationService.Configure?",
                        nameof(pageKey));
                }
            }
        }

        public void Configure(string pageKey, Type pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    _pagesByKey[pageKey] = pageType;
                }
                else
                {
                    _pagesByKey.Add(pageKey, pageType);
                }
            }
        }

        public void Initialize(NavigationPage navigation)
        {
            _navigation = navigation;
        }

        public void NavigateToModal(string pageKey)
        {
            throw new NotImplementedException();
        }

        public void NavigateToModal(string pageKey, object parameter)
        {
            throw new NotImplementedException();
        }

       

        object INavigationService.Parameters()
        {
            return _parameters;
        }
    }


}
