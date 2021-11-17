using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logika interakcji dla klasy ImageButton.xaml
    /// </summary>
    public partial class ImageButton : UserControl
    {

        public Thickness ContainPadding { get; set; }
        public ImageSource ImageSourceNormalState { get; set; }
        public ImageSource ImageSourceMouseOver { get; set; }
        public ImageSource ImageSourceClick { get; set; }

        public event RoutedEventHandler Click;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonImage.Source = ImageSourceClick;
            Click?.Invoke(sender, e);
            //ButtonImage.Source = this?.ImageSourceNormalState.Source;
        }
    }
}
