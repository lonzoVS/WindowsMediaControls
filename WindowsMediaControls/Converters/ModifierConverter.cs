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
    public class ModifierConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {


            ModifierKeys modifier = ModifierKeys.None;
            var gesture = value.ToString();
            if (gesture == "")
                return modifier;
            else
            {
                gesture = gesture.ToLower();
                if (gesture.Contains("alt"))
                    modifier = ModifierKeys.Alt;
                if (gesture.Contains("shift"))
                    modifier |= ModifierKeys.Shift;
                if (gesture.Contains("ctrl") || gesture.Contains("ctl"))
                    modifier |= ModifierKeys.Control;
                return modifier;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
