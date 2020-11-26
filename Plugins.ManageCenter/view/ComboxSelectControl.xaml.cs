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

namespace Plugins.ManageCenter.view
{
    /// <summary>
    /// ComboxSelectControl.xaml 的交互逻辑
    /// </summary>
    public partial class ComboxSelectControl : UserControl
    {

        public static readonly DependencyProperty ComboxItemsProperty = DependencyProperty.Register("ComboxItems", typeof(ICollection<object>), typeof(ComboxSelectControl), new FrameworkPropertyMetadata(new ObservableCollection<object>(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
        public ICollection<object> ComboxItems  
        {
            get { return (ICollection<object>)GetValue(ComboxItemsProperty); }
            set { SetValue(ComboxItemsProperty, value); }
        }
        public static readonly DependencyProperty ComboxTitleProperty = DependencyProperty.Register("ComboxTitle", typeof(string), typeof(ComboxSelectControl), new FrameworkPropertyMetadata("默认值", FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public string ComboxTitle
        {
            get { return (string)GetValue(ComboxTitleProperty); }
            set { SetValue(ComboxTitleProperty, value); }
        }

        public static readonly DependencyProperty ComboxSelectItemProperty = DependencyProperty.Register("ComboxSelectItem", typeof(object), typeof(ComboxSelectControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public object ComboxSelectItem
        {
            get { return (object)GetValue(ComboxSelectItemProperty); }
            set { SetValue(ComboxSelectItemProperty, value); }
        }
        public static readonly DependencyProperty ComboxDisplayMemberPathProperty = DependencyProperty.Register("ComboxDisplayMemberPath", typeof(string), typeof(ComboxSelectControl), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public string ComboxDisplayMemberPath
        {
            get { return (string)GetValue(ComboxDisplayMemberPathProperty); }
            set { SetValue(ComboxDisplayMemberPathProperty, value); }
        }

        
        public ComboxSelectControl()
        {
            InitializeComponent();
        }
    }
}
