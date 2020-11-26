using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using UI框架.myControl.NoticeWindow;

namespace Panuon.UI.Silver.Controls.Internal
{
    /// <summary>
    /// NoticeWindow.xaml 的交互逻辑
    /// </summary>
    internal partial class NoticeWindow : Window
    {
        public NoticeWindow()
        {
            InitializeComponent();
            _viewModel = new NoticemMainViewModel();
            this.DataContext = _viewModel;
            Instance = this;
        }
        NoticemMainViewModel _viewModel;

        #region Property
        public static NoticeWindow Instance { get; set; }
        #endregion

        #region EventHandler

        private void NoticeWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Instance = null;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = 0;
            Height = desktopWorkingArea.Bottom;
            
        }
        #endregion

        public void AddNotice(string message, string title, int durationSeconds=5)
        {
            myList.Height = this.Height;
            myList.VerticalAlignment = VerticalAlignment.Bottom;
            var temp = new NoticeViewModel()
            {
                ShowTime = durationSeconds
            ,
                Msg = message
            ,
                Title = title
                , Opcity = 1
            };
            _viewModel.NoticeItems.Add(temp);
            BeginHide(temp);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
          if(sender is Button button)
            {
                if(button.DataContext is NoticeViewModel item)
                {
                    BeginHide(item);
                }
            }
        }

        void BeginHide(NoticeViewModel item)
        {
            new Thread(
                (object para) => {
                    if(para is NoticeViewModel model)
                    {
                        int time = 0;
                        while(time<400)
                        {
                            Thread.Sleep(100);
                            time += 10;
                        }
                        while(time<500)
                        {
                            model.Opcity -= 0.1;
                            time += 10;
                            Thread.Sleep(100);
                        }
                        this.Dispatcher.Invoke(() =>
                        {
                            _viewModel.NoticeItems.Remove(model);
                        });
                    }
                }
     ).Start(item);
        }
    }
}
