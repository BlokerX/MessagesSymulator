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
    /// Logika interakcji dla klasy ImageButton.xaml
    /// </summary>
    public partial class ImageButton : Button
    {
        private ImageSource _buttonImage;

        public ImageSource ButtonImage
        {
            get { return _buttonImage; }
            set { _buttonImage = value; }
        }

        public ImageSource ClickImage { get; set; }
        public ImageSource MouseOverImage { get; set; }
        public ImageSource ImageNormalState { get; set; }
        public ImageButton()
        {
            InitializeComponent();

        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonImage = MouseOverImage;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonImage = ImageNormalState;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonImage = ClickImage;
        }
    }
}
