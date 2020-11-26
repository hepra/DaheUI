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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace UI框架.myControl
{
    /// <summary>
    /// My轮播.xaml 的交互逻辑
    /// </summary>
    public partial class My轮播 : UserControl
    {
        public My轮播()
        {
            InitializeComponent();
        }

        public void SetDataSource<T>(ObservableCollection<T> CLASSList)
        {
            this.lst.ItemsSource = CLASSList;
            Init轮播();
        }


        /// <summary>
        /// 向左移动撤出
        /// </summary>
        private DoubleAnimation _MiddleToLeftAnimation;
        private DoubleAnimation _MiddleToLeftAnimationL;
        /// <summary>
        /// 向左移动进入
        /// </summary>
        private DoubleAnimation _RightToMiddelAnimation;
        private DoubleAnimation _RightToMiddelAnimationL;

        /// <summary>
        /// 向右移动撤出
        /// </summary>
        private DoubleAnimation _MiddleToRightAnimation;
        private DoubleAnimation _MiddleToRightAnimationL;
        /// <summary>
        /// 向右移动进入
        /// </summary>
        private DoubleAnimation _LeftToMiddleAnimation;
        private DoubleAnimation _LeftToMiddleAnimationL;

        /// <summary>
        /// 当前显示的图片
        /// </summary>
        int CurrentIndex = 0;

        /// <summary>
        /// 动画是否完成
        /// </summary>
        bool AnimationCompleted = false;
        DispatcherTimer AutoPlay = new DispatcherTimer();
        void Init轮播()
        {
            if (this.lst.Items.Count > 0)
            {
                Image image = new Image();
                image.Width = 1600;
                image.Height = 900;
                image.Stretch = Stretch.Uniform;
                image.Source = this.lst.Items[0] as ImageSource;
                canvas.Children.Add(image);
                AnimationCompleted = false;
                double i = image.Width;
                var easOut = new CubicEase();
                easOut.EasingMode = EasingMode.EaseInOut;
                var easIn = new CubicEase();
                easIn.EasingMode = EasingMode.EaseIn;
                _MiddleToLeftAnimation = new DoubleAnimation(i, 0, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.Stop);
                _MiddleToLeftAnimationL = new DoubleAnimation(0, 0, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.Stop);
                _RightToMiddelAnimation = new DoubleAnimation(0, i, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
                _RightToMiddelAnimationL = new DoubleAnimation(i, 0, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);

                _MiddleToLeftAnimation.Completed += _MiddleToLeftAnimation_Completed;
                _RightToMiddelAnimation.Completed += _RightToMiddelAnimation_Completed;

                _LeftToMiddleAnimation = new DoubleAnimation(0, i, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
                _LeftToMiddleAnimationL = new DoubleAnimation(0, 0, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
                _MiddleToRightAnimation = new DoubleAnimation(i, 0, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
                _MiddleToRightAnimationL = new DoubleAnimation(0, i * 2 / 3, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);


                _MiddleToRightAnimation.EasingFunction = easOut;

                _LeftToMiddleAnimation.Completed += _LeftToMiddleAnimation_Completed;
                _MiddleToRightAnimation.Completed += _MiddleToRightAnimation_Completed;

                this.lst.SelectionChanged += lst_SelectionChanged;
                AutoPlay.Interval = new TimeSpan(0, 0, 3);
                AutoPlay.Tick -= AutoPlay_Tick;
                AutoPlay.Tick += AutoPlay_Tick;
                AutoPlay.Start();
            }
        }

        private void AutoPlay_Tick(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (this.lst.SelectedIndex < this.lst.Items.Count - 1)
                {
                    this.lst.SelectedIndex++;
                }
                else
                {
                    this.lst.SelectedIndex = 0;
                }
            });

        }

        void _MiddleToRightAnimation_Completed(object sender, EventArgs e)
        {
            if (this.canvas != null && canvas.Children.Count > 1)
            {
                this.canvas.Children.RemoveAt(0);
            }
        }

        void _LeftToMiddleAnimation_Completed(object sender, EventArgs e)
        {
            if (this.canvas != null && canvas.Children.Count > 1)
            {
                this.canvas.Children.RemoveAt(0);
            }
            AnimationCompleted = false;
        }

        void _MiddleToLeftAnimation_Completed(object sender, EventArgs e)
        {
            if (this.canvas != null && canvas.Children.Count > 1)
            {
                this.canvas.Children.RemoveAt(0);
            }
        }
        //动画结束，删除第一张
        void _RightToMiddelAnimation_Completed(object sender, EventArgs e)
        {
            if (this.canvas != null && canvas.Children.Count > 1)
            {
                this.canvas.Children.RemoveAt(0);
            }
            AnimationCompleted = false;
        }



        ///右侧选择时，左侧进行相应的改变

        void lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int t_index = this.lst.SelectedIndex;
            if (t_index < 0)
            {
                return;
            }
            Image image = new Image();
            image.Width = 1600;
            image.Height = 900;
            image.Stretch = Stretch.Uniform;
            image.Source = (this.lst.Items[t_index] as ImageSource);
            if (t_index > CurrentIndex)
            {
                MoveToLeftAnimate(image, t_index);
            }
            else if (t_index < CurrentIndex)
            {
                MoveToRightAnimate(image, t_index);
            }

        }

        private void MoveToLeftAnimate(Image image, int t_index)
        {
            if (!AnimationCompleted)
            {
                CurrentIndex = t_index;
                AnimationCompleted = true;

                canvas.Children.Add(image);
                canvas.Children[0].BeginAnimation(Image.WidthProperty, _MiddleToLeftAnimation);
                canvas.Children[0].BeginAnimation(Canvas.LeftProperty, _MiddleToLeftAnimationL);
                canvas.Children[1].BeginAnimation(Image.WidthProperty, _RightToMiddelAnimation);
                canvas.Children[1].BeginAnimation(Canvas.LeftProperty, _RightToMiddelAnimationL);
            }
            else
            {
                this.lst.SelectedItem = this.lst.Items[CurrentIndex];
            }

        }
        private void MoveToRightAnimate(Image image, int t_index)
        {
            if (!AnimationCompleted)
            {
                CurrentIndex = t_index;
                AnimationCompleted = true;

                canvas.Children.Add(image);
                canvas.Children[0].BeginAnimation(Image.WidthProperty, _MiddleToRightAnimation);
                canvas.Children[0].BeginAnimation(Canvas.LeftProperty, _MiddleToRightAnimationL);
                canvas.Children[1].BeginAnimation(Image.WidthProperty, _LeftToMiddleAnimation);
                canvas.Children[1].BeginAnimation(Canvas.LeftProperty, _LeftToMiddleAnimationL);
            }

            else
            {
                this.lst.SelectedItem = this.lst.Items[CurrentIndex];
            }

        }



        private void 上一张(object sender, RoutedEventArgs e)
        {
            if (this.lst.SelectedIndex > 1)
            {
                this.lst.SelectedIndex--;
            }
            else
            {
                this.lst.SelectedIndex = this.lst.Items.Count - 1;
            }
        }

        private void 下一张(object sender, RoutedEventArgs e)
        {
            if (this.lst.SelectedIndex < this.lst.Items.Count - 1)
            {
                this.lst.SelectedIndex++;
            }
            else
            {
                this.lst.SelectedIndex = 0;
            }
        }

    }
}
