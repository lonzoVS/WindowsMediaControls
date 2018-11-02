using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace WindowsMediaControls.Converters
{
    public class KeyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            Key key = Key.NoName;
            var keyString = value.ToString();

            if (keyString == "")
                return key;
            else
            {
                keyString =
                keyString.ToLower().Replace("+", "")
                    .Replace("-", "")
                    .Replace("_", "")
                    .Replace(" ", "")
                    .Replace("alt", "")
                    .Replace("shift", "")
                    .Replace("ctrl", "")
                    .Replace("ctl", "");

                keyString = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(keyString);
                if (!string.IsNullOrEmpty(keyString))
                {
                    System.Windows.Input.KeyConverter k = new System.Windows.Input.KeyConverter();
                    key = (Key)k.ConvertFromString(keyString);
                }
                return key;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
