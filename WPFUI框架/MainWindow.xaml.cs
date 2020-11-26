
using EasyFileTransfer;
using file_transfer;
using Newtonsoft.Json;
using Panuon.UI.Silver;
using Panuon.UI.Silver.Controls.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using UIFrameworkCore;
using UIFrameworkCore.DependencyInjectionExtension;
using UIFrameworkCore.Helper;
using UIFrameworkCore.Interface;
using UIFrameworkCore.Model;
using UIFrameworkCore.Model.DataBase;
using UIFrameworkCore.Settings;
using UI框架.ViewModel;
using Button = System.Windows.Controls.Button;

namespace UI框架
{
   [NoProxy]
   [Export(typeof(MainWindow))]
   public partial class MainWindow
   {
       static string root_path = (System.AppDomain.CurrentDomain.BaseDirectory);
       ViewModel.MainViewModel _viewModel;
       SimpleTCP.SimpleTcpServer SQLiteSever;

       #region  UI框架 内置函数

        /// <summary>
        /// 模拟win10通知  但是不知道怎么从下面往上面叠加
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="durationSeconds"></param>
        /// <param name="noticeIcon"></param>
       private static void CallNoticeWindow(string message, string title, double? durationSeconds, MessageBoxIcon noticeIcon)
       {
           if (NoticeWindow.Instance == null)
           {
               var window = new NoticeWindow();
               window.Show();
           }
           NoticeWindow.Instance.AddNotice(message, title);
       }

       private void gridLoading_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
       {
           if (gridLoading.Visibility == Visibility.Visible)
           {
               myLoad.IsLoading = true;
           }
           else
           {
               myLoad.IsLoading = false;
           }
       }

       private void 键盘弹出(object sender, RoutedEventArgs e)
       {
           NumkeyBorad numkeyBoradTemp = new NumkeyBorad();
           numkeyBoradTemp.Owner = this;

           if (numkeyBoradTemp.ShowDialog() == true)
           {
               this.Close();
           }
       }
       private void Window_Closed(object sender, EventArgs e)
       {
           SystemManager.Exit();
       }
       private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
       {
           if (e.Key == System.Windows.Input.Key.Escape)
           {
               NumkeyBorad numkeyBoradTemp = new NumkeyBorad();
               numkeyBoradTemp.Owner = this;

               if (numkeyBoradTemp.ShowDialog() == true)
               {
                   this.Close();
               }
           }
       }

