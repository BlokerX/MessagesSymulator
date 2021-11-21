using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.SerializeObject
{
    public class MessageCanelModelSerializeObject
    {
        public ObservableCollection<MessageModelSerializeObject> Messages;
        public int ID;

        // Serialize
        public MessageCanelModelSerializeObject(Models.MessageCanelModel model)
        {
            ID = model.ID;
            Messages = new ObservableCollection<MessageModelSerializeObject>();
            foreach (var item in model.Messages)
            {
                Messages.Add(new MessageModelSerializeObject(item));
            }
        }

        public MessageCanelModelSerializeObject(ObservableCollection<MessageModelSerializeObject> messages, int iD)
        {
            Messages = messages;
            ID = iD;
        }

        public MessageCanelModelSerializeObject()
        {
        }
    }
}
