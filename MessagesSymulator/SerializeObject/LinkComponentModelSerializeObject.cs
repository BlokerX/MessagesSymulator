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
        public Size ImageSize;

        // Serialize
        public LinkComponentModelSerializeObject(Models.LinkComponentModel model)
        {
            Link = model.Link;
            ImageSize = model.ImageSize;
        }

        public LinkComponentModelSerializeObject(string link, Size imageSize)
        {
            Link = link;
            ImageSize = imageSize;
        }

        public LinkComponentModelSerializeObject()
        {

        }

    }
}
