using UIFrameworkCore.Settings.UIAttributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using static Player.Helper.PrimaryScreen;

namespace UIFrameworkCore
{
    public class GlobalSettings
    {
        public void Init()
        {
            this.BaseUrl = "https://www.wemew.com";
            this.currentSelectWemewPattern = "2";


            this.当前已更新版本 = this.Version;
            this.Type2Pattern = 1;
            this.currentSelectWemewBackground = "0";
            this.MaxVirualScreenSount = 5;
            this.MaxDownloadSpeed = 10240;
            this.AutoCheckUpdate = true;
            this.DownloadServicePort = 10083;
            this.时间服务器地址 = "ntp1.aliyun.com";
            this.浏览器控制台快捷键 = "Ctrl+F12";
            this.关闭投屏快捷键 = "Alt+R";
            this.自动同步时间 = true;
            this.IsRememberPwd = true;
            this.AutoClearMemery = true;
            this.IsAutoLogin = false;
            this.IsEnableGPU = true;
            this.PingOffsetMs = 1000;
            this.MaxFrameRate = 60;

            this.ScreenListInfo = new ObservableCollection<DisplayDevice>();
            var screens = Screen.AllScreens.OrderBy(m => m.DeviceName).ToArray();
            foreach (var item in screens)
            {
                var displayDevice = new DisplayDevice
                {
                    MaxHeight = item.Bounds.Height,
                    MaxWidth = item.Bounds.Width,
                    Opened = false,
                    VirtualDevice = false,
                    Opacity = 100,
                    Light = 100,
                    LeftMarginX = item.Bounds.X,
                    TopMarginY = item.Bounds.Y, 
                    Width = item.Bounds.Width,
                    Height = item.Bounds.Height,
                    ScreenTitle = item.DeviceName
                };
                this.ScreenListInfo.Add(displayDevice);
            }

        }
        public void GetScreenInfo(double dpiRate)
        {
            var screens = Screen.AllScreens.OrderBy(m => m.DeviceName).ToArray();
            string xx = dpiRate.ToString("0.##");
            string Scalefactor = "100%";
            switch (dpiRate.ToString("0.##"))
            {
                case "1":
                    Scalefactor = "100%";
                    break;
                case "1.25":
                    Scalefactor = "125%";
                    break;
                case "1.5":
                    Scalefactor = "150%";
                    break;
                case "1.75":
                    Scalefactor = "175%";
                    break;
            }

            var wuli = this.ScreenListInfo.Where(x => x.VirtualDevice == false).ToList();
            foreach (var item in wuli)
            {
                this.ScreenListInfo.Remove(item);
            }
            foreach (var item in screens)
            {
                if (item.Primary == true)
                {
                    var displayDevice = new DisplayDevice
                    {
                        MaxHeight = item.Bounds.Height / dpiRate,
                        MaxWidth = item.Bounds.Width / dpiRate,
                        VirtualDevice = false,
                        Opacity = 100,
                        Light = 100,
                        LeftMarginX = item.Bounds.X,
                        TopMarginY = item.Bounds.Y,
                        Width = item.Bounds.Width / dpiRate,
                        Height = item.Bounds.Height / dpiRate,
                        ScreenTitle = item.DeviceName,
                    };
                    var existSetting = wuli.Where(x => x.ScreenTitle == displayDevice.ScreenTitle).FirstOrDefault();
                    displayDevice.Opened = existSetting == null?false: existSetting.Opened;
                    this.UpdateDisplayScreenList(displayDevice);
                }
                else
                {
                    var displayDevice = new DisplayDevice
                    {
                        MaxHeight = item.Bounds.Height,
                        MaxWidth = item.Bounds.Width,
                        VirtualDevice = false,
                        Opacity = 100,
                        Light = 100,
                        LeftMarginX = item.Bounds.X / dpiRate,
                        TopMarginY = item.Bounds.Y / dpiRate,
                        Width = item.Bounds.Width / dpiRate,
                        Height = item.Bounds.Height / dpiRate,
                        ScreenTitle = item.DeviceName
                    };
                    var existSetting = wuli.Where(x => x.ScreenTitle == displayDevice.ScreenTitle).FirstOrDefault();
                    displayDevice.Opened = existSetting == null ? false : existSetting.Opened;
                    this.UpdateDisplayScreenList(displayDevice);
                }


            }
        }
        [ModelIgnore]
        public string pwd关机密码 { get; set; } = "1234";
        [ModelIgnore]
        public string pwd退出密码 { get; set; } = "1234";
        [ModelIgnore]
        public string pwd管理员密码 { get; set; } = "1234";

        [ModelIgnore]
        public string VlcRootPath { get; set; } = System.AppDomain.CurrentDomain.BaseDirectory+ "libvlc\\win-x86";
        [ModelIgnore]
        public string IP文件服务器 { get; set; } = "127.0.0.1";
        [ModelIgnore]
        public string IP数据库同步 { get; set; } = "127.0.0.1";
        [ModelIgnore]
        public int port文件传输端口 { get; set; } = 10086;
        [ModelIgnore]
        public int port数据库同步端口 { get; set; } = 10084;
        [ModelIgnore]
        public string DbPath { get; set; } = System.AppDomain.CurrentDomain.BaseDirectory + "db\\database.db";

