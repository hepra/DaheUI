using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeSlider
{
    public class TimeLineInfo:DMSkin.Core.ViewModelBase
    {

        public TimeLineInfo()
        {
            _RangeItems = new ObservableCollection<TimeRangeInfo>();
        }
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        private ObservableCollection<TimeRangeInfo> _RangeItems;
        public ObservableCollection<TimeRangeInfo> RangeItems
        {
            get { return _RangeItems; }
            set
            {
                _RangeItems = value;
                OnPropertyChanged(nameof(RangeItems));
            }
        }

        private double _MinRangeVlue;
        public double MinRangeVlue
        {
            get { return _MinRangeVlue; }
            set
            {
                _MinRangeVlue = value;
                OnPropertyChanged(nameof(MinRangeVlue));
            }
        }
        private double _MaxRangeVlue;
        public double MaxRangeVlue
        {
            get { return _MaxRangeVlue; }
            set
            {
                _MaxRangeVlue = value;
                OnPropertyChanged(nameof(MaxRangeVlue));
            }
        }
        private double _Step;
        public double Step
        {
            get { return _Step; }
            set
            {
                _Step = value;
                OnPropertyChanged(nameof(Step));
            }
        }

        private double _Width;
        public double Width
        {
            get { return _Width; }
            set
            {
                _Width = value;
                OnPropertyChanged(nameof(Width));
            }
        }
        private double _Height;
        public double Height
        {
            get { return _Height; }
            set
            {
                _Height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

    }


}
