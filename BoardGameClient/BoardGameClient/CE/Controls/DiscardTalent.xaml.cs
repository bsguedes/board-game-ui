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
    /// Interaction logic for DiscardTalent.xaml
    /// </summary>
    public partial class DiscardTalent : UserControl
    {
        public delegate void TalentDiscardedEventHandler(string talent);
        public event TalentDiscardedEventHandler TalentDiscarded;

        public DiscardTalent()
        {
            InitializeComponent();
        }

        public CETalentDescriptor Talents
        {
            get { return (CETalentDescriptor)GetValue(TalentsProperty); }
            set { SetValue(TalentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Talents.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TalentsProperty =
            DependencyProperty.Register("Talents", typeof(CETalentDescriptor), typeof(DiscardTalent), new PropertyMetadata(null));

        private void SelectTalent_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            TalentDiscarded?.Invoke((string)b.Tag);
        }
    }    
}
