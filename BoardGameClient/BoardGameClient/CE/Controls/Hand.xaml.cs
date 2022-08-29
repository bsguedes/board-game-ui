using BoardGameClient.CE.Model;
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
using static BoardGameClient.CE.CEView;

namespace BoardGameClient.CE.Controls
{
    /// <summary>
    /// Interaction logic for Hand.xaml
    /// </summary>
    public partial class Hand : UserControl
    {
        public Hand()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        public delegate void CardSelectedFromHandEventHandler(CECard card);
        public event CardSelectedFromHandEventHandler CardSelected;

        public string StateName
        {
            get { return (string)GetValue(StateNameProperty); }
            set { SetValue(StateNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StateName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StateNameProperty =
            DependencyProperty.Register("StateName", typeof(string), typeof(Hand), new PropertyMetadata(string.Empty));



        public IEnumerable<CEOptionDescriptor> CurrentOptions
        {
            get { return (IEnumerable<CEOptionDescriptor>)GetValue(CurrentOptionsProperty); }
            set { SetValue(CurrentOptionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentOptions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentOptionsProperty =
            DependencyProperty.Register("CurrentOptions", typeof(IEnumerable<CEOptionDescriptor>), typeof(Hand), new PropertyMetadata(null));



        public IEnumerable<CECard> CardList
        {
            get { return (IEnumerable<CECard>)GetValue(CardListProperty); }
            set { SetValue(CardListProperty, value); }
        }

        public static readonly DependencyProperty CardListProperty =
            DependencyProperty.Register("CardList", typeof(IEnumerable<CECard>), typeof(Hand), new PropertyMetadata(null));

        public IEnumerable<CEBonusCard> BonusCardList
        {
            get { return (IEnumerable<CEBonusCard>)GetValue(BonusCardListProperty); }
            set { SetValue(BonusCardListProperty, value); }
        }

        public static readonly DependencyProperty BonusCardListProperty =
            DependencyProperty.Register("BonusCardList", typeof(IEnumerable<CEBonusCard>), typeof(Hand), new PropertyMetadata(null));

        public event MouseOverCardHandler MouseOverCard;
        public event MouseOutOfCardHandler MouseOffCard;

        public CETalentDescriptor Talents
        {
            get { return (CETalentDescriptor)GetValue(TalentsProperty); }
            set { SetValue(TalentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Talents.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TalentsProperty =
            DependencyProperty.Register("Talents", typeof(CETalentDescriptor), typeof(Hand), new PropertyMetadata(null));


        private void CardMedium_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is CardMedium card)
            {
                MouseOverCard?.Invoke(card.CardObject, null);
            } 
            else if (sender is BonusCardMini bonusCard)
            {
                MouseOverCard?.Invoke(null, bonusCard.BonusCardObject);
            }
        }

        private void CardMedium_MouseLeave(object sender, MouseEventArgs e)
        {
            MouseOffCard?.Invoke();
        }

        private void SelectCard_Click(object sender, RoutedEventArgs e)
        {
            dynamic button = sender;
            CECard card = button.Content.CardObject;
            CardSelected?.Invoke(card);
        }
    }
}
