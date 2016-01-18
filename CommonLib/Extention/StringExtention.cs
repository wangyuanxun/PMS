using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonLib
{
    public static class StringExtention
    {
        #region 过滤SQL字符
        /// <summary>
        /// 过滤SQL字符
        /// </summary>
        /// <param name="sInput">输入项</param>
        /// <returns></returns>
        public static string FilterSQL(this string sInput)
        {
            if (sInput.IsNullOrEmpty()) return string.Empty;
            string pattern = @"exec|insert|update|master|truncate|declare|mid|chr";
            if (Regex.Match(sInput.ToLower(), pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase).Success)
                throw new Exception("字符串中含有非法字符!");
            return sInput;
        }
        #endregion
    }
}
