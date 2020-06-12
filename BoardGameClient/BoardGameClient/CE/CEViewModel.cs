using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameClient.CE
{
    public class CEViewModel : GameViewModelBase
    {
        public CEViewModel(MatchDescriptor match) 
            : base(match)
        {
            StartPollingState<CEStateDescriptor, CEOptionDescriptor>();
        }

        internal override bool UpdateViewModel<S, O>(StateDescriptor<S, O> state)
        {
            CEStateDescriptor descriptor = state.State as CEStateDescriptor;
            OptionsDescriptor<CEOptionDescriptor>[] options = state.Options as OptionsDescriptor<CEOptionDescriptor>[];

            return false;
        }        
    }
}
