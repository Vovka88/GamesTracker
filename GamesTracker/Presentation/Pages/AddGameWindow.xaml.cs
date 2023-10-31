using System.Windows.Controls;
namespace GamesTracker.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for AddGameWindow.xaml
    /// </summary>
    public partial class AddGameWindow : UserControl
    {
        public AddGameWindow()
        {
            InitializeComponent();
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
                    if (i % 2 != 0) teamA.Children.Add(tb);
                    else teamB.Children.Add(tb);
                    }
                }
            
        }
    }
}
