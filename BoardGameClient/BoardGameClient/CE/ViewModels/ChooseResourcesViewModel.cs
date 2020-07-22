using BoardGameClient.CE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace BoardGameClient.CE.ViewModels
{
    public class ChooseResourcesViewModel : ViewModelBase
    {
        public ChooseResourcesViewModel()
        {
            TalentList = new string[] { "{X1}", "{X2}", "{X3}", "{X4}", "{X5}" }.Select(x => new CETalent { Type = x }).ToArray();
        }

        private bool _IsValidConfiguration;
        public bool IsValidConfiguration
        {
            get { return _IsValidConfiguration; }
            set { SetProperty(ref _IsValidConfiguration, value); }
        }

        int selectedObjects = 0;
        int selectedBonus = 0;

        public void ChangeObjectsAndBonus(int deltaObject, int deltaBonus)
        {
            selectedObjects += deltaObject;
            selectedBonus += deltaBonus;

            IsValidConfiguration = selectedObjects == 5 && selectedBonus == 1;
        }

        private IEnumerable<CETalent> _TalentList;
        public IEnumerable<CETalent> TalentList
        {
            get { return _TalentList; }
            set { SetProperty(ref _TalentList, value); }
        }

    }
}
