using GalaSoft.MvvmLight.Ioc;


namespace Bootstrap.Common.Code
{
    public static class RegisterIoC
    {
        public static void Run()
        {
           
            SimpleIoc.Default.Register<GalaSoft.MvvmLight.Views.IDialogService, GalaSoft.MvvmLight.Views.DialogService>();
            SimpleIoc.Default.Register<Core.Interfaces.IPlatform, PlatformSpecific.Services.PlatformService>();
       

        }
    }
}
