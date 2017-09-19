using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Clock
{
    public class FitClock : ContentPage
    {
        public FitClock()
        {
            Label clocklabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            Content = clocklabel;

            SizeChanged += (object sender, EventArgs args) =>
            {
                if (this.Width > 0)
                {
                    clocklabel.FontSize = this.Width / 6;
                }
            };

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                clocklabel.Text = DateTime.Now.ToString("h:mm:ss tt");
                return true;
            });
                
        }
    }
}