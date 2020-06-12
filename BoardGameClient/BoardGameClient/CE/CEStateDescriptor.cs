using System;
using System.Collections.Generic;
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
    }

    public class CEStageDescriptor
    {
        public string[] OnStage { get; set; }
        public int OffStage { get; set; }
        public bool CanReroll { get; set; }
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
    }

    public class CETalentDescriptor
    {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int X3 { get; set; }
        public int X4 { get; set; }
        public int X5 { get; set; }
    }

}
