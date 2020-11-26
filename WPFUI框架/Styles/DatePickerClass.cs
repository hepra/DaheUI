using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Styles
{
    public partial class DatePickerClass
    {
        private void Calendar_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Calendar calendar = sender as Calendar;
                List<CalendarDayButton> list = Helper.FindVisualChild<CalendarDayButton>(calendar);
                System.Diagnostics.Debug.WriteLine(list.Count.ToString());
                DateTime day = DateTime.Now.Date;
                if (calendar.SelectedDate != null)
                {
                    day = (DateTime)calendar.SelectedDate;
                }
                calendar.DisplayDate = day;

                calendar.DisplayDateChanged += Calendar_DisplayDateChanged;
                calendar.DisplayModeChanged += Calendar_DisplayModeChanged;

                calendar.Unloaded += (s, e1) =>
                {
                    calendar.DisplayDateChanged -= Calendar_DisplayDateChanged;
                    calendar.DisplayModeChanged -= Calendar_DisplayModeChanged;
                };
                SetCurrentWeekBackground(list, day);
            }
            catch (Exception ex)
            {
             //   Utils.Helper.ShowMessage(ex);
            }
        }

        private void Calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            try
            {
                if (e.NewMode == CalendarMode.Month)
                {
                    Calendar calendar = sender as Calendar;
                    List<CalendarDayButton> list = Helper.FindVisualChild<CalendarDayButton>(calendar);

                    DateTime day = DateTime.Now.Date;
                    if (calendar.SelectedDate != null)
                    {
                        day = (DateTime)calendar.SelectedDate;
                    }

                    SetCurrentWeekBackground(list, day);
                }
            }
            catch (Exception ex)
            {
              //  Utils.Helper.ShowMessage(ex);
            }
        }

        private void Calendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            try
            {
                Calendar calendar = sender as Calendar;
                List<CalendarDayButton> list = Helper.FindVisualChild<CalendarDayButton>(calendar);

                DateTime day = DateTime.Now.Date;
                if (calendar.SelectedDate != null)
                {
                    day = (DateTime)calendar.SelectedDate;
                }

                SetCurrentWeekBackground(list, day);
            }
            catch (Exception ex)
            {
                //Utils.Helper.ShowMessage(ex);
            }
        }


        private void CalendarDayButton_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                List<CalendarDayButton> list = Helper.FindVisualChild<CalendarDayButton>((sender as CalendarDayButton).Parent);
                DateTime day = (DateTime)(sender as CalendarDayButton).DataContext;

                SetCurrentWeekBackground(list, day);
            }
            catch (Exception ex)
            {
             //   Utils.Helper.ShowMessage(ex);
            }
        }

        /// <summary>
        /// 设置指定日期所在周的背景色
        /// </summary>
        /// <param name="list"></param>
        /// <param name="day"></param>
        private void SetCurrentWeekBackground(List<CalendarDayButton> list, DateTime day)
        {
            try
            {
                int indexInWeek = day.DayOfWeek.GetHashCode();
                if (indexInWeek == 0) indexInWeek = 7;
                DateTime startDate = day.AddDays(1 - indexInWeek).Date;
                int intTmp = 0;
                foreach (CalendarDayButton btn in list)
                {
                    intTmp = ((DateTime)btn.DataContext - startDate).Days;
                    if(((DateTime)btn.DataContext - day.Date).Days == 0)
                    {
                        btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00CB7C"));
                        btn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
                        btn.BorderThickness = new Thickness(0);
                    }
                    else if ((((DateTime)btn.DataContext).Date - DateTime.Now.Date).Days == 0)
                    {
                        //今日样式固定
                        btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
                        btn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00CB7C"));
                        btn.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00CB7C"));
                        btn.BorderThickness = new Thickness(1);
                    }
                    else if (intTmp >= 0 && intTmp <= 6)
                    {
                        btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2000CB7C"));
                        btn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF333333"));
                        btn.BorderThickness = new Thickness(0);
                    }
                    else
                    {
                        btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00000000"));
                        btn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF333333"));
                        btn.BorderThickness = new Thickness(0);
                    }
                }
            }
            catch (Exception ex)
            {
               // Utils.Helper.ShowMessage(ex);
            }
        }

        
    }

    public class Helper
    {
        public static List<T> FindVisualChild<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            List<T> TList = new List<T> { };
            try
            {
                if (dependencyObject == null)
                {
                    return new List<T>();
                }
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);
                    if (child != null && child is T)
                    {
                        TList.Add((T)child);
                        List<T> childOfChildren = FindVisualChild<T>(child);
                        if (childOfChildren != null)
                        {
                            TList.AddRange(childOfChildren);
                        }
                    }
                    else
                    {
                        List<T> childOfChildren = FindVisualChild<T>(child);
                        if (childOfChildren != null)
                        {
                            TList.AddRange(childOfChildren);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TList;
        }

        public static T GetParentObject<T>(DependencyObject obj, string name) where T : FrameworkElement
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);

            while (parent != null)
            {
                if (parent is T && (((T)parent).Name == name | string.IsNullOrEmpty(name)))
                {
                    return (T)parent;
                }

                // 在上一级父控件中没有找到指定名字的控件，就再往上一级找
                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }
    }

}
