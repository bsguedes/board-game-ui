using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Collections;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using BoardGameClient.CE.Model;
using System.Linq;
using BoardGameClient.CE.ViewModels;
using BoardGameClient.CE.Controls;

namespace BoardGameClient.CE
{    
    public class ProgrammingCodeToImageConverter : BaseImageConverter<int>
    {                   
        public override Bitmap ImageConversion(int value)
        {
            switch (value)
            {
                case 1:
                    return Properties.CEResources.A3cost;
                case 2:
                    return Properties.CEResources.A2cost;
                case 3:
                    return Properties.CEResources.A2A3;
                case 4:
                    return Properties.CEResources.A1cost;
                case 5:
                    return Properties.CEResources.A1A3;
                case 6:
                    return Properties.CEResources.A1A2;
                case 7:
                    return Properties.CEResources.A1A2A3;
                default:
                    return null;
            }
        }
    }

    public class CEToImageConverter : BaseImageConverter<string>
    {        
        public override Bitmap ImageConversion(string value)
        {
            switch (value)
            {
                case "L":
                    return Properties.CEResources.L;
                case "12":
                    return Properties.CEResources._12;
                case "14":
                    return Properties.CEResources._14;
                case "16":
                    return Properties.CEResources._16;
                case "18":
                    return Properties.CEResources._18;
                default:
                    return null;
            }
        }
    }

    public class CEPhotoToImageConverter : BaseImageConverter<string>
    {
        public override Bitmap ImageConversion(string value)
        {
            return (Bitmap)Properties.CEResources.ResourceManager.GetObject(value);
        }
    }

    public class ChannelToImageConverter : BaseImageConverter<string>
    {
        public override Bitmap ImageConversion(string value)
        {
            switch (value)
            {
                case "Globo":
                    return Properties.CEResources.globo;
                case "SBT":
                    return Properties.CEResources.sbt;
                case "Record":
                    return Properties.CEResources.record;
                case "MTV":
                    return Properties.CEResources.mtv;
                case "Band":
                    return Properties.CEResources.band;
                default:
                    return null;
            }
        }
    }

    public class DieToImageConverter : BaseImageConverter<string>
    {
        public override Bitmap ImageConversion(string value)
        {
            switch (value)
            {
                case "X1":
                    return Properties.CEResources.DX1;
                case "X2":
                    return Properties.CEResources.DX2;
                case "X3":
                    return Properties.CEResources.DX3;
                case "X4":
                    return Properties.CEResources.DX4;
                case "X5":
                    return Properties.CEResources.DX5;
                case "X4/X5":
                    return Properties.CEResources.DX4X5;
                default:
                    return null;
            }
        }
    }

    public class ChampionLevelToLockedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int currentLevel = (int)values[0];
            int boardLevel = (int)values[1];
            return currentLevel < boardLevel;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ActionUpgradeToEnabledConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool canUpgradeChampion = (bool)values[0];
            int currentLevel = (int)values[1];
            int boardLevel = (int)values[2];
            return canUpgradeChampion && currentLevel + 1 == boardLevel;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
    public class ChampionToImageConverter : BaseImageConverter<string>
    {
        public override Bitmap ImageConversion(string value)
        {
            switch (value)
            {
                case "Xuxa":
                    return Properties.CEResources.ch04xuxa;
                case "Silvio Santos":
                    return Properties.CEResources.ch_silvio;
                case "Ana Paula Padrão":
                    return Properties.CEResources.ch_ana;
                case "João Gordo":
                    return Properties.CEResources.ch_gordo;
                case "Faustão":
                    return Properties.CEResources.ch_faustao;
                default:
                    return null;
            }
        }
    }

    public class BracketTextToTokenConverter: BaseImageConverter<string>
    {
        public override Bitmap ImageConversion(string value)
        {
            switch (value)
            {
                case "{A1}":
                    return Properties.CEResources.A1;
                case "{A2}":
                    return Properties.CEResources.A2;
                case "{A3}":
                    return Properties.CEResources.A3;
                case "{X1}":
                    return Properties.CEResources.X1;
                case "{X2}":
                    return Properties.CEResources.X2;
                case "{X3}":
                    return Properties.CEResources.X3;
                case "{X4}":
                    return Properties.CEResources.X4;
                case "{X5}":
                    return Properties.CEResources.X5;
                case "{X}":
                    return Properties.CEResources.X;
                case "{L}":
                    return Properties.CEResources.L;
                case "{12}":
                    return Properties.CEResources._12;
                case "{14}":
                    return Properties.CEResources._14;
                case "{16}":
                    return Properties.CEResources._16;
                case "{18}":
                    return Properties.CEResources._18;
                case "{C}":
                    return Properties.CEResources.C;
                case "{D}":
                    return Properties.CEResources.D;
                case "{DN}":
                    return Properties.CEResources.DN;
                case "{I}":
                    return Properties.CEResources.I;
                case "{ra}":
                    return Properties.CEResources.ra;                
                default:
                    return null;
            }
        }
    }

