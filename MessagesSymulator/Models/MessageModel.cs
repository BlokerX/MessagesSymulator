using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.Models
{
    public class MessageModel : UserInformations
    {
        public string Message { get; set; }

        private LinkComponentModel _imageLink = new LinkComponentModel();
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
        public MessageModel(SerializeObject.MessageModelSerializeObject serializeObject) : base(serializeObject)
        {
            Message = serializeObject.Message;
            Time = serializeObject.Time;
            IsFirst = serializeObject.IsFirst;
            ImageLink = new LinkComponentModel(serializeObject.ImageLink);

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
    }
}
