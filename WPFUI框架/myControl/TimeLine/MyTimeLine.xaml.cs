using RangeSlider;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using UI框架.Styles;

namespace UI框架.myControl.TimeLine
{
    /// <summary>
    /// MyTimeLine.xaml 的交互逻辑
    /// </summary>
    public partial class MyTimeLine : UserControl
    {

        public static readonly DependencyProperty StepValueProperty;
        public double StepValue
        {
            get { return (double)GetValue(StepValueProperty); }
            set { SetValue(StepValueProperty, value); }
        }
        static MyTimeLine()
        {
            StepValueProperty = DependencyProperty.Register("StepValue", typeof(double), typeof(MyTimeLine), new PropertyMetadata(80d));
            TimeLineInfo temp = new TimeLineInfo();
            RangeItemsProperty = DependencyProperty.Register("RangeItems", typeof(TimeLineInfo), typeof(MyTimeLine), new PropertyMetadata(temp));
        }
        public static readonly DependencyProperty RangeItemsProperty;
        public TimeLineInfo RangeItems
        {
            get { return (TimeLineInfo)GetValue(RangeItemsProperty); }
            set { SetValue(RangeItemsProperty, value); }
        }

        public MyTimeLine()
        {
            InitializeComponent();
            InitDropCanvas();
            TestHook.HookUserActivity hookUserActivity = new TestHook.HookUserActivity();
            //  hookUserActivity.OnMouseActivity += HookUserActivity_OnMouseActivity;
            hookUserActivity.MouseLeftButtonUp += HookUserActivity_MouseLeftButtonUp; ;
            hookUserActivity.Start(true, false);
            Loaded += MyTimeLine_Loaded;
            this.DataContext = RangeItems;
        }

