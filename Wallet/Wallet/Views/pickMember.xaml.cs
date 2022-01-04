using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pickMember : ContentPage
    {
        
        public pickMember()
        {
            InitializeComponent();
            listInit();
        }

        void listInit()
        {
            List<Member> memberList = new List<Member>();
            memberList.Add(new Member()
            {
                memberImage = "caidat_thanhvien_03.png",
                memberTitle = "Cá nhân"
            });
            memberList.Add(new Member()
            {
                memberImage = "caidat_thanhvien_10.png",
                memberTitle = "Vợ"
            });
            memberList.Add(new Member()
            {
                memberImage = "caidat_thanhvien_12.png",
                memberTitle = "Chồng"
            });
            memberList.Add(new Member()
            {
                memberImage = "caidat_thanhvien_14.png",
                memberTitle = "Con cái"
            });
            memberList.Add(new Member()
            {
                memberImage = "caidat_thanhvien_16.png",
                memberTitle = "Cha mẹ"
            });
            memberList.Add(new Member()
            {
                memberImage = "caidat_thanhvien_18.png",
                memberTitle = "Gia đình"
            });
            lstMember.ItemsSource = memberList;
        }

        private void lstMember_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Member selectedMember = e.SelectedItem as Member;
        }

        private void ImageCell_Tapped(object sender, EventArgs e)
        {
            Member tappedMember = (Member)((ListView)sender).SelectedItem;
            Navigation.PushModalAsync(new addNewPaymentPage());
        }

        private void lstMember_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}