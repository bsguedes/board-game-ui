using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoardGameClient.Common
{
    public partial class ActivationToggleButton : ToggleButton
    {
        public ActivationToggleButton()
        {
            InitializeComponent();
        }

        public bool IsLocked
        {
            get { return (bool)GetValue(IsLockedProperty); }
            set { SetValue(IsLockedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLocked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLockedProperty =
            DependencyProperty.Register("IsLocked", typeof(bool), typeof(ActivationToggleButton), new PropertyMetadata(false));



        public Brush BackgroundColorWhenChecked
        {
            get { return (Brush)GetValue(BackgroundColorWhenCheckedProperty); }
            set { SetValue(BackgroundColorWhenCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundColorWhenChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundColorWhenCheckedProperty =
            DependencyProperty.Register("BackgroundColorWhenChecked", typeof(Brush), typeof(ActivationToggleButton), new PropertyMetadata(Brushes.Transparent));



        public double OpacityWhenUnchecked
        {
            get { return (double)GetValue(OpacityWhenUncheckedProperty); }
            set { SetValue(OpacityWhenUncheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpacityWhenUnchecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpacityWhenUncheckedProperty =
            DependencyProperty.Register("OpacityWhenUnchecked", typeof(double), typeof(ActivationToggleButton), new PropertyMetadata(0.5));




        public bool CanBeClicked
        {
            get { return (bool)GetValue(CanBeClickedProperty); }
            set { SetValue(CanBeClickedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanBeClicked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanBeClickedProperty =
            DependencyProperty.Register("CanBeClicked", typeof(bool), typeof(ActivationToggleButton), new PropertyMetadata(false));


        protected override void OnChecked(RoutedEventArgs e)
        {
            if (CanBeClicked)
            {
                base.OnChecked(e);
            }
        }

        protected override void OnUnchecked(RoutedEventArgs e)
        {
            if (CanBeClicked)
            {
                base.OnUnchecked(e);
            }
        }
    }
}
