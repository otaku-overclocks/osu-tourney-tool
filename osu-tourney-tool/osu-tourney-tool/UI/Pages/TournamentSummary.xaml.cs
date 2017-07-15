using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using osu_tourney_tool.Models;



// to do:
// 1) design
// 1.1) do the content, the top is done <-- Done
// 2) propdps for the interesting fields
// 3) make the constructor with argument fill in the data

namespace osu_tourney_tool.UI.Pages
{
    /// <summary>
    /// Logique d'interaction pour TournamentSummary.xaml
    /// </summary>
    public partial class TournamentSummary
    {
        public TournamentSummary()
        {
            InitializeComponent();
        }

        public TournamentSummary(Tournament tourney)
        {
            InitializeComponent();
            // fill in the fields with the object
        }
    }
}
