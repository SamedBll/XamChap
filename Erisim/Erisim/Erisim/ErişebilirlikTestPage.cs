using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Erisim
{
    public class ErişebilirlikTestPage : ContentPage
    {
        public ErişebilirlikTestPage()
        {
            Label testLabel = new Label
            {
                Text = "FontSize 20" + Environment.NewLine + "20 karakter arasında",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            Label displayLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            testLabel.SizeChanged += (sender, args) =>
            {
                displayLabel.Text = String.Format("{0:F0} \u00D7 {1:F0}", testLabel.Width, testLabel.Height);
            };

            Content = new StackLayout
            {
                Children =
                {
                    testLabel,
                    displayLabel
                }
            };
        }
    }
}