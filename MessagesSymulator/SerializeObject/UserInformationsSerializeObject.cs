using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.SerializeObject
{
    public class UserInformationsSerializeObject
    {
        public int ID;
        public string Username;
        public string UsernameColor;
        public string ImageSource;
        public bool ActiveState;


        // Serialize
        public UserInformationsSerializeObject(Models.UserInformations informations)
        {
            ID = informations.ID;
            Username = informations.Username;
            UsernameColor = informations.UsernameColor;
            ImageSource = informations.ImageSource;
            ActiveState = informations.ActiveState;
        }

        public UserInformationsSerializeObject(int iD, string username, string usernameColor, string imageSource, bool activeState)
        {
            ID = iD;
            Username = username;
            UsernameColor = usernameColor;
            ImageSource = imageSource;
            ActiveState = activeState;
        }

        public UserInformationsSerializeObject()
        {

        }

    }
}
