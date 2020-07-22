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

namespace BoardGameClient.CE.Controls
{
    /// <summary>
    /// Interaction logic for Stage.xaml
    /// </summary>
    public partial class Stage : UserControl
    {
        public Stage()
        {
            InitializeComponent();
        }

        public CEStageDescriptor CurrentStage
        {
            get { return (CEStageDescriptor)GetValue(CurrentStageProperty); }
            set { SetValue(CurrentStageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentStage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentStageProperty =
            DependencyProperty.Register("CurrentStage", typeof(CEStageDescriptor), typeof(Stage), new PropertyMetadata(new CEStageDescriptor()));
    }


}
