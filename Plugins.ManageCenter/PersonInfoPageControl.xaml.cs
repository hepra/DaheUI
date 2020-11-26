
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using UIFrameworkCore.Model;
using UIFrameworkCore.Model.DataBase;
using UIFrameworkCore.Settings;

namespace Plugins.ManageCenter
{
    public class PersonInfoPageViewModel<T> : DMSkin.Core.ViewModelBase
    {
        private ObservableCollection<T> _CurrentPageList = new ObservableCollection<T>();
        public ObservableCollection<T> CurrentPageList
        {
            get { return _CurrentPageList; }
            set
            {
                _CurrentPageList = value;
                OnPropertyChanged(nameof(CurrentPageList));
            }
        }
        private T _CurrentPerson;
        public T CurrentPerson
        {
            get { return _CurrentPerson; }
            set
            {
                _CurrentPerson = value;
                OnPropertyChanged(nameof(CurrentPerson));
            }
        }
        private SqliteSeverMsgModel _MsgModel;
        public SqliteSeverMsgModel MsgModel
        {
            get { return _MsgModel; }
            set
            {
                _MsgModel = value;
                OnPropertyChanged(nameof(MsgModel));
            }
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
    }
    public partial class PersonInfoPageControl : UserControl
    {

        PersonInfoPageViewModel<PersonInfo> _viewModel;
        SimpleTCP.SimpleTcpClient SQLiteClient;
        public PersonInfoPageControl()
        {
            InitializeComponent();
            StartSqliteClient();
            _viewModel = new PersonInfoPageViewModel<PersonInfo>();
            this.DataContext = _viewModel;
        }

        void StartSqliteClient()
        {
            try
            {
                SQLiteClient = new SimpleTCP.SimpleTcpClient();
                SQLiteClient.Connect(SettingManager.GetSettingSingleton().IP数据库同步, SettingManager.GetSettingSingleton().port数据库同步端口);
                SQLiteClient.DataReceived += SQLiteClient_DataReceived; ;
            }
            catch (Exception ex)
            {

                UIFrameworkCore.SystemManager.ShowMessageDialog(ex.ToString());
            }

        }
        private void SQLiteClient_DataReceived(object sender, SimpleTCP.Message e)
        {
            if (e.MessageString.Contains("MsgModelName"))
            {
                SqliteSeverMsgModel msgModel = JsonConvert.DeserializeObject<SqliteSeverMsgModel>(e.MessageString);
                switch (msgModel.MsgModelName)
                {
                    case "PersonInfo":
                        switch (msgModel.MsgType)
                        {
                            case "更新成功":
                            case "添加成功":
                            case "删除成功":
                                this.Dispatcher.Invoke(() =>
                                {
                                    UIFrameworkCore.SystemManager.ShowMessageDialog(msgModel.MsgType);
                                });
                             
                                break;
                            case "queryresult":
                                var msgData = JsonConvert.DeserializeObject<List<PersonInfo>>(msgModel.MsgModel);
                                var resultList = new ObservableCollection<PersonInfo>(msgData);
                                this.Dispatcher.Invoke(()=> {
                                    _viewModel.CurrentPageList = resultList;
                                    _viewModel.TotalPage = msgModel.PageTotalCount;
                                });
                            
                                break;
                        }
                        break;
                }
            }
        }

