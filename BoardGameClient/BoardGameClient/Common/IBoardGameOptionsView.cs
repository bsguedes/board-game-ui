using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BoardGameClient.Common
{
    public interface IBoardGameOptionsView
    {
        UserControl AsUserControl();
        OptionsBase GetOptions();
        ViewModelBase ViewModel { get; }
    }
}
