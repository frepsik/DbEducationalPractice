using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace EventManagement.Models.Resources
{
    internal class ConvertMessageToColorConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string message)
            {
                if (message == "Запись успешно обновлена" || message == "Данные успешно добавлены")
                {
                    return new SolidColorBrush(Color.Parse("#45adff"));
                }
                else
                {
                    return new SolidColorBrush(Colors.Red);
                }
            }
            return null;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return new Avalonia.Data.BindingNotification(value);
        }
    }
}
