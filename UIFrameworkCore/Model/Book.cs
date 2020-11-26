using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UIFrameworkCore.Model
{
    public class Book:DMSkin.Core.ViewModelBase
    {
        private ImageSource _BookContent;
        public ImageSource BookContent
        {
            get { return _BookContent; }
            set
            {
                _BookContent = value;
                OnPropertyChanged(nameof(BookContent));
            }
        }
    }
}
