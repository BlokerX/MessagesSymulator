using MessagesSymulator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.Models
{
    public class UserInformations : ObservableObject
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _usernameColor = "White";

        public string UsernameColor
        {
            get { return _usernameColor; }
            set
            {
                if (value != _usernameColor)
                {
                    _usernameColor = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _imageSource;

        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                if (value != _imageSource)
                {
                    _imageSource = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _activeState = true;

        public bool ActiveState
        {
            get { return _activeState; }
            set
            {
                if (value != _activeState)
                {
                    _activeState = value;
                    OnPropertyChanged();
                }
            }
        }

        // Deserialize
        public UserInformations(SerializeObject.UserInformationsSerializeObject serializeObject)
        {
            Username = serializeObject.Username;
            UsernameColor = serializeObject.UsernameColor;
            ImageSource = serializeObject.ImageSource;
            ActiveState = serializeObject.ActiveState;
        }

        public UserInformations(string username, string usernameColor, string imageSource, bool activeState)
        {
            Username = username;
            UsernameColor = usernameColor;
            ImageSource = imageSource;
            ActiveState = activeState;
        }

        public UserInformations()
        {

        }
    }
}
