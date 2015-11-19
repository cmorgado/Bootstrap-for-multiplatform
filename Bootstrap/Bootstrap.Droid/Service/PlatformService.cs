using System;
using Android.Provider;

namespace Bootstrap.PlatformSpecific.Services
{
    public class PlatformService : Core.Interfaces.IPlatform
    {
        public string AppName => "Boostrap APP";
        public string AppVersion => Xamarin.Forms.Forms.Context.PackageManager.GetPackageInfo(Xamarin.Forms.Forms.Context.PackageName, 0).VersionName;

        public string DeviceId => Settings.Secure.GetString(Xamarin.Forms.Forms.Context.ContentResolver, Settings.Secure.AndroidId);

        public string DeviceName => "[" + Android.OS.Build.Device + "]" + "[" + Android.OS.Build.Model + "]";

        public string OsName => "Android";

        public string OsVersion => Android.OS.Build.VERSION.Release;



        public string xAuthKey
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string xAuthUser
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
