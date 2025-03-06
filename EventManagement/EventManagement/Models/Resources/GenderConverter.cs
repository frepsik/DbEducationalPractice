using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace EventManagement.Models.Resources
{
    internal class GenderConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string gender)
            {
                return gender switch
                {
                    "�"=>"�������",
                    "�"=>"�������",
                    _=>"��� ����"
                };
            }
            return "��� ����";
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string gender)
            {
                return gender switch
                {
                    "�������" => "�",
                    "�������" => "�",
                    _ => "��� ����"
                };
            }
            return "��� ����";
        }
    }
}
