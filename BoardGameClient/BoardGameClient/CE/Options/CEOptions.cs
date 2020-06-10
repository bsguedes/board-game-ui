using BoardGameClient.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameClient.CE.Options
{
    public class CEOptions : OptionsBase
    {
        public CEOptions(int max_players)
        {
            MaxPlayers = max_players;
        }
    }

    public class CEOptionsViewModel : OptionsViewModelBase
    {
        public override OptionsBase LoadCurrentOptions()
        {
            return new CEOptions(MaxPlayers);
        }

        internal override bool VerifyOptions()
        {
            return 1 <= MaxPlayers && MaxPlayers <= 5;
        }

        private int _maxPlayers;
        public int MaxPlayers
        {
            get { return _maxPlayers; }
            set { SetProperty(ref _maxPlayers, value); }
        }

        public int[] AllowedPlayers => new int[] { 1, 2, 3, 4, 5 };        
    }
}
