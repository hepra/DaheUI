using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UIFrameworkCore.Model
{
     public class BookInfo:DMSkin.Core.ViewModelBase
    {
        private string _BookName;
        public string BookName
        {
            get { return _BookName; }
            set
            {
                _BookName = value;
                OnPropertyChanged(nameof(BookName));
            }
        }
        private ImageSource _BookIcon;
        public ImageSource BookIcon
        {
            get { return _BookIcon; }
            set
            {
                _BookIcon = value;
                OnPropertyChanged(nameof(BookIcon));
            }
        }
    }
}
