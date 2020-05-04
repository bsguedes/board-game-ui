using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameClient
{
    public class PlayerDescriptor
    {
        public string Name { get; set; }
        public string Secret { get; set; }    
        public bool ValidMove { get; set; }
        public int Ping { get; set; }
    }
}
