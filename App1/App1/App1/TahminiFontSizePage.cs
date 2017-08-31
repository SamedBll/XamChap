using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public class TahminiFontSizePage : ContentPage
    {
        Label label;
        public TahminiFontSizePage()
        {
            label = new Label();
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            ContentView contentView = new ContentView
            {
                Content = label
            };
            contentView.SizeChanged += OnContentViewSizeChanged;
            Content = contentView;
        }
        void OnContentViewSizeChanged(object sender, EventArgs args)
        {
            string text =
                 "S font boyutuna sahip varsayılan bir sistem fontu yaklaşık ({0:F1} * S) bir satır yüksekliğine " +
                 "ve yaklaşık ({1:F1} * S) bir ortalama karakter genişliğine sahiptir." +
                 " Genişliği {2:F0} ve yüksekliği {3:F0} olan bu sayfada ?1 olan bir yazı tipi boyutu, " +
                 "bu paragraftaki ??2 karakteri, ?3 satır ve yaklaşık satır başına ?4 karakterle rahatça oluşturmalıdır. " +
                 "Çalışıyor mu?";


            // Boyutu değişen View’u Al.
            View view = (View)sender;
            // Yazı tipi boyutunun katları olarak iki değer tanımlar.
            double lineHeight = Device.OnPlatform(1.2, 1.2, 1.3);
            double charWidth = 0.5;
            // Text format ve karakter uzunluğunu elde edin.
            text = String.Format(text, lineHeight, charWidth, view.Width, view.Height);
            int charCount = text.Length;
            // Çünkü:
            // lineCount = view.Height / (lineHeight * fontSize)
            // charsPerLine = view.Width / (charWidth * fontSize)
            // charCount = lineCount * charsPerLine
            // Bu nedenle, fontSize için çözüm:
            int fontSize = (int)Math.Sqrt(view.Width * view.Height /
            (charCount * lineHeight * charWidth));
            // Şimdi bu değerler hesaplanabilir.
            int lineCount = (int)(view.Height / (lineHeight * fontSize));
            int charsPerLine = (int)(view.Width / (charWidth * fontSize));
            // Yer tutucularını (placeholder) değerlerle değiştirin.
            text = text.Replace("?1", fontSize.ToString());
            text = text.Replace("??2", charCount.ToString());
            text = text.Replace("?3", lineCount.ToString());
            text = text.Replace("?4", charsPerLine.ToString());
            // Label özelliklerini ayarlayın.
            label.Text = text;
            label.FontSize = fontSize;
        }
    }

}