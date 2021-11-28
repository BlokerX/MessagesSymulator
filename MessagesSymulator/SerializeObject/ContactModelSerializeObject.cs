using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.SerializeObject
{
    public class ContactModelSerializeObject
    {
        //public ObservableCollection<MessageModelSerializeObject> Messages = new ObservableCollection<MessageModelSerializeObject>();
        public bool IsFirstMy;
        public List<int> UsersID = new List<int>();

        public UserInformationsSerializeObject InformationsAboutUser { get; set; }

        public ContactModelSerializeObject(Models.ContactModel model)
        {
            //UsersID = model.UsersID;
            IsFirstMy = model.IsFirstMy;
            //foreach (var item in model.Messages)
            //{
            //    Messages.Add(new MessageModelSerializeObject(item));
            //}
            //InformationsAboutUser = new UserInformationsSerializeObject(model.InformationsAboutUser);
        }

        public ContactModelSerializeObject(ObservableCollection<MessageModelSerializeObject> messages, bool isFirstMy,
            List<int> usersID, UserInformationsSerializeObject userInformations)
        {
            InformationsAboutUser = userInformations;
            UsersID = usersID;
            //Messages = messages;
            IsFirstMy = isFirstMy;
        }

        public ContactModelSerializeObject()
        {

        }
    }
}
