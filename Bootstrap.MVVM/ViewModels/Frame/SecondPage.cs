using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Bootstrap.MVVM.ViewModels.Frame
{
    public class SecondPage : BaseVM
    {


        private string _receivedMessage;
        public string ReceivedMessage
        {
            get { return this._receivedMessage; }
            set
            {
                if (_receivedMessage == value) return;
                _receivedMessage = value;
                NotifyPropertyChanged();

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
                  ReceivedMessage = _navigationService.Parameters().ToString();

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

        public SecondPage(Interfaces.INavigationService navigation, Core.Interfaces.IPlatform platform)
            : base(navigation, platform)
        {
            PageTitle = "SecondPage!!!";
        }
    }
}
