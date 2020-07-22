using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameClient
{
    public class StateDescriptor<S, O>
        where S : GameStateDescriptor
        where O : GameOptionsDescriptor
    {
        public int StateNo { get; set; }
        public string GameStatus { get; set; }
        public S State { get; set; }        
        public string CurrentPlayer { get; set; }
        public OptionsDescriptor<O>[] Options { get; set; }
    }

    public abstract class GameStateDescriptor
    {
        public string StateName { get; set; }
    }

    public class OptionsDescriptor<O>
        where O : GameOptionsDescriptor
    {
        public string OptionCode { get; set; }
        public O Option { get; set; }
    }

    public abstract class GameOptionsDescriptor
    {

    }
}
