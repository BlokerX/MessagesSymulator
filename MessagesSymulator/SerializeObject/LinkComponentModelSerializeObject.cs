using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MessagesSymulator.SerializeObject
{
    public class LinkComponentModelSerializeObject
    {
        public string Link;

        // Serialize
        public LinkComponentModelSerializeObject(Models.LinkComponentModel model)
        {
            Link = model.Link;
        }

        public LinkComponentModelSerializeObject(string link, Size imageSize)
        {
            Link = link;
        }

        public LinkComponentModelSerializeObject()
        {

        }

    }
}
