using Newtonsoft.Json;
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
 

namespace UIFrameworkCore.Dialogs
{ 
    /// <summary>
    /// HandleExpection.xaml 的交互逻辑
    /// </summary>
public partial class HandleExpection : Window
    {
        public bool _showDialog = true;

        public HandleExpection(string title,string ErrorMsg)
        {
            InitializeComponent();
            tbErrorInfo.Text = ErrorMsg;
            lbTitle.Content = title;
        }
        public HandleExpection(string Title, string ErrorMsg,string LeftButtonContent,string RightButtonContent)
        {
            InitializeComponent();
            tbErrorInfo.Text = ErrorMsg;
            lbTitle.Content = Title;
            btnLeft.Content = LeftButtonContent;
            btnRight.Content = RightButtonContent;
        }


        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                //Max_MouseLeftButtonDown(null, null);
                e.Handled = true;
                return;
            }
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DialogResult = false;
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DialogResult = false;
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        private void 确认(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DialogResult = true;
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }
    }
}
