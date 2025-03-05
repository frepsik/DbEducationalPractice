using System;
using System.Globalization;
using System.Reflection;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace EventManagement.Models.Resources
{
    internal class ImageConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Uri uri;
            if (value is string pathToImage)
            {      
                string firstLetter = pathToImage.Substring(0, 1);

                if (firstLetter == "p" || firstLetter == "j" || firstLetter == "m" || firstLetter == "o")
                {
                    uri = new Uri($"avares://{assemblyName}/Assets/{pathToImage}");
                }
                else if (pathToImage == string.Empty)
                {
                    uri = new Uri($"avares://{assemblyName}/stub.png");
                }
                else
                {
                    uri = new Uri($"avares://{assemblyName}/Assets/events/{pathToImage}");
                }                
                return new Bitmap(AssetLoader.Open(uri));
            }
            else
            {
                uri = new Uri($"avares://{assemblyName}/Assets/stub.png");
                return new Bitmap(AssetLoader.Open(uri));
            }
        }

        //Не задействуется
        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return new Avalonia.Data.BindingNotification(value);
        }
    }
}
