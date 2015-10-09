using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap.MVVM.ViewModels
{
    public class BaseVM : BaseWithProgress
    {

        public GalaSoft.MvvmLight.Views.INavigationService _navigationService;
        public Core.Interfaces.IPlatform _platform;

        bool _InternetConnection = true;
        public bool InternetConnection
        {
            get { return this._InternetConnection; }
            set
            {
                if (_InternetConnection != value)
                {
                    _InternetConnection = value;
                    NotifyPropertyChanged();
                }
            }
        }


        bool _IsLogged = false;
        public bool IsLogged
        {
            get { return this._IsLogged; }
            set
            {
                if (_IsLogged != value)
                {
                    _IsLogged = value;
                    NotifyPropertyChanged();
                }
            }
        }





        string _PageTitle;
        public string PageTitle
        {
            get { return this._PageTitle; }
            set
            {
                if (_PageTitle != value)
                {
                    _PageTitle = value;
                    NotifyPropertyChanged();
                }
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


        public BaseVM()
        {

        }




        public BaseVM(GalaSoft.MvvmLight.Views.INavigationService navigation, Core.Interfaces.IPlatform platform

          )
        {
            _navigationService = navigation;
            _platform = platform;

        }




    }
}
