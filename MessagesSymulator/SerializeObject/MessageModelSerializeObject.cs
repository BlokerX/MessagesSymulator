using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.SerializeObject
{
    public class MessageModelSerializeObject : UserInformationsSerializeObject
    {
        public string Message;
        public List<LinkComponentModelSerializeObject> ImageLinks = new List<LinkComponentModelSerializeObject>();
        public DateTime Time;
        public bool IsFirst;

        // Serialize
        public MessageModelSerializeObject(Models.MessageModel model) : base(model)
        {
            Message = model.Message;
            Time = model.Time;
            IsFirst = model.IsFirst;
            foreach (var item in model.ImageLinks)
            {
                ImageLinks.Add(new LinkComponentModelSerializeObject(item));
            }
        }

        public MessageModelSerializeObject(string message, List<LinkComponentModelSerializeObject> imageLinks,
            DateTime time, bool isFirst, UserInformationsSerializeObject userInformations) 
            : base(userInformations.Username,
            userInformations.UsernameColor,
            userInformations.ImageSource,
            userInformations.ActiveState)
        {
            Message = message;
            ImageLinks = imageLinks;
            Time = time;
            IsFirst = isFirst;
        }

        public MessageModelSerializeObject()
        {

        }
    }
}
