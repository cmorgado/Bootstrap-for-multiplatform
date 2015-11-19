using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap.MVVM.Interfaces
{
    public interface INavigationService : GalaSoft.MvvmLight.Views.INavigationService
    {
        void NavigateToModal(string pageKey);
        void NavigateToModal(string pageKey, object parameter);

        object Parameters();



    }
}
