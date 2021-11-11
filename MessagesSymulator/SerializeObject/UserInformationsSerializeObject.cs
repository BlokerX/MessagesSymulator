using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.SerializeObject
{
    public class UserInformationsSerializeObject
    {
        public string Username;
        public string UsernameColor;
        public string ImageSource;
        public bool ActiveState;

        // Serialize
        public UserInformationsSerializeObject(Models.UserInformations informations)
        {
            Username = informations.Username;
            UsernameColor = informations.UsernameColor;
            ImageSource = informations.ImageSource;
            ActiveState = informations.ActiveState;
        }

        public UserInformationsSerializeObject(string username, string usernameColor, string imageSource, bool activeState)
        {
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
