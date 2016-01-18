using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonLib;
using EntityLib;

namespace WEB.Controllers
{
    public class UserController : BaseController
    {
        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login(string returnUrl = "")
        {
            returnUrl = returnUrl.IsNullOrEmpty() ? "/" : returnUrl;
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// 用户登录提交
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <param name="returnUrl">登录成功跳转url</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string userName, string passWord, string returnUrl = "")
        {
            userName = userName.FilterSQL();
            passWord = passWord.FilterSQL();
            if (userName.IsNullOrEmpty())
                return JsonResponce.New(false, "请先输入登录名", 1).AsJsonResult();
            if (passWord.IsNullOrEmpty())
                return JsonResponce.New(false, "请先输入登录密码", 1).AsJsonResult();
            var count = CacheClientLib.CacheClient.Services.UserService.GetCount(string.Format("UserName='{0}'", userName));
            if (count <= 0)
                return JsonResponce.New(false, "用户名不存在", 1).AsJsonResult();
            var model = CacheClientLib.CacheClient.Services.UserService.GetModelDynamic(string.Format("UserName='{0}' AND PassWord='{1}'", userName, passWord));
            if (model.IsNullOrEmpty())
                return JsonResponce.New(false, "密码错误", 1).AsJsonResult();
            AppContext.LoginIn(model);
            if (!AppContext.isLoginIn())
                return JsonResponce.New(false, "登录失败", 1).AsJsonResult();
            LogicClientLib.LogicClient.Services.UserService.UpdateDynamic("LoginCount=ISNULL(LoginCount,0)+1,LastLoginTime=GETDATE()", "ID=" + model.ID);
            return JsonResponce.New(true, returnUrl).AsJsonResult();
        }
        #endregion
    }
}
