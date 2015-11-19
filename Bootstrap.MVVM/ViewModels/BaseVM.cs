using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootstrap.MVVM.Interfaces;

namespace Bootstrap.MVVM.ViewModels
{
    public class BaseVM : BaseWithProgress
    {

        public readonly INavigationService _navigationService;
        public Core.Interfaces.IPlatform Platform;

        bool _internetConnection = true;
        public bool InternetConnection
        {
            get { return this._internetConnection; }
            set
            {
                if (_internetConnection == value) return;
                _internetConnection = value;
                NotifyPropertyChanged();
            }
        }


        bool _isLogged = false;
        public bool IsLogged
        {
            get { return this._isLogged; }
            set
            {
                if (_isLogged == value) return;
                _isLogged = value;
                NotifyPropertyChanged();
            }
        }





        string _pageTitle;
        public string PageTitle
        {
            get { return this._pageTitle; }
            set
            {
                if (_pageTitle == value) return;
                _pageTitle = value;
                NotifyPropertyChanged();
            }
        }

        RelayCommand _GoBack;
        public RelayCommand GoBack
        {
            get
            {
                return _GoBack ?? (_GoBack = new RelayCommand(
                     () =>
                     {
                         Exception ex = null;
                         try
                         {
                             LoadingCounter++;

                             _navigationService.GoBack();

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



        RelayCommand _Unload;
        public RelayCommand Unload
        {
            get
            {
                return _Unload ?? (_Unload = new RelayCommand(
                     () =>
                     {
                         Exception ex = null;
                         try
                         {
                             LoadingCounter++;
                             // this.BackgroundImage = string.Empty;

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

        
        public BaseVM(INavigationService navigation, Core.Interfaces.IPlatform platform

          )
        {
            _navigationService = navigation;
            Platform = platform;

        }




    }
}
