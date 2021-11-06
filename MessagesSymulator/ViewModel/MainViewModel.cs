using MessagesSymulator.Core;
using MessagesSymulator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MessagesSymulator.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public List<ChatUserModel> UsersList { get; set; }
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

        public MainViewModel()
        {
            ActiveUser = new ChatUserModel();
            ActiveUser.MyInformations.ActiveState = false;

            #region CommandsInitialize
            SendCommand = new RelayCommand(o =>
            {
                if (Message != null && Message != "" &&
                CharCountInString(Message, ' ') != Message.Length)
                {

                    ActiveUser.SelectedContact.Messages.Add(new MessageModel()
                    {
                        MainInformations = ActiveUser.MyInformations,
                        Message = Message,
                        Time = DateTime.Now,
                        IsFirst = ActiveUser.SelectedContact.IsFirstMy
                    });
                    ActiveUser.SelectedContact.IsFirstMy = false;

                    Message = "";
                }
            });
            #endregion

            #region AddUsers

            ActiveUser.Contacts.Add(new ContactModel()
            {
                MainInformations = new UserInformations()
                {
                    Username = "Orion Łukasik",
                    UsernameColor = "LightCyan",
                    ImageSource = "https://www.kupgwiazde.com/media/wysiwyg/zodiacs_de/orion.jpg"
                },

                Messages = new ObservableCollection<MessageModel>()

            });

            ActiveUser.Contacts.Add(new ContactModel()
            {
                MainInformations = new UserInformations()
                {
                    Username = "Wiktor Anek",
                    UsernameColor = "Navy",
                    ImageSource = "https://www.abdn.ac.uk/stories/song-of-the-oceans/assets/UYxDb1S4Ba/shutterstock_158257880-2560x1707.jpeg"
                },

                Messages = new ObservableCollection<MessageModel>()

            });

            //ActiveUser.Contacts.Add(new ContactModel()
            //{
            //    MainInformations = new UserInformations()
            //    {
            //        Username = "Belle Delphina",
            //        UsernameColor = "Pink",
            //        ImageSource = "https://telegra.ph/file/e264763c39e4195ab2634.jpg"
            //    },

            //    Messages = new ObservableCollection<MessageModel>()

            //});

            //ActiveUser.Contacts.Add(new ContactModel()
            //{
            //    MainInformations = new UserInformations()
            //    {
            //        Username = "Hayasaka",
            //        UsernameColor = "Purple",
            //        ImageSource = "https://i.ytimg.com/vi/na6k3AXRyrQ/hq720.jpg"
            //    },

            //    Messages = new ObservableCollection<MessageModel>()

            //});

            #endregion

            #region AddMessages

            for (int i = 1; i <= 3; i++)
            {

                foreach (var item in ActiveUser.Contacts)
                {

                    item.Messages.Add(new MessageModel()
                    {
                        MainInformations = item.MainInformations,
                        Message = "Hello world!",
                        Time = DateTime.Now.Date,
                        ImageLinks = new List<LinkComponentModel>(),
                        IsFirst = true
                    });

                    for (int j = 0; j < i * 2; j++)
                    {

                        item.Messages.Add(new MessageModel()
                        {
                            MainInformations = item.MainInformations,
                            Message = "Hello word! " + (j + 1).ToString(),
                            Time = DateTime.Now.Date,
                            IsFirst = false
                        });

                    }

                    item.Messages.Add(new MessageModel()
                    {
                        MainInformations = item.MainInformations,
                        Message = "Hello world!",
                        Time = DateTime.Now.Date,
                        IsFirst = true
                    });

                    for (int j = 0; j < i * 2; j++)
                    {

                        item.Messages.Add(new MessageModel()
                        {
                            MainInformations = item.MainInformations,
                            Message = "Hello word! " + (j + 1).ToString(),
                            Time = DateTime.Now.Date,
                            IsFirst = false
                        });
                        if(j==i*2-1 && i == 2)
                        item.Messages.Add(new MessageModel()
                        {
                            MainInformations = item.MainInformations,
                            Message = "Hello word! " + (j + 1).ToString(),
                            Time = DateTime.Now.Date,
                            ImageLinks = new List<LinkComponentModel>()
                            {
                                new LinkComponentModel(){Link="https://scontent.fpoz4-1.fna.fbcdn.net/v/t39.30808-6/242868839_3094191224197301_3106382277220540879_n.jpg?_nc_cat=109&ccb=1-5&_nc_sid=e3f864&_nc_ohc=XmMdQ4Dbbm4AX9gtq4r&_nc_ht=scontent.fpoz4-1.fna&oh=4eaab412bc11cfe9f548138e0a19ad5d&oe=618BC5F0"}
                            },
                            IsFirst = false
                        });

                    }
                }

            }
            #endregion

            ActiveUser.SelectedContact = ActiveUser.Contacts.First();
        }

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
