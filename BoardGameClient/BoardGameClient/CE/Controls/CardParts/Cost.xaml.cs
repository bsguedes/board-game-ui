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

namespace BoardGameClient.CE.Controls.CardParts
{
    /// <summary>
    /// Interaction logic for Cost.xaml
    /// </summary>
    public partial class Cost : UserControl
    {
        public Cost()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        public int ValidProgrammingRows
        {
            get { return (int)GetValue(ValidProgrammingRowsProperty); }
            set { SetValue(ValidProgrammingRowsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ValidProgrammingRows.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValidProgrammingRowsProperty =
            DependencyProperty.Register("ValidProgrammingRows", typeof(int), typeof(Cost), new PropertyMetadata(1));


        public string TalentString
        {
            get { return (string)GetValue(TalentStringProperty); }
            set { SetValue(TalentStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TalentString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TalentStringProperty =
            DependencyProperty.Register("TalentString", typeof(string), typeof(Cost), new PropertyMetadata(string.Empty));


    }
}
