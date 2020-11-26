using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFrameworkCore.Interface
{
  public  interface IWordHelper
    {
        string ReadAllLine(string fileName);
        List<string> ReadPargraph(string fileName);
    }
}
