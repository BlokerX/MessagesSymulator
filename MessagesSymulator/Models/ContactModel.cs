using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.Models
{
    public class ContactModel
    {
        public UserInformations MainInformations { get; set; }
        public ObservableCollection<MessageModel> Messages { get; set; }
        public bool IsFirstMy { get; set; } = true;
        public string LastMessage
        {
            get
            {
                if (Messages.Count > 0) { return Messages.Last().Message; }
                else return null;
            }
        }
    }
}
