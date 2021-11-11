using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MessagesSymulator.Models
{
    public class LinkComponentModel
    {
        public string Link { get; set; }
        public Size ImageSize { get; set; }

        // Deserialize
        public LinkComponentModel(SerializeObject.LinkComponentModelSerializeObject serializeObject)
        {
            Link = serializeObject.Link;
            ImageSize = serializeObject.ImageSize;
            // todo czy dodać skalowanie automatyczne z objektu po serializacji
        }

        public LinkComponentModel()
        {
            // Scaling Method!
            ImageSize = new Size()
            {
                Width = System.Windows.SystemParameters.PrimaryScreenWidth / 6,
                Height = System.Windows.SystemParameters.PrimaryScreenHeight / 6
            };
        }

    }
}
