using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap.MVVM.ViewModels
{
    public class BaseWithProgress : Models.ModelBase
    {


        int loadingCounter = 0;
        public int LoadingCounter
        {
            get { return loadingCounter; }
            set
            {
                loadingCounter = value;
                if (value != loadingCounter)
                {
                    loadingCounter = value;
                    // NotifyPropertyChanged();
                }
                if (loadingCounter < 0)
                    loadingCounter = 0;

                if (loadingCounter > 0)
                {
                    IsLoading = true;
                }
                else
                {
                    IsLoading = false;
                }
            }
        }

        bool isLoading = false;
        public bool IsLoading
        {
            get { return isLoading; }
            set
            {

                isLoading = value;
                NotifyPropertyChanged();

            }
        }


      
    }
}
