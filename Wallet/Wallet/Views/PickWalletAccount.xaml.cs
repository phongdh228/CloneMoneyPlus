﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wallet.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickWalletAccount : ContentPage
    {
        WalletInfo wallet;
        public PickWalletAccount()
        {
            InitializeComponent();
            HienThiWallet();
        }
        async void HienThiWallet()
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/LayWallet");
            var dswallet = JsonConvert.DeserializeObject<List<WalletInfo>>(chuoi);
            lstWallet.ItemsSource = dswallet;
        }

        private void lstWallet_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            WalletInfo selectedWallet = e.SelectedItem as WalletInfo;
            Navigation.PushAsync(new addNewPaymentPage(selectedWallet));
        }

        private void editButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManageAccount());
        }
    }
}