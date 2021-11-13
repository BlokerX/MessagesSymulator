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
        public LinkComponentModelSerializeObject ImageLink = new LinkComponentModelSerializeObject();
        public DateTime Time;
        public bool IsFirst;

        // Serialize
        public MessageModelSerializeObject(Models.MessageModel model) : base(model)
        {
            Message = model.Message;
            Time = model.Time;
            IsFirst = model.IsFirst;
            ImageLink = new LinkComponentModelSerializeObject(model.ImageLink);
        }

        public MessageModelSerializeObject(string message, LinkComponentModelSerializeObject imageLink,
            DateTime time, bool isFirst, UserInformationsSerializeObject userInformations) 
            : base(userInformations.Username,
            userInformations.UsernameColor,
            userInformations.ImageSource,
            userInformations.ActiveState)
        {
            Message = message;
            ImageLink = imageLink;
            Time = time;
            IsFirst = isFirst;
        }

        public MessageModelSerializeObject()
        {

        }
    }
}
