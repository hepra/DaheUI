using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI框架.myControl.NoticeWindow
{
    public class NoticemMainViewModel : DMSkin.Core.ViewModelBase
    {
        public NoticemMainViewModel()
        {
            _NoticeItems = new ObservableCollection<NoticeViewModel>();
        }
        private ObservableCollection<NoticeViewModel> _NoticeItems;
        public ObservableCollection<NoticeViewModel> NoticeItems
        {
            get { return _NoticeItems; }
            set
            {
                _NoticeItems = value;
                OnPropertyChanged(nameof(NoticeItems));
            }
        }
    }
        public class NoticeViewModel:DMSkin.Core.ViewModelBase
    {
        public override bool Equals(object obj)
        {
            if(obj is NoticeViewModel model)
            {
                return (model.Msg + model.Title) == (this.Msg + this.Title);
            }
            return false;
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
        private string _Msg;
        public string Msg
        {
            get { return _Msg; }
            set
            {
                _Msg = value;
                OnPropertyChanged(nameof(Msg));
            }
        }
        private int _ShowTime;
        public int ShowTime
        {
            get { return _ShowTime; }
            set
            {
                _ShowTime = value;
                OnPropertyChanged(nameof(ShowTime));
            }
        }
        private double _Opcity;
        public double Opcity
        {
            get { return _Opcity; }
            set
            {
                _Opcity = value;
                OnPropertyChanged(nameof(Opcity));
            }
        }
    }
}
