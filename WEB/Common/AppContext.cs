using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonLib;
using EntityLib;

namespace WEB
{
    public class AppContext
    {
        #region 常量key
        private const string sessionKeyUser = "AppContext.User";
        #endregion

        #region 登录用户信息
        /// <summary>
        /// 登录用户信息
        /// </summary>
        public static User User
        {
            get
            {
                return HttpContext.Current.Session[sessionKeyUser] as User;
            }
        }
        #endregion

        #region 用户登入
        /// <summary>
        /// 用户登入
        /// </summary>
        /// <param name="user"></param>
        public static void LoginIn(User user)
        {
            if (!user.IsNullOrEmpty() && user.ID > 0)
                HttpContext.Current.Session[sessionKeyUser] = user;
        }
        #endregion

        #region 用户登出
        /// <summary>
        /// 用户登出
        /// </summary>
        public static void LoginOut()
        {
            HttpContext.Current.Session.Remove(sessionKeyUser);
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }
        #endregion

        #region 是否登录
        /// <summary>
        /// 是否登录
        /// </summary>
        /// <returns>true：登录 false：未登录或者已过期</returns>
        public static bool isLoginIn()
        {
            return !HttpContext.Current.Session[sessionKeyUser].IsNullOrEmpty() ? true : false;
        }
        #endregion
    }
}