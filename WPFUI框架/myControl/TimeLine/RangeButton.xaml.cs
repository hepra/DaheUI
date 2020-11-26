using RangeSlider;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace UI框架.myControl.TimeLine
{
    /// <summary>
    /// RangeButton.xaml 的交互逻辑
    /// </summary>
    public partial class RangeButton : UserControl
    {

        public event EventHandler Delete;
        public event EventHandler Edit;
        public static readonly DependencyProperty StepProperty;
        public double Step
        {
            get { return (double)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }
        public TimeRangeInfo _viewModel;
        static RangeButton( )
        {
            StepProperty = DependencyProperty.Register("Step", typeof(double), typeof(RangeButton));
        }
        public RangeButton(TimeRangeInfo model)
        {
            InitializeComponent();
            _viewModel = model;
            this.DataContext = _viewModel;
        }
        public void SetViewModel(TimeRangeInfo model)
        {
            _viewModel = model;
            this.DataContext = _viewModel;
        }

        private void MidSliderPart_Unchecked(object sender, RoutedEventArgs e)
        {
            btnAdd.IsEnabled = true;
            borText.IsEnabled = true;
        }

        private void MidSliderPart_Checked(object sender, RoutedEventArgs e)
        {
            btnAdd.IsEnabled = false;
            btnAdd.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Width += Step;
            _viewModel.EndTime = _viewModel.StartTime.AddHours(_viewModel.Width / Step);
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if(_viewModel.Width>Step)
            {
                _viewModel.Width -= Step;
                _viewModel.EndTime = _viewModel.StartTime.AddHours(_viewModel.Width / Step);
            }
        }
        private void 删除(object sender, RoutedEventArgs e)
        {
            Delete?.Invoke(this, e);
        }

        private void 编辑(object sender, RoutedEventArgs e)
        {
            AddTimeRangeWindows addTimeRangeWindows = new AddTimeRangeWindows(this._viewModel);
            if(addTimeRangeWindows.ShowDialog()==true)
            {
                this._viewModel = addTimeRangeWindows._viewModel;
             //   Edit?.Invoke(this, e);
            }
        }
    }
    public class myVisibilityConvert : IValueConverter
    {
        static string root_path = (System.AppDomain.CurrentDomain.BaseDirectory);
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility btnVisibility = Visibility.Collapsed;

            if (value is bool bVal)
            {
                if (parameter?.ToString() == "2")
                {
                    if (bVal == true)
                    {
                        return Visibility.Collapsed;
                    }
                    else
                    {
                        return Visibility.Visible;
                    }
                }
                if (parameter?.ToString() == "1")
                {
                    if (bVal == true)
                    {
                        return Visibility.Visible;
                    }
                    else
                    {
                        return Visibility.Collapsed;
                    }
                }
            }
            return btnVisibility;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
            //throw new NotImplementedException();
        }
    }
}
