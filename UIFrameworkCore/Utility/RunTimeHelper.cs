using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFrameworkCore.Helper
{
   public class RunTimeHelper
    {
        /// <summary>
        /// 开机自启动
        /// </summary>
        /// <param name="isStart">true为添加启动项，否则为删除启动项</param>
        /// <param name="startName">启动项的名称</param>
        /// <param name="applicationPath">要开机启动的应用程序的exe文件的路径</param>
        /// <returns>表示是否完成添加或删除任务</returns>
        public static bool RunItem(bool isStart, string startName, string applicationPath)
        {
            bool result = true;
            RegistryKey HKLM = Registry.CurrentUser;
            RegistryKey run = HKLM.CreateSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\");

            if (isStart)
            {
                try
                {
                    run.SetValue(startName, applicationPath);
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
                    run.DeleteValue(startName);
                    HKLM.Close();
                }
                catch (Exception)
                {


                }
            }
            result = run.GetValue(startName) != null;
            HKLM.Close();

            return result;
        }

    }
}
