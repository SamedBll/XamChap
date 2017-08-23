using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Boyutlar
{
    public class MetricBoxView : ContentPage
    {
        public MetricBoxView()
        {

            Content = new BoxView
            {
                Color = Color.Accent,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 64,
                HeightRequest = 160,
                
            };
        }
    }
}