    public class AbilityTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "Quando Ativado":
                    return Colors.DarkGoldenrod;
                case "Permanente":
                    return Colors.Thistle;
                case "Uma Vez Entre Turnos":
                    return Colors.LightPink;
                case "Polêmico":
                    return Colors.Crimson;
                default:
                    return Colors.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public static class TextBlockExtensions
    {
        public static IEnumerable<Inline> GetBindableInlines(DependencyObject obj)
        {
            return (IEnumerable<Inline>)obj.GetValue(BindableInlinesProperty);
        }

        public static void SetBindableInlines(DependencyObject obj, IEnumerable<Inline> value)
        {
            obj.SetValue(BindableInlinesProperty, value);
        }

        public static readonly DependencyProperty BindableInlinesProperty =
            DependencyProperty.RegisterAttached("BindableInlines", typeof(IEnumerable<Inline>), typeof(TextBlockExtensions), new PropertyMetadata(null, OnBindableInlinesChanged));

        private static void OnBindableInlinesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBlock Target)
            {
                Target.Inlines.Clear();
                if (e.NewValue is IEnumerable enumerable)
                {
                    Target.Inlines.AddRange(enumerable);
                }
            }
        }
    }

    public class StateNameToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stateName = (string)parameter;
            string currentState = (string)value;
            return stateName == currentState ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class BaseCanBeClickedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string stateName = (string)values[0];
            IEnumerable<CEOptionDescriptor> options = (IEnumerable<CEOptionDescriptor>)values[1];
            if (stateName == null || options == null || stateName != (string)parameter)
            {
                return false;
            }
            return ConvertBase(values, (string)parameter, stateName, options);
        }

        protected abstract bool ConvertBase(object[] values, string parameter, string stateName, IEnumerable<CEOptionDescriptor> options);

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class CardInHandCanBeClickedConverter : BaseCanBeClickedConverter
    {
        protected override bool ConvertBase(object[] values, string parameter, string stateName, IEnumerable<CEOptionDescriptor> options)
        {
            CECard card = (CECard)values[2];
            CEOptionDescriptor option = options.FirstOrDefault(x => x.Action == "PlayCard" && x.PlayableCard.ID == card.ID);
            return option != null;
        }
    }

    public class BoardSlotCanBeClickedConverter : BaseCanBeClickedConverter
    {
        protected override bool ConvertBase(object[] values, string parameter, string stateName, IEnumerable<CEOptionDescriptor> options)
        {
            RowResource rowResource = (RowResource)values[2];
            int position = (int)values[3];
            CEOptionDescriptor option = options.FirstOrDefault(x => x.Action == ProgrammingRowCommon.RowResourceAction[rowResource] && x.Position == position);
            return option != null;
        }
    }

    public class BoardSlotToRowModelConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            RowResource rowResource = (RowResource)values[1];
            RowModel[] rows = Enumerable.Range(0, 5).Select( x => new RowModel(x, rowResource)).ToArray();            
            CEBoardSlotDescriptor[] slots = (CEBoardSlotDescriptor[])values[0];
            if (slots.Length > 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (slots[i].Card != null)
                    {
                        rows[i] = new RowModel(i, slots[i].CardObject);
                    }
                    else
                    {
                        rows[i] = new RowModel(i, rowResource);
                    }
                }
            }
            return rows;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AbilityTextWithImageSizeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            object abilityText = values[0];
            object symbolSize = values[1];
            return new AbilityTextToInlineCollectionConverter().Convert(abilityText, targetType, symbolSize, culture);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AbilityTextToInlineCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string ability = ((string)value).Replace("}.", "} .").Replace("},", "} ,").Replace("}{", "} {");
            string[] tokens = ability.Split(' ');
            int height = parameter == null ? 15 : int.Parse(parameter.ToString());

            List<string> currentRun = new List<string>();
            List<Inline> col = new List<Inline>();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].Contains("{"))
                {
                    col.Add(new InlineUIContainer(new System.Windows.Controls.Image { 
                        Source = (BitmapImage) new BracketTextToTokenConverter().Convert(tokens[i], typeof(System.Drawing.Image), null, null),
                        Height = height
                    }));
                    col.Add(new Run(" "));
                }
                else if ((i == tokens.Length - 1) || tokens[i + 1].Contains("{"))
                {
                    currentRun.Add(tokens[i]);
                    Run run = new Run(string.Join(" ", currentRun) + " ");
                    run.BaselineAlignment = BaselineAlignment.Center;
                    col.Add(run);
                    currentRun = new List<string>();
                }
                else
                {
                    currentRun.Add(tokens[i]);
                }
            }
            return col;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
