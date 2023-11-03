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
            match_id.Visibility = Visibility.Hidden;
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
                    StackPanel sp = new StackPanel();
                    sp.Orientation = Orientation.Horizontal;
                    TextBlock tb = new TextBlock();
                    tb.Text = "Player";
                    tb.FontSize = 15;
                    tb.FontWeight = FontWeights.Regular;
                    tb.Foreground = Brushes.White;
                    sp.Children.Add(tb);
                    TextBox tbx = new TextBox();
                    tbx.Text = "\t";
                    tbx.FontSize = 15;
                    tbx.FontWeight = FontWeights.Regular;
                    tbx.Foreground = Brushes.White;
                    sp.Children.Add(tbx);
                    if (i % 2 != 0) teamA.Children.Add(sp);
                    else teamB.Children.Add(sp);
                    }
                }
            
        }

        private void AddGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GameData gameData = new GameData(gamename.Text, int.Parse(players.Text), "TeamA", "TeamB");
            if (match_id.IsEnabled == true)
            {
                if(match_id.Text != string.Empty) gameData._matchId = match_id.Text;
            }
            _matches.Add(gameData);
            NavigatorObject.Switch(new HistoryWindow(_matches));
        }

        private void pressets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pressets.Items[pressets.SelectedIndex].ToString() == "System.Windows.Controls.ComboBoxItem: Dota 2")
            {
                gamename.Text = "Dota 2";
                players.Text = (10).ToString();
                match_id.IsEnabled = true;
                players.IsEnabled = false;
                match_id.Visibility = Visibility.Visible;
                teamA_Name.Visibility = Visibility.Visible;
                teamB_Name.Visibility = Visibility.Visible;
            } 
            else if (pressets.Items[pressets.SelectedIndex].ToString() == "System.Windows.Controls.ComboBoxItem: None")
            {
                gamename.Text = string.Empty;
                players.Text = string.Empty;
                teamA.Children.Clear();
                teamB.Children.Clear();
                match_id.IsEnabled = false;
                players.IsEnabled = true;
                match_id.Visibility = Visibility.Hidden;
                teamA_Name.Visibility = Visibility.Visible;
                teamB_Name.Visibility = Visibility.Visible;
            }
            else if (pressets.Items[pressets.SelectedIndex].ToString() == "System.Windows.Controls.ComboBoxItem: Battle Royale")
            {
                gamename.Text = string.Empty;
                players.Text = string.Empty;
                players.Text = (100).ToString();
                match_id.IsEnabled = false;
                players.IsEnabled = true;
                teamA.Children.Clear();
                teamB.Children.Clear();
                match_id.Visibility = Visibility.Hidden;
                teamA_Name.Visibility = Visibility.Hidden;
                teamB_Name.Visibility = Visibility.Hidden;
            }
        }
    }
}
