using BoardGameClient.CE.Options;
using BoardGameClient.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BoardGameClient.CE
{
    public class CEGame : Game
    {
        public override string Name => "Classificação Etária";

        private CEViewModel _model;

        protected override IBoardGameOptionsView BuildOptionsView()
        {
            return new CEOptionsView();
        }

        protected override ViewModelBase CreateGameViewModel(MatchDescriptor match)
        {
            _model = new CEViewModel(match);
            return _model;            
        }

        protected override Window CreateGameWindow()
        {
            return new CEView(_model);
        }
    }
}
