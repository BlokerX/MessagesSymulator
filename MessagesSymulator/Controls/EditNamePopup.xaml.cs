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
    /// Logika interakcji dla klasy EditTextPopup.xaml
    /// </summary>
    public partial class EditTextPopup : UserControl
    {
        public EditTextPopup()
        {
            InitializeComponent();
        }

        public EditTextPopup(string title, string subtitle, string propertyName) : this()
        {
            this.TitleLabel.Content = title;
            this.SubtitleLabel.Content = subtitle;
            this.PropertyNameLabel.Content = propertyName;
        }

        public event EventHandler<string> SaveButtonEvent;
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveButtonEvent?.Invoke(this, NameTextBox.TextBoxSourceElement.Text);
        }

        public event RoutedEventHandler BackgroundClickEvent;
        private void BackgroundButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundClickEvent?.Invoke(this, e);
        }

    }

}
