using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.Models
{
    public class MessageModel : UserInformations
    {
        public string Message { get; set; }
        public List<LinkComponentModel> ImageLinks { get; set; } = new List<LinkComponentModel>();
        public DateTime Time { get; set; }
        public bool IsFirst { get; set; }

        // Deserialize
        public MessageModel(SerializeObject.MessageModelSerializeObject serializeObject) : base(serializeObject)
        {
            Message = serializeObject.Message;
            Time = serializeObject.Time;
            IsFirst = serializeObject.IsFirst;
            foreach (var item in serializeObject.ImageLinks)
            {
                ImageLinks.Add(new LinkComponentModel(item));
            }
        }

        public MessageModel(string message, List<LinkComponentModel> imageLinks, DateTime time, bool isFirst)
        {
            Message = message;
            ImageLinks = imageLinks;
            Time = time;
            IsFirst = isFirst;
        }

        public MessageModel()
        {

        }
    }
}