        private void 数据库搜索(object sender, RoutedEventArgs e)
        {
            _viewModel.CurrentPerson = new PersonInfo() { SearchCondition = tbName.Text};
            _viewModel.CurrentPageList.Add(_viewModel.CurrentPerson);
            _viewModel.MsgModel = new SqliteSeverMsgModel()
            {
                MsgModel = JsonConvert.SerializeObject(new List<PersonInfo>() { _viewModel.CurrentPerson })
                ,
                MsgModelName = "PersonInfo"
                ,
                MsgType = "query"
                ,
                PageInex = _viewModel.PageIndex
                ,
                PageCount = SettingManager.GetSettingSingleton().PerPageRecordCount
                ,
                PageTotalCount = _viewModel.TotalPage
            };
            SQLiteClient.Write(JsonConvert.SerializeObject(_viewModel.MsgModel));
        }
        private void btn操作数据库_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button btn)
            {
                if(btn.DataContext is PersonInfo soure)
                {
                    switch (btn.Content.ToString())
                    {
                        case "更新":
                            _viewModel.CurrentPerson = soure;
                            DataBaseOperationWindow dataBaseOperationWindow = new DataBaseOperationWindow();
                            dataBaseOperationWindow.InitWindow<PersonInfo>(_viewModel.CurrentPerson);
                            dataBaseOperationWindow.ShowDialog();
                            //点击更新
                            if(dataBaseOperationWindow.DialogResult == true)
                            {
                                for (int i = 0; i < _viewModel.CurrentPageList.Count; i++)
                                {
                                    var item = _viewModel.CurrentPageList[i];
                                    if (item.Id == _viewModel.CurrentPerson.Id)
                                    {
                                        _viewModel.CurrentPageList[i] = _viewModel.CurrentPerson;
                                    }
                                }
                                _viewModel.MsgModel = new SqliteSeverMsgModel()
                                {
                                    MsgModel = JsonConvert.SerializeObject(new List<PersonInfo>() { _viewModel.CurrentPerson })
                   ,
                                    MsgModelName = "PersonInfo"
                   ,
                                    MsgType = "update"
                   ,
                                    PageInex = _viewModel.PageIndex
                   ,
                                    PageCount = SettingManager.GetSettingSingleton().PerPageRecordCount
                   ,
                                    PageTotalCount = _viewModel.TotalPage
                                };
                                SQLiteClient.Write(JsonConvert.SerializeObject(_viewModel.MsgModel));
                            }
                            //点击返回
                            break;
                        case "添加":
                            _viewModel.CurrentPerson = new PersonInfo();
                            DataBaseOperationWindow dataBaseOperationWindowAdd = new DataBaseOperationWindow("添加");
                            dataBaseOperationWindowAdd.InitWindow<PersonInfo>(_viewModel.CurrentPerson);
                            dataBaseOperationWindowAdd.ShowDialog();
                            if(dataBaseOperationWindowAdd.DialogResult==true)
                            {
                                _viewModel.CurrentPageList.Add(_viewModel.CurrentPerson);
                                _viewModel.MsgModel = new SqliteSeverMsgModel()
                                {
                                    MsgModel = JsonConvert.SerializeObject(new List<PersonInfo>() { _viewModel.CurrentPerson })
                                    ,
                                    MsgModelName = "PersonInfo"
                                    ,
                                    MsgType = "add"
                                    ,
                                    PageInex = _viewModel.PageIndex
                                    ,
                                    PageCount = SettingManager.GetSettingSingleton().PerPageRecordCount
                                    ,
                                    PageTotalCount = _viewModel.TotalPage
                                };
                                SQLiteClient.Write(JsonConvert.SerializeObject(_viewModel.MsgModel));
                            }
                          
                            break;
                        case "删除":
                            if (MessageBox.Show("确认删除吗?", "删除提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                            {
                                _viewModel.CurrentPerson =soure;
                                _viewModel.CurrentPageList.Remove(_viewModel.CurrentPerson);
                                _viewModel.MsgModel = new SqliteSeverMsgModel()
                                {
                                    MsgModel = JsonConvert.SerializeObject(new List<PersonInfo>() { _viewModel.CurrentPerson })
                ,
                                    MsgModelName = "PersonInfo"
                ,
                                    MsgType = "delete"
                ,
                                    PageInex = _viewModel.PageIndex
                ,
                                    PageCount = SettingManager.GetSettingSingleton().PerPageRecordCount
                ,
                                    PageTotalCount = _viewModel.TotalPage
                                };
                                SQLiteClient.Write(JsonConvert.SerializeObject(_viewModel.MsgModel));
                            }
                            break;
                    }

                }

            }

        }

        //过滤DataGrid展示的数据
        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;

            //默认字段 不显示
            if (propertyDescriptor.DisplayName == nameof(_viewModel.CurrentPerson.IsLoad))
            {
                e.Cancel = true;
            }
            if (propertyDescriptor.DisplayName == nameof(_viewModel.CurrentPerson.Id))
            {
                e.Cancel = true;
            }
            if (propertyDescriptor.DisplayName == nameof(_viewModel.CurrentPerson.SearchCondition))
            {
                e.Cancel = true;
            }
            if (propertyDescriptor.DisplayName == nameof(_viewModel.CurrentPerson.DeleteFlag))
            {
                e.Cancel = true;
            }
            if (propertyDescriptor.DisplayName == nameof(_viewModel.CurrentPerson.CreateDate))
            {
                e.Cancel = true;
            }

