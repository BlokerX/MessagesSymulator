using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.Models
{
    public class ContactModel : UserInformations
    {
        public ObservableCollection<MessageModel> Messages { get; set; } = new ObservableCollection<MessageModel>();
        public bool IsFirstMy { get; set; } = true;

        // Deserialize
        public ContactModel(SerializeObject.ContactModelSerializeObject serializeObject) : base(serializeObject)
        {
            IsFirstMy = serializeObject.IsFirstMy;
            foreach (var item in serializeObject.Messages)
            {
                Messages.Add(new MessageModel(item));
            }
        }

        public ContactModel(ObservableCollection<MessageModel> messages, bool isFirstMy)
        {
            Messages = messages;
            IsFirstMy = isFirstMy;
        }

        public ContactModel()
        {

        }

        public string LastMessage
        {
            get
            {
                if (Messages.Count > 0) { return Messages.Last().Message; }
                else return null;
            }
        }
    }
}
