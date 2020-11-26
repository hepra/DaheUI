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

namespace Plugins.ManageCenter.view
{
    public partial class ColorSelectControl : UserControl
    {

        public static readonly DependencyProperty ColorPickerTitleProperty = DependencyProperty.Register("ColorPickerTitle", typeof(string), typeof(ColorSelectControl), new FrameworkPropertyMetadata("默认值", FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public string ColorPickerTitle
        {
            get { return (string)GetValue(ColorPickerTitleProperty); }
            set { SetValue(ColorPickerTitleProperty, value); }
        }
        public static readonly DependencyProperty ColorPickerSelectedColoerProperty = DependencyProperty.Register("ColorPickerSelectedColoer", typeof(Color), typeof(ColorSelectControl), new FrameworkPropertyMetadata(Colors.Black, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public Color ColorPickerSelectedColoer
        {
            get { return (Color)GetValue(ColorPickerSelectedColoerProperty); }
            set { SetValue(ColorPickerSelectedColoerProperty, value); }
        }
        public ColorSelectControl()
        {
            InitializeComponent();
        }
    }
}
