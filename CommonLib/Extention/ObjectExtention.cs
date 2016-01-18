using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
    public static class ObjectExtention
    {
        #region ToString2
        /// <summary>
        /// 转换成string类型 默认值为string.Empty
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <returns></returns>
        public static string ToString2(this object value)
        {
            return ToString2(value, string.Empty);
        }

        /// <summary>
        /// 转换成string类型 默认值为defaultValue
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string ToString2(this object value, string defaultValue)
        {
            var result = value as string;
            if (result == null && value != null && value != DBNull.Value)
            {
                result = value.ToString();
                return result;
            }
            return result ?? defaultValue;
        }
        #endregion

        #region ToInt
        /// <summary>
        /// 转换为int类型 默认值为0
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <returns></returns>
        public static int ToInt(this object value)
        {
            return ToInt(value, 0);
        }

        /// <summary>
        /// 转换为int类型 默认值为defaultValue
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int ToInt(this object value, int defaultValue)
        {
            int result;
            if (value is int)
            {
                result = (int)value;
                return result;
            }
            var stringExpression = ToString2(value, string.Empty);
            if (int.TryParse(stringExpression, out result))
            {
                return result;
            }
            return defaultValue;
        }
        #endregion

        #region ToLong
        /// <summary>
        /// 转换为long类型 默认值为0L
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <returns></returns>
        public static long ToLong(this object value)
        {
            return ToLong(value, 0L);
        }

        /// <summary>
        /// 转换为long类型 默认值为defaultValue
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static long ToLong(this object value, long defaultValue)
        {
            long result;
            if (value is long)
            {
                result = (long)value;
                return result;
            }
            var stringExpression = ToString2(value, string.Empty);
            if (long.TryParse(stringExpression, out result))
            {
                return result;
            }
            return defaultValue;
        }
        #endregion

        #region ToDecimal
        /// <summary>
        /// 转换为decimal类型 默认值为0
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <returns></returns>
        public static decimal ToDecimal(this object value)
        {
            return ToDecimal(value, 0);
        }

        /// <summary>
        /// 转换为decimal类型 默认值为defaultValue
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static decimal ToDecimal(this object value, decimal defaultValue)
        {
            decimal result;
            if (value is decimal)
            {
                result = (decimal)value;
                return result;
            }
            var stringExpression = ToString2(value, string.Empty);
            if (decimal.TryParse(stringExpression, out result))
            {
                return result;
            }
            return defaultValue;
        }
        #endregion

        #region ToDouble
        /// <summary>
        /// 转换为double类型 默认值为0
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <returns></returns>
        public static double ToDouble(this object value)
        {
            return ToDouble(value, 0);
        }

        /// <summary>
        /// 转换为double类型 默认值为defaultValue
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static double ToDouble(this object value, double defaultValue)
        {
            double result;
            if (value is double)
            {
                result = (double)value;
                return result;
            }
            var stringExpression = ToString2(value, string.Empty);
            if (double.TryParse(stringExpression, out result))
            {
                return result;
            }
            return defaultValue;
        }
        #endregion

        #region ToFloat
        /// <summary>
        /// 转换为float类型 默认值为0
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <returns></returns>
        public static float ToFloat(this object value)
        {
            return ToFloat(value, 0);
        }

        /// <summary>
        /// 转换为float类型 默认值为defaultValue
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static float ToFloat(this object value, float defaultValue)
        {
            float result;
            if (value is float)
            {
                result = (float)value;
                return result;
            }
            var stringExpression = ToString2(value, string.Empty);
            if (float.TryParse(stringExpression, out result))
            {
                return result;
            }
            return defaultValue;
        }
        #endregion

        #region ToDateTime
        /// <summary>
        /// 转换为DateTime类型 默认值为DateTime.Now
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object value)
        {
            return ToDateTime(value, DateTime.Now);
        }

        /// <summary>
        /// 转换为DateTime类型 默认值为defaultValue
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object value, DateTime defaultValue)
        {
            DateTime result;
            if (value is DateTime)
            {
                result = (DateTime)value;
                return result;
            }
            var stringExpression = ToString2(value, string.Empty);
            if (DateTime.TryParse(stringExpression, out result))
            {
                return result;
            }
            return defaultValue;
        }
        #endregion

        #region ToTimeSpan
        /// <summary>
        /// 转换为TimeSpan类型 默认值为TimeSpan.Zero
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(this object value)
        {
            return ToTimeSpan(value, TimeSpan.Zero);
        }

        /// <summary>
        /// 转换为TimeSpan类型 默认值为defaultValue
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(this object value, TimeSpan defaultValue)
        {
            TimeSpan result;
            if (value is TimeSpan)
            {
                result = (TimeSpan)value;
                return result;
            }
            var stringExpression = ToString2(value, string.Empty);
            if (TimeSpan.TryParse(stringExpression, out result))
            {
                return result;
            }
            return defaultValue;
        }
        #endregion

        #region ToBoolean
        /// <summary>
        /// 转换为bool类型 默认值为false
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <returns></returns>
        public static bool ToBoolean(this object value)
        {
            return ToBoolean(value, false);
        }

        /// <summary>
        /// 转换为bool类型 默认值为defaultValue
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static bool ToBoolean(this object value, bool defaultValue)
        {
            bool result;
            if (value is bool)
            {
                result = (bool)value;
                return result;
            }
            var stringExpression = ToString2(value, string.Empty);
            if (bool.TryParse(stringExpression, out result))
                return result;
            return defaultValue;
        }
        #endregion
    }
}
