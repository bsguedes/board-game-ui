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

        private void PlayerZone_ActionSelected(ViewModels.RowModel slot)
        {
            _viewModel.SelectTurnAction(slot);
        }

        private void Stage_StageActionSelected(CEDieOption dieOption, bool reroll)
        {
            _viewModel.StageAction(dieOption, reroll);
        }

        private void BlindDraw_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.BlindDrawCardFromDeck();
        }

        private void PlayerZone_CardSelected(CECard card)
        {
            _viewModel.UseCardFromHand(card);
        }

        private void PlayerZone_RowSelected(RowResource row)
        {
            _viewModel.RowSelected(row);
        }

        private void PlayCardCost_PaidTalents(CETalentDescriptor paidTalents)
        {
            _viewModel.PayTalents(paidTalents);
        }

        private void ContractCard_Click(object sender, RoutedEventArgs e)
        {
            dynamic button = sender;
            CECard card = button.Content.CardObject;
            _viewModel.TakeCardFromContract(card);
        }

        private void PlayerZone_MoneyAddedToCard(CECard card)
        {
            _viewModel.CardOnBoardClicked(card);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CancelOptionalCost();
        }

        private void DiscardTalent_TalentChosen(string talent)
        {
            _viewModel.DiscardTalent(talent);
        }
    }
}
