using GamesTracker.Core.Model;
using Multipage.Navigator;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GamesTracker.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for AddGameWindow.xaml
    /// </summary>
    public partial class AddGameWindow : UserControl
    {
        List<GameData> _matches = new List<GameData>();
        public AddGameWindow(List<GameData> _matches)
        {
            InitializeComponent();
            this._matches = _matches;
        }

        private void players_TextChanged(object sender, TextChangedEventArgs e)
        {
            teamA.Children.Clear();
            teamB.Children.Clear();
            int c = 0;
            if(int.TryParse(players.Text, out c) == true) 
                {
                    for (int i = 1; i <= c; i++)
                    {
                    TextBlock tb = new TextBlock();
                    tb.Text = "Player";
                    tb.FontSize = 15;
                    tb.FontWeight = FontWeights.Regular;
                    tb.Foreground = Brushes.White;
                    if (i % 2 != 0) teamA.Children.Add(tb);
                    else teamB.Children.Add(tb);
                    }
                }
            else players.Text = (10).ToString();
            
        }

        private void AddGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GameData gameData = new GameData(gamename.Text, int.Parse(players.Text), "TeamA", "TeamB");
            _matches.Add(gameData);
            NavigatorObject.Switch(new HistoryWindow(_matches));
        }
    }
}
