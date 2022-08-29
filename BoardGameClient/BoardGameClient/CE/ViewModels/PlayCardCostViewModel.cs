using BoardGameClient.CE.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameClient.CE.ViewModels
{
    public class PlayCardCostViewModel : ViewModelBase
    {
        public PlayCardCostViewModel()
        {

        }

        private bool _IsValidConfiguration;
        public bool IsValidConfiguration
        {
            get { return _IsValidConfiguration; }
            set { SetProperty(ref _IsValidConfiguration, value); }
        }


        private int _PayX1;
        public int PayX1
        {
            get { return _PayX1; }
            set { SetProperty(ref _PayX1, value); }
        }

        private int _PayX2;
        public int PayX2
        {
            get { return _PayX2; }
            set { SetProperty(ref _PayX2, value); }
        }

        private int _PayX3;
        public int PayX3
        {
            get { return _PayX3; }
            set { SetProperty(ref _PayX3, value); }
        }

        private int _PayX4;
        public int PayX4
        {
            get { return _PayX4; }
            set { SetProperty(ref _PayX4, value); }
        }

        private int _PayX5;
        public int PayX5
        {
            get { return _PayX5; }
            set { SetProperty(ref _PayX5, value); }
        }

        public CETalentDescriptor PaidCost 
        { 
            get
            {
                return new CETalentDescriptor
                {
                    X1 = PayX1,
                    X2 = PayX2,
                    X3 = PayX3,
                    X4 = PayX4,
                    X5 = PayX5,
                };
            }
        }

        public void UpdateStatus(CEPayTalentCostDescriptor[] cost, CETalentDescriptor max_talents)
        {
            if (max_talents == null)
            {
                IsValidConfiguration = false;
                return;
            }
            List<string> talents = new List<string>();
            for (int i = 0; i < PayX1; i++)
            {
                talents.Add("X1");
            }
            for (int i = 0; i < PayX2; i++)
            {
                talents.Add("X2");
            }
            for (int i = 0; i < PayX3; i++)
            {
                talents.Add("X3");
            }
            for (int i = 0; i < PayX4; i++)
            {
                talents.Add("X4");
            }
            for (int i = 0; i < PayX5; i++)
            {
                talents.Add("X5");
            }

            if (cost.Any(x => x.Cost < 1 && x.Cost > 0))
            {
                IsValidConfiguration = (talents.Count == 1 && cost.FirstOrDefault(x => x.Cost > 0 && x.Talent == talents[0]) != null) ||
                    (talents.Count == 2 && cost.FirstOrDefault(x => x.Cost > 0 && x.Talent == talents[0]) == null && cost.FirstOrDefault(x => x.Cost > 0 && x.Talent == talents[1]) == null);
            }
            else if (cost.Any(x => x.Cost >= 1))
            {
                List<string> card_cost = new List<string>();
                foreach (CEPayTalentCostDescriptor item in cost)
                {
                    for (int i = 0; i < (int)item.Cost; i++)
                    {
                        card_cost.Add(item.Talent);
                    }
                }
                List<string> commons = new List<string>();
                foreach (string talent in talents)
                {
                    if (card_cost.Contains(talent))
                    {
                        card_cost.Remove(talent);
                        commons.Add(talent);
                    }
                }
                foreach (string talent in commons)
                {
                    talents.Remove(talent);
                }
                if (talents.Any(x => card_cost.Contains(x)))
                {
                    IsValidConfiguration = false;
                }
                else
                {
                    int joker_count = cost.Where(x => x.Talent == "X").Select(x => (int)x.Cost).Sum();
                    IsValidConfiguration = 2 * card_cost.Count - joker_count == talents.Count;
                }
            }
            else
            {
                IsValidConfiguration = true;
            }
            IsValidConfiguration = IsValidConfiguration && PayX1 <= max_talents.X1 && PayX2 <= max_talents.X2 && PayX3 <= max_talents.X3 && PayX4 <= max_talents.X4 && PayX5 <= max_talents.X5;
        }

        internal void Increase(string talent, CETalentDescriptor max_talents)
        {
            if (talent == "X1" && PayX1 < max_talents.X1)
            {
                PayX1++;
            }
            else if (talent == "X2" && PayX2 < max_talents.X2)
            {
                PayX2++;
            }
            else if (talent == "X3" && PayX3 < max_talents.X3)
            {
                PayX3++;
            }
            else if (talent == "X4" && PayX4 < max_talents.X4)
            {
                PayX4++;
            }
            else if (talent == "X5" && PayX5 < max_talents.X5)
            {
                PayX5++;
            }
        }

        internal void ResetControl()
        {
            PayX1 = 0;
            PayX2 = 0;
            PayX3 = 0;
            PayX4 = 0;
            PayX5 = 0;
        }
    }
}
