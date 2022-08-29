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

namespace BoardGameClient.CE.Controls
{
    /// <summary>
    /// Interaction logic for Stage.xaml
    /// </summary>
    public partial class Stage : UserControl
    {
        public Stage()
        {
            InitializeComponent();
        }

        public delegate void StageActionSelectedHandler(CEDieOption dieOption, bool reroll);
        public event StageActionSelectedHandler StageActionSelected;

        public CEStageDescriptor CurrentStage
        {
            get { return (CEStageDescriptor)GetValue(CurrentStageProperty); }
            set { SetValue(CurrentStageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentStage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentStageProperty =
            DependencyProperty.Register("CurrentStage", typeof(CEStageDescriptor), typeof(Stage), new PropertyMetadata(new CEStageDescriptor()));


        public bool CanReroll
        {
            get { return (bool)GetValue(CanRerollProperty); }
            set { SetValue(CanRerollProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanReroll.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanRerollProperty =
            DependencyProperty.Register("CanReroll", typeof(bool), typeof(Stage), new PropertyMetadata(false));


        public bool CanTakeDice
        {
            get { return (bool)GetValue(CanTakeDiceProperty); }
            set { SetValue(CanTakeDiceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanTakeDice.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanTakeDiceProperty =
            DependencyProperty.Register("CanTakeDice", typeof(bool), typeof(Stage), new PropertyMetadata(false));

        private void Reroll_Dice(object sender, RoutedEventArgs e)
        {
            StageActionSelected?.Invoke(null, true);
        }

        private void Die_Taken(object sender, RoutedEventArgs e)
        {
            dynamic button = sender;
            CEDieOption dieOption = button.Tag;
            StageActionSelected?.Invoke(dieOption, false);
        }
    }


}
