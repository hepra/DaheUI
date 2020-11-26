using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using UIFrameworkCore.Convert;

namespace Plugins.ManageCenter.view
{
    public partial class EnumControl : UserControl
    {

        public static readonly DependencyProperty EnumControlTitleProperty = DependencyProperty.Register("EnumControlTitle", typeof(string), typeof(EnumControl), new FrameworkPropertyMetadata("默认值", FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
        public string EnumControlTitle
        {
            get { return (string)GetValue(EnumControlTitleProperty); }
            set { SetValue(EnumControlTitleProperty, value); }
        }

        public static readonly DependencyProperty CheckValueProperty = DependencyProperty.Register("Title", typeof(int), typeof(EnumControl), new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
        public int CheckValue
        {
            get { return (int)GetValue(CheckValueProperty); }
            set { SetValue(CheckValueProperty, value); }
        }

        public static readonly DependencyProperty EnumItemListProperty = DependencyProperty.Register("EnumItemList", typeof(Dictionary<string, int>), typeof(EnumControl), new PropertyMetadata(new Dictionary<string, int>(), onPropertyChanged));

        private static void onPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is EnumControl control)
            {
                if (e.NewValue is Dictionary<string, int> source)
                {
                    foreach (var item in source)
                    {
                        RadioButton radioButton = new RadioButton()
                        {
                            Content = item.Key,
                            GroupName = control.EnumControlTitle,
                            Margin = new Thickness(10, 0, 0, 0),
                            Tag=control     ,
                            TabIndex = item.Value
                        };
                        radioButton.Checked += RadioButton_Checked;
                        control.MainPanel.Children.Add(radioButton);
                    }

                }
            }
        }

        private static void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(sender is RadioButton radioButton)
            {
                if(radioButton.Tag is EnumControl control)
                {
                    control.CheckValue = radioButton.TabIndex;
                }
            }
        }

        public Dictionary<string, int> EnumItemList
        {
            get { return (Dictionary<string, int>)GetValue(EnumItemListProperty); }
            set { SetValue(EnumItemListProperty, value); }
        }


        public EnumControl()
        {
            InitializeComponent();
        }
    }
}
