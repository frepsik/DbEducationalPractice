using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace EventManagement.Models.Resources
{
    internal class BoolToPasswordCharConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool isVisible && isVisible)
            {
                return '\0'; //��������, ��� ������ ����� ��� �����, ������� �
            }
            return '�'; //������ ��� ����� ������
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return new Avalonia.Data.BindingNotification(value);
        }
    }
}
