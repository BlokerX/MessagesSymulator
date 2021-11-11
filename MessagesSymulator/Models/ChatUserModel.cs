using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.Models
{
    public class ChatUserModel
    {
        public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();
        public ContactModel SelectedContact { get; set; }
        public UserInformations MyInformations { get; set; } = new UserInformations()
        {
            Username = "User",
            UsernameColor = "White",
            ImageSource = "https://www.cot.pl/wp-content/uploads/2019/10/placeholder-user.png"
        };

        public ChatUserModel()
        {
            // todo ładowanie kontaktów oraz informacji
            if (Contacts.Count > 0)
                SelectedContact = Contacts.First();
        }

        public ChatUserModel(UserInformations myInformations, ObservableCollection<ContactModel> contacts)
        {
            MyInformations = myInformations;
            Contacts = contacts;
        }

        public ChatUserModel(UserInformations myInformations, ObservableCollection<ContactModel> contacts, ContactModel selectedContact) : this(myInformations, contacts)
        {
            SelectedContact = selectedContact;
        }
    }
}