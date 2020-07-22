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
    public partial class TopBar : UserControl
    {
        public TopBar()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        public string ChannelName
        {
            get { return (string)GetValue(ChannelNameProperty); }
            set { SetValue(ChannelNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChannelName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChannelNameProperty =
            DependencyProperty.Register("ChannelName", typeof(string), typeof(TopBar), new PropertyMetadata(string.Empty));



        public string ChampionName
        {
            get { return (string)GetValue(ChampionNameProperty); }
            set { SetValue(ChampionNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChampionName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChampionNameProperty =
            DependencyProperty.Register("ChampionName", typeof(string), typeof(TopBar), new PropertyMetadata(string.Empty));


    }

}
