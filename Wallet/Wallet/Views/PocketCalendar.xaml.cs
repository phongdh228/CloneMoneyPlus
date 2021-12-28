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
    public partial class PocketCalendar : ContentPage
    {
        public PocketCalendar()
        {
            InitializeComponent();
        }

        private void lstPayment_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void billButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Pocketbook());
        }
    }
}