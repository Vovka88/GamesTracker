using GamesTracker;
using System.Windows.Controls;

namespace Multipage.Navigator
{
    public class NavigatorObject
    {
        public static MainWindow pageSwitcher;

        public static void Switch(UserControl newPage)
        {
            pageSwitcher?.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            pageSwitcher?.Navigate(newPage, state);
        }
    }
}
