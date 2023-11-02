using GamesTracker.Core.Model;
using Multipage.Navigator;
using System;
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
            
        }

        private void AddGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GameData gameData = new GameData(gamename.Text, int.Parse(players.Text), "TeamA", "TeamB");
            _matches.Add(gameData);
            NavigatorObject.Switch(new HistoryWindow(_matches));
        }

        private void pressets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //gamename.Text = pressets.Items[pressets.SelectedIndex].ToString();
            if (pressets.Items[pressets.SelectedIndex].ToString() == "System.Windows.Controls.ComboBoxItem: Dota 2")
            {
                gamename.Text = "Dota 2";
                players.Text = (10).ToString();
                match_id.IsEnabled = true;
            } 
            else if (pressets.Items[pressets.SelectedIndex].ToString() == "System.Windows.Controls.ComboBoxItem: None")
            {
                gamename.Text = string.Empty;
                players.Text = string.Empty;
                teamA.Children.Clear();
                teamB.Children.Clear();
                match_id.IsEnabled = false;
            }
        }
    }
}
