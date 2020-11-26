using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RangeSlider
{
    public class TimeRangeInfo : DMSkin.Core.ViewModelBase
    {
        public override bool Equals(object obj)
        {
            if(obj is TimeRangeInfo info)
            {
                return this.Width == info.Width && this.RangeStr == info.RangeStr && this.StartTime == info.StartTime;
            }
            return false;    
        }
        private bool _IsLocked;
        public bool IsLocked
        {
            get { return _IsLocked; }
            set
            {
                _IsLocked = value;
                OnPropertyChanged(nameof(IsLocked));
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
        private double _StartTimeValue;
        public double StartTimeValue
        {
            get { return _StartTimeValue; }
            set
            {
                _StartTimeValue = value;
                OnPropertyChanged(nameof(StartTimeValue));
            }
        }
        private DateTime _StartTime;
        public DateTime StartTime
        {
            get { return _StartTime; }
            set
            {
                try
                {
                    _StartTime = value;
                    OnPropertyChanged(nameof(StartTime));
                }
                catch
                {
                }
                
            }
        }
        private DateTime _EndTime;
        public DateTime EndTime
        {
            get { return _EndTime; }
            set
            {
                try
                {
                    _EndTime = value;
                    OnPropertyChanged(nameof(EndTime));
                }
                catch
                {
                }
 
            }
        }
        private double _EndTimeValue;
        public double EndTimeValue
        {
            get { return _EndTimeValue; }
            set
            {
                _EndTimeValue = value;
                OnPropertyChanged(nameof(EndTimeValue));
            }
        }
        private string _RangeStr;
        public string RangeStr
        {
            get { return _RangeStr; }
            set
            {
                _RangeStr = value;
                OnPropertyChanged(nameof(RangeStr));
            }
        }
        private Brush _RangeBrush;
        public Brush RangeBrush
        {
            get { return _RangeBrush; }
            set
            {
                _RangeBrush = value;
                OnPropertyChanged(nameof(RangeBrush));
            }
        }
    }
}
