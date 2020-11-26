using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UIFrameworkCore.Interface
{
   public  interface IControl
    {
        Version Version { get; }
        string AssemblyName { get; }
        string Name { get; }
        string DownloadUrl { get; }
        string Descript { get; }

        Control Create();
    }
}
