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
using static BoardGameClient.CE.Controls.Hand;
using static BoardGameClient.CE.Controls.ProgrammingRow;

namespace BoardGameClient.CE.Controls
{
    public partial class PlayerZone : UserControl
    {
        public PlayerZone()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        public event MouseOverCardHandler MouseOverCard;
        public event MouseOutOfCardHandler MouseOffCard;
        public event ActionSelectedEventHandler ActionSelected;
        public event CardSelectedFromHandEventHandler CardSelected;
        public event RowSelectedEventHandler RowSelected;
        public event MoneyAddedToCardEventHandler MoneyAddedToCard;

        public CEPlayerDescriptor Player
        {
            get { return (CEPlayerDescriptor)GetValue(PlayerProperty); }
            set { SetValue(PlayerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Player.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerProperty =
            DependencyProperty.Register("Player", typeof(CEPlayerDescriptor), typeof(PlayerZone), new PropertyMetadata(new CEPlayerDescriptor()));


        public IEnumerable<CEOptionDescriptor> CurrentOptions
        {
            get { return (IEnumerable<CEOptionDescriptor>)GetValue(CurrentOptionsProperty); }
            set { SetValue(CurrentOptionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentOptions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentOptionsProperty =
            DependencyProperty.Register("CurrentOptions", typeof(IEnumerable<CEOptionDescriptor>), typeof(PlayerZone), new PropertyMetadata(null));


        public string StateName
        {
            get { return (string)GetValue(StateNameProperty); }
            set { SetValue(StateNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StateName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StateNameProperty =
            DependencyProperty.Register("StateName", typeof(string), typeof(PlayerZone), new PropertyMetadata(string.Empty));


        public bool CanUpgradeChampion
        {
            get { return (bool)GetValue(CanUpgradeChampionProperty); }
            set { SetValue(CanUpgradeChampionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanUpgradeChampion.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanUpgradeChampionProperty =
            DependencyProperty.Register("CanUpgradeChampion", typeof(bool), typeof(PlayerZone), new PropertyMetadata(false));

        private void Hand_MouseOverCard(Model.CECard card, Model.CEBonusCard bonusCard)
        {
            MouseOverCard?.Invoke(card, bonusCard);
        }

        private void Hand_MouseOffCard()
        {
            MouseOffCard?.Invoke();
        }

        private void ProgrammingRow_ActionSelected(RowModel slot)
        {
            ActionSelected?.Invoke(slot);
        }

        private void Hand_CardSelected(Model.CECard card)
        {
            CardSelected?.Invoke(card);
        }

        private void ProgrammingRow_RowSelected(RowResource row)
        {
            RowSelected?.Invoke(row);
        }

        private void ProgrammingRow_MoneyAddedToCard(Model.CECard card)
        {
            MoneyAddedToCard?.Invoke(card);            
        }
    }
}
