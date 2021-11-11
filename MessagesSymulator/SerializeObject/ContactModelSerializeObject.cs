using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.SerializeObject
{
    public class ContactModelSerializeObject : UserInformationsSerializeObject
    {
        public ObservableCollection<MessageModelSerializeObject> Messages = new ObservableCollection<MessageModelSerializeObject>();
        public bool IsFirstMy;

        public ContactModelSerializeObject(Models.ContactModel model) : base(model)
        {
            IsFirstMy = model.IsFirstMy;
            foreach (var item in model.Messages)
            {
                Messages.Add(new MessageModelSerializeObject(item));
            }
        }

        public ContactModelSerializeObject(ObservableCollection<MessageModelSerializeObject> messages, bool isFirstMy,
            UserInformationsSerializeObject userInformations)
            : base(userInformations.Username,
                 userInformations.UsernameColor,
                 userInformations.ImageSource,
                 userInformations.ActiveState)
        {
            Messages = messages;
            IsFirstMy = isFirstMy;
        }

        public ContactModelSerializeObject()
        {

        }
    }
}
