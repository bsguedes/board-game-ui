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
    /// Interaction logic for AbilityBox.xaml
    /// </summary>
    public partial class AbilityBox : UserControl
    {
        public AbilityBox()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        public string AbilityType
        {
            get { return (string)GetValue(AbilityTypeProperty); }
            set { SetValue(AbilityTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AbilityType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AbilityTypeProperty =
            DependencyProperty.Register("AbilityType", typeof(string), typeof(AbilityBox), new PropertyMetadata("Nada"));


        public string AbilityText
        {
            get { return (string)GetValue(AbilityTextProperty); }
            set { SetValue(AbilityTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AbilityText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AbilityTextProperty =
            DependencyProperty.Register("AbilityText", typeof(string), typeof(AbilityBox), new PropertyMetadata("N/A"));



        public int BoxFontSize
        {
            get { return (int)GetValue(BoxFontSizeProperty); }
            set { SetValue(BoxFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BoxFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BoxFontSizeProperty =
            DependencyProperty.Register("BoxFontSize", typeof(int), typeof(AbilityBox), new PropertyMetadata(12));
        

    }
}
