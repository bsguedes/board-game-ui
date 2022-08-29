using BoardGameClient.CE.Model;
using BoardGameClient.CE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
    /// Interaction logic for ProgrammingRow.xaml
    /// </summary>
    public partial class ProgrammingRow : UserControl
    {
        readonly ProgrammingRowViewModel _viewModel;

        public delegate void ActionSelectedEventHandler(RowModel slot);
        public event ActionSelectedEventHandler ActionSelected;

        public delegate void RowSelectedEventHandler(RowResource row);
        public event RowSelectedEventHandler RowSelected;

        public delegate void MoneyAddedToCardEventHandler(CECard card);
        public event MoneyAddedToCardEventHandler MoneyAddedToCard;

        public event MouseOverCardHandler MouseOverCard;
        public event MouseOutOfCardHandler MouseOffCard;

        public ProgrammingRow()
        {
            _viewModel = new ProgrammingRowViewModel();
            InitializeComponent();
            FirstColumn.DataContext = this;
        }

        public CEBoardSlotDescriptor[] Cards
        {
            get { return (CEBoardSlotDescriptor[])GetValue(CardsProperty); }
            set { SetValue(CardsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Cards.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardsProperty =
            DependencyProperty.Register("Cards", typeof(CEBoardSlotDescriptor[]), typeof(ProgrammingRow), new PropertyMetadata(new CEBoardSlotDescriptor[] { }));


        public RowResource RowResource
        {
            get { return (RowResource)GetValue(RowResourceProperty); }
            set { SetValue(RowResourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RowResource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RowResourceProperty =
            DependencyProperty.Register("RowResource", typeof(RowResource), typeof(ProgrammingRow), new PropertyMetadata(RowResource.Talents));


        public string StateName
        {
            get { return (string)GetValue(StateNameProperty); }
            set { SetValue(StateNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StateName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StateNameProperty =
            DependencyProperty.Register("StateName", typeof(string), typeof(ProgrammingRow), new PropertyMetadata(string.Empty));


        public IEnumerable<CEOptionDescriptor> CurrentOptions
        {
            get { return (IEnumerable<CEOptionDescriptor>)GetValue(CurrentOptionsProperty); }
            set { SetValue(CurrentOptionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentOptions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentOptionsProperty =
            DependencyProperty.Register("CurrentOptions", typeof(IEnumerable<CEOptionDescriptor>), typeof(ProgrammingRow), new PropertyMetadata(null));

        private void ActivationButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic button = sender;
            RowModel rowModel = button.Content.Tag;
            ActionSelected?.Invoke(rowModel);
        }

        private void Row_Click(object sender, RoutedEventArgs e)
        {
            RowSelected?.Invoke(RowResource);
        }

        private void Card_Click(object sender, RoutedEventArgs e)
        {
            dynamic button = sender;
            RowModel rowModel = button.Content.Tag;
            MoneyAddedToCard?.Invoke(rowModel.Card);
        }

        private void Card_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is CardMini card)
            {
                MouseOverCard?.Invoke(card.CardObject, null);
            }
        }

        private void Card_MouseLeave(object sender, MouseEventArgs e)
        {
            MouseOffCard?.Invoke();
        }
    }

    public enum RowResource
    {
        Talents,
        Cash,
        Cards
    }

    public static class ProgrammingRowCommon
    {
        public static Dictionary<RowResource, string> RowResourceAction = new Dictionary<RowResource, string>()
        {
            { RowResource.Cards, "RecruitAttractions" },
            { RowResource.Cash, "ShowAds" },
            { RowResource.Talents, "TalentHunt" },
        };

        public static Dictionary<RowResource, string> RowResourceLevel = new Dictionary<RowResource, string>()
        {
            { RowResource.Cards, "Bot" },
            { RowResource.Cash, "Mid" },
            { RowResource.Talents, "Top" },
        };
    }
}
