using MessagesSymulator.Core;
using MessagesSymulator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System.ComponentModel;

namespace MessagesSymulator.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ObservableCollection<ChatUserModel> _usersList = new ObservableCollection<ChatUserModel>();
        public ObservableCollection<ChatUserModel> UsersList 
        { 
            get
            {
                return _usersList;
            }
            set
            {
                UsersList = value;
                OnPropertyChanged();
            }
        }

        public List<MessageCanelModel> MessagesCanelList { get; set; } = new List<MessageCanelModel>();

        public int FindMessagesCanelIndexForID(int id)
        {
            for (int i = 0; i < MessagesCanelList.Count; i++)
            {
                if (MessagesCanelList[i].ID == id)
                    return i;
            }
            return -1;
        }

        private ChatUserModel _activeUser { get; set; }

        public ChatUserModel ActiveUser
        {
            get
            {
                return _activeUser;
            }
            set
            {
                _activeUser = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public RelayCommand SendCommand { get; set; }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }


        private string _messageLink;
        public string MessageLink
        {
            get { return _messageLink; }
            set
            {
                _messageLink = value;
                OnPropertyChanged();
            }
        }

        public bool IsMessageGood { get; set; }

        public MainViewModel()
        {
            IsMessageGood = true;
            ActiveUser = new ChatUserModel();

            #region CommandsInitialize
            SendCommand = new RelayCommand(o =>
            {
                if (ActiveUser.Contacts.Count > 0 && IsMessageGood && 
                ((Message != null && Message != "" && CharCountInString(Message, ' ') != Message.Length) || MessageLink != null))
                {
                    if (ActiveUser.SelectedContact.Messages.Last().InformationsAboutUser.Username != ActiveUser.Username ||
                        ActiveUser.SelectedContact.Messages.Last().InformationsAboutUser.ID != ActiveUser.ID ||
                        ActiveUser.SelectedContact.Messages.Last().InformationsAboutUser.ImageSource != ActiveUser.ImageSource ||
                        ActiveUser.SelectedContact.Messages.Last().InformationsAboutUser.UsernameColor != ActiveUser.UsernameColor)
                        ActiveUser.SelectedContact.IsFirstMy = true;

                    LinkComponentModel _imageLink = null;
                    if (MessageLink != null)
                        _imageLink = new LinkComponentModel(MessageLink);

                    ActiveUser.SelectedContact.Messages.Add(new MessageModel()
                    {
                        InformationsAboutUser = new UserInformations
                        (
                            ActiveUser.ID,
                            ActiveUser.Username,
                            ActiveUser.UsernameColor,
                            ActiveUser.ImageSource,
                            ActiveUser.ActiveState
                        ),
                        Message = Message,
                        Time = DateTime.Now,
                        ImageLink = _imageLink,
                        IsFirst = ActiveUser.SelectedContact.IsFirstMy
                    });
                    ActiveUser.SelectedContact.IsFirstMy = false;

                    Message = "";
                    MessageLink = null;
                }
            });
            #endregion

            if (File.Exists(SavePath))
                DownloadUserDataFromFile();
            else
            {

                #region MessagesCanelList

                MessagesCanelList.Add(new MessageCanelModel()
                {
                    Messages = new ObservableCollection<MessageModel>()
                });

                #endregion

                #region AddUsers

                _usersList.Add(new ChatUserModel()
                {
                    Username = "Orion Łukasik",
                    UsernameColor = "Cyan",
                    ImageSource = "https://uwalls.pl/gallery/53/31493_thumb_b1000.jpg",
                    ActiveState = true,
                    ContactsCanels = new List<int> { 1 }
                });

                _usersList.Add(new ChatUserModel()
                {
                    Username = "Adam Bogusz",
                    UsernameColor = "Brown",
                    ImageSource = "https://i.ytimg.com/vi/na6k3AXRyrQ/hq720.jpg",
                    ActiveState = true,
                    ContactsCanels = new List<int> { 1 }
                });

                #endregion


                #region AddContacts
                AddContacts();

                #region comments
                //ActiveUser.Contacts.Add(new ContactModel()
                //{
                //    Username = "Belle Delphina",
                //    UsernameColor = "Pink",
                //    ImageSource = "https://telegra.ph/file/e264763c39e4195ab2634.jpg",
                //    Messages = new ObservableCollection<MessageModel>()

                //});

                //ActiveUser.Contacts.Add(new ContactModel()
                //{
                //    Username = "Hayasaka",
                //    UsernameColor = "Purple",
                //    ImageSource = "https://i.ytimg.com/vi/na6k3AXRyrQ/hq720.jpg",
                //    Messages = new ObservableCollection<MessageModel>()

                //});
                #endregion

                #endregion

                #region AddMessages

                foreach (var item in MessagesCanelList)
                {

                    item.Messages.Add(new MessageModel()
                    {
                        InformationsAboutUser = _usersList.First(),
                        //ActiveState = item.ActiveState,//todo usunąć active state z wiadomości
                        Message = "Hello world!",
                        Time = DateTime.Now,
                        ImageLink = new LinkComponentModel("http://2.bp.blogspot.com/-zVqfkF3YTqU/VQLhqBLGguI/AAAAAAAAANs/RYu3h4Gu6l4/s1600/slenderman28n-1-web.jpg"),
                        IsFirst = true
                    });
                }


                #endregion

                ActiveUser = _usersList.First();

            }

            if(ActiveUser.Contacts.Count > 0)
            ActiveUser.SelectedContact = ActiveUser.Contacts.First();

            SaveUserData();
        }

        private void AddContacts()
        {
            foreach (var messageCanel in MessagesCanelList)
            {
                foreach (var user in _usersList)
                {

                    if (user.ContactsCanels.Contains(messageCanel.ID))
                    {
                        user.Contacts.Clear();
                        foreach (var contactUser in _usersList)
                        {
                            if (contactUser.ContactsCanels.Contains(messageCanel.ID) && contactUser != user)
                            {
                                user.Contacts.Add(new ContactModel(ref messageCanel.Messages, true)
                                {
                                    InformationsAboutUser = contactUser
                                });
                            }
                        }
                    }

                }
            }
        }



        #region Serializacja

        //private readonly string UsersDataSavePath = Path.Combine(Directory.GetCurrentDirectory(), "UsersData");
        //private readonly string MessgesCanellsSavePath = Path.Combine(Directory.GetCurrentDirectory(), "MessagesCanells");

        private readonly string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "MS_Data.json");

        public void SaveUserData()
        {
            if (File.Exists(SavePath))
                File.Delete(SavePath);

            List<SerializeObject.ChatUserModelSerializeObject> chatUserModelSerializes = new List<SerializeObject.ChatUserModelSerializeObject>();
            foreach (var item in _usersList)
            {
                chatUserModelSerializes.Add(new SerializeObject.ChatUserModelSerializeObject(item));
            }

            List<SerializeObject.MessageCanelModelSerializeObject> messageCanelModelSerializes = new List<SerializeObject.MessageCanelModelSerializeObject>();
            foreach (var item in MessagesCanelList)
            {
                messageCanelModelSerializes.Add(new SerializeObject.MessageCanelModelSerializeObject(item));
            }

            SerializeObject.SaveInformationsModelSerializeObject serializeObject = new SerializeObject.SaveInformationsModelSerializeObject()
            {
                ChatUsers = chatUserModelSerializes,
                MessageCanels = messageCanelModelSerializes,
                ActiveUserIndex = _usersList.IndexOf(ActiveUser)
            };


            using (var f = File.CreateText(SavePath))
            {
                f.Write(JsonConvert.SerializeObject(serializeObject));
            }


            //if (File.Exists(UsersDataSavePath))
            //    File.Delete(UsersDataSavePath);

            //List<SerializeObject.ChatUserModelSerializeObject> chatUserModelSerializes = new List<SerializeObject.ChatUserModelSerializeObject>();
            //foreach (var item in UsersList)
            //{
            //    chatUserModelSerializes.Add(new SerializeObject.ChatUserModelSerializeObject(item));
            //}

            //using (var f = File.CreateText(UsersDataSavePath))
            //{
            //    f.Write(JsonConvert.SerializeObject(chatUserModelSerializes));
            //}

            //// ----------------------------------------------------------------------------------------------------------------------------------------------------- //

            //if (File.Exists(MessgesCanellsSavePath))
            //    File.Delete(MessgesCanellsSavePath);

            //List<SerializeObject.MessageCanelModelSerializeObject> messageCanelModelSerializes = new List<SerializeObject.MessageCanelModelSerializeObject>();
            //foreach (var item in MessagesCanelList)
            //{
            //    messageCanelModelSerializes.Add(new SerializeObject.MessageCanelModelSerializeObject(item));
            //}

            //using (var f = File.CreateText(MessgesCanellsSavePath))
            //{
            //    f.Write(JsonConvert.SerializeObject(messageCanelModelSerializes));
            //}
        }

        public void DownloadUserDataFromFile()
        {
            //if (File.Exists(SavePath))
            //    using (var f = File.OpenText(MessgesCanellsSavePath))
            //    {
            //        List<SerializeObject.MessageCanelModelSerializeObject> messageCanelModelSerializes = JsonConvert.DeserializeObject<List<SerializeObject.MessageCanelModelSerializeObject>>(f.ReadToEnd());
            //        MessagesCanelList = new List<MessageCanelModel>();
            //        foreach (var item in messageCanelModelSerializes)
            //        {
            //            MessagesCanelList.Add(new MessageCanelModel(item));
            //        }
            //    }

            //if (File.Exists(UsersDataSavePath))
            //    using (var f = File.OpenText(UsersDataSavePath))
            //    {
            //        List<SerializeObject.ChatUserModelSerializeObject> chatUserModelSerializes = JsonConvert.DeserializeObject<List<SerializeObject.ChatUserModelSerializeObject>>(f.ReadToEnd());
            //        UsersList = new List<ChatUserModel>();
            //        foreach (var item in chatUserModelSerializes)
            //        {
            //            UsersList.Add(new ChatUserModel(item));
            //        }
            //    }

            if (File.Exists(SavePath))
                using (var f = File.OpenText(SavePath))
                {
                    SerializeObject.SaveInformationsModelSerializeObject serializeObject = JsonConvert.DeserializeObject<SerializeObject.SaveInformationsModelSerializeObject>(f.ReadToEnd());

                    List<SerializeObject.MessageCanelModelSerializeObject> messageCanelModelSerializes = serializeObject.MessageCanels;
                    MessagesCanelList = new List<MessageCanelModel>();
                    foreach (var item in messageCanelModelSerializes)
                    {
                        MessagesCanelList.Add(new MessageCanelModel(item));
                    }

                    List<SerializeObject.ChatUserModelSerializeObject> chatUserModelSerializes = serializeObject.ChatUsers;
                    _usersList = new ObservableCollection<ChatUserModel>();
                    foreach (var item in chatUserModelSerializes)
                    {
                        _usersList.Add(new ChatUserModel(item));
                    }
                    if (serializeObject.ActiveUserIndex >= 0  && serializeObject.ActiveUserIndex < _usersList.Count)
                    ActiveUser = _usersList[serializeObject.ActiveUserIndex];
                }

            AddContacts();

        }

        #endregion

        #region Helpers

        public int CharCountInString(string s, char c)
        {
            if (!s.Contains(c))
                return 0;

            int charInStringCount = 0;

            foreach (var item in s)
            {
                if (item == c)
                    charInStringCount++;
            }
            return charInStringCount;
        }

        #endregion
    }
}
