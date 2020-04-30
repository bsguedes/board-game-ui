using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameClient
{
    public abstract class GameViewModelBase : ViewModelBase
    {
        protected int LastState { get; private set; }
        protected MatchDescriptor Match { get; private set; }
        internal bool MatchEnded { get; private set; }
        internal bool PollingCancelled { get; set; }

        protected GameViewModelBase(MatchDescriptor match)
        {
            LastState = -1;
            Match = match;
        }

        internal async void StartPollingState<S, O>()
            where S : GameStateDescriptor
            where O : GameOptionsDescriptor
        {
            while (true)
            {
                await GetStateFromServer<S, O>();
                if (PollingCancelled || MatchEnded)
                {
                    break;
                }
                await Task.Delay(1000);
            }
        }

        protected async Task GetStateFromServer<S, O>()
            where S : GameStateDescriptor
            where O : GameOptionsDescriptor
        {
            StateDescriptor<S, O> state = await GameLoader.Instance.LoadStateForPlayer<S, O>(GameLoader.Instance.CurrentMatchID, GameLoader.Instance.Player.Secret);
            if (state.StateNo != LastState)
            {
                MatchEnded = UpdateViewModel(state);
                LastState = state.StateNo;
            }
        }

        internal async Task<bool> SelectOption(string optionCode)
        {
            PlayerDescriptor response = await GameLoader.Instance.SelectOption(optionCode);
            return response.ValidMove;
        }

        internal abstract bool UpdateViewModel<S, O>(StateDescriptor<S, O> state)
            where S : GameStateDescriptor
            where O : GameOptionsDescriptor;
    }
}
