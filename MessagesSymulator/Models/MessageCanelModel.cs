using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesSymulator.Models
{
    public class MessageCanelModel
    {
        public ObservableCollection<MessageModel> Messages = new ObservableCollection<MessageModel>();

        private readonly int _id = 1;
        public int ID
        {
            get { return _id; }
        }

        public MessageCanelModel(int iD)
        {
            _id = iD;
            OccupiedIDs.Add(ID);
        }

        public MessageCanelModel(SerializeObject.MessageCanelModelSerializeObject serializeObject)
        {
            _id=serializeObject.ID;
            OccupiedIDs.Add(ID);
            Messages = new ObservableCollection<MessageModel>();
            foreach (var item in serializeObject.Messages)
            {
                Messages.Add(new MessageModel(item));
            }
        }

        public MessageCanelModel()
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
