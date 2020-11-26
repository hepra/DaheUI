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
    /// TextBoxControl.xaml 的交互逻辑
    /// </summary>
    public partial class TextBoxControl : UserControl
    {
        public static readonly DependencyProperty TextValueProperty = DependencyProperty.Register("TextValue", typeof(string), typeof(TextBoxControl), new FrameworkPropertyMetadata("默认值", FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
        public string TextValue
        {
            get { return (string)GetValue(TextValueProperty); }
            set { SetValue(TextValueProperty, value); }
        }
        public static readonly DependencyProperty TextTitleProperty = DependencyProperty.Register("TextTitle", typeof(string), typeof(TextBoxControl), new FrameworkPropertyMetadata("默认值", FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public string TextTitle
        {
            get { return (string)GetValue(TextTitleProperty); }
            set { SetValue(TextTitleProperty, value); }
        }
        public TextBoxControl()
        {
            InitializeComponent();
        }
    }
}
