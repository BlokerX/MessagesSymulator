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
        public List<ChatUserModel> UsersList { get; set; } = new List<ChatUserModel>();

        public ChatUserModel ActiveUser { get; set; }

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

        public MainViewModel()
        {
            ActiveUser = new ChatUserModel();

            #region CommandsInitialize
            SendCommand = new RelayCommand(o =>
            {
                if ((Message != null && Message != "" &&
                CharCountInString(Message, ' ') != Message.Length) || MessageLink != null)
                {
                    if (ActiveUser.SelectedContact.Messages.Last().Username != ActiveUser.Username ||
                        ActiveUser.SelectedContact.Messages.Last().ImageSource != ActiveUser.ImageSource ||
                        ActiveUser.SelectedContact.Messages.Last().UsernameColor != ActiveUser.UsernameColor)
                        ActiveUser.SelectedContact.IsFirstMy = true;

                    LinkComponentModel _imageLink = null;
                    if (MessageLink != null)
                        _imageLink = new LinkComponentModel(MessageLink);

                    ActiveUser.SelectedContact.Messages.Add(new MessageModel()
                    {
                        Username = ActiveUser.Username,
                        UsernameColor = ActiveUser.UsernameColor,
                        ImageSource = ActiveUser.ImageSource,
                        ActiveState = ActiveUser.ActiveState,
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
                #region AddUsers

                ActiveUser.Contacts.Add(new ContactModel()
                {

                    Username = "Orion Łukasik",
                    UsernameColor = "Cyan",
                    ImageSource = "https://uwalls.pl/gallery/53/31493_thumb_b1000.jpg",
                    Messages = new ObservableCollection<MessageModel>()

                });

                ActiveUser.Contacts.Add(new ContactModel()
                {
                    Username = "Wiktor Anek",
                    UsernameColor = "Yellow",
                    ImageSource = "https://img.pixers.pics/pho_wat(s3:700/FO/15/21/75/12/700_FO15217512_4b773ae21b5736fcabf808cc201e840a.jpg,700,700,cms:2018/10/5bd1b6b8d04b8_220x50-watermark.png,over,480,650,jpg)/plakaty-fire-letter-d.jpg.jpg",
                    Messages = new ObservableCollection<MessageModel>()

                });

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

                #region AddMessages

                for (int i = 1; i <= 1; i++)
                {

                    foreach (var item in ActiveUser.Contacts)
                    {

                        item.Messages.Add(new MessageModel()
                        {
                            Username = item.Username,
                            UsernameColor = item.UsernameColor,
                            ImageSource = item.ImageSource,
                            ActiveState = item.ActiveState,
                            Message = "Hello world!",
                            Time = DateTime.Now,
                            ImageLink = new LinkComponentModel("http://2.bp.blogspot.com/-zVqfkF3YTqU/VQLhqBLGguI/AAAAAAAAANs/RYu3h4Gu6l4/s1600/slenderman28n-1-web.jpg"),
                            IsFirst = true
                        });

                        item.Messages.Add(new MessageModel()
                        {
                            Username = item.Username,
                            UsernameColor = item.UsernameColor,
                            ImageSource = item.ImageSource,
                            ActiveState = item.ActiveState,
                            Time = DateTime.Now,
                            ImageLink = new LinkComponentModel("https://th.bing.com/th/id/R.e51c97a2235d2df87219ce42e35788f1?rik=Q%2fMlW5XwnyaAYA&riu=http%3a%2f%2f1.bp.blogspot.com%2f_dFeSIoIIWWc%2fS8GNBv6nJQI%2fAAAAAAAAAAM%2f8a7hzaUiU7E%2fs1600%2fscrollbar1.JPG&ehk=cYL%2bSBLK6fbFIa3%2bSvyJNgCx7DOV6Q7rHKzhh7EPDUY%3d&risl=&pid=ImgRaw&r=0"),
                            IsFirst = true
                        });

                        item.Messages.Add(new MessageModel()
                        {
                            Username = item.Username,
                            UsernameColor = item.UsernameColor,
                            ImageSource = item.ImageSource,
                            ActiveState = item.ActiveState,
                            Message = "Hello word! " + (1).ToString(),
                            Time = DateTime.Now,
                            ImageLink = new LinkComponentModel("https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg"),
                            IsFirst = false
                        });

                        item.Messages.Add(new MessageModel()
                        {
                            Username = item.Username,
                            UsernameColor = item.UsernameColor,
                            ImageSource = item.ImageSource,
                            ActiveState = item.ActiveState,
                            Message = "Hello world!",
                            Time = DateTime.Now,
                            ImageLink = new LinkComponentModel("https://th.bing.com/th/id/R.e51c97a2235d2df87219ce42e35788f1?rik=Q%2fMlW5XwnyaAYA&riu=http%3a%2f%2f1.bp.blogspot.com%2f_dFeSIoIIWWc%2fS8GNBv6nJQI%2fAAAAAAAAAAM%2f8a7hzaUiU7E%2fs1600%2fscrollbar1.JPG&ehk=cYL%2bSBLK6fbFIa3%2bSvyJNgCx7DOV6Q7rHKzhh7EPDUY%3d&risl=&pid=ImgRaw&r=0"),
                            IsFirst = false
                        });

                        item.Messages.Add(new MessageModel()
                        {
                            Username = item.Username,
                            UsernameColor = item.UsernameColor,
                            ImageSource = item.ImageSource,
                            ActiveState = item.ActiveState,
                            Message = "Hello word! " + (1).ToString(),
                            Time = DateTime.Now,
                            IsFirst = false
                        });

                        item.Messages.Add(new MessageModel()
                        {
                            Username = item.Username,
                            UsernameColor = item.UsernameColor,
                            ImageSource = item.ImageSource,
                            ActiveState = item.ActiveState,
                            Message = "Hello word! " + (1).ToString(),
                            Time = DateTime.Now,
                            IsFirst = false
                        });

                        item.Messages.Add(new MessageModel()
                        {
                            Username = item.Username,
                            UsernameColor = item.UsernameColor,
                            ImageSource = item.ImageSource,
                            ActiveState = item.ActiveState,
                            Message = "Hello word! " + (1).ToString(),
                            Time = DateTime.Now,
                            IsFirst = false
                        });

                        item.Messages.Add(new MessageModel()
                        {
                            Username = item.Username,
                            UsernameColor = item.UsernameColor,
                            ImageSource = item.ImageSource,
                            ActiveState = item.ActiveState,
                            Message = "Hello word! " + (1).ToString(),
                            Time = DateTime.Now,
                            IsFirst = false
                        });

                        item.Messages.Add(new MessageModel()
                        {
                            Username = item.Username,
                            UsernameColor = item.UsernameColor,
                            ImageSource = item.ImageSource,
                            ActiveState = item.ActiveState,
                            Time = DateTime.Now,
                            ImageLink = new LinkComponentModel("https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg"),
                            IsFirst = false
                        });

                        for (int j = 0; j < i * 2; j++)
                        {

                            item.Messages.Add(new MessageModel()
                            {
                                Username = item.Username,
                                UsernameColor = item.UsernameColor,
                                ImageSource = item.ImageSource,
                                ActiveState = item.ActiveState,
                                Message = "Hello word! " + (j + 1).ToString(),
                                Time = DateTime.Now,
                                IsFirst = false
                            });

                        }

                        item.Messages.Add(new MessageModel()
                        {
                            Username = item.Username,
                            UsernameColor = item.UsernameColor,
                            ImageSource = item.ImageSource,
                            ActiveState = item.ActiveState,
                            Message = "Hello world!",
                            Time = DateTime.Now,
                            IsFirst = true
                        });



                        item.Messages.Add(new MessageModel()
                        {
                            Username = item.Username,
                            UsernameColor = item.UsernameColor,
                            ImageSource = item.ImageSource,
                            ActiveState = item.ActiveState,
                            Message = "Hello word! " + (1).ToString(),
                            Time = DateTime.Now,
                            IsFirst = false
                        });



                    }

                }
                #endregion

                ActiveUser.SelectedContact = ActiveUser.Contacts.First();
                SaveUserData();
            }

        }

        #region Serializacja

        private readonly string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "UserData");

        public void SaveUserData()
        {
            if (File.Exists(SavePath))
                File.Delete(SavePath);

            using (var f = File.CreateText(SavePath))
            {
                f.Write(JsonConvert.SerializeObject(new SerializeObject.ChatUserModelSerializeObject(ActiveUser)));
            }
        }

        public void DownloadUserDataFromFile()
        {
            if (File.Exists(SavePath))
                using (var f = File.OpenText(SavePath))
                {
                    ActiveUser = new ChatUserModel(JsonConvert.DeserializeObject<SerializeObject.ChatUserModelSerializeObject>(f.ReadToEnd()));
                }
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
