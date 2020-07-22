using BoardGameClient.CE.Controls;
using BoardGameClient.CE.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameClient.CE
{
    public class CEStateDescriptor : GameStateDescriptor
    {
        public int DeckCount { get; set; }
        public int[] Contracts { get; set; }
        public int BonusDeckCount { get; set; }
        public int[] ObjectiveBoard { get; set; }
        public CEStageDescriptor Stage { get; set; }
        public CEOpponentDescriptor[] Opponents { get; set; }
        public CEPlayerDescriptor Player { get; set; }

        /* CEPayCards */
        public int Count { get; set; }

        /* CEPayTalents */
        public string[] Talents { get; set; }
    }

    public class CEPlayerDescriptor
    {
        public string Champion { get; set; }
        public CETalentDescriptor Talents { get; set; }
        public int[] Hand { get; set; }
        public CEBoardDescriptor Board { get; set; }
        public int[] BonusCards { get; set; }
        public int Round { get; set; }
        public int Turn { get; set; }

        public ObservableCollection<Model.CEChampion> ChampionLevels => new ObservableCollection<Model.CEChampion>(CEViewModel.GameData.Champions.Where(x => x.Champion == Champion));
        public string ChannelName => CEViewModel.GameData.Champions.FirstOrDefault(x => x.Champion == Champion)?.Channel;
        public CECard[] PlayerCards => Hand?.Select(x => CEViewModel.GameData.Cards.First(c => c.ID == x)).ToArray() ?? new CECard[] { };
        public CEBonusCard[] PlayerBonusCards => BonusCards?.Select(x => CEViewModel.GameData.Bonus.First(c => c.ID == x)).ToArray() ?? new CEBonusCard[] { };
    }

    public class CEStageDescriptor
    {
        public string[] OnStage { get; set; }
        public int OffStage { get; set; }
        public bool CanReroll { get; set; }

        public ObservableCollection<CEDie> Dice => new ObservableCollection<CEDie>(OnStage?.Select(x => new CEDie(x)) ?? new List<CEDie>());
    }

    public class CEOpponentDescriptor
    {
        public string Player { get; set; }
        public string Champion { get; set; }
        public CETalentDescriptor Talents { get; set; }
        public int HandCount { get; set; }
        public CEBoardDescriptor Board { get; set; }
        public int BonusCardCount { get; set; }
        public int Round { get; set; }
        public int Turn { get; set; }
    }

    public class CEBoardDescriptor
    {
        public int ChampionLevel { get; set; }
        public CEBoardSlotDescriptor[] TopRow { get; set; }
        public CEBoardSlotDescriptor[] MidRow { get; set; }
        public CEBoardSlotDescriptor[] BotRow { get; set; }        
    }

    public class CEBoardSlotDescriptor
    {
        public int? Card { get; set; }
        public int Cached { get; set; }
        public int Cash { get; set; }
        public CETalentDescriptor Talents { get; set; }

        public Model.CECard CardObject => CEViewModel.GameData.Cards.FirstOrDefault(x => x.ID == Card);
    }

    public class CETalentDescriptor
    {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int X3 { get; set; }
        public int X4 { get; set; }
        public int X5 { get; set; }
    }

    public class CEDie
    {
        public string Face { get; set; }
        public string[] Options { get; set; }

        public CEDie(string face)
        {
            Face = face;
            Options = face.Split('/').Select(x => $"{{{x}}}").ToArray();
        }
    }

}
