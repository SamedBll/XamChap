﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Reflection;
using System.IO;

using Xamarin.Forms;

namespace simpbook
{
    public class AIPage : ContentPage
    {
        public AIPage()
        {
            StackLayout mainStack = new StackLayout();
            StackLayout textStack = new StackLayout
            {
                Padding = new Thickness(5),
                Spacing = 10
            };

            Assembly assembly = GetType().GetTypeInfo().Assembly;

            string resource = "simpbook.Metin.AI.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resource))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    bool gotTitle = false;
                    string line;

                    while(null != (line = reader.ReadLine()))
                    {
                        Label label = new Label
                        {
                            Text = line,
                            TextColor = Color.Black
                        };

                        if (!gotTitle)
                        {
                            label.HorizontalOptions = LayoutOptions.Center;
                            label.FontSize = Device.GetNamedSize(NamedSize.Medium, label);
                            label.FontAttributes = FontAttributes.Bold;
                            mainStack.Children.Add(label);
                            gotTitle = true;
                        }
                        else
                        {
                            textStack.Children.Add(label);
                        }
                    }
                }

            }

            ScrollView scrollView = new ScrollView
            {
                Content = textStack,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(5,0)
            };

            mainStack.Children.Add(scrollView);

            Content = mainStack;

            BackgroundColor = Color.White;

            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
        }
    }
}