        /// <summary>
        /// 最大化 最小化  退出最大化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMin_Click(object sender, RoutedEventArgs e)
        {
            var temp = sender as Button;
            switch (temp.Name)
            {
                case "Min":
                    this.WindowState = WindowState.Minimized;
                    break;
                case "Max":
                    var window = Window.GetWindow(this);//获取当前主窗口
                    var intPtr = new WindowInteropHelper(window).Handle;//获取当前窗口的句柄
                    var screen = System.Windows.Forms.Screen.FromHandle(intPtr);//获取当前屏幕
                    this.Left = screen.Bounds.Left / SettingManager.GetSettingSingleton().DPIRate;
                    this.Top = screen.Bounds.Top / SettingManager.GetSettingSingleton().DPIRate;
                    this.Height = screen.WorkingArea.Height / SettingManager.GetSettingSingleton().DPIRate;
                    this.Width = screen.WorkingArea.Width / SettingManager.GetSettingSingleton().DPIRate;
                    Max.Visibility = Visibility.Collapsed;
                    Full.Visibility = Visibility.Visible;

                    break;
                case "Full":
                    this.WindowState = WindowState.Normal;
                    this.Width = SettingManager.GetSettingSingleton().normalWidth;
                    this.Height = SettingManager.GetSettingSingleton().normalHeight;
                    this.Left = SettingManager.GetSettingSingleton().normalLeft;
                    this.Top = SettingManager.GetSettingSingleton().normalTop;
                    Full.Visibility = Visibility.Collapsed;
                    Max.Visibility = Visibility.Visible;
                    this.Topmost = false;
                    break;
                case "Close":
                    SystemManager.Exit();
                    break;
            }
        }
        /// <summary>
        /// 拖动窗口   双击放大  双击退出最大化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var window = Window.GetWindow(this);//获取当前主窗口
            var intPtr = new WindowInteropHelper(window).Handle;//获取当前窗口的句柄
            var screen = System.Windows.Forms.Screen.FromHandle(intPtr);//获取当前屏幕
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (this.Height != screen.WorkingArea.Height)
                {
                    DragMove();
                }
            }
            else
            {

            }
            if (e.ClickCount == 2)
            {
                if (this.Height != screen.WorkingArea.Height / SettingManager.GetSettingSingleton().DPIRate && this.Width != screen.WorkingArea.Width / SettingManager.GetSettingSingleton().DPIRate)
                {
                    SettingManager.GetSettingSingleton().normalHeight = this.Height;
                    SettingManager.GetSettingSingleton().normalWidth = this.Width;
                    SettingManager.GetSettingSingleton().normalLeft = this.Left;
                    SettingManager.GetSettingSingleton().normalTop = this.Top;

                    this.Height = screen.WorkingArea.Height / SettingManager.GetSettingSingleton().DPIRate;
                    this.Width = screen.WorkingArea.Width / SettingManager.GetSettingSingleton().DPIRate;
                    this.Left = screen.WorkingArea.Left;
                    this.Top = screen.WorkingArea.Top;
                    Max.Visibility = Visibility.Collapsed;
                    Full.Visibility = Visibility.Visible;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                    this.Left = SettingManager.GetSettingSingleton().normalLeft;
                    this.Top = SettingManager.GetSettingSingleton().normalTop;
                    this.Height = SettingManager.GetSettingSingleton().normalHeight;
                    this.Width = SettingManager.GetSettingSingleton().normalWidth;
                    Full.Visibility = Visibility.Collapsed;
                    Max.Visibility = Visibility.Visible;
                }
            }
        }
        #endregion

        public MainWindow()
       {
           #region 目录创建
           if (!Directory.Exists(root_path + "Logs"))
           {
               Directory.CreateDirectory(root_path + "Logs");
           }
           if (!Directory.Exists(root_path + "photo"))
           {
               Directory.CreateDirectory(root_path + "photo");
           }
           if (!Directory.Exists(root_path + "资源文件"))
           {
               Directory.CreateDirectory(root_path + "资源文件");
           }
           #endregion

           #region 开启数据库服务器
           StartSqliteSever();
           #endregion

           InitializeComponent();

           _viewModel = new MainViewModel();
           this.DataContext = _viewModel;

           //开启文件传输服务
           EftServer server = new EftServer(root_path+"资源文件", SettingManager.GetSettingSingleton().port文件传输端口);
           System.Threading.Thread thread = new System.Threading.Thread(server.StartServer);
           thread.Start();
          
           myGrid.Children.Add(ServiceLocator.Instance.GetRequiredService<IControl>().Create());
       }

       void StartSqliteSever()
       {
           SQLiteSever = new SimpleTCP.SimpleTcpServer();
           SQLiteSever.Start(SettingManager.GetSettingSingleton().port数据库同步端口);
           SQLiteSever.DataReceived += SQLiteSever_DataReceived;
       }
       #region 代码生成  数据库查询缓存
       List<PersonInfo> AllList_PersonInfo = new List<PersonInfo>();
       List<ModelBaseForDB> AllList_ModelBaseForDB = new List<ModelBaseForDB>();
       #endregion

       private void SQLiteSever_DataReceived(object sender, SimpleTCP.Message e)
       {
           if (e.MessageString.Contains("MsgModelName"))
           {
             
               SqliteSeverMsgModel msgModel = JsonConvert.DeserializeObject<SqliteSeverMsgModel>(e.MessageString);

               #region 代码生成 数据库局 局域网后台交互
               if (msgModel.MsgModelName == "PersonInfo")
               {

                   var msgData = JsonConvert.DeserializeObject<List<PersonInfo >>(msgModel.MsgModel);
                   switch (msgModel.MsgType)
                   {
                       case "exit":

                           break;
                       case "add":
                           SqliteHelper.InsertList<PersonInfo >(msgData);
                           msgModel.MsgType = "添加成功";
                           SQLiteSever.Broadcast(JsonConvert.SerializeObject(msgModel));
                           break;
                       case "delete":
                           foreach (var item in msgData)
                           {
                               var deleteItem = SqliteHelper.GetDbContext().Table<PersonInfo >().Where(x => x.Id == item.Id).ToList().FirstOrDefault();
                               SqliteHelper.Delete<PersonInfo >(deleteItem);
                           }
                           msgModel.MsgType = "删除成功";
                           msgModel.MsgModel = null;
                           SQLiteSever.Broadcast(JsonConvert.SerializeObject(msgModel));
                           break;
                       case "update":
                           foreach (var item in msgData)
                           {
                               SqliteHelper.Update<PersonInfo >(item);
                           }
                           msgModel.MsgType = "更新成功";
                           SQLiteSever.Broadcast(JsonConvert.SerializeObject(msgModel));
                           break;
                       case "query":
                           var condition = msgData.FirstOrDefault();
                           AllList_PersonInfo  = SqliteHelper.GetDbContext().Table<PersonInfo >().Where(x => x.SearchCondition.Contains(condition.SearchCondition)).ToList();
                            var resultList = AllList_PersonInfo .Skip(msgModel.PageCount * (msgModel.PageInex - 1)).Take(msgModel.PageCount).ToList();
                            msgModel.MsgType = "queryresult";
                            msgModel.MsgModel = JsonConvert.SerializeObject(resultList);
                            msgModel.PageTotalCount = AllList_PersonInfo .Count / msgModel.PageCount;
                            if (msgModel.PageTotalCount == 0 || AllList_PersonInfo .Count % msgModel.PageCount > 0)
                            {
                                msgModel.PageTotalCount += 1;
                            }
                            SQLiteSever.Broadcast(JsonConvert.SerializeObject(msgModel));
                            break;
                        case "queryPage":
                            msgModel.MsgType = "queryresult";
                            msgModel.MsgModel = JsonConvert.SerializeObject(AllList_PersonInfo .Skip(msgModel.PageCount * (msgModel.PageInex - 1)).Take(msgModel.PageCount).ToList());
                            SQLiteSever.Broadcast(JsonConvert.SerializeObject(msgModel));
                            break;
                    }
                }
               if (msgModel.MsgModelName == "ModelBaseForDB")
               {

                   var msgData = JsonConvert.DeserializeObject<List<ModelBaseForDB >>(msgModel.MsgModel);
                   switch (msgModel.MsgType)
                   {
                       case "exit":

                           break;
                       case "add":
                           SqliteHelper.InsertList<ModelBaseForDB >(msgData);
                           msgModel.MsgType = "添加成功";
                           SQLiteSever.Broadcast(JsonConvert.SerializeObject(msgModel));
                           break;
                       case "delete":
                           foreach (var item in msgData)
                           {
                               var deleteItem = SqliteHelper.GetDbContext().Table<ModelBaseForDB >().Where(x => x.Id == item.Id).ToList().FirstOrDefault();
                               SqliteHelper.Delete<ModelBaseForDB >(deleteItem);
                           }
                           msgModel.MsgType = "删除成功";
                           msgModel.MsgModel = null;
                           SQLiteSever.Broadcast(JsonConvert.SerializeObject(msgModel));
                           break;
                       case "update":
                           foreach (var item in msgData)
                           {
                               SqliteHelper.Update<ModelBaseForDB >(item);
                           }
                           msgModel.MsgType = "更新成功";
                           SQLiteSever.Broadcast(JsonConvert.SerializeObject(msgModel));
                           break;
                       case "query":
                           var condition = msgData.FirstOrDefault();
                           AllList_ModelBaseForDB  = SqliteHelper.GetDbContext().Table<ModelBaseForDB >().Where(x => x.SearchCondition.Contains(condition.SearchCondition)).ToList();
                            var resultList = AllList_ModelBaseForDB .Skip(msgModel.PageCount * (msgModel.PageInex - 1)).Take(msgModel.PageCount).ToList();
                            msgModel.MsgType = "queryresult";
                            msgModel.MsgModel = JsonConvert.SerializeObject(resultList);
                            msgModel.PageTotalCount = AllList_ModelBaseForDB .Count / msgModel.PageCount;
                            if (msgModel.PageTotalCount == 0 || AllList_ModelBaseForDB .Count % msgModel.PageCount > 0)
                            {
                                msgModel.PageTotalCount += 1;
                            }
                            SQLiteSever.Broadcast(JsonConvert.SerializeObject(msgModel));
                            break;
                        case "queryPage":
                            msgModel.MsgType = "queryresult";
                            msgModel.MsgModel = JsonConvert.SerializeObject(AllList_ModelBaseForDB .Skip(msgModel.PageCount * (msgModel.PageInex - 1)).Take(msgModel.PageCount).ToList());
                            SQLiteSever.Broadcast(JsonConvert.SerializeObject(msgModel));
                            break;
                    }
                }
                #endregion

            }
        }


    }

}

