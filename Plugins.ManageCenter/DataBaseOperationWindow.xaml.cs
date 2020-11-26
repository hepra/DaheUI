
using Newtonsoft.Json;
using Plugins.ManageCenter.view;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
using UIFrameworkCore;
using UIFrameworkCore.Model;
using UIFrameworkCore.Settings;
using UIFrameworkCore.Settings.UIAttributes;

namespace Plugins.ManageCenter
{
    /// <summary>
    /// NumkeyBorad.xaml 的交互逻辑
    /// </summary>
    public partial class DataBaseOperationWindow : Window
    {
        public string Password { get; set; }
        public DataBaseOperationWindow()
        {
            InitializeComponent();
        }
        public DataBaseOperationWindow(string Add)
        {
            InitializeComponent();
            btn操作数据库.Content = "添加";
        }
        public void InitWindow<T>(T  source)
        {
            Type setting_type = source.GetType();
            if (setting_type == null)
                return ;
            //获取需要显示的 属性
            var props = setting_type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.GetCustomAttribute<NameAliasAttribute>() != null);

            MainSatckPanel.Children.Clear();
            foreach (var item in props)
            {
                //if (item.GetCustomAttribute<GroupAttribute>()!=null)
                //{
                //    string controlStyle = item.GetCustomAttribute<GroupAttribute>().GroupName;
                //    if(controlStyle == ControlStyle.ColorPickerControl)
                //    {

                //    }
                //}
                    MainSatckPanel.Children.Add(GenerateMiniVisualizableSetting<T>(item,source));
            }
        }
        private FrameworkElement GenerateMiniVisualizableSetting<T>(PropertyInfo prop_info,T source)
        {
            FrameworkElement control = null;
            #region Create Control

            switch (prop_info.PropertyType.Name)
            {
                case "Boolean":
                    control = GenerateBoolControl(prop_info,source);
                    break;

                case "String":
                case "Double":
                case "Byte":
                case "Int16":
                case "UInt16":
                case "Int64":
                case "UInt64":
                case "Int32":
                case "UInt32":
                case "Single":
                    control = GenerateValueControl(prop_info,source);
                    break;

                default:
                    control = GenerateValueControl(prop_info,source);
                    break;

            }

            #endregion


            return control;
        }

        private FrameworkElement GenerateBoolControl<T>(PropertyInfo prop_info,T source)
        {
            CheckBoxControl checkBoxControl = new CheckBoxControl();
            checkBoxControl.CheckBoxTitle = prop_info.GetCustomAttribute<NameAliasAttribute>().AliasName;
            Binding binding = new Binding(prop_info.Name);
            binding.Source = source;
            binding.Mode = BindingMode.TwoWay;

            checkBoxControl.SetBinding(CheckBoxControl.CheckBoxValueProperty, binding);
            return checkBoxControl;
        }
        private FrameworkElement GenerateValueControl<T>(PropertyInfo prop_info,T source)
        {
            TextBoxControl checkBoxControl = new TextBoxControl();
            checkBoxControl.TextTitle = prop_info.GetCustomAttribute<NameAliasAttribute>().AliasName;
            Binding binding = new Binding(prop_info.Name);
            binding.Source = source;
            binding.Mode = BindingMode.TwoWay;
            checkBoxControl.SetBinding(TextBoxControl.TextValueProperty, binding);
            return checkBoxControl;

        }




        private void btn操作数据库_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Content.ToString())
            {
                case "更新":
                    this.DialogResult = true;
                    break;
                case "添加":
                    this.DialogResult = true;
                    break;
                case "返回":
                    this.DialogResult = false;
                    this.Close();
                    break;
            }
        }
    }
}
