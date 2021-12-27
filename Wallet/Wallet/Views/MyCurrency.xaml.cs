using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCurrency : ContentPage
    {
        public MyCurrency()
        {
            InitializeComponent();
            BindingContext = new ViewModels.MyCurrencyViewModel();
        }
    }
}