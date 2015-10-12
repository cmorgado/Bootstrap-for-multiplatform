using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap.MVVM.Models
{
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName]String propertyName = null)
        {
            var handler = PropertyChanged;
            if (null == handler) return;
            try
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
            catch
            {
                // ignored
            }
        }
    }
}
