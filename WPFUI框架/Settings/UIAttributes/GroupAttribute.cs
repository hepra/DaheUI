using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugs.Core.Settings.UIAttributes
{
    /// <summary>
    /// 表示一个选项所属的选项组
    /// </summary>
    public class GroupAttribute:SettingUIAttributeBase, IEquatable<GroupAttribute>
    {
        public GroupAttribute(string group_name)
        {
            GroupName = group_name;
        }

        public string GroupName { get; }

        public bool Equals(GroupAttribute other)
        {
            return other.GroupName == GroupName;
        }
    }
}
