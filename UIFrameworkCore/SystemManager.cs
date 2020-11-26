using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIFrameworkCore.Dialogs;
using UIFrameworkCore.Settings;

namespace UIFrameworkCore
{
    public class SystemManager
    {
        static public void Restart()
        {
            SettingManager.GetSettingSingleton().IsAutoLogin = false;
            SettingManager.SaveInfo();

            var fileName = Process.GetCurrentProcess().MainModule.FileName;
            // MessageBox.Show(fileName);
            Process.Start(fileName);

            Environment.Exit(0);
        }  
        static public void Exit()
        {
            SettingManager.GetSettingSingleton().IsAutoLogin = false;
            SettingManager.SaveInfo();
            //强制杀死所有进程
            var processList = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            foreach (var item in processList)
            {
                item.Kill();
            }
            Environment.Exit(0);
        }

        /// <summary>
        /// 开机自启动
        /// </summary>
        /// <param name="isStart">true为添加启动项，否则为删除启动项</param>
        /// <param name="startName">启动项的名称</param>
        /// <param name="applicationPath">要开机启动的应用程序的exe文件的路径</param>
        /// <returns>表示是否完成添加或删除任务</returns>
        public static bool RunBootUpItem(bool isStart)
        {
            bool result = true;
            RegistryKey HKLM = Registry.CurrentUser;
            RegistryKey run = HKLM.CreateSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\");

            if (isStart)
            {
                try
                {
                    run.SetValue(Process.GetCurrentProcess().ProcessName + "_BootUp", Process.GetCurrentProcess().MainModule.FileName);
                    HKLM.Close();
                }
                catch (Exception)
                {


                }
            }
            else
            {
                try
                {
                    run.DeleteValue(Process.GetCurrentProcess().ProcessName + "_BootUp");
                    HKLM.Close();
                }
                catch (Exception)
                {


                }
            }
            result = run.GetValue(Process.GetCurrentProcess().ProcessName + "_BootUp") != null;
            HKLM.Close();

            return result;
        }


        public static bool ShowMessageDialog(string msg)
        {
          HandleExpection handleExpection = new HandleExpection("提示", msg);
            return (bool)handleExpection.ShowDialog();
        }

        public static bool ShowMessageDialogConfim_Cancel(string msg)
        {
            HandleExpection handleExpection = new HandleExpection("提示", msg,"取消","确认");
            return (bool)handleExpection.ShowDialog();
        }

    }
}