            if (propertyDescriptor.DisplayName == nameof(_viewModel.CurrentPerson.Update))
            {
                e.Cancel = true;
            }
        }

        private void 新增数据库数据(object sender, RoutedEventArgs e)
        {
            _viewModel.CurrentPerson = new PersonInfo();
            DataBaseOperationWindow dataBaseOperationWindowAdd = new DataBaseOperationWindow("添加");
            dataBaseOperationWindowAdd.InitWindow<PersonInfo>(_viewModel.CurrentPerson);
            dataBaseOperationWindowAdd.ShowDialog();
            if (dataBaseOperationWindowAdd.DialogResult == true)
            {
                _viewModel.CurrentPageList.Add(_viewModel.CurrentPerson);
                _viewModel.MsgModel = new SqliteSeverMsgModel()
                {
                    MsgModel = JsonConvert.SerializeObject(new List<PersonInfo>() { _viewModel.CurrentPerson })
                    ,
                    MsgModelName = "PersonInfo"
                    ,
                    MsgType = "add"
                    ,
                    PageInex = _viewModel.PageIndex
                    ,
                    PageCount = SettingManager.GetSettingSingleton().PerPageRecordCount
                    ,
                    PageTotalCount = _viewModel.TotalPage
                };
                SQLiteClient.Write(JsonConvert.SerializeObject(_viewModel.MsgModel));
            }

        }

        private void 数据库搜索时删除(object sender, RoutedEventArgs e)
        {
            if (tbName.Text.Length > 0)
            {
                tbName.Text = tbName.Text.Substring(0, tbName.Text.Length - 1);
            }

        }
        private void Grid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(gridLoading.Visibility == Visibility.Collapsed)
            {
                loading.IsActive = false;
            }
            else
            {
                loading.IsActive = true;
            }
        }

        private void 上一页(object sender, RoutedEventArgs e)
        {
            _viewModel.PageIndex--;
            if (_viewModel.PageIndex < 1)
            {
                _viewModel.PageIndex = _viewModel.TotalPage;
            }
            if (_viewModel.PageIndex > 1)
            {

                _viewModel.下一页Visibility = Visibility.Visible;
            }
            else
            {
                _viewModel.上一页Visibility = Visibility.Collapsed;
            }
            _viewModel.CurrentPerson = new PersonInfo() {Id=Guid.NewGuid()};
            _viewModel.MsgModel = new SqliteSeverMsgModel()
            {
                MsgModel = JsonConvert.SerializeObject(new List<PersonInfo>() { _viewModel.CurrentPerson })
                ,
                MsgModelName = "PersonInfo"
                ,
                MsgType = "queryPage"
                ,
                PageInex = _viewModel.PageIndex
                ,
                PageCount = SettingManager.GetSettingSingleton().PerPageRecordCount
                ,
                PageTotalCount = _viewModel.TotalPage
            };
            SQLiteClient.Write(JsonConvert.SerializeObject(_viewModel.MsgModel));
        }

        private void 下一页(object sender, RoutedEventArgs e)
        {
            _viewModel.PageIndex++;
            if (_viewModel.PageIndex > _viewModel.TotalPage)
            {
                _viewModel.PageIndex = 1;
            }
            if (_viewModel.PageIndex < _viewModel.TotalPage)
            {

                _viewModel.上一页Visibility = Visibility.Visible;
            }
            else
            {
                _viewModel.下一页Visibility = Visibility.Collapsed;
            }
            _viewModel.CurrentPerson = new PersonInfo() ;
            _viewModel.MsgModel = new SqliteSeverMsgModel()
            {
                MsgModel = JsonConvert.SerializeObject(new List<PersonInfo>() { _viewModel.CurrentPerson })
                ,
                MsgModelName = "PersonInfo"
                ,
                MsgType = "queryPage"
                ,
                PageInex = _viewModel.PageIndex
                ,
                PageCount = SettingManager.GetSettingSingleton().PerPageRecordCount
                ,
                PageTotalCount = _viewModel.TotalPage
            };
            SQLiteClient.Write(JsonConvert.SerializeObject(_viewModel.MsgModel));
        }
    }
}
