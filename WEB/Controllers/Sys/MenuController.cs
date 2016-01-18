using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonLib;
using EntityLib;

namespace WEB.Controllers.Sys
{
    public class MenuController : BaseController
    {
        #region 菜单列表
        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        [Authorization]
        [HttpGet]
        public ActionResult List(int page = 1, int pageSize = 13, string keyword = "")
        {
            keyword = keyword.FilterSQL();
            string where = "IsEnable=1";
            if (!keyword.IsNullOrEmpty())
                where += string.Format(" AND CHARINDEX('{0}',MenuName)>0", keyword);
            var data = CacheClientLib.CacheClient.Services.Sys_MenuService.GetPageList(page, pageSize, where, "ID,ParentID,MenuName,LinkUrl,OrderIndex", "OrderIndex Asc");
            return View(data);
        }
        #endregion

        #region 编辑菜单
        /// <summary>
        /// 编辑菜单
        /// </summary>
        /// <param name="id">菜单Id</param>
        /// <returns></returns>
        [Authorization]
        [HttpGet]
        public ActionResult Edit(long id = 0)
        {
            var model = new Sys_Menu() { OrderIndex = 0 };
            if (id > 0)
                model = CacheClientLib.CacheClient.Services.Sys_MenuService.GetModel(id) ?? new Sys_Menu() { OrderIndex = 0 };
            return View(model);
        }

        /// <summary>
        /// 编辑菜单提交
        /// </summary>
        /// <param name="id">菜单Id</param>
        /// <param name="parentID">菜单父级Id</param>
        /// <param name="menuName">菜单名称</param>
        /// <param name="linkUrl">链接地址</param>
        /// <param name="orderIndex">排序</param>
        /// <param name="intro">备注</param>
        /// <param name="menuImg">菜单图标</param>
        /// <returns></returns>
        [Authorization]
        [HttpPost]
        public ActionResult Edit(long id, long parentID, string menuName, string linkUrl, int orderIndex, string intro, string menuImg)
        {
            var result = LogicClientLib.LogicClient.Services.Sys_MenuService.Insert(new Sys_Menu()
            {
                ParentID = 0,
                MenuName = menuName,
                MenuImg = string.Empty,
                IsEnable = 1,
                LinkUrl = linkUrl,
                Intro = intro,
                OrderIndex = orderIndex,
                CreateTime = DateTime.Now
            });
            return JsonResponce.New(result).AsJsonResult();
        }
        #endregion
    }
}
