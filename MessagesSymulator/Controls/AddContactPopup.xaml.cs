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

namespace MessagesSymulator.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy AddContactPopup.xaml
    /// </summary>
    public partial class AddContactPopup : UserControl
    {
        public AddContactPopup()
        {
            InitializeComponent();
        }

        public event EventHandler AddButtonEvent;
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(UserList.SelectedItem != null)
            AddButtonEvent?.Invoke(this, e);
        }

        public event RoutedEventHandler BackgroundClickEvent;
        private void BackgroundButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundClickEvent?.Invoke(this, e);
        }

    }
}
