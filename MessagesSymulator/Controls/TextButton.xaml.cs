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
    /// Logika interakcji dla klasy TextButton.xaml
    /// </summary>
    public partial class TextButton : Button
    {
        public Brush MouseOverColor { get; set; }
        public Brush BackgroundColor { get; set; }
        //TODO public Brush ClickColor { get; set; }

        public TextButton()
        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Background = MouseOverColor;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Background = BackgroundColor;
        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            BackgroundColor = Background;
        }

    }
}
