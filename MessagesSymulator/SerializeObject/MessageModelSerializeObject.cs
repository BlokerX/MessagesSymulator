using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.SerializeObject
{
    public class MessageModelSerializeObject
    {
        public string Message;
        public LinkComponentModelSerializeObject ImageLink = new LinkComponentModelSerializeObject();
        public DateTime Time;
        public bool IsFirst;
        public UserInformationsSerializeObject InformationsAboutUser;

        // Serialize
        public MessageModelSerializeObject(Models.MessageModel model) //: base(model)
        {
            Message = model.Message;
            Time = model.Time;
            IsFirst = model.IsFirst;
            ImageLink = new LinkComponentModelSerializeObject(model.ImageLink);
            InformationsAboutUser = new UserInformationsSerializeObject(model.InformationsAboutUser);
        }

        public MessageModelSerializeObject(string message, LinkComponentModelSerializeObject imageLink,
            DateTime time, bool isFirst, UserInformationsSerializeObject userInformations) 
        {
            InformationsAboutUser = userInformations;
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
