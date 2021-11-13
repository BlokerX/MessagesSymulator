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

        private string _imageName;
        public string ImageName
        {
            get { return _imageName; }
            set
            {
                _imageName = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public SendMessageWithLinkComponentPopup()
        {
            InitializeComponent();

            // Scaling Method!
            ImageElement.Width = System.Windows.SystemParameters.PrimaryScreenWidth / 10;
            ImageElement.Height = System.Windows.SystemParameters.PrimaryScreenHeight / 10;
        }

        public SendMessageWithLinkComponentPopup(string messageText, string link, string imageName) : this()
        {
            MessageText = messageText;
            Link = link;
            ImageName = imageName;
        }

        public event EventHandler<SendMessageWithLinkComponentPopupArgs> SendButtonEvent;
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var saveDirePath = Path.Combine(Directory.GetCurrentDirectory(), "LinkedImages");

            if (!Directory.Exists(saveDirePath))
                Directory.CreateDirectory(saveDirePath);

            string newLink = "";

            newLink = Path.Combine(saveDirePath, ImageName);

            var last = ImageName.LastIndexOfAny(new char[1] { '.' });
            string fileExt = "";
            if(last > 0)
            for (int j = last; j < ImageName.Length; j++)
            {
                fileExt += ImageName[j];
            }
            if (last == -1)
                last = ImageName.Length;
            string nameWithoutExt = "";
            for (int j = 0; j < last; j++)
            {
                nameWithoutExt += ImageName[j];
            }

            int i = 0;
            while (File.Exists(newLink) && newLink?.ToString() != "")
            {

                newLink = Path.Combine(saveDirePath, nameWithoutExt + "_" + (++i).ToString() + fileExt);
            }


            File.Copy(Link, newLink);
            SendButtonEvent?.Invoke(this, new SendMessageWithLinkComponentPopupArgs(MessageText, newLink));
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri(Link));
            ImageElement.Background = imageBrush;
        }
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
