using MessagesSymulator.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.Models
{
    public class ChatUserModel : UserInformations
    {
        public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();
        //public ContactModel SelectedContact { get; set; }

        public List<int> ContactsCanels { get; set; } = new List<int>();

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set {
                if (value != _selectedContact)
                {
                    _selectedContact = value;
                    OnPropertyChanged();
                }
            }
        }


        // Deserialize
        public ChatUserModel(SerializeObject.ChatUserModelSerializeObject serializeObject) : base(serializeObject)
        {
            foreach (var item in serializeObject.Contacts)
            {
                Contacts.Add(new ContactModel(item));
            }
            if(Contacts.Count > serializeObject.SelectedContactIndex && serializeObject.SelectedContactIndex>=0)
            SelectedContact = Contacts[serializeObject.SelectedContactIndex];
            ContactsCanels = serializeObject.ContactsCanels;
        }

        public static ref ChatUserModel GetChatUserModel(ref ChatUserModel chatUserModel)
        {
            return ref chatUserModel;
        }

        public ChatUserModel()
        {
            // Domyślne wartości
            Username = "User";
            UsernameColor = "White";
            ImageSource = "https://www.cot.pl/wp-content/uploads/2019/10/placeholder-user.png";

            // todo ładowanie kontaktów oraz informacji
            if (Contacts.Count > 0)
                SelectedContact = Contacts.First();
        }

        public ChatUserModel(UserInformations myInformations, ObservableCollection<ContactModel> contacts) 
            : base(myInformations.ID, myInformations.Username, myInformations.UsernameColor, myInformations.ImageSource, myInformations.ActiveState)
        {
            Contacts = contacts;
        }

        public ChatUserModel(UserInformations myInformations, ObservableCollection<ContactModel> contacts, ContactModel selectedContact) : this(myInformations, contacts)
        {
            SelectedContact = selectedContact;
        }

        public SerializeObject.ChatUserModelSerializeObject ToSerializeObject()
        {
            return new SerializeObject.ChatUserModelSerializeObject(this);
        }

    }
}