        private void MyTimeLine_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in RangeItems.RangeItems)
            {
                AddTimeRange(item);
            }
            DrawScale();
        }

        private void HookUserActivity_MouseLeftButtonUp(bool obj)
        {
            stopwatch.Stop();
            isDragDropInEffect = false;
        }

        #region WPF canvas内元素拖拽
        void InitDropCanvas()
        {
            InitiCanvasControlPosition();
            int index = 1;
            foreach (UIElement uiEle in CanDropCanvas.Children)
            {
                if (uiEle is Button || uiEle is TextBox)
                {
                    uiEle.AddHandler(Button.MouseLeftButtonDownEvent, new MouseButtonEventHandler(Element_MouseLeftButtonDown), true);
                   // uiEle.AddHandler(Button.MouseMoveEvent, new MouseEventHandler(Element_MouseMove), true);
                    uiEle.AddHandler(Button.MouseLeftButtonUpEvent, new MouseButtonEventHandler(Element_MouseLeftButtonUp), true);
                    continue;
                }
                uiEle.MouseLeftButtonDown += new MouseButtonEventHandler(Element_MouseLeftButtonDown);
                uiEle.MouseLeftButtonUp += new MouseButtonEventHandler(Element_MouseLeftButtonUp);
                if (uiEle is Image img)
                {
                    Point pos = new Point(Canvas.GetLeft(img), Canvas.GetTop(img));
                    controlsList.Add(new MyStruct(img, new Rect(pos, new Point(pos.X + img.Width, pos.Y + img.Height))));
                    img.Name = "img" + index++;
                }
            }
        }

        private void InitiCanvasControlPosition()
        {
            double aLocationX = 0;
            double aLocationY = 0;
            double MaxHeight = 0;
            foreach (var item in CanDropCanvas.Children)
            {
                FrameworkElement currEle = item as FrameworkElement;
                MaxHeight = MaxHeight > currEle.Height ? MaxHeight : currEle.Height;
                //一行满了就换行
                if (aLocationX > CanDropCanvas.Width)
                {
                    MyMessageBox myMessageBox = new MyMessageBox("提示","已超过最大时间");
                    myMessageBox.ShowDialog();
                    return;
                    //aLocationY += (int)MaxHeight + 50;
                    //aLocationX = 0;
                }
                currEle.SetValue(Canvas.LeftProperty, aLocationX);
                currEle.SetValue(Canvas.TopProperty, aLocationY);
                aLocationX += (int)currEle.Width + 50;

            }
        }

        bool isDragDropInEffect = false;
        System.Windows.Point pos = new System.Windows.Point();
        List<MyStruct> controlsList = new List<MyStruct>();
        public class MyStruct
        {
            public Image image { get; set; }
            public Rect rect { get; set; }
            public MyStruct(Image img, Rect r)
            {
                image = img;
                rect = r;
            }
        }
        double xPos;
        double yPos;
        void Element_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine(isDragDropInEffect);
            if (isDragDropInEffect)
            {
                FrameworkElement currEle = sender as FrameworkElement;
                pos = e.GetPosition(CanDropCanvas);
                xPos = pos.X - 0.5 * currEle.Width;
               // yPos = pos.Y - 0.5 * currEle.Height;

                if (stopwatch.ElapsedMilliseconds > 100)
                {
                    currEle.SetValue(Canvas.LeftProperty, xPos);
                 //   currEle.SetValue(Canvas.TopProperty, yPos);
                    for (int i = 0; i < controlsList.Count; i++)
                    {
                        if (controlsList[i].image.Name == currEle.Name)
                        {
                            Point p1 = new Point(xPos, yPos);
                            Point p2 = new Point(xPos + currEle.Width, yPos + currEle.Height);
                            var rect = new Rect(p1, p2);
                            controlsList[i].rect = rect;
                        }
                    }
                }

            }
        }

        public bool IsPointIn(Rect rect, Point pt)
        {
            if (pt.X >= rect.X && pt.Y >= rect.Y && pt.X <= rect.X + rect.Width && pt.Y <= rect.Y + rect.Height)
            {
                return true;
            }
            else return false;
        }

        async void Element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        if(sender  is  RangeButton fEle)
            {
                isDragDropInEffect = true;
                stopwatch.Restart();
                fEle.Cursor = Cursors.Hand;
                while (e.LeftButton == MouseButtonState.Pressed)
                {

                    // yPos = pos.Y - 0.5 * currEle.Height;
                    if(fEle._viewModel.IsLocked==true)
                    {
                        return;
                    }

                    if (stopwatch.ElapsedMilliseconds > 100)
                    {
                        pos = e.GetPosition(CanDropCanvas);
                        xPos = pos.X - 0.5 * fEle._viewModel.Width;
                        if(xPos<0||xPos>StepValue*18)
                        {
                           
                        }
                        else
                        {
                            fEle.SetValue(Canvas.LeftProperty, xPos);
                        }
                      
                    }
                    await Task.Delay(25);
                }
                var left = (double)fEle.GetValue(Canvas.LeftProperty);
                var Xpos = left;

                if (left % StepValue != 0)
                {
                    if (left % StepValue < StepValue / 2)
                    {
                        Xpos = left - left % StepValue;
                        fEle.SetValue(Canvas.LeftProperty, left - left % StepValue);
                    }
                    else
                    {
                        Xpos = left + (StepValue - left % StepValue);
                        fEle.SetValue(Canvas.LeftProperty, left + (StepValue - left % StepValue));
                    }
                }
                fEle._viewModel.StartTimeValue = Xpos ;
                fEle._viewModel.StartTime = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day,(int)(Xpos/StepValue)+6, 0,0);
                fEle._viewModel.EndTime = fEle._viewModel.StartTime.AddHours(fEle._viewModel.Width/StepValue);
            }
          
        }
        Stopwatch stopwatch = new Stopwatch();
        void Element_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragDropInEffect)
            {
                FrameworkElement ele = sender as FrameworkElement;
                isDragDropInEffect = false;
                stopwatch.Stop();
                ele.ReleaseMouseCapture();
            }
        }

        private void 左旋_click(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image image)
            {
                RotateLeft(image.Tag as Image);
            }
        }

        private void 右旋_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image image)
            {
                RotateRight(image.Tag as Image);
            }
        }

        /// <summary>
        /// 图片左转
        /// </summary>
        /// <param name="img">被操作的前台Image控件</param>
        public void RotateLeft(Image img)
        {
            TransformGroup tg = img.RenderTransform as TransformGroup;
            if (tg == null)
            {
                tg = new TransformGroup();
            }
            var tgnew = tg.CloneCurrentValue();
            if (tgnew != null)
            {
                RotateTransform rt = tgnew.Children[2] as RotateTransform;
                img.RenderTransformOrigin = new Point(0.5, 0.5);
                rt.Angle -= 5;
            }


            // 重新给图像赋值Transform变换属性
            img.RenderTransform = tgnew;
        }

        /// <summary>
        /// 图片右转
        /// </summary>
        /// <param name="img">被操作的前台Image控件</param>
        public void RotateRight(Image img)
        {
            TransformGroup tg = img.RenderTransform as TransformGroup;
            if (tg == null)
            {
                tg = new TransformGroup();
            }
            var tgnew = tg.CloneCurrentValue();
            if (tgnew != null)
            {
                RotateTransform rt = tgnew.Children[2] as RotateTransform;
                img.RenderTransformOrigin = new Point(0.5, 0.5);
                rt.Angle += 5;
            }


            // 重新给图像赋值Transform变换属性
            img.RenderTransform = tgnew;
        }



        /// <summary>
        /// 图片放大
        /// </summary>
        /// <param name="img">被操作的前台Image控件</param>
        public void ZoomIn(Image img)
        {
            TransformGroup tg = img.RenderTransform as TransformGroup;
            var tgnew = tg.CloneCurrentValue();
            if (tgnew != null)
            {
                ScaleTransform st = tgnew.Children[1] as ScaleTransform;
                img.RenderTransformOrigin = new Point(0.5, 0.5);
                if (st.ScaleX > 0 && st.ScaleX <= 2.0)
                {
                    st.ScaleX += 0.05;
                    st.ScaleY += 0.05;
                }
                else if (st.ScaleX < 0 && st.ScaleX >= -2.0)
                {
                    st.ScaleX -= 0.05;
                    st.ScaleY += 0.05;
                }
            }

            // 重新给图像赋值Transform变换属性
            img.RenderTransform = tgnew;
        }

        /// <summary>
        /// 图片缩小
        /// </summary>
        /// <param name="img">被操作的前台Image控件</param>
        public void ZoomOut(Image img)
        {
            TransformGroup tg = img.RenderTransform as TransformGroup;
            var tgnew = tg.CloneCurrentValue();
            if (tgnew != null)
            {
                ScaleTransform st = tgnew.Children[1] as ScaleTransform;
                img.RenderTransformOrigin = new Point(0.5, 0.5);
                if (st.ScaleX >= 0.2)
                {
                    st.ScaleX -= 0.05;
                    st.ScaleY -= 0.05;
                }
                else if (st.ScaleX <= -0.2)
                {
                    st.ScaleX += 0.05;
                    st.ScaleY -= 0.05;
                }
            }

            // 重新给图像赋值Transform变换属性
            img.RenderTransform = tgnew;
        }



        #endregion

        private void RangeButton_Delete(object sender, EventArgs e)
        {
            if(sender is RangeButton range)
            {
                CanDropCanvas.Children.Remove(range);
                RangeItems.RangeItems.Remove(range._viewModel);
            }
        }
       public void AddTimeRange( TimeRangeInfo rangeInfo)
        {
            rangeInfo.StartTimeValue = StepValue * (rangeInfo.StartTime.Hour - 6);
            rangeInfo.Width = (rangeInfo.EndTime.Hour - rangeInfo.StartTime.Hour) * StepValue;
            rangeInfo.Height = 60;
            var newElement = new RangeButton(rangeInfo);
            newElement.Step = StepValue;
            newElement.Delete += RangeButton_Delete;
            newElement.MouseLeftButtonDown += new MouseButtonEventHandler(Element_MouseLeftButtonDown);
            newElement.MouseLeftButtonUp += new MouseButtonEventHandler(Element_MouseLeftButtonUp);
            CanDropCanvas.Children.Add(newElement);
            newElement.SetValue(Canvas.LeftProperty, rangeInfo.StartTimeValue);
            this.RangeItems.RangeItems.Add(rangeInfo);
        }
        private void 增加时间段(object sender, RoutedEventArgs e)
        {
            AddTimeRangeWindows addTimeRangeWindows = new AddTimeRangeWindows();
            addTimeRangeWindows.ShowDialog();
            if(addTimeRangeWindows.DialogResult== true)
            {
                AddTimeRange(addTimeRangeWindows._viewModel);
            }
        }

        private void NewElement_Edit(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RangeItems.RangeItems.Count; i++)
            {
                this.RangeItems.RangeItems[i] = (sender as RangeButton)._viewModel;
            } 
        }

        /// <summary>
        /// 作出x轴和y轴的标尺
        /// </summary>
        private void DrawScale()
        {
            for (int j = 0; j < 18; j++)
            {
                Line y_scale = new Line(); //主Y轴标尺
                y_scale.StrokeEndLineCap = PenLineCap.Triangle;
                y_scale.StrokeThickness = 1;
                y_scale.Stroke = new SolidColorBrush(Color.FromRgb(6, 6, 6));

                y_scale.Y1 = 0;            //原点x=40
                if (j % 5 == 0)
                {
                    y_scale.StrokeThickness = 3;
                    y_scale.Y2 = y_scale.Y1 + 8;//大刻度线
                }
                else
                {
                    y_scale.Y2 = y_scale.Y1 + 4;//小刻度线
                }

                y_scale.X1 = 1280 - j * this.StepValue;  //每10px作一个刻度 
                y_scale.X2 = y_scale.X1;
                this.CanDropCanvas.Children.Add(y_scale);
            }

        }
    }
}
