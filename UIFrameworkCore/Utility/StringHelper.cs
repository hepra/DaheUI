using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UIFrameworkCore.Helper
{
   public  class StringHelper
    {
        /// <summary>
        /// 返回 提取的数字  和 去掉数字之后的 字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Dictionary<int, string> _str_提取数字(string data)
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            decimal result = 10008610;
            if (data != null && data != string.Empty)
            {
                // 正则表达式剔除非数字字符（不包含小数点.）
                string num = Regex.Replace(data, @"[^\d.\d]", "");
                if (num.Length > 0)
                {
                    data = data.Replace(num, "");
                    // 如果是数字，则转换为decimal类型
                    if (Regex.IsMatch(num, @"^[+-]?\d*[.]?\d*$"))
                    {
                        result = decimal.Parse(num);
                    }
                }

            }
            temp.Add((int)result, data);
            return temp;
        }


    }
}
