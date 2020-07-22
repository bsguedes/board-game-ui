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

namespace BoardGameClient.Common
{
    public partial class ActivationButton : Button
    {
        public ActivationButton()
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
            DependencyProperty.Register("IsLocked", typeof(bool), typeof(ActivationButton), new PropertyMetadata(false));


        public bool CanBeClicked
        {
            get { return (bool)GetValue(CanBeClickedProperty); }
            set { SetValue(CanBeClickedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanBeClicked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanBeClickedProperty =
            DependencyProperty.Register("CanBeClicked", typeof(bool), typeof(ActivationButton), new PropertyMetadata(false));



        public bool HideWhenUnclickable
        {
            get { return (bool)GetValue(HideWhenUnclickableProperty); }
            set { SetValue(HideWhenUnclickableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HideWhenUnclickable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HideWhenUnclickableProperty =
            DependencyProperty.Register("HideWhenUnclickable", typeof(bool), typeof(ActivationButton), new PropertyMetadata(false));



        protected override void OnClick()
        {
            if (CanBeClicked)
            {
                base.OnClick();
            }
        }
    }
}
