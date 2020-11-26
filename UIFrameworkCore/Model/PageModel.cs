using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFrameworkCore.Model
{
    public class PageModel<T>:DMSkin.Core.ViewModelBase
    {
        private int _Total;
        public int Total
        {
            get { return _Total; }
            set
            {
                _Total = value;
                OnPropertyChanged(nameof(Total));
            }
        }
        private int _Pre;
        public int Pre
        {
            get { return _Pre; }
            set
            {
                _Pre = value;
                OnPropertyChanged(nameof(Pre));
            }
        }
        private int _Index;
        public int Index
        {
            get { return _Index; }
            set
            {
                _Index = value;
                OnPropertyChanged(nameof(Index));
            }
        }
        private List<T> _DataList;
        public List<T> DataList
        {
            get { return _DataList; }
            set
            {
                _DataList = value;
                OnPropertyChanged(nameof(DataList));
            }
        }
        private List<T> _CurrentPageDataList;
        public List<T> CurrentPageDataList
        {
            get { return _CurrentPageDataList; }
            set
            {
                _CurrentPageDataList = value;
                OnPropertyChanged(nameof(CurrentPageDataList));
            }
        }
    }
}
