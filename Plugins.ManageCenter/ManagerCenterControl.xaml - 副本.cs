using System.Collections.Generic;
using System.Windows.Controls;
using UIFrameworkCore.DependencyInjectionExtension;
using UIFrameworkCore.Emnu;

namespace Plugins.ManageCenter
{
    [NoProxy]
    [Export(typeof(ManagerCenterControl))]
    public partial class ManagerCenterControl : UserControl
    {
        public ManagerCenterControl()
        {
            InitializeComponent();
            tabMain.Items.Clear();

            TabItem tabItemDataBaseInfo = new TabItem();
            tabItemDataBaseInfo.Content = new DataBaseInfoDIsplayPageControl(new List<UIFrameworkCore.Model.DataBase.ModelBaseForDB>());
            tabMain.Items.Add(tabItemDataBaseInfo);
            var type = typeof(Level);
            var propList = type.GetProperties();
            List<PropertyInfoWrapper> wrappers = new List<PropertyInfoWrapper>();
            foreach (var item in propList)
            {
                wrappers.Add(new PropertyInfoWrapper()
                {
                    PropertyInfo = item,
                    OwnerObject = type
                });
            }

        }
    }
}
