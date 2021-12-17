﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewWalletPage : ContentPage
    {
        WalletInfo wallet;
        public string icon { get; set; }
        
        public AddNewWalletPage()
        {
            InitializeComponent();
            BindingContext = new MyWalletPageViewModel();
        }
        public AddNewWalletPage(string str)
        {
            InitializeComponent();
            icon = str;
            this.BindingContext = this;
        }
        public AddNewWalletPage(Account account)
        {
            InitializeComponent();
            Title = "Tạo nên "+ account.accountName;
        }

        private void completeButton_Clicked(object sender, EventArgs e)
        {
            WalletInfo newWallet = new WalletInfo();
            newWallet.walletName = walletName.Text;
            newWallet.walletImg = icon;
            newWallet.walletPrice = Int32.Parse(walletPrice.Text);
            newWallet.walletCurrency = walletCurrency.Text;
            newWallet.walletNote = edtNote.Text;


            Database db = new Database();
    
                if (db.AddNewWallet(newWallet))
                {
                    DisplayAlert("Thông báo", "Thêm ví thành công", null, "OK");
                    Navigation.PushAsync(new ManageAccount());
                }
                else
                {
                    DisplayAlert("Thông báo", "Thêm ví thất bại", null, "OK");
                }

            
           
        }

        private void pickIcon_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addNewIcon());
        }
    }
}