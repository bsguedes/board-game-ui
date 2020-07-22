using BoardGameClient.CE.Controls;
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
using System.Windows.Shapes;

namespace BoardGameClient.CE
{
    public partial class CEView : Window
    {
        private readonly CEViewModel _viewModel;
        public delegate void MouseOverCardHandler(CECard card, CEBonusCard bonusCard);
        public delegate void MouseOutOfCardHandler();

        public CEView(CEViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            this._viewModel = vm;
        }

        private void ChooseResources_ResourcesTaken(IEnumerable<CETalent> talents, IEnumerable<CECard> cards, CEBonusCard bonusCard)
        {
            _viewModel.ChooseResources(talents, cards, bonusCard);
        }

        private void PlayerZone_MouseOverCard(CECard card, CEBonusCard bonusCard)
        {
            PlayerZone_MouseOutOfCard();
            if (card != null)
            {
                _viewModel.SelectedCard = card;
            }
            if (bonusCard != null)
            {
                _viewModel.SelectedBonusCard = bonusCard;
            }
        }

        private void PlayerZone_MouseOutOfCard()
        {
            _viewModel.SelectedCard = null;
            _viewModel.SelectedBonusCard = null;
        }

        private void CardMini_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is CardMini card)
            {
                PlayerZone_MouseOverCard(card.CardObject, null);
            }
            else if (sender is BonusCardMini bonusCard)
            {
                PlayerZone_MouseOverCard(null, bonusCard.BonusCardObject);
            }
        }

        private void CardMini_MouseLeave(object sender, MouseEventArgs e)
        {
            PlayerZone_MouseOutOfCard();
        }
    }
}
