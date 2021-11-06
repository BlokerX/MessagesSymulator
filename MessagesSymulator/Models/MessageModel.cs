using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.Models
{
    public class MessageModel
    {
        public UserInformations MainInformations { get; set; }
        public string Message { get; set; }
        public List<LinkComponentModel> ImageLinks { get; set; } = new List<LinkComponentModel>();
        public DateTime Time { get; set; }
        public bool IsFirst { get; set; }
    }
}
