using DMSkin.Core;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using UIFrameworkCore.Settings.UIAttributes;

namespace UIFrameworkCore.Model.DataBase
{
    public class PersonInfo : ModelBaseForDB
    {
        private string _Name;
        [NameAlias("姓名")]
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private bool _IsAlive;
        [NameAlias("是否活着")]
        public bool IsAlive
        {
            get { return _IsAlive; }
            set
            {
                _IsAlive = value;
                OnPropertyChanged(nameof(IsAlive));
            }
        }

    }

}
