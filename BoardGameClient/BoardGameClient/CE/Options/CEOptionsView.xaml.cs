using BoardGameClient.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoardGameClient.CE.Options
{
    public partial class CEOptionsView : UserControl, IBoardGameOptionsView
    {
        private readonly CEOptionsViewModel _CEOptionsViewModel;

        public CEOptionsView()
        {
            InitializeComponent();
            this._CEOptionsViewModel = new CEOptionsViewModel();
            this.DataContext = this._CEOptionsViewModel;
        }

        public OptionsViewModelBase ViewModel => _CEOptionsViewModel;

        public UserControl AsUserControl()
        {
            return this;
        }

        public OptionsBase GetOptions()
        {
            return _CEOptionsViewModel.LoadCurrentOptions();
        }
    }
}
