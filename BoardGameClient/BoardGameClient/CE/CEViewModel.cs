using BoardGameClient.CE.Model;
using BoardGameClient.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameClient.CE
{
    public class CEViewModel : GameViewModelBase
    {
        private static CEVersionData _data = null;
        internal static CEVersionData GameData
        {
            get
            {
                if (_data == null)
                {
                    _data = CEVersionData.Load();
                }
                return (_data);
            }
        }

        OptionsDescriptor<CEOptionDescriptor>[] currentOptions = null;

        public CEViewModel(MatchDescriptor match) 
            : base(match)
        {
            StartPollingState<CEStateDescriptor, CEOptionDescriptor>();
        }

        internal override bool UpdateViewModel<S, O>(StateDescriptor<S, O> state)
        {
            CEStateDescriptor descriptor = state.State as CEStateDescriptor;
            OptionsDescriptor<CEOptionDescriptor>[] options = state.Options as OptionsDescriptor<CEOptionDescriptor>[];
            currentOptions = options;

            Player = descriptor.Player;
            CanUpgradeChampion = options.Any(x => x.Option.Action == "Upgrade");
            CurrentStage = descriptor.Stage;
            Contracts = descriptor.Contracts.Select(x => GameData.Cards.FirstOrDefault(y => y.ID == x));
            CurrentOptions = options.Select(x => x.Option);
            StateName = descriptor.StateName;            

            if (StateName == "ChooseResources")
            {
                CardList = Player.Hand.Select(id => GameData.Cards.First(x => x.ID == id));
                BonusCardList = Player.BonusCards.Select(id => GameData.Bonus.First(x => x.ID == id));
            }

            return false;
        }

        internal async void ChooseResources(IEnumerable<CETalent> talents, IEnumerable<CECard> cards, CEBonusCard bonusCard)
        {
            string optionCode = currentOptions.First(x => x.Option.BonusCard == bonusCard.ID && x.Option.Talents.SequenceEqual(talents.Select(y=> y.NormalizedType)) && x.Option.Cards.SequenceEqual(cards.Select(z => z.ID))).OptionCode;
            if (await SelectOption(optionCode))
            {
                await GetStateFromServer<CEStateDescriptor, CEOptionDescriptor>();
            }
        }


        private CECard _SelectedCard;
        public CECard SelectedCard
        {
            get { return _SelectedCard; }
            set { SetProperty(ref _SelectedCard, value); }
        }

        private CEBonusCard _SelectedBonusCard;
        public CEBonusCard SelectedBonusCard
        {
            get { return _SelectedBonusCard; }
            set { SetProperty(ref _SelectedBonusCard, value); }
        }

        private CEPlayerDescriptor _Player;
        public CEPlayerDescriptor Player
        {
            get { return _Player; }
            set { SetProperty(ref _Player, value); }
        }

        private CEStageDescriptor _CurrentStage;
        public CEStageDescriptor CurrentStage
        {
            get { return _CurrentStage; }
            set { SetProperty(ref _CurrentStage, value); }
        }

        private bool _CanUpgradeChampion;
        public bool CanUpgradeChampion
        {
            get { return _CanUpgradeChampion; }
            set { SetProperty(ref _CanUpgradeChampion, value); }
        }

        private string _StateName;
        public string StateName
        {
            get { return _StateName; }
            set { SetProperty(ref _StateName, value); }
        }

        private IEnumerable<CEOptionDescriptor> _CurrentOptions;
        public IEnumerable<CEOptionDescriptor> CurrentOptions
        {
            get { return _CurrentOptions; }
            set { SetProperty(ref _CurrentOptions, value); }
        }

        private IEnumerable<CECard> _Contracts;
        public IEnumerable<CECard> Contracts
        {
            get { return _Contracts; }
            set { SetProperty(ref _Contracts, value); }
        }

        private IEnumerable<CECard> _CardList;
        public IEnumerable<CECard> CardList
        {
            get { return _CardList; }
            set { SetProperty(ref _CardList, value); }
        }

        private IEnumerable<CEBonusCard> _BonusCardList;
        public IEnumerable<CEBonusCard> BonusCardList
        {
            get { return _BonusCardList; }
            set { SetProperty(ref _BonusCardList, value); }
        }        
    }
}
