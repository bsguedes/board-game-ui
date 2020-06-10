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
using System.Windows.Shapes;

namespace BoardGameClient.CE
{
    public partial class CEView : Window
    {
        private readonly CEViewModel _viewModel;

        public CEView(CEViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            this._viewModel = vm;
        }
    }
}
