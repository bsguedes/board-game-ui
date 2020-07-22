using BoardGameClient.CE.Model;
using System.Windows;
using System.Windows.Controls;

namespace BoardGameClient.CE.Controls
{
    public partial class BonusCardMini : UserControl
    {
        public BonusCardMini()
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
            DependencyProperty.Register("BonusCardObject", typeof(CEBonusCard), typeof(BonusCardMini), new PropertyMetadata(null));



    }
}
