using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Wallet.ViewModels
{
    internal class AnalyExpenseViewModel
    {
        List<AnalyIE> ExpenseList = new List<AnalyIE>();
        public List<AnalyIE> ListToShow = new List<AnalyIE>();
        List<Payment> payments = new List<Payment>();
        int TotalPrice = 0;

        public AnalyExpenseViewModel()
        {
            InitExpense();
            GetData();
            CountPrice();
        }

        protected virtual void OnAppearing()
        {
            GetData();
            CountPrice();
        }

        protected void InitExpense()
        {
            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend_01.png", ieTitle = "Chế độ ăn", iePrice = 0, ieColor = "#f44336" });
            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend_03.png", ieTitle = "Hàng ngày", iePrice = 0, ieColor = "#e91e63" });
            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend_05.png", ieTitle = "Giao thông", iePrice = 0, ieColor = "#9c27b0" });
            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend_07.png", ieTitle = "Xã hội", iePrice = 0, ieColor = "#673ab7" });

            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend_12.png", ieTitle = "Dân cư", iePrice = 0, ieColor = "#3f51b5" });
            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend_13.png", ieTitle = "Quà tặng", iePrice = 0, ieColor = "#2196f3" });
            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend_14.png", ieTitle = "Giao tiếp", iePrice = 0, ieColor = "#03a9f4" });
            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend_15.png", ieTitle = "Quần áo", iePrice = 0, ieColor = "#00bcd4" });

            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend_20.png", ieTitle = "Giải trí", iePrice = 0, ieColor = "#009688" });
            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend_21.png", ieTitle = "Sắc đẹp", iePrice = 0, ieColor = "#4caf50" });
            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend_22.png", ieTitle = "Y khoa", iePrice = 0, ieColor = "#8bc34a" });
            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend_23.png", ieTitle = "Thuế", iePrice = 0, ieColor = "#cddc39" });

            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend2_03.png", ieTitle = "Giáo dục", iePrice = 0, ieColor = "#ffeb3b" });
            ExpenseList.Add(new AnalyIE { ieImg = "caidat_thanhvien_14.png", ieTitle = "Trẻ em", iePrice = 0, ieColor = "#ffc107" });
            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend2_07.png", ieTitle = "Thú nuôi", iePrice = 0, ieColor = "#ff9800" });
            ExpenseList.Add(new AnalyIE { ieImg = "sachbotui_expend2_09.png", ieTitle = "Du lịch", iePrice = 0, ieColor = "#ff5722" });
        }

        async void GetData()
        {
            HttpClient http = new HttpClient();
            var chuoi = await http.GetStringAsync("http://webapimoneyplus.somee.com/api/XuLyController/GetPayment");
            payments = JsonConvert.DeserializeObject<List<Payment>>(chuoi);

        }

        void CountPrice()
        {
            foreach (AnalyIE Expense in ExpenseList)
            {
                Expense.iePrice = 0;
            }
            if (payments != null)
                foreach (Payment payment in payments)
                {
                    if (int.Parse(payment.PaymentMoney) > 0)
                    {
                        foreach (AnalyIE Expense in ExpenseList)
                        {
                            if (Expense.ieTitle == payment.PaymentTitle)
                            {
                                Expense.iePrice += int.Parse(payment.PaymentMoney);
                                break;
                            }
                        }
                    }
                }
            ListToShow.Clear();
            TotalPrice = 0;
            if (ExpenseList != null)
                foreach (AnalyIE Expense in ExpenseList)
                {
                    TotalPrice += Expense.iePrice;
                    if (Expense.iePrice != 0)
                    {
                        ListToShow.Add(Expense);
                    }
                }
            if (ListToShow != null)
                foreach (AnalyIE Expense in ListToShow)
                {
                    float price = (float)Expense.iePrice * 100 / TotalPrice;
                    if (price < 1)
                        Expense.iePercent = "0" + string.Format("{0:#.##}", price) + " %";
                    else
                        Expense.iePercent = string.Format("{0:#.##}", price) + " %";
                }
        }
    }
}
