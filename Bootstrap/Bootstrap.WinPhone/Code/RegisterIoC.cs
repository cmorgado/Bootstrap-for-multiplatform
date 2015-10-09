using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bootstrap.Common.Code
{
    public static class Bootstrap
    {
        public static void Run()
        {
           
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<Core.Interfaces.IPlatform, PlatformSpecific.Services.PlatformService>();
            SimpleIoc.Default.Register<MVVM.Interfaces.INavigationService, XForms.Services.NavigationService>();

        }
    }
}
