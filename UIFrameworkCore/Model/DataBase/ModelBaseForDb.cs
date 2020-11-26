using DMSkin.Core;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using UIFrameworkCore.Settings.UIAttributes;

namespace UIFrameworkCore.Model.DataBase
{
    public class ModelBaseForDB: ViewModelBase
    {
        [PrimaryKey]
        [ModelIgnore]
        public Guid Id { get; set; }

        public ModelBaseForDB()
        {
            Id = Guid.NewGuid();
            CreateDate = System.DateTime.Now;
        }
        [ModelIgnore]
        public string SearchCondition { get; set; }

        private string _Image;
        [Group("ImageControl")]
        [NameAlias("图片资源")]
        public string Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        private string _Video;
        [Group("VideoControl")]
        [NameAlias("视频资源")]
        public string Video
        {
            get { return _Video; }
            set
            {
                _Video = value;
                OnPropertyChanged(nameof(Video));
            }
        }

        private int _DeleteFlag;
        [ModelIgnore]
        public int DeleteFlag
        {
            get { return _DeleteFlag; }
            set
            {
                _DeleteFlag = value;
                OnPropertyChanged(nameof(DeleteFlag));
            }
        }   

        private DateTime? _CreateDate;
        [ModelIgnore]
        public DateTime? CreateDate
        {
            get { return _CreateDate; }
            set
            {
                _CreateDate = value;
                OnPropertyChanged(nameof(CreateDate));
            }
        }
    }

    }
