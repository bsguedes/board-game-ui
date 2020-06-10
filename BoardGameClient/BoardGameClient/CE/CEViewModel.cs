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
            
        }

        internal override bool UpdateViewModel<S, O>(StateDescriptor<S, O> state)
        {
            throw new NotImplementedException();
        }
    }
}
