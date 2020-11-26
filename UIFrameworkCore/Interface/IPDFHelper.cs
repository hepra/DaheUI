using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UIFrameworkCore.Interface
{
   public interface IPDFHelper
    {
        ObservableCollection<ImageSource> LoadPDF(string fileName);
    }
}
