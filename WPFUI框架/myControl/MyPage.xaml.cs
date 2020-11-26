using DMSkin.Core;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI框架.Styles
{
    /// <summary>
    /// MyPage.xaml 的交互逻辑
    /// </summary>
    public partial class MyPage:  UserControl 
    {
        public MyPage()
        {
            InitializeComponent();
        }
        public void SetDataSource<T>(DataTemplate listBoxDataTemplate, ObservableCollection<T> CLASSList,int prePageNum)
        {
            this.myList.ItemTemplate = listBoxDataTemplate;
            var _viewModel = new PageModel<T>();
            _viewModel.DataList = new ObservableCollection<T>(CLASSList);
            _viewModel.Pre = prePageNum;
            _viewModel.Total = CLASSList.Count / prePageNum;
            if(_viewModel.Total==0|| CLASSList.Count% prePageNum>0)
            {
                _viewModel.Total += 1;
            }
            _viewModel.Index = 1;
           
            this.DataContext = _viewModel;
        }
        public class PageModel<T> : DMSkin.Core.ViewModelBase
        {
            public PageModel()
            {
                DataList = new ObservableCollection<T>();
                CurrentPageDataList = new ObservableCollection<T>();
            }  
            private Visibility _上一页Visibility;
            public Visibility 上一页Visibility
            {
                get { return _上一页Visibility; }
                set
                {
                    _上一页Visibility = value;
                    OnPropertyChanged(nameof(上一页Visibility));
                }
            }
            private Visibility _下一页Visibility;
            public Visibility 下一页Visibility
            {
                get { return _下一页Visibility; }
                set
                {
                    _下一页Visibility = value;
                    OnPropertyChanged(nameof(下一页Visibility));
                }
            }
            private int _Total;
            public int Total
            {
                get { return _Total; }
                set
                {
                    _Total = value;
                    if(_Total<=1)
                    {
                        _下一页Visibility = Visibility.Collapsed;
                        _上一页Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        _下一页Visibility = Visibility.Visible; 
                    }
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
                    if(_Index==1&&_Total>1)
                    {
                        _下一页Visibility = Visibility.Visible;
                        _上一页Visibility = Visibility.Collapsed;
                    }
                    if(Index>1&&Index<Total)
                    {
                        _下一页Visibility = Visibility.Visible;
                        _上一页Visibility = Visibility.Visible;
                    }
                    if (Index == Total&&Total>1)
                    {
                        _下一页Visibility = Visibility.Collapsed;
                        _上一页Visibility = Visibility.Visible;
                    }
                    CurrentPageDataList = new ObservableCollection<T>( DataList.Skip((Index - 1) * Pre).Take(Pre));
                    OnPropertyChanged(nameof(Index));
                }
            }
            private ObservableCollection<T> _DataList;
            public ObservableCollection<T> DataList
            {
                get { return _DataList; }
                set
                {
                    _DataList = value;
                    OnPropertyChanged(nameof(DataList));
                }
            }
            private ObservableCollection<T> _CurrentPageDataList;
            public ObservableCollection<T> CurrentPageDataList
            {
                get { return _CurrentPageDataList; }
                set
                {
                    _CurrentPageDataList = value;
                    OnPropertyChanged(nameof(CurrentPageDataList));
                }
            }

            public ICommand Prev => new DelegateCommand(obj =>
            {
                this.Index--;
                if (Index>1)
                {
                
                    this.下一页Visibility = Visibility.Visible;
                }
                else
                {
                    this.上一页Visibility = Visibility.Collapsed;
                }
            });
            public ICommand Next => new DelegateCommand(obj =>
            {
                this.Index++;
                if (Index <Total)
                {
               
                    this.上一页Visibility = Visibility.Visible;
                }
                else
                {
                    this.下一页Visibility = Visibility.Collapsed;
                }
            });
        }

    }
}
