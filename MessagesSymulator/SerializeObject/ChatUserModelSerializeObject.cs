using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.SerializeObject
{
    public class ChatUserModelSerializeObject : UserInformationsSerializeObject
    {
        public ObservableCollection<ContactModelSerializeObject> Contacts = new ObservableCollection<ContactModelSerializeObject>();
        public int SelectedContactIndex;
        public List<int> ContactsCanels;

        // Serialize
        public ChatUserModelSerializeObject(Models.ChatUserModel model) : base(model)
        {
            foreach (var item in model.Contacts)
            {
                Contacts.Add(new ContactModelSerializeObject(item));
            }
            SelectedContactIndex = model.Contacts.IndexOf(model.SelectedContact);
            ContactsCanels = model.ContactsCanels;
        }

        public ChatUserModelSerializeObject(ObservableCollection<ContactModelSerializeObject> contacts,
            int selectedContact, UserInformationsSerializeObject userInformations)
            : base(userInformations.ID, userInformations.Username,userInformations.UsernameColor,userInformations.ImageSource,userInformations.ActiveState)
        {
            Contacts = contacts;
            SelectedContactIndex = selectedContact;
        }

        public ChatUserModelSerializeObject()
        {

        }
    }
}
