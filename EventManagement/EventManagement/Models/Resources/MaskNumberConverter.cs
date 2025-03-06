using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace EventManagement.Models.Resources
{
    internal class MaskNumberConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string number)
            {
                return $"+{number}";
            }
            return string.Empty;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string number)
            {
                return number[1..]; //������ substrin, ������� � 1 ������� ������������ ��� ������ (����� +)
            }
            return string.Empty;
        }
    }
}
