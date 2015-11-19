using System;

using Bootstrap.Core.Code;
using Bootstrap.MVVM.Code;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Bootstrap.MVVM.ViewModels.Frame
{
    public class Home : BaseVM
    {


        private RelayCommand _gotoPageBCommand;
        public RelayCommand GotoPageBCommand
        {
            get
            {
                return _gotoPageBCommand ?? (_gotoPageBCommand = new RelayCommand(
             () =>
            {
                Exception ex = null;
                try
                {
                    LoadingCounter++;
                    _navigationService.NavigateTo(PagesDefinitions.SecondPage.ConvertToString(), "string parameter");

                }
                catch (Exception e)
                {

                    ex = e;
                }
                finally
                {
                    LoadingCounter--;
                }
                if (ex != null)
                {
                    //   await _messageBoxService.ShowAsync(Multilingual.Resources.error_generic_headerHeader, Constants.APP_NAME);
                }


            }));
            }

        }


        private RelayCommand _load
            ;
        public RelayCommand Load
        {
            get
            {
                return _load ?? (_load = new RelayCommand(
          () =>
            {
                Exception ex = null;
                try
                {
                    LoadingCounter++;


                }
                catch (Exception e)
                {

                    ex = e;
                }
                finally
                {
                    LoadingCounter--;
                }
                if (ex != null)
                {
                    //   await _messageBoxService.ShowAsync(Multilingual.Resources.error_generic_headerHeader, Constants.APP_NAME);
                }


            }));
            }

        }

        public Home(Interfaces.INavigationService navigation, Core.Interfaces.IPlatform platform): base(navigation, platform)
        {
            PageTitle = "Bootstraping project!";
        }

    }
}
