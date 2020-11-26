using RangeSlider;
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
using System.Windows.Shapes;

namespace UI框架.myControl.TimeLine
{
    /// <summary>
    /// AddTimeRangeWindows.xaml 的交互逻辑
    /// </summary>
    public partial class AddTimeRangeWindows : Window
    {
        public TimeRangeInfo _viewModel;
        public AddTimeRangeWindows()
        {
            InitializeComponent();
            _viewModel = new TimeRangeInfo() { StartTimeValue=0,
            EndTimeValue = 80,
            RangeStr=""
            ,Width=80
            };
            this.DataContext = _viewModel;
            btnOpreation.Content = "添加";
        }
        public AddTimeRangeWindows(TimeRangeInfo model)
        {
            InitializeComponent();
            _viewModel = new TimeRangeInfo() { StartTime=model.StartTime, 
                EndTime = model.EndTime, 
                RangeStr = model.RangeStr,
             Width = model.Width,
             RangeBrush = model.RangeBrush
            };
            this.DataContext = _viewModel;
            btnOpreation.Content = "修改";
        }

        private void 添加(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void 取消(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
