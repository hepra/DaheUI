
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
            Auto.GenerarteDataBase.GenerateDataBase();
            #region 代码动态生成控件
            TabItem tabItemPersonInfo = new TabItem();
            tabItemPersonInfo.Height = 60;
            tabItemPersonInfo.Header = "PersonInfo";
            tabItemPersonInfo.Content = new PersonInfoPageControl();
            tabMain.Items.Add(tabItemPersonInfo);
            TabItem tabItemModelBaseForDB = new TabItem();
            tabItemModelBaseForDB.Height = 60;
            tabItemModelBaseForDB.Header = "ModelBaseForDB";
            tabItemModelBaseForDB.Content = new ModelBaseForDBPageControl();
            tabMain.Items.Add(tabItemModelBaseForDB);
            #endregion

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
