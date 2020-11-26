using System.Windows.Controls;
using UIFrameworkCore.DependencyInjectionExtension;
using UIFrameworkCore.Interface;
using UIFrameworkCore.PluginsBase;

namespace Plugins.ManageCenter
{
    [Export(typeof(IControl))]
    public class ManageCenter : ControlBase
    {
        Control _control;
        public ManageCenter(ManagerCenterControl control)
        {
            _control = control;
        }
        public override string Name => "后台管理中心";

        public override string DownloadUrl => "";

        public override string Descript => "";

        public override Control Create()
        {
            return _control;
        }
    }
}
