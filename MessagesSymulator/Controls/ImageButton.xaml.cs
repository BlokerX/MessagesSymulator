using MessagesSymulator.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Logika interakcji dla klasy ImageButton.xaml
    /// </summary>
    public partial class ImageButton : ButtonBase
    {

        public Thickness ContainPadding { get; set; }
        public ImageSource ImageSourceNormalState { get; set; }
        public ImageSource ImageSourceMouseOver { get; set; }
        public ImageSource ImageSourceClick { get; set; }

        public ImageButton()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ButtonImage.Source = ImageSourceNormalState;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonImage.Source = ImageSourceMouseOver;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonImage.Source = ImageSourceNormalState;
        }

        private void Button_PreviewClick(object sender, RoutedEventArgs e)
        {
            ButtonImage.Source = ImageSourceClick;
        }

        private void Button_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ButtonImage.Source = ImageSourceMouseOver;
        }
    }
}
