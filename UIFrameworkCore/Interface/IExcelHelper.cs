using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFrameworkCore.Interface
{
  public  interface IExcelHelper
    {
        void ReadExcelToDB(string path);
        void ReadExcelPictureToLocal(string path);
    }
}
