using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UIFrameworkCore.Interface;

namespace UIFrameworkCore.PluginsBase
{
    public abstract class ControlBase : IControl
    {
        public  Version Version => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        public  string AssemblyName=> Assembly.GetExecutingAssembly().GetName().Name+".dll";
        public abstract string Name { get; }
        public abstract string DownloadUrl { get; }
        public abstract string Descript { get; }
        public abstract Control Create();
    }
}
