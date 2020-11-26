using DMSkin.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player.Helper
{
    public static class PrimaryScreen
    {
        #region Win32 API  
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr ptr);
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(
        IntPtr hdc, // handle to DC  
        int nIndex // index of capability  
        );
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
        #endregion
        #region DeviceCaps常量  
        const int HORZRES = 8;
        const int VERTRES = 10;
        const int LOGPIXELSX = 88;
        const int LOGPIXELSY = 90;
        const int DESKTOPVERTRES = 117;
        const int DESKTOPHORZRES = 118;
        #endregion
        public enum DpiType
        {
            Effective = 0,
            Angular = 1,
            Raw = 2,
        }

        public class DisplayDevice : ViewModelBase
        {
            /// <summary>
            /// 屏幕最大高度
            /// </summary>
            public double MaxHeight { get; set; }
            /// <summary>
            /// 屏幕最大宽度
            /// </summary>
            public double MaxWidth { get; set; }
            private string _screenTitle;
            /// <summary>
            /// 设备名称
            /// </summary>
            public string ScreenTitle
            {
                get { return _screenTitle; }
                set
                {
                    _screenTitle = value;
                    OnPropertyChanged(nameof(ScreenTitle));
                }
            }
            private double _leftMarginX;
            /// <summary>
            /// 左边距
            /// </summary>
            public double LeftMarginX
            {
                get { return _leftMarginX; }
                set
                {
                    _leftMarginX = value;
                    OnPropertyChanged(nameof(LeftMarginX));
                }
            }
            private double _topMarginY;
            /// <summary>
            /// 上边距
            /// </summary>
            public double TopMarginY
            {
                get { return _topMarginY; }
                set
                {

                    _topMarginY = value;

                    OnPropertyChanged(nameof(TopMarginY));
                }
            }

            private double _width;
            public double Width
            {
                get { return _width; }
                set
                {
                    _width = value;
                    OnPropertyChanged(nameof(Width));
                }
            }
            private double height;
            public double Height
            {
                get { return height; }
                set
                {
                    height = value;
                    OnPropertyChanged(nameof(Height));
                }
            }

            private double opacity;
            /// <summary>
            /// 透明度
            /// </summary>
            public double Opacity
            {
                get { return opacity; }
                set
                {
                    opacity = value;
                    if (value > 100)
                    {
                        opacity = 100;
                    }
                    if (value < 0)
                    {
                        opacity = 0;
                    }
                    OnPropertyChanged(nameof(Opacity));
                }
            }

            private double light;
            /// <summary>
            /// 亮度
            /// </summary>
            public double Light
            {
                get { return light; }
                set
                {
                    light = value;

                    if (value > 100)
                    {
                        light = 100;
                    }

                    if (value < 0)
                    {
                        light = 0;
                    }

                    UiLight = 1 - light / 100.0;
                    OnPropertyChanged(nameof(Light));
                }
            }
            private double uiLight;
            public double UiLight
            {
                get { return uiLight; }
                set
                {
                    uiLight = value;

                    OnPropertyChanged(nameof(UiLight));
                }
            }

            private bool opened;
            /// <summary>
            /// 亮度
            /// </summary>
            public bool Opened
            {
                get { return opened; }
                set
                {
                    opened = value;
                    OnPropertyChanged(nameof(Opened));
                }
            }
            /// <summary>
            /// 是否是虚拟显示设备,此属性用于显示在界面上,不作存储
            /// </summary>
            private bool _virtualDevice;
            public bool VirtualDevice
            {
                get => _virtualDevice;
                set
                {
                    _virtualDevice = value;
                    OnPropertyChanged(nameof(VirtualDevice));
                }
            }

            public void SetValue(DisplayDevice d)
            {
                this.Height = d.Height;
                this.height = d.height;
                this.LeftMarginX = d.LeftMarginX;
                this.light = d.light;
                this.Light = d.Light;
                this.MaxHeight = d.MaxHeight;
                this.MaxWidth = d.MaxWidth;
                this.opacity = d.opacity;
                this.Opacity = d.Opacity;
                this.ScreenTitle = d.ScreenTitle;
                this.TopMarginY = d.TopMarginY;
                this.VirtualDevice = d.VirtualDevice;
                this.Width = d.Width;
                this._leftMarginX = d._leftMarginX;
                this._screenTitle = d._screenTitle;
                this._topMarginY = d._topMarginY;
                this._virtualDevice = d._virtualDevice;
                this._width = d._width;
            }
        }
        public static void GetScreenNDpi(System.Windows.Forms.Screen screen, DpiType dpiType, out uint dpiX, out uint dpiY)
        {
            try
            {
                var pnt = new System.Drawing.Point(screen.Bounds.Left + 1, screen.Bounds.Top + 1);
                var mon = MonitorFromPoint(pnt, 2/*MONITOR_DEFAULTTONEAREST*/);
                GetDpiForMonitor(mon, dpiType, out dpiX, out dpiY);
            }
            catch (Exception)
            {
                dpiX = 96;
                dpiY = 96;
            }


        }

        public static IEnumerable< DisplayDevice> GetScreenInfo()
        {
            List<DisplayDevice> res = new List<DisplayDevice>();
            var screens = Screen.AllScreens.OrderBy(m => m.DeviceName).ToArray();
            var primary = Screen.PrimaryScreen;

            //   var primary = Screen.GetBounds();
            for (int i = 0; i < screens.Length; i++)
            {
                DisplayDevice displayDevice = new DisplayDevice();
                displayDevice.ScreenTitle = screens[i].DeviceName;
                uint dpiX = 96;
                uint dpiY = 96;
                PrimaryScreen.GetScreenNDpi(screens[i], 0, out dpiX, out dpiY);
                double dpiRatio = dpiX / 96d;
                displayDevice.MaxHeight = screens[i].Bounds.Height / dpiRatio;
                displayDevice.MaxWidth = screens[i].Bounds.Width / dpiRatio;
                displayDevice.LeftMarginX = screens[i].Bounds.Left / dpiRatio;
                displayDevice.TopMarginY = screens[i].Bounds.Top / dpiRatio;
                displayDevice.Width = screens[i].Bounds.Width / dpiRatio;
                displayDevice.Height = screens[i].Bounds.Height / dpiRatio;
                res.Add(displayDevice);
            }
            return res;
        }

        [DllImport("User32.dll")]
        private static extern IntPtr MonitorFromPoint([In] System.Drawing.Point pt, [In] uint dwFlags);

        [DllImport("Shcore.dll")]
        private static extern IntPtr GetDpiForMonitor([In] IntPtr hmonitor, [In] DpiType dpiType, [Out] out uint dpiX, [Out] out uint dpiY);


        #region 属性  
        /// <summary>  
        /// 获取屏幕分辨率当前物理大小  
        /// </summary>  
        public static Size WorkingArea
        {
            get
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                Size size = new Size();
                size.Width = GetDeviceCaps(hdc, HORZRES);
                size.Height = GetDeviceCaps(hdc, VERTRES);
                ReleaseDC(IntPtr.Zero, hdc);
                return size;
            }
        }
        /// <summary>  
        /// 当前系统DPI_X 大小 一般为96  
        /// </summary>  
        public static int DpiX
        {
            get
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                int DpiX = GetDeviceCaps(hdc, LOGPIXELSX);
                ReleaseDC(IntPtr.Zero, hdc);
                return DpiX;
            }
        }
        /// <summary>  
        /// 当前系统DPI_Y 大小 一般为96  
        /// </summary>  
        public static int DpiY
        {
            get
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                int DpiX = GetDeviceCaps(hdc, LOGPIXELSY);
                ReleaseDC(IntPtr.Zero, hdc);
                return DpiX;
            }
        }
        /// <summary>  
        /// 获取真实设置的桌面分辨率大小  
        /// </summary>  
        public static Size DESKTOP
        {
            get
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                Size size = new Size();
                size.Width = GetDeviceCaps(hdc, DESKTOPHORZRES);
                size.Height = GetDeviceCaps(hdc, DESKTOPVERTRES);
                ReleaseDC(IntPtr.Zero, hdc);
                return size;
            }
        }

        /// <summary>  
        /// 获取宽度缩放百分比  
        /// </summary>  
        public static float ScaleX
        {
            get
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                int t = GetDeviceCaps(hdc, DESKTOPHORZRES);
                int d = GetDeviceCaps(hdc, HORZRES);
                float ScaleX = (float)GetDeviceCaps(hdc, DESKTOPHORZRES) / (float)GetDeviceCaps(hdc, HORZRES);
                ReleaseDC(IntPtr.Zero, hdc);
                return ScaleX;
            }
        }
        /// <summary>  
        /// 获取高度缩放百分比  
        /// </summary>  
        public static float ScaleY
        {
            get
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                float ScaleY = (float)(float)GetDeviceCaps(hdc, DESKTOPVERTRES) / (float)GetDeviceCaps(hdc, VERTRES);
                ReleaseDC(IntPtr.Zero, hdc);
                return ScaleY;
            }
        }
        #endregion
    }

}
