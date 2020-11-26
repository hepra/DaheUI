using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UIFrameworkCore;
using UIFrameworkCore.Settings;

namespace Plugins.ManageCenter.view
{
    /// <summary>
    /// ImageSelectControl.xaml 的交互逻辑
    /// </summary>
    public partial class ImageSelectControl : UserControl
    {


        public static readonly DependencyProperty ImageTitleProperty = DependencyProperty.Register("ImageTitle", typeof(string), typeof(ImageSelectControl), new FrameworkPropertyMetadata("默认值", FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
        public string ImageTitle
        {
            get { return (string)GetValue(ImageTitleProperty); }
            set { SetValue(ImageTitleProperty, value); }
        }

        public static readonly DependencyProperty ImageListProperty = DependencyProperty.Register("ImageList", typeof(List<string>), typeof(ImageSelectControl), new PropertyMetadata(new List<string>(),  onPropertyChanged));

        private static void onPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is List<string> source)
            {
                if (d is ImageSelectControl control)
                {
                    if (control.DataContext is ImageViewModel model)
                    {
                        model.ImageModelList=new ObservableCollection<IamgeModel>();
                        foreach (var item in source)
                        {
                            model.ImageModelList.Add(new IamgeModel() { ImgPath = item, Image_Source = UIFrameworkCore.Helper.ImagHelper.SetSource(item, 200) });
                        }
                    }
                }
            }
        }
        public List<string> ImageList
        {
            get { return (List<string>)GetValue(ImageListProperty); }
            set { SetValue(ImageListProperty, value); }
        }
       public class IamgeModel
        {
            public string ImgPath { get; set; }
            public ImageSource Image_Source { get; set; }
            public override bool Equals(object obj)
            {
                if(obj is IamgeModel model)
                {
                    return this.ImgPath == model.ImgPath;
                }
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return ImgPath.GetHashCode();
            }
        }

        public class ImageViewModel:DMSkin.Core.ViewModelBase
        {
            private ObservableCollection<IamgeModel> _ImageModelList;
            public ObservableCollection<IamgeModel> ImageModelList
            {
                get { return _ImageModelList; }
                set
                {
                    _ImageModelList = value;
                    OnPropertyChanged(nameof(ImageModelList));
                }
            }
        }
        ImageViewModel _viewModel = new ImageViewModel();
        public ImageSelectControl()
        {
            InitializeComponent();
            _viewModel.ImageModelList = new ObservableCollection<IamgeModel>();
            this.DataContext = _viewModel;
        }

        private void 打开文件(object sender, RoutedEventArgs e)
        {
            var openFolder = new OpenFileDialog();
            openFolder.Title = "选择照片(可多选)";
            openFolder.Multiselect = true;
            openFolder.Filter = "图片|*.jpg;*.png;*.gif;*.jpeg;*.bmp";
            if (openFolder.ShowDialog()==true)
            {
                if (openFolder.FileNames.Length > 0)
                {
                    foreach (var filename in openFolder.FileNames)
                    {
                        var tempFileInfo = new FileInfo(filename);
                      

                        string AfterTranferFileName = SettingManager.GetSettingSingleton().ExecutePath + "资源文件\\" + tempFileInfo.Name;
                        if (ImageList.Contains(AfterTranferFileName))
                        {
                            SystemManager.ShowMessageDialog("请不要重复导入!");
                            return;
                        }
                            SettingManager.GetSettingSingleton().LastestImportPath = tempFileInfo.DirectoryName;
                        if(File.Exists(AfterTranferFileName))
                        {
                            ImageList.Add(AfterTranferFileName);
                            _viewModel.ImageModelList.Add(new IamgeModel() { ImgPath = AfterTranferFileName, Image_Source = UIFrameworkCore.Helper.ImagHelper.SetSource(AfterTranferFileName, 200) });
                            continue;
                        }
                        gridLoading.Visibility = Visibility.Visible;
                        new Thread(()=>{
                            EasyFileTransfer.EftClient.Send(filename, SettingManager.GetSettingSingleton().IP文件服务器, SettingManager.GetSettingSingleton().port文件传输端口);
                            this.Dispatcher.Invoke(()=> {
                                gridLoading.Visibility = Visibility.Collapsed;
                         
                                ImageList.Add(AfterTranferFileName);
                                _viewModel.ImageModelList.Add(new IamgeModel() { ImgPath = AfterTranferFileName, Image_Source = UIFrameworkCore.Helper.ImagHelper.SetSource(AfterTranferFileName, 200) });
                            });
                        }).Start();
                    }
                }
                else
                {
                    SystemManager.ShowMessageDialog("请选择文件!");
                }
            }
        }

        private void 删除添加的照片_Click(object sender, RoutedEventArgs e)
        {
         if(    SystemManager.ShowMessageDialogConfim_Cancel("确认删除吗?")==true)
            {
                if (sender is Button button)
                {
                    if (button.DataContext is IamgeModel model)
                    {
                        _viewModel.ImageModelList.Remove(model);
                        for (int i = 0; i < ImageList.Count; i++)
                        {
                            if (ImageList[i] == model.ImgPath)
                            {
                                ImageList.Remove(ImageList[i]);
                            }
                        }
                        model.Image_Source = null;
                        try
                        {
                            File.Delete(model.ImgPath);
                        }
                        catch (System.Exception ex)
                        {
                            UIFrameworkCore.Helper.FileHelper.Appand系统日志Info(ex.ToString(), "Error");
                        }

                    }
                }
            }        
        }

        private void Grid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (gridLoading.Visibility == Visibility.Collapsed)
            {
                loading.IsActive = false;
            }
            else
            {
                loading.IsActive = true;
            }
        }
    }
}
