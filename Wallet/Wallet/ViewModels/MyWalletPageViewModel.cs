using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Runtime.CompilerServices;

namespace Wallet.ViewModels
{
    public class MyWalletPageViewModel : INotifyPropertyChanged
    {
        public IList<AccountImage> MyWalletViewModelCollector { get { return AccountData.Accounts; } }
        AccountImage selectedAccount;
        public AccountImage SelectedAccount
        {
            get { return selectedAccount; }
            set
            {
                if (SelectedAccount != value)
                {
                    selectedAccount = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler2 = PropertyChanged;
            if (handler2 != null)
            {
                handler2(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
