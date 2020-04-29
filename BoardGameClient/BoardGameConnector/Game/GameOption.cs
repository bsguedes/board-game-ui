using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameConnector.Game
{
    public abstract class GameOption
    {
        internal GameOption(string text)
        {
            this.Text = text;            
        }

        public string Text { get; }
    }
}
