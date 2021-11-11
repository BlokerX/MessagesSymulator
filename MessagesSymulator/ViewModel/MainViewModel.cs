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
                    ImageSource = "https://uwalls.pl/gallery/53/31493_thumb_b1000.jpg"
                },

                Messages = new ObservableCollection<MessageModel>()

            });

            ActiveUser.Contacts.Add(new ContactModel()
            {
                MainInformations = new UserInformations()
                {
                    Username = "Wiktor Anek",
                    UsernameColor = "Navy",
                    ImageSource = "https://lh3.googleusercontent.com/proxy/mBhauPzNO4rfoQykuDpvrQuX3BAhzQYowIpBQjJbVGaA7-BSuOf_FWmRgKSHDpKnwu08BwZDEwFDTEAZ-o7nWV0_p_G7wKfv1zhj8CFle9MXJQG4lle7_XM"
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
                        ImageLinks = new List<LinkComponentModel>() {
                            new LinkComponentModel()
                            {
                                Link = "http://2.bp.blogspot.com/-zVqfkF3YTqU/VQLhqBLGguI/AAAAAAAAANs/RYu3h4Gu6l4/s1600/slenderman28n-1-web.jpg"
                            }
                        },
                        IsFirst = true
                    });

                    item.Messages.Add(new MessageModel()
                    {
                        MainInformations = item.MainInformations,
                        Message = "Hello world!",
                        Time = DateTime.Now.Date,
                        ImageLinks = new List<LinkComponentModel>() {
                            new LinkComponentModel()
                            {
                                Link = "https://th.bing.com/th/id/R.e51c97a2235d2df87219ce42e35788f1?rik=Q%2fMlW5XwnyaAYA&riu=http%3a%2f%2f1.bp.blogspot.com%2f_dFeSIoIIWWc%2fS8GNBv6nJQI%2fAAAAAAAAAAM%2f8a7hzaUiU7E%2fs1600%2fscrollbar1.JPG&ehk=cYL%2bSBLK6fbFIa3%2bSvyJNgCx7DOV6Q7rHKzhh7EPDUY%3d&risl=&pid=ImgRaw&r=0"
                            }
                        },
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
                        if (j == i * 2 - 1 && i == 2)
                            item.Messages.Add(new MessageModel()
                            {
                                MainInformations = item.MainInformations,
                                Message = "Hello word! " + (j + 1).ToString(),
                                Time = DateTime.Now.Date,
                                ImageLinks = new List<LinkComponentModel>()
                            {
                                new LinkComponentModel()
                                {
                                    Link="https://samequizy.pl/wp-content/uploads/2016/03/filing_images_3e6948328f17.jpeg"
                                }
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
