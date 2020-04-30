using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameClient.Common
{
    public class OptionsBase
    {
        public int MaxPlayers { get; protected set; }        
    }

    public abstract class OptionsViewModelBase : ViewModelBase
    {
        public abstract OptionsBase LoadCurrentOptions();
        internal abstract bool VerifyOptions();
    }
}
