using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addNewIncome : ContentPage
    {
        public addNewIncome()
        {
            InitializeComponent();
        }

        private void pickAccount_Clicked(object sender, EventArgs e)
        {

        }

        private void pickMember_Clicked(object sender, EventArgs e)
        {

        }

        private void pickDate_Clicked(object sender, EventArgs e)
        {

        }

        private void pickcalculationX_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber7_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber8_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber9_Clicked(object sender, EventArgs e)
        {

        }

        private void pickcaculationDivine_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber4_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber5_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber6_Clicked(object sender, EventArgs e)
        {

        }

        private void pickcalculationSubtract_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber1_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber2_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber3_Clicked(object sender, EventArgs e)
        {

        }

        private void pickcalculationAdd_Clicked(object sender, EventArgs e)
        {

        }

        private void pickcalculationPoint_Clicked(object sender, EventArgs e)
        {

        }

        private void picknumber0_Clicked(object sender, EventArgs e)
        {

        }

        private void pickDelete_Clicked(object sender, EventArgs e)
        {

        }

        private void expend_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addNewPaymentPage());
        }

        private void tranfer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addNewTranferPage());

        }
    }
}