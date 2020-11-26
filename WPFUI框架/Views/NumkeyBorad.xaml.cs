
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using UIFrameworkCore;
using UIFrameworkCore.Settings;

namespace UI框架
{
    /// <summary>
    /// NumkeyBorad.xaml 的交互逻辑
    /// </summary>
    public partial class NumkeyBorad : Window
    {
        public string Password { get; set; }
        public NumkeyBorad()
        {
            InitializeComponent();
            管理员模式 = false;
        }
        public bool 管理员模式 { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var tempButton = sender as Button;
            string content = tempButton.Content.ToString();
            switch (content)
            {
                case "删除":
                    if (tbShow.Password.Length > 0)
                    {
                        tbShow.Password = tbShow.Password.Substring(0, tbShow.Password.Length - 1);
                    }
                    break;
                case "管理员模式":
                    if (tbShow.Password == SettingManager.GetSettingSingleton().pwd管理员密码)
                    {
                        管理员模式 = true;
                        DialogResult = false;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("密码错误!");
                    }
                 
                    break;
                case "关机":
                    if (tbShow.Password == SettingManager.GetSettingSingleton().pwd关机密码)
                    {
                        Process process = new Process
                        {
                            StartInfo = {
                                FileName = "cmd.exe",
                                Arguments = "/c shutdown -s -f -t 00",
                                UseShellExecute = false,
                                RedirectStandardInput = true,
                                RedirectStandardOutput = true,
                                RedirectStandardError = true,
                                CreateNoWindow = true
                             }
                        };
                        process.Start();
                    }
                    else
                    {
                        MessageBox.Show("密码错误!");
                    }
                    break;
                case "退出软件":
                    if (tbShow.Password == SettingManager.GetSettingSingleton().pwd退出密码)
                    {
                        DialogResult = true;
                        SystemManager.Exit();
                    }
                    else
                    {
                        MessageBox.Show("密码错误!");
                    }
                    break;
                case "返回":
                    DialogResult = false;
                    this.Close();
                    break;
                case "重置":
                    tbShow.Password = "";
                    break;
                default:
                    tbShow.Password += content;
                    break;
            }
        }
    }
}