        [ModelIgnore]
        public string BaseUrl { get; set; } = "https://www.wemew.com";
        [ModelIgnore]
        public string PlugsManagerUrl { get; set; } = "http://192.168.4.122/PlugsConfig.json";
        [ModelIgnore]
        public string UpdateConfigUrl { get; set; } = "http://192.168.4.122/PlugsUpdateConfig.json";
        [ModelIgnore]
        public string UserId { get; set; }
        [ModelIgnore]
        public string UserName { get; set; }
        [ModelIgnore]
        public  string LoginId { get; set; }
        [ModelIgnore]
        public string LiveUrl { get; set; }
        [ModelIgnore]
        public  string Password { get; set; }
        [ModelIgnore]
        public  string IcoUrl { get; set; }
        [ModelIgnore]
        public bool IsRememberPwd { get; set; }
        [ModelIgnore]
        public bool IsAutoLogin { get; set; }
        [ModelIgnore]
        public string CurrentBrowserUrl { get; set; }
        [Group("系统信息")]
        [Description("系统缩放")]
        [NameAlias("系统DPI")]
        public double DPI { get; set; }
        [ModelIgnore]
        public double DPIRate { get; set; }
        [Group("系统信息")]
        [Description("当前版本")]
        [NameAlias("版本号")]
        public  Version Version { get; set; }
        [Group("系统信息")]
        [NameAlias("是否启动检查更新")]
        public bool AutoCheckUpdate { get; set; }
        [Group("系统设置")]
        [Description("重启后生效")]
        [NameAlias("启用硬件加速")]
        public  bool IsEnableGPU { get; set; }
        [Group("系统设置")]
        [Description("(重启后生效)")]
        [NameAlias("浏览器最大渲染帧率")]
        public int MaxFrameRate { get; set; } = 60;
        [Group("系统设置")]
        [Description("重启后生效")]
        [NameAlias("自动释放内存")]
        public bool AutoClearMemery { get; set; } = true;

        [Group("系统设置")]
        [Description("每隔 x(ms)检测一次网络延迟")]
        [NameAlias("网络延迟检测间隔(ms)")]
        public int PingOffsetMs { get; set; } = 1000;
        [Group("快捷键")]
        [NameAlias("启动浏览器控制台")]
        public string 浏览器控制台快捷键 { get; set; } = "Ctrl+F12";
        [Group("快捷键")]
        [NameAlias("关闭投影")]
        public string 关闭投屏快捷键 { get; set; } = "Alt+R";

        #region  记录主窗体最大化之前的大小和位置
        public double normalHeight { get; set; }
        public double normalWidth { get; set; }
        public double normalLeft { get; set; }
        public double normalTop { get; set; }

        /// <summary>
        /// 1弹幕 2上下新潮 3 绝伦直播
        /// </summary>
        [ModelIgnore]
        public string currentSelectWemewPattern { get; set; }
        /// <summary>
        /// 0上下滚动 1新潮
        /// </summary>
        [ModelIgnore]
        public  int Type2Pattern { get; set; }

        /// <summary>
        /// 0 视频 1图片 3黑色 4透明
        /// </summary>
        [ModelIgnore]
        public  string currentSelectWemewBackground { get; set; }

        #endregion
        [Group("系统设置")]
        [NameAlias("启用自动同步时间")]
        public bool 自动同步时间 { get; set; }
        [Group("系统设置")]
        [NameAlias("设置时间服务器地址")]
        public string 时间服务器地址 { get; set; } = "ntp1.aliyun.com";

        /// <summary>
        /// 执行文件路径
        /// </summary>
        [ModelIgnore]
        public  string ExecutePath { get; set; } = System.AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 记录打开文件操作 上次打开的路径
        /// </summary>
        [ModelIgnore]
        public  string LastestImportPath { get; set; }
        [Group("系统设置")]
        [NameAlias("最大可添加虚拟屏幕数量")]
        public int MaxVirualScreenSount { get; set; }
        [Group("系统设置")]
        [NameAlias("后台每页展示数量")]
        public int PerPageRecordCount { get; set; } = 10;
        [ModelIgnore]
        public  ObservableCollection<DisplayDevice> ScreenListInfo { get; set; }
        [ModelIgnore]
    

        [Group("系统设置")]
        [NameAlias("开机自启动")]
        public bool AutoStarting { get; set; }

        [Group("下载设置")]
        [NameAlias("下载完成时提示")]
        public bool DownloadCompleteTips { get; set; }
        [Group("下载设置")]
        [NameAlias("最大下载速度(kb/s)")]
        public int MaxDownloadSpeed { get; set; }
        [Group("下载设置")]
        [NameAlias("自动下载未完成任务")]
        public bool AutoContinueDownload { get; set; }
        [Group("下载设置")]
        [NameAlias("下载服务端口")]
        public int DownloadServicePort { get; set; }
        [ModelIgnore]
        public Version 当前已更新版本 { get; set; }
        [ModelIgnore]
        public bool UpdateDownloadComplete { get; set; } = true;
        [ModelIgnore]

        public void UpdateDisplayScreenList(DisplayDevice device)
        {
           if(ScreenListInfo.Contains(device))
            {
                for (int i = 0; i < ScreenListInfo.Count; i++)
                {
                    if (ScreenListInfo[i].Equals(device))
                    {
                        ScreenListInfo[i] = device;
                    }
                }
            }
           else
            {
                ScreenListInfo.Add(device);
            }
            for (int i = 0; i < this.ScreenListInfo.Count; i++)
            {
                for (int j = i + 1; j < this.ScreenListInfo.Count; j++)
                {
                    if (this.ScreenListInfo[i].VirtualDevice==true&&this.ScreenListInfo[j].VirtualDevice==false)
                    {
                        var t = this.ScreenListInfo[i];
                        this.ScreenListInfo[i] = this.ScreenListInfo[j];
                        this.ScreenListInfo[j] = t;
                        //   break;
                    }
                }
            }
        }

    } 
}
