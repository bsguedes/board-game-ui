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
    public partial class PlayCardCost : UserControl
    {
        readonly PlayCardCostViewModel _viewModel;

        public delegate void PaidTalentsEventHandler(CETalentDescriptor paidTalents);
        public event PaidTalentsEventHandler PaidTalents;

        public PlayCardCost()
        {
            _viewModel = new PlayCardCostViewModel();
            InitializeComponent();
            LayoutRoot.DataContext = _viewModel;
        }

        public CEPayTalentCostDescriptor[] Cost
        {
            get { return (CEPayTalentCostDescriptor[])GetValue(CostProperty); }
            set { SetValue(CostProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Cost.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CostProperty =
            DependencyProperty.Register("Cost", typeof(CEPayTalentCostDescriptor[]), typeof(PlayCardCost), new PropertyMetadata(new CEPayTalentCostDescriptor[] { }));


        public CETalentDescriptor Talents
        {
            get { return (CETalentDescriptor)GetValue(TalentsProperty); }
            set { SetValue(TalentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Talents.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TalentsProperty =
            DependencyProperty.Register("Talents", typeof(CETalentDescriptor), typeof(PlayCardCost), new PropertyMetadata(null));


        private void ActivationButton_Click(object sender, RoutedEventArgs e)
        {            
            PaidTalents?.Invoke(_viewModel.PaidCost);
            _viewModel.ResetControl();
        }

        private void IntegerUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            _viewModel.UpdateStatus(Cost, Talents);
        }

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            _viewModel.Increase((string)b.Tag, Talents);
        }
    }    
}
