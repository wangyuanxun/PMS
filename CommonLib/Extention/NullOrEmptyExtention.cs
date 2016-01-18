using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
    public static class NullOrEmptyExtention
    {
        /// <summary>
        /// 判断DataTable为NULL或者里面数据为空
        /// </summary>
        /// <param name="dt">需要判断的DataTable</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this DataTable dt)
        {
            return dt == null || dt.Columns.Count == 0 || dt.Rows.Count == 0;
        }

        /// <summary>
        /// 判断String[]是否为空
        /// </summary>
        /// <param name="str">要检测的数组</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this String[] str)
        {
            return str == null || str.Length == 0 || (str.Length == 1 && str[0].IsNullOrEmpty());
        }

        /// <summary>
        /// 判断ArrayList对象是否为空
        /// </summary>
        /// <param name="arrList">要检测的ArrayList对象</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this ArrayList arrList)
        {
            return arrList == null || arrList.Count == 0 || (arrList.Count == 1 && arrList[0].ToString().IsNullOrEmpty());
        }

        /// <summary>
        /// 判断List<String>对象是否为空
        /// </summary>
        /// <param name="list">要检测的list对象</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this List<String> list)
        {
            return list == null || list.Count == 0 || (list.Count == 1 && list[0].IsNullOrEmpty());
        }

        /// <summary>
        /// 判断List<T>对象是否为空
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="list">要检测的list对象</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || list.Count == 0 || (list.Count == 1 && list[0] == null);
        }

        /// <summary>
        /// 判断DataRow是否为空
        /// </summary>
        /// <param name="dr">Rows行数组</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this DataRow[] dr)
        {
            return dr == null || dr.Length == 0 || dr[0].ItemArray.Length == 0 || dr[0].Table.Columns.Count == 0;
        }

        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="strObject">字符串内容</param>
        /// <returns>为空返回True否则返回False</returns>
        public static bool IsNullOrEmpty(this String strObject)
        {
            return String.IsNullOrEmpty(strObject) || strObject == "" || strObject.Trim().Length == 0 || strObject.ToLower() == "null";
        }

        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="strObject">字符串内容</param>
        /// <returns>为空返回True否则返回False</returns>
        public static bool IsNullOrEmpty(this StringBuilder strObject)
        {
            return strObject == null || strObject.Length == 0;
        }

        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="obj">字符串内容</param>
        /// <returns>为空返回True否则返回False</returns>
        public static bool IsNullOrEmpty(this Object obj)
        {
            return obj == null || obj == DBNull.Value;
        }
    }
}
