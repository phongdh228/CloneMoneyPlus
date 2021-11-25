using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TabbedPageMain();
            Database db = new Database();
            db.createDatabase();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
