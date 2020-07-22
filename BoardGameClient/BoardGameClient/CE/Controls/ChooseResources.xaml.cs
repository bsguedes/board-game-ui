using BoardGameClient.CE.Model;
using BoardGameClient.CE.ViewModels;
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
    /// Interaction logic for ChooseResources.xaml
    /// </summary>
    public partial class ChooseResources : UserControl
    {
        readonly ChooseResourcesViewModel _viewModel;

        public delegate void ResourcesTakenEventHandler(IEnumerable<CETalent> talents, IEnumerable<CECard> cards, CEBonusCard bonusCard);

        public event ResourcesTakenEventHandler ResourcesTaken;
        public event MouseOverCardHandler MouseOverCard;
        public event MouseOutOfCardHandler MouseOffCard;

        public ChooseResources()
        {
            _viewModel = new ChooseResourcesViewModel();
            InitializeComponent();
            ActivationButton.DataContext = _viewModel;
            TalentListControl.DataContext = _viewModel;
        }

        public IEnumerable<CECard> CardList
        {
            get { return (IEnumerable<CECard>)GetValue(CardListProperty); }
            set { SetValue(CardListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CardList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardListProperty =
            DependencyProperty.Register("CardList", typeof(IEnumerable<CECard>), typeof(ChooseResources), new PropertyMetadata(null));

        public IEnumerable<CEBonusCard> BonusCardList
        {
            get { return (IEnumerable<CEBonusCard>)GetValue(BonusCardListProperty); }
            set { SetValue(BonusCardListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BonusCardList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BonusCardListProperty =
            DependencyProperty.Register("BonusCardList", typeof(IEnumerable<CEBonusCard>), typeof(ChooseResources), new PropertyMetadata(null));

        private void ActivationToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            dynamic button = sender;
            bool isBonus = button.Content is BonusCardMini;
            _viewModel.ChangeObjectsAndBonus(isBonus ? 0 : 1, isBonus ? 1 : 0);
        }

        private void ActivationToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            dynamic button = sender;
            bool isBonus = button.Content is BonusCardMini;
            _viewModel.ChangeObjectsAndBonus(isBonus ? 0 : -1, isBonus ? -1 : 0);
        }

        private void ActivationButton_Click(object sender, RoutedEventArgs e)
        {
            ResourcesTaken?.Invoke(_viewModel.TalentList.Where(x => x.IsSelected), CardList.Where(x => x.IsSelected), BonusCardList.First(x => x.IsSelected));
        }

        private void Card_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is CardMini card)
            {
                MouseOverCard?.Invoke(card.CardObject, null);
            }
            else if (sender is BonusCardMini bonusCard)
            {
                MouseOverCard?.Invoke(null, bonusCard.BonusCardObject);
            }
        }

        private void Card_MouseLeave(object sender, MouseEventArgs e)
        {
            MouseOffCard?.Invoke();
        }
    }    
}
