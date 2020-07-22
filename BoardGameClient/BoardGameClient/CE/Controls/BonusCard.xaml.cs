using BoardGameClient.CE.Model;
using System.Windows;
using System.Windows.Controls;

namespace BoardGameClient.CE.Controls
{
    public partial class BonusCard : UserControl
    {
        public BonusCard()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        public CEBonusCard BonusCardObject
        {
            get { return (CEBonusCard)GetValue(BonusCardObjectProperty); }
            set { SetValue(BonusCardObjectProperty, value); }
        }

        public static readonly DependencyProperty BonusCardObjectProperty =
            DependencyProperty.Register("BonusCardObject", typeof(CEBonusCard), typeof(BonusCard), new PropertyMetadata(null));



    }
}
