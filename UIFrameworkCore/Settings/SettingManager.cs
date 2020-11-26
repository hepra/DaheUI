using Newtonsoft.Json;
using UIFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UIFrameworkCore.Helper;

namespace UIFrameworkCore.Settings
{
    public class SettingManager
    {
        static SettingManager()
        {
            if (globalSettings == null)
            {
                ReadInfo();
            }
        }

        private static GlobalSettings globalSettings { get; set; }
        public static string SettingFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "GlobalSettings.json";
        public static void SaveInfo()
        {
            try
            {
                FileHelper.SaveFile_Create(SettingFilePath, JsonConvert.SerializeObject(globalSettings, Formatting.Indented));
            }
            catch (Exception ex)
            {

                throw new Exception("配置保存失败:" + ex.ToString());
            }

        }
        static double PrimaryScreenDPI = 96d;
        public static GlobalSettings ReadInfo()
        {
            try
            {
                var dpiXProperty = typeof(SystemParameters).GetProperty("DpiX", BindingFlags.NonPublic | BindingFlags.Static);
                PrimaryScreenDPI = (int)dpiXProperty.GetValue(null, null);
            }
            catch
            {
                PrimaryScreenDPI = 96d;
            }
            SettingManager.MainDPIRate = PrimaryScreenDPI / 96d;
            if (File.Exists(SettingFilePath))
            {
                globalSettings = JsonConvert.DeserializeObject<GlobalSettings>(FileHelper.readFile(SettingFilePath));
                globalSettings.GetScreenInfo(MainDPIRate);
                globalSettings.DPIRate = MainDPIRate;
                globalSettings.DPI = MainDPIRate * 96d;
                return globalSettings;
            }
            else
            {

                globalSettings = new GlobalSettings();
                globalSettings.DPIRate = MainDPIRate;
                globalSettings.DPI = MainDPIRate * 96d;
                globalSettings.Init();
                return globalSettings;
            }
        }
        public static double MainDPIRate { get; set; }
        public static GlobalSettings GetSettingSingleton()
        {
            if (globalSettings == null)
            {
                ReadInfo();
                DirectoryInfo di = new DirectoryInfo(globalSettings.ExecutePath);
            }
            if (globalSettings.Version == null)
            {
                DirectoryInfo di = new DirectoryInfo(globalSettings.ExecutePath);
            }
            if (globalSettings.当前已更新版本 == null)
            {
                globalSettings.当前已更新版本 = globalSettings.Version;
            }
            return globalSettings;
        }

        static Version GetMaxVersion(FileInfo[] files)
        {
            List<Version> temp = new List<Version>();
            foreach (var item in files)
            {
                var fileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(item.FullName);
                temp.Add(new Version(fileVersion.FileVersion));
            }
            return temp.Max();
        }
    }

}
