﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace osu_tourney_tool.UI.Controls
{
    /// <summary>
    /// Logique d'interaction pour MultiplayerScore.xaml
    /// </summary>
    public partial class MultiplayerScore : UserControl
    {
        private readonly NumberFormatInfo _nfIperformance = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
        public MultiplayerScore()
        {
            InitializeComponent();
            // NumberFormatInfo for PPs
            _nfIperformance.NumberGroupSeparator = ",";
            _nfIperformance.NumberDecimalSeparator = ".";
            _nfIperformance.NumberDecimalDigits = 0;
        }


        [Flags]
        public enum Modifiers
        {
            None = 0,
            NoFail = 1,
            Easy = 2,
            NoVideo = 4,
            Hidden = 8,
            HardRock = 16,
            SuddenDeath = 32,
            DoubleTime = 64,
            Relax = 128,
            HalfTime = 256,
            Nightcore = 512, // Only set along with DoubleTime. i.e: Nightcore only gives 576
            Flashlight = 1024,
            Auto = 2048,
            SpunOut = 4096,
            AutoPilot = 8192,  // Autopilot?
            Perfect = 16384, // Only set along with SuddenDeath. i.e: Perfect only gives 16416  
            Key4 = 32768,
            Key5 = 65536,
            Key6 = 131072,
            Key7 = 262144,
            Key8 = 524288,
            KeyMod = Key4 | Key5 | Key6 | Key7 | Key8,
            FadeIn = 1048576,
            Random = 2097152,
            LastMod = 4194304,
            FreeModAllowed = NoFail | Easy | Hidden | HardRock | SuddenDeath | Flashlight | FadeIn | Relax | AutoPilot | SpunOut | KeyMod,
            Key9 = 16777216,
            Key10 = 33554432,
            Key1 = 67108864,
            Key3 = 134217728,
            Key2 = 268435456
        }
        public enum Teams
        {
            FreeForAll = 0,
            Blue = 1,
            Red = 2
        }

        // Util methods
        private void AddModPictures(Modifiers mods)
        {
            ModIcons.Children.Clear();
            var marginLeft = 0.0;
            if (mods != Modifiers.None)
            {
                var regex = new Regex("([A-z]{2,})");
                Debug.WriteLine(mods.ToString());
                var matches = regex.Matches(mods.ToString());
                var modsList = new List<string>();
                foreach (Match match in matches)
                {
                    modsList.Add(match.Value);
                }
                if (modsList.Contains("Perfect"))
                {
                    modsList.Remove("SuddenDeath");
                }
                if (modsList.Contains("Nightcore"))
                {
                    modsList.Remove("DoubleTime");
                }
                foreach (var modImage in modsList)
                {
                    var logo = new BitmapImage();
                    logo.BeginInit();
                    logo.UriSource = new Uri($"pack://application:,,,/osu-tourney-tool;component/Assets/Mods/{modImage}.png");
                    logo.EndInit();
                    var modPic = new Image()
                    {
                        Height = 18.0,
                        Margin = new Thickness(marginLeft,0,0,0),
                        Source = logo
                    };
                    RenderOptions.SetBitmapScalingMode(modPic, BitmapScalingMode.HighQuality);
                    ModIcons.Children.Add(modPic);
                    marginLeft = -8.0; 
                }
            }
        }



        // DependencyProperties
        
        public Modifiers Mods
        {
            get => (Modifiers)GetValue(ModsProperty);
            set { SetValue(ModsProperty, value);
                AddModPictures(value);
            }
        }
        
        // Using a DependencyProperty as the backing store for Mods.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModsProperty =
            DependencyProperty.Register("Mods", typeof(Modifiers), typeof(MultiplayerScore), new PropertyMetadata(Modifiers.None));
        


        public string Username
        {
            get => (string)GetValue(UsernameProperty);
            set { SetValue(UsernameProperty, value);
                UsernameLabel.Content = value;
            }
        }

        // Using a DependencyProperty as the backing store for Username.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UsernameProperty =
            DependencyProperty.Register("Username", typeof(string), typeof(MultiplayerScore), new PropertyMetadata("peppy"));

        public double Accuracy
        {
            get => (double)GetValue(AccuracyProperty);
            set { SetValue(AccuracyProperty, value);
                AccLabel.Content = Math.Round(value, 2) + "%";
            }
        }

        // Using a DependencyProperty as the backing store for Accuracy.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccuracyProperty =
            DependencyProperty.Register("Accuracy", typeof(double), typeof(MultiplayerScore), new PropertyMetadata(100.00));



        public int MaxCombo
        {
            get => (int)GetValue(MaxComboProperty);
            set { SetValue(MaxComboProperty, value);
                ComboLabel.Content = value + "x";
            }
        }

        // Using a DependencyProperty as the backing store for MaxCombo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxComboProperty =
            DependencyProperty.Register("MaxCombo", typeof(int), typeof(MultiplayerScore), new PropertyMetadata(1337));



        public int Count300
        {
            get => (int)GetValue(Count300Property);
            set { SetValue(Count300Property, value);
                Count300Label.Content = value;
            }
        }

        // Using a DependencyProperty as the backing store for Count300.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Count300Property =
            DependencyProperty.Register("Count300", typeof(int), typeof(MultiplayerScore), new PropertyMetadata(1337));



        public int Count100
        {
            get => (int)GetValue(Count100Property);
            set { SetValue(Count100Property, value);
                Count100Label.Content = value;
            }
        }

        // Using a DependencyProperty as the backing store for Count100.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Count100Property =
            DependencyProperty.Register("Count100", typeof(int), typeof(MultiplayerScore), new PropertyMetadata(0));



        public int Count50
        {
            get => (int)GetValue(Count50Property);
            set { SetValue(Count50Property, value);
                Count50Label.Content = value;
            }
        }

        // Using a DependencyProperty as the backing store for Count50.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Count50Property =
            DependencyProperty.Register("Count50", typeof(int), typeof(MultiplayerScore), new PropertyMetadata(0));



        public int CountMiss
        {
            get => (int)GetValue(CountMissProperty);
            set { SetValue(CountMissProperty, value);
                CountMissLabel.Content = value;
            }
        }

        // Using a DependencyProperty as the backing store for CountMiss.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountMissProperty =
            DependencyProperty.Register("CountMiss", typeof(int), typeof(MultiplayerScore), new PropertyMetadata(0));



        public long Score
        {
            get => (long)GetValue(ScoreProperty);
            set { SetValue(ScoreProperty, value);
                ScoreLabel.Content = value.ToString("n",_nfIperformance);
            }
        }

        // Using a DependencyProperty as the backing store for Score.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScoreProperty =
            DependencyProperty.Register("Score", typeof(long), typeof(MultiplayerScore), new PropertyMetadata((long)13376969));

        
        public Teams Team
        {
            get => (Teams)GetValue(TeamProperty);
            set
            {
                SetValue(TeamProperty, value);
                switch (value)
                {
                    case Teams.FreeForAll:
                        triangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#ef6da7");
                        break;
                    case Teams.Blue:
                        triangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#2287a4");
                        break;
                    case Teams.Red:
                        triangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#ba1d7b");
                        break;
                }
            }
        }

        // Using a DependencyProperty as the backing store for Team.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TeamProperty =
            DependencyProperty.Register("Team", typeof(Teams), typeof(MultiplayerScore), new PropertyMetadata(Teams.FreeForAll));



        public string Country
        {
            get => (string)GetValue(CountryProperty);
            set { SetValue(CountryProperty, value);
                try
                {
                    var logo = new BitmapImage();
                    logo.BeginInit();
                    logo.UriSource = new Uri($"pack://application:,,,/osu-tourney-tool;component/Assets/Flags/{value}.png");
                    logo.EndInit();
                    CountryImage.Source = logo;
                }
                catch (Exception)
                {
                    var logo = new BitmapImage();
                    logo.BeginInit();
                    logo.UriSource = new Uri("pack://application:,,,/osu-tourney-tool;component/Assets/Flags/unknown.png");
                    logo.EndInit();
                    CountryImage.Source = logo;
                }
            }
        }

        // Using a DependencyProperty as the backing store for Country.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountryProperty =
            DependencyProperty.Register("Country", typeof(string), typeof(MultiplayerScore), new PropertyMetadata(""));



        public bool Pass
        {
            get => (bool)GetValue(PassProperty);
            set
            {
                SetValue(PassProperty, value);
                FailedLabel.Visibility = value ? Visibility.Hidden : Visibility.Visible;
            }
        }

        // Using a DependencyProperty as the backing store for Pass.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PassProperty =
    DependencyProperty.Register("Pass", typeof(bool), typeof(MultiplayerScore), new PropertyMetadata(true));


    }
}
