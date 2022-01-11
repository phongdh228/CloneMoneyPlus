using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet
{
    public class DateConverter
    {
        public object Convert(object value, Type targetType, object parameter)
        {
            DateTime date = (DateTime)value;
            if (date.Equals(DateTime.Today))
            {
                return "Today";
            }
            return date.Day.ToString().PadLeft(2, '0') + @"/" + date.Month.ToString().PadLeft(2, '0') + "-" + date.Year;
        }
    }
}
