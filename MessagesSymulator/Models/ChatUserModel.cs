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
            if(Contacts.Count > serializeObject.SelectedContactIndex)
            SelectedContact = Contacts[serializeObject.SelectedContactIndex];

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
        {
            Username = myInformations.Username;
            UsernameColor = myInformations.UsernameColor;
            ImageSource = myInformations.ImageSource;
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