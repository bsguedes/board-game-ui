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


        public string CashResourcesText
        {
            get { return (string)GetValue(CashResourcesTextProperty); }
            set { SetValue(CashResourcesTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CashResourcesText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CashResourcesTextProperty =
            DependencyProperty.Register("CashResourcesText", typeof(string), typeof(CardMini), new PropertyMetadata(null));


        public string CardsTalentsResourcesText
        {
            get { return (string)GetValue(CardsTalentsResourcesTextProperty); }
            set { SetValue(CardsTalentsResourcesTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CardsTalentsResourcesText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardsTalentsResourcesTextProperty =
            DependencyProperty.Register("CardsTalentsResourcesText", typeof(string), typeof(CardMini), new PropertyMetadata(null));

    }
}
