using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MessagesSymulator.Models
{
    public class MessageModel
    {
        public UserInformations InformationsAboutUser { get; set; }
        public string Message { get; set; }

        private LinkComponentModel _imageLink;
        public LinkComponentModel ImageLink
        {
            get { return _imageLink; }
            set
            {
                _imageLink = value;

                ImageLinks.Clear();
                if (_imageLink?.Link != null)
                {
                    ImageLinks.Add(_imageLink);
                }
            }
        }

        public ObservableCollection<LinkComponentModel> ImageLinks { get; set; } = new ObservableCollection<LinkComponentModel>();
        public bool IsFirst { get; set; }
        public DateTime Time { get; set; }

        public string GetShortTime
        {
            get
            {
                var timeSegments = Time.GetDateTimeFormats('t');
                string x = "";
                foreach (var item in timeSegments)
                {
                    x += item;
                }
                return x;
            }
        }

        // Deserialize
        public MessageModel(SerializeObject.MessageModelSerializeObject serializeObject)
        {
            Message = serializeObject.Message;
            Time = serializeObject.Time;
            IsFirst = serializeObject.IsFirst;
            ImageLink = new LinkComponentModel(serializeObject.ImageLink);
            InformationsAboutUser = new UserInformations(serializeObject.InformationsAboutUser);
        }

        public MessageModel(string message, LinkComponentModel imageLink, DateTime time, bool isFirst)
        {
            Message = message;
            ImageLink = imageLink;
            Time = time;
            IsFirst = isFirst;
        }

        public MessageModel()
        {

        }
// todo zrobić kontrolkę chatItem i pomyśleć nad dziedziczeniem lub przekazaniem argumentów z wiadomości
    }
}
