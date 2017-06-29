using System;
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
    /// Logique d'interaction pour MultiplayerGame.xaml
    /// </summary>
    public partial class MultiplayerGame : UserControl
    {
        NumberFormatInfo NFIperformance = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
        public MultiplayerGame()
        {
            InitializeComponent();
            NFIperformance.NumberGroupSeparator = ",";
            NFIperformance.NumberDecimalSeparator = ".";
            NFIperformance.NumberDecimalDigits = 0;
        }

        [Flags]
        public enum Modifiers
        {
            None = 0,
            NF = 1,
            EZ = 2,
            NoVideo = 4,
            HD = 8,
            HR = 16,
            SD = 32,
            DT = 64,
            RX = 128,
            HT = 256,
            NC = 512, // Only set along with DoubleTime. i.e: NC only gives 576
            FL = 1024,
            Auto = 2048,
            SO = 4096,
            AP = 8192,  // Autopilot?
            PF = 16384, // Only set along with SuddenDeath. i.e: PF only gives 16416  
            Key4 = 32768,
            Key5 = 65536,
            Key6 = 131072,
            Key7 = 262144,
            Key8 = 524288,
            keyMod = Key4 | Key5 | Key6 | Key7 | Key8,
            FI = 1048576,
            Random = 2097152,
            LastMod = 4194304,
            FreeModAllowed = NF | EZ | HD | HR | SD | FL | FI | RX | AP | SO | keyMod,
            Key9 = 16777216,
            Key10 = 33554432,
            Key1 = 67108864,
            Key3 = 134217728,
            Key2 = 268435456
        }
        public enum TeamModes
        {
            HeadToHead = 0,
            TagCoop = 1,
            TeamVS = 2,
            TagTeamVS = 3
        }

        // Util methods

        private void AddModPictures(Modifiers mods)
        {
            ModIcons.Children.Clear();
            var marginLeft = 0.0;
            if (mods != Modifiers.None)
            {
                Regex regex = new Regex("([A-z0-9]{2,})");
                Debug.WriteLine(mods.ToString());
                MatchCollection matches = regex.Matches(mods.ToString());
                List<string> modsList = new List<string>();
                foreach (Match match in matches)
                {
                    modsList.Add(match.Value);
                }
                if (modsList.Contains("PF"))
                {
                    modsList.Remove("SD");
                }
                if (modsList.Contains("NC"))
                {
                    modsList.Remove("DT");
                }
                foreach (string modImage in modsList)
                {
                    BitmapImage logo = new BitmapImage();
                    logo.BeginInit();
                    logo.UriSource = new Uri($"pack://application:,,,/osu-tourney-tool;component/Assets/Mods/{modImage}.png");
                    logo.EndInit();
                    Image modPic = new Image()
                    {
                        Height = 30.0,
                        Margin = new Thickness(marginLeft,0,0,0),
                        Source = logo
                    };
                    RenderOptions.SetBitmapScalingMode(modPic, BitmapScalingMode.HighQuality);
                    ModIcons.Children.Add(modPic);
                    marginLeft = -12.0;
                }
            }
        }

        // here come the properties

        public Modifiers Mods
        {
            get { return (Modifiers)GetValue(ModsProperty); }
            set
            {
                SetValue(ModsProperty, value);
                AddModPictures(value);
            }
        }

        // Using a DependencyProperty as the backing store for Mods.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModsProperty =
            DependencyProperty.Register("Mods", typeof(Modifiers), typeof(MultiplayerGame), new PropertyMetadata(Modifiers.None));



        public List<MultiplayerScore> Scores
        {
            get { return (List<MultiplayerScore>)GetValue(ScoresProperty); }
            set
            {
                SetValue(ScoresProperty,value);
                RedTeamScore = 0;
                BlueTeamScore = 0;
                ScoresPanel.Children.Clear();
                var _scores = (List<MultiplayerScore>)GetValue(ScoresProperty);
                
                if (TeamMode == TeamModes.TeamVS || TeamMode == TeamModes.TagTeamVS)
                {
                    _scores = _scores.OrderBy(x => x.Team).ToList();
                } else {
                    _scores = _scores.OrderByDescending(x => x.Score).ToList();
                }
                SetValue(ScoresProperty, _scores);
                foreach (MultiplayerScore score in _scores)
                {
                    if (TeamMode == TeamModes.TeamVS || TeamMode == TeamModes.TagTeamVS)
                    {
                        if (score.Team == MultiplayerScore.Teams.Red && score.Pass == true)
                        {
                            RedTeamScore += score.Score;
                        }
                        else if (score.Team == MultiplayerScore.Teams.Blue && score.Pass == true)
                        {
                            BlueTeamScore += score.Score;
                        }
                    }
                    ScoresPanel.Children.Add(score);
                }
                if (TeamMode == TeamModes.TeamVS || TeamMode == TeamModes.TagTeamVS)
                {
                    
                    if (RedTeamScore > BlueTeamScore)
                    {
                        //RedTeamNameLabel.FontFamily = (FontFamily)TryFindResource("Exo2");
                        RedTeamNameLabel.FontWeight = FontWeights.Bold;
                        RedTeamScoreLabel.FontFamily = (FontFamily)TryFindResource("Venera900");

                        //BlueTeamNameLabel.FontFamily = (FontFamily)TryFindResource("Exo2");
                        BlueTeamNameLabel.FontWeight = FontWeights.Regular;
                        BlueTeamScoreLabel.FontFamily = (FontFamily)TryFindResource("Venera500");

                    }
                    else if (RedTeamScore < BlueTeamScore)
                    {
                        //RedTeamNameLabel.FontFamily = (FontFamily)TryFindResource("Exo2");
                        RedTeamNameLabel.FontWeight = FontWeights.Regular;
                        RedTeamScoreLabel.FontFamily = (FontFamily)TryFindResource("Venera500");

                        //BlueTeamNameLabel.FontFamily = (FontFamily)TryFindResource("Exo2");
                        BlueTeamNameLabel.FontWeight = FontWeights.Bold;
                        BlueTeamScoreLabel.FontFamily = (FontFamily)TryFindResource("Venera900");
                    }
                    else
                    {
                        //RedTeamNameLabel.FontFamily = (FontFamily)TryFindResource("Exo2");
                        RedTeamNameLabel.FontWeight = FontWeights.Regular;
                        RedTeamScoreLabel.FontFamily = (FontFamily)TryFindResource("Venera500");

                        //BlueTeamNameLabel.FontFamily = (FontFamily)TryFindResource("Exo2");
                        BlueTeamNameLabel.FontWeight = FontWeights.Regular;
                        BlueTeamScoreLabel.FontFamily = (FontFamily)TryFindResource("Venera500");

                    }
                }
            }
        }

        // Using a DependencyProperty as the backing store for Scores.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScoresProperty =
            DependencyProperty.Register("Scores", typeof(List<MultiplayerScore>), typeof(MultiplayerGame), new PropertyMetadata(new List<MultiplayerScore>()));



        public string SongName
        {
            get { return (string)GetValue(SongNameProperty); }
            set { SetValue(SongNameProperty, value);
                NameAndDiffLabel.Content = $"{value} [{(string)GetValue(DifficultyProperty)}]";
            }
        }

        // Using a DependencyProperty as the backing store for SongName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SongNameProperty =
            DependencyProperty.Register("SongName", typeof(string), typeof(MultiplayerGame), new PropertyMetadata("Overtime"));



        public string Difficulty
        {
            get { return (string)GetValue(DifficultyProperty); }
            set { SetValue(DifficultyProperty, value);
                NameAndDiffLabel.Content = $"{(string)GetValue(SongNameProperty)} [{value}]";
            }
        }

        // Using a DependencyProperty as the backing store for Difficulty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DifficultyProperty =
    DependencyProperty.Register("Difficulty", typeof(string), typeof(MultiplayerGame), new PropertyMetadata("Hard"));



        public string SongArtist
        {
            get { return (string)GetValue(SongArtistProperty); }
            set { SetValue(SongArtistProperty, value);
                ArtistLabel.Content = value;
            }
        }

        // Using a DependencyProperty as the backing store for SongArtist.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SongArtistProperty =
    DependencyProperty.Register("SongArtist", typeof(string), typeof(MultiplayerGame), new PropertyMetadata("Cash Cash"));



        public string CoverImage
        {
            get { return (string)GetValue(CoverImageProperty); }
            set { SetValue(CoverImageProperty, value);
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(value, UriKind.RelativeOrAbsolute);
                bi3.CacheOption = BitmapCacheOption.OnLoad;
                bi3.EndInit();
                Cover.Source = bi3;
            }
        }

        // Using a DependencyProperty as the backing store for CoverImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CoverImageProperty =
    DependencyProperty.Register("CoverImage", typeof(string), typeof(MultiplayerGame), new PropertyMetadata(""));



        // next properties: Teams! Sort by teams!

        public TeamModes TeamMode
        {
            get { return (TeamModes)GetValue(TeamModeProperty); }
            set { SetValue(TeamModeProperty, value);
                if (value == TeamModes.TagTeamVS || value == TeamModes.TeamVS)
                {
                    RedTeamScoreLabel.Visibility = Visibility.Visible;
                    RedTeamNameLabel.Visibility = Visibility.Visible;
                    BlueTeamScoreLabel.Visibility = Visibility.Visible;
                    BlueTeamNameLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    RedTeamScoreLabel.Visibility =  Visibility.Hidden;
                    RedTeamNameLabel.Visibility =   Visibility.Hidden;
                    BlueTeamScoreLabel.Visibility = Visibility.Hidden;
                    BlueTeamNameLabel.Visibility =  Visibility.Hidden;
                }
            }
        }

        // Using a DependencyProperty as the backing store for TeamMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TeamModeProperty =
    DependencyProperty.Register("TeamMode", typeof(TeamModes), typeof(MultiplayerGame), new PropertyMetadata(TeamModes.HeadToHead));



        public long BlueTeamScore
        {
            get { return (long)GetValue(BlueTeamScoreProperty); }
            set { SetValue(BlueTeamScoreProperty, value);
                BlueTeamScoreLabel.Content = value.ToString("n", NFIperformance);
            }
        }

        // Using a DependencyProperty as the backing store for BlueTeamScore.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BlueTeamScoreProperty =
            DependencyProperty.Register("BlueTeamScore", typeof(long), typeof(MultiplayerGame), new PropertyMetadata((long)0));



        public long RedTeamScore
        {
            get { return (long)GetValue(RedTeamScoreProperty); }
            set { SetValue(RedTeamScoreProperty, value);
                RedTeamScoreLabel.Content = value.ToString("n", NFIperformance);
            }
        }

        // Using a DependencyProperty as the backing store for RedTeamScore.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RedTeamScoreProperty =
            DependencyProperty.Register("RedTeamScore", typeof(long), typeof(MultiplayerGame), new PropertyMetadata((long)0));


        // TODO: 
        // Custom team labels



        public string RedTeamName
        {
            get { return (string)GetValue(RedTeamNameProperty); }
            set { SetValue(RedTeamNameProperty, value);
                RedTeamNameLabel.Content = value;
            }
        }

        // Using a DependencyProperty as the backing store for RedTeamName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RedTeamNameProperty =
            DependencyProperty.Register("RedTeamName", typeof(string), typeof(MultiplayerGame), new PropertyMetadata("Red"));



        public string BlueTeamName
        {
            get { return (string)GetValue(BlueTeamNameProperty); }
            set { SetValue(BlueTeamNameProperty, value);
                BlueTeamNameLabel.Content = value;
            }
        }

        // Using a DependencyProperty as the backing store for BlueTeamName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BlueTeamNameProperty =
            DependencyProperty.Register("BlueTeamName", typeof(string), typeof(MultiplayerGame), new PropertyMetadata("Blue"));





    }
}
