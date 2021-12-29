using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPageMain : Xamarin.Forms.TabbedPage
    {
        public TabbedPageMain()
        {
            InitializeComponent();
    
        }


    }
}