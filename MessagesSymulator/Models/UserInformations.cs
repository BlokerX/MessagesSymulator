using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.Models
{
    public class UserInformations
    {
        public string Username { get; set; }
        public string UsernameColor { get; set; } = "White";
        public string ImageSource { get; set; }
        public bool ActiveState { get; set; } = true;

    }
}
