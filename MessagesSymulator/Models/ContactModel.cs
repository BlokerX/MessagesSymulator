using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.Models
{
    public class ContactModel
    {
        public ObservableCollection<MessageModel> Messages { get; } = new ObservableCollection<MessageModel> ();
        public bool IsFirstMy { get; set; } = true;

        public UserInformations InformationsAboutUser { get; set; }

        // Deserialize
        public ContactModel(SerializeObject.ContactModelSerializeObject serializeObject)
        {
            IsFirstMy = serializeObject.IsFirstMy;
            Messages = new ObservableCollection<MessageModel>();
            //foreach (var item in serializeObject.Messages)
            //{
            //    Messages.Add(new MessageModel(item));
            //}
        }

        public ContactModel(ref ObservableCollection<MessageModel> messages, bool isFirstMy)
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
                if (Messages?.Count > 0) { return Messages.Last().Message; }
                else return null;
            }
        }
    }
}
