using DMSkin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFrameworkCore.Model
{
   public class SqliteSeverMsgModel : ViewModelBase
    {
        private string _MsgType;
        public string MsgType
        {
            get { return _MsgType; }
            set
            {
                _MsgType = value;
                OnPropertyChanged(nameof(MsgType));
            }
        }
        private string _MsgModel;
        public string MsgModel
        {
            get { return _MsgModel; }
            set
            {
                _MsgModel = value;
                OnPropertyChanged(nameof(MsgModel));
            }
        }
        private int _PageCount;
        public int PageCount
        {
            get { return _PageCount; }
            set
            {
                _PageCount = value;
                OnPropertyChanged(nameof(PageCount));
            }
        }
        private int _PageInex;
        public int PageInex
        {
            get { return _PageInex; }
            set
            {
                _PageInex = value;
                OnPropertyChanged(nameof(PageInex));
            }
        }
        private int _PageTotalCount;
        public int PageTotalCount
        {
            get { return _PageTotalCount; }
            set
            {
                _PageTotalCount = value;
                OnPropertyChanged(nameof(PageTotalCount));
            }
        }
        private string _MsgModelName;
        public string MsgModelName
        {
            get { return _MsgModelName; }
            set
            {
                _MsgModelName = value;
                OnPropertyChanged(nameof(MsgModelName));
            }
        }
    }
}
