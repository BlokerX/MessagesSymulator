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

namespace MessagesSymulator.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void UsersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lv = (sender as ListView);

            Settings_MyAccount_Page.Visibility = Visibility.Hidden;
            Settings_FrendsSettings_Page.Visibility = Visibility.Hidden;
            Settings_UsersSettings_Page.Visibility = Visibility.Hidden;

            switch (lv.SelectedIndex)
            {
                case 0:
                    Settings_MyAccount_Page.Visibility = Visibility.Visible;
                    break;
                case 1:
                    Settings_FrendsSettings_Page.Visibility = Visibility.Visible;
                    break;
                case 2:
                    Settings_UsersSettings_Page.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }
    }
}
