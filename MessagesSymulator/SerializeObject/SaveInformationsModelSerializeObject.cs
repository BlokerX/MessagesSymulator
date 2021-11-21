using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.SerializeObject
{
    public class SaveInformationsModelSerializeObject
    {
        public int ActiveUserIndex;
        public List<SerializeObject.ChatUserModelSerializeObject> ChatUsers;
        public List<SerializeObject.MessageCanelModelSerializeObject> MessageCanels;
    }
}
