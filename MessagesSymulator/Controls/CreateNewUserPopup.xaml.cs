using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Logika interakcji dla klasy CreateNewUserPopup.xaml
    /// </summary>
    public partial class CreateNewUserPopup : UserControl
    {
        public CreateNewUserPopup()
        {
            InitializeComponent();
            UsernameTextBox.TextBoxSourceElement.Text = "NewUser";
            UsernameColorTextBox.TextBoxSourceElement.Text = "White";
        }

        public event EventHandler SaveButtonEvent;
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(UsernameTextBox.TextBoxSourceElement.Text != null && UsernameTextBox.TextBoxSourceElement.Text != "" && (ImageSourceLabel.Content.ToString() == "-" || File.Exists(ImageSourceLabel.Content.ToString())))
            SaveButtonEvent?.Invoke(this, e);
        }

        public event RoutedEventHandler BackgroundClickEvent;
        private void BackgroundButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundClickEvent?.Invoke(this, e);
        }


        private void TextButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog()
            {
                Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif"
                //todo filtrowanie zdjęć + "|All Files|*.*"
            };
            if ((bool)fileDialog.ShowDialog())
            {
                this.ImageSourceLabel.Content = fileDialog.FileName;
            }
        }
    }
}
