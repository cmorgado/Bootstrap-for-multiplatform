﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Bootstrap.Common.Code;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Bootstrap.Droid
{
    [Activity(Label = "Bootstrap", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);



            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            Code.RegisterPagesNavigation.Run();

            RegisterIoC.Run();
            Xamarin.Forms.Forms.Init(this, bundle);


            LoadApplication(new XForms.App());


        }
    }
}

