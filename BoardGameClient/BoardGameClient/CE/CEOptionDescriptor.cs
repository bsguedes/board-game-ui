using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameClient.CE
{
    public class CEOptionDescriptor : GameOptionsDescriptor
    {
        public string Action { get; set; }

        /* CEChooseResources */
        public int BonusCard { get; set; }
        public int[] Cards { get; set; }
        public string[] Talents { get; set; }

        /* CEDrawCard */
        public int Card { get; set; }

        /* CEDrawCardPayingMoney */
        public int CashOrigin { get; set; }

        /* CEEarnMoneyPayingTalent */
        public string Talent { get; set; }

        /* CEPlayCardUpgradeChampion */
        public int CardCost { get; set; }
        public int CashCost { get; set; }
        public string[] TalentCost { get; set; }

        /* CETakeTalent */
        public string Die { get; set; }

        /* CEPlayerTurn */
        public int CashCount { get; set; }
        public int CardCount { get; set; }
        public int TalentCount { get; set; }
        public int Optional { get; set; }
        public int Position { get; set; }
        public CEPlayableCardOption PlayableCard { get; set; }
    }

    public class CEPlayableCardOption
    {
        public int ID { get; set; }
        public string Row { get; set; }
        public int CashCost { get; set; }
        public string[] TalentCost { get; set; }
    }
}
