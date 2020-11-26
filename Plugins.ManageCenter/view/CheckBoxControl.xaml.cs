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
    /// <summary>
    /// CheckBoxControl.xaml 的交互逻辑
    /// </summary>
    public partial class CheckBoxControl : UserControl
    {
        public static readonly DependencyProperty CheckBoxTitleProperty = DependencyProperty.Register("CheckBoxTitle", typeof(string), typeof(CheckBoxControl), new FrameworkPropertyMetadata("默认值", FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
        public string CheckBoxTitle
        {
            get { return (string)GetValue(CheckBoxTitleProperty); }
            set { SetValue(CheckBoxTitleProperty, value); }
        }

        public static readonly DependencyProperty CheckBoxContentProperty = DependencyProperty.Register("CheckBoxContent", typeof(string), typeof(CheckBoxControl), new FrameworkPropertyMetadata("checkbox", FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
        public string CheckBoxContent
        {
            get { return (string)GetValue(CheckBoxContentProperty); }
            set { SetValue(CheckBoxContentProperty, value); }
        }


        public static readonly DependencyProperty CheckBoxValueProperty = DependencyProperty.Register("CheckBoxValue", typeof(bool), typeof(CheckBoxControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public bool CheckBoxValue
        {
            get { return (bool)GetValue(CheckBoxValueProperty); }
            set { SetValue(CheckBoxValueProperty, value); }
        }
        public CheckBoxControl()
        {
            InitializeComponent();
        }
    }
}
