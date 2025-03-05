using Avalonia.Media.Imaging;
using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media.TextFormatting;

namespace EventManagement.Models.Captcha
{
    internal class CaptchaGenereate
    {
        Random random = new Random();

        /// <summary>
        /// Метод предназначенный для генерации текста капчи
        /// </summary>
        /// <returns></returns>
        public string GenerateCaptchaText()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYabcdefghijklmnopqrstuvwxyzZ0123456789";
            return new string(Enumerable.Repeat(chars, 4)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        /// <summary>
        /// Генерация картинки капчи
        /// </summary>
        /// <returns></returns>
        public Bitmap GenerateCaptchaImage(string captchaText)        {
            
            int width = 120, height = 50;

            var renderTarget = new RenderTargetBitmap(new PixelSize(width, height), new Vector(96, 96));

            using (var ctx = renderTarget.CreateDrawingContext())
            {
                // Фон
                ctx.FillRectangle(Brushes.White, new Rect(0, 0, width, height));

                // Добавляем шум (линии)
                for (int i = 0; i < 15; i++)
                {
                    ctx.DrawLine(new Pen(Brushes.Gray, 1.5),
                        new Point(random.Next(width), random.Next(height)),
                        new Point(random.Next(width), random.Next(height)));
                }

                // Настройки шрифта
                Typeface typeface = new Typeface("Arial");
                double fontSize = 24;
                var textBrush = Brushes.Black;
                var textGeometry = new TextLayout(captchaText, typeface, fontSize, textBrush);

                // Центрирование текста
                var textWidth = textGeometry.Width;
                var textHeight = textGeometry.Height;
                var textPosition = new Point((width - textWidth) / 2, (height - textHeight) / 2);

                // Отрисовка текста
                textGeometry.Draw(ctx, textPosition);
            }

            return renderTarget;
        }

    }
}
