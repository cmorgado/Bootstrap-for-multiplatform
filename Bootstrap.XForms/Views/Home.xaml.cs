using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Bootstrap.XForms.Views
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();

            BindingContext = App.Locator.Home;
        }
    }
}
