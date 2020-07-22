using BoardGameClient.CE.Model;
using System.Windows;
using System.Windows.Controls;

namespace BoardGameClient.CE.Controls
{
    public partial class CardMini : UserControl
    {
        public CardMini()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        public CECard CardObject
        {
            get { return (CECard)GetValue(CardObjectProperty); }
            set { SetValue(CardObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CardObject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardObjectProperty =
            DependencyProperty.Register("CardObject", typeof(CECard), typeof(CardMini), new PropertyMetadata(null));



    }
}
