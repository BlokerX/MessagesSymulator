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
        private readonly int _id = 1;

        public int ID
        {
            get { return _id; }
        }


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
            _id = serializeObject.ID;
            OccupiedIDs.Add(ID);
            Username = serializeObject.Username;
            UsernameColor = serializeObject.UsernameColor;
            ImageSource = serializeObject.ImageSource;
            ActiveState = serializeObject.ActiveState;
        }

        public UserInformations(int iD, string username, string usernameColor, string imageSource, bool activeState)
        {
            _id = iD;
            OccupiedIDs.Add(ID);
            Username = username;
            UsernameColor = usernameColor;
            ImageSource = imageSource;
            ActiveState = activeState;
        }

        public UserInformations()
        {
            _id = GetNewID();
            OccupiedIDs.Add(ID);
        }

        private int GetNewID()
        {
            int nextID = 1;
            // dodać sortowanie wartości occupiedIDs
            foreach (var item in OccupiedIDs)
            {
                if (item == nextID)
                {
                    nextID++;
                }
            }
            return nextID;
        }

        public static List<int> OccupiedIDs { get; set; } = new List<int>();
    }
}
