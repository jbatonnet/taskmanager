using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using TaskManager.Common;

namespace TaskManager.Desktop
{
    public class TagColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TagColor) || targetType != typeof(Color))
                return null;

            switch ((TagColor)value)
            {
                case TagColor.Black: return Colors.Black;
                case TagColor.Gray: return Colors.Gray;
                case TagColor.White: return Colors.White;
                case TagColor.Red: return Colors.Red;
                case TagColor.Green: return Colors.ForestGreen;
                case TagColor.Blue: return Colors.Blue;
                case TagColor.Cyan: return Colors.DeepSkyBlue;
                case TagColor.Magenta: return Colors.Magenta;
                case TagColor.Yellow: return Colors.Yellow;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}