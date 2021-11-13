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
    /// Logika interakcji dla klasy SendMessageWithLinkComponentPopup.xaml
    /// </summary>
    public partial class SendMessageWithLinkComponentPopup : UserControl, INotifyPropertyChanged
    {

        #region Properties

        private string _messageText;
        public string MessageText
        {
            get { return _messageText; }
            set
            {
                _messageText = value;
                OnPropertyChanged();
            }
        }

        private string _link;
        public string Link
        {
            get { return _link; }
            set
            {
                _link = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public SendMessageWithLinkComponentPopup()
        {
            InitializeComponent();

            // Scaling Method!
            ImageElement.Width = System.Windows.SystemParameters.PrimaryScreenWidth / 9;
            ImageElement.Height = System.Windows.SystemParameters.PrimaryScreenHeight / 9;
        }

        public SendMessageWithLinkComponentPopup(string messageText, string link) : this()
        {
            MessageText = messageText;
            Link = link;
        }

        public event EventHandler<SendMessageWithLinkComponentPopupArgs> SendButtonEvent;
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SendButtonEvent?.Invoke(this, new SendMessageWithLinkComponentPopupArgs(MessageText, Link));
        }

        public event RoutedEventHandler BackgroundClickEvent;
        private void BackgroundButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundClickEvent?.Invoke(this, e);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));

        }

        #endregion

    }

    public class SendMessageWithLinkComponentPopupArgs
    {
        public string MessageText;
        public string Link;

        public SendMessageWithLinkComponentPopupArgs(string messageText, string link)
        {
            MessageText = messageText;
            Link = link;
        }

        public SendMessageWithLinkComponentPopupArgs()
        {

        }
    }
}
