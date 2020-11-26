using DMSkin.Core;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using UIFrameworkCore.Model;

namespace UI框架.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public  MainViewModel()
        {
            _BookPages = new ObservableCollection<Book>();
            PageIndex = 1;
        }
    
 
        private int _PageIndex;
        public int PageIndex
        {
            get { return _PageIndex; }
            set
            {
                _PageIndex = value;
                OnPropertyChanged(nameof(PageIndex));
            }
        }
        private int _TotalPage;
        public int TotalPage
        {
            get { return _TotalPage; }
            set
            {
                _TotalPage = value;
                OnPropertyChanged(nameof(TotalPage));
            }
        }
    

        private ImageSource _屏保页;
        [JsonIgnore]
        public ImageSource 屏保页
        {
            get { return _屏保页; }
            set
            {
                _屏保页 = value;
           
                OnPropertyChanged(nameof(屏保页));
            }
        }

        private ObservableCollection<Book> _BookPages;
        public ObservableCollection<Book> BookPages
        {
            get { return _BookPages; }
            set
            {
                _BookPages = value;
                OnPropertyChanged(nameof(BookPages));
            }
        }

        private ImageSource _CurrentImage_Source;
        [JsonIgnore]
        public ImageSource CurrentImage_Source
        {
            get { return _CurrentImage_Source; }
            set
            {
                _CurrentImage_Source = value;
                OnPropertyChanged(nameof(CurrentImage_Source));
            }
        }


        private Visibility _管理员模式;
        [JsonIgnore]
        public Visibility 管理员模式
        {
            get { return _管理员模式; }
            set
            {
                _管理员模式 = value;
                OnPropertyChanged(nameof(管理员模式));
            }
        }
    
    

        private ImageSource _MainBackGround;
        [JsonIgnore]
        public ImageSource MainBackGround
        {
            get { return _MainBackGround; }
            set
            {
                _MainBackGround = value;
                OnPropertyChanged(nameof(MainBackGround));
            }
        }
        private ImageSource _OtherBackGround;
        [JsonIgnore]
        public ImageSource OtherBackGround
        {
            get { return _OtherBackGround; }
            set
            {
                _OtherBackGround = value;
                OnPropertyChanged(nameof(OtherBackGround));
            }
        }


    
    }
}
