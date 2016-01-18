﻿//------------------------------------------------------------------------------
//Description: Sys_Menu服务接口实现BLL
//Author: WANGYX
//Date: 2015/11/13 10:57:18
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using CacheSrvInterfaceLib;
using CacheSrvLib.DAL;
using EntityLib;

namespace CacheSrvLib
{
    public class Sys_MenuService : MarshalByRefObject, ISys_MenuService
    {
        #region 服务实现实例
        /// <summary>
        /// 实例
        /// </summary>
        private static Sys_MenuService instance;
        
        /// <summary>
        /// 实例
        /// </summary>
        public static Sys_MenuService Instance
        {
            get { return instance; }
        }
        
        /// <summary>
        /// 静态构造方法生成单实例
        /// </summary>
        static Sys_MenuService()
        {
            instance = new Sys_MenuService();
        }
        
        /// <summary>
        /// 私有构造方法
        /// </summary>
        private Sys_MenuService() { }
        #endregion
    
        #region 系统自动生成服务接口
        /// <summary>
        /// 获取表主键最大ID
        /// </summary>
        /// <returns></returns>
        public long GetMaxID()
        {
            return DalSys_Menu.Singleton.GetMaxID();
        }

        /// <summary>
        /// 根据主键判断是否存在记录
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns></returns>
        public bool Exists(long ID)
        {
            return DalSys_Menu.Singleton.Exists(ID);
        }

        /// <summary>
        /// 根据自定义条件判断是否存在记录
        /// </summary>
        /// <param name="selectWhere">限定条件 不带Where</param>
        /// <returns>是否存在记录</returns>
        public bool ExistsDynamic(string selectWhere)
        {
            return DalSys_Menu.Singleton.ExistsDynamic(selectWhere);
        }

        /// <summary>
        /// 根据自定义条件统计记录数
        /// </summary>
        /// <param name="selectWhere">限定条件 不带Where</param>
        /// <returns>记录数</returns>
        public int GetCount(string selectWhere)
        {
            return DalSys_Menu.Singleton.GetCount(selectWhere);
        }
        
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="ID">查询编号</param>
        /// <param name="fields">查询返回字段 如果查询全部则不需要传入参数</param>
        /// <returns></returns>
        public Sys_Menu GetModel(long ID, string fields = "")
        {
            return DalSys_Menu.Singleton.GetModel(ID, fields);
        }

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="selectWhere">查询条件 不带Where</param>
        /// <param name="fields">查询返回字段 如果查询全部则不需要传入参数</param>
        /// <returns></returns>
        public Sys_Menu GetModelDynamic(string selectWhere, string fields = "")
        {
            return DalSys_Menu.Singleton.GetModelDynamic(selectWhere, fields);
        }
        
        /// <summary>
        /// 获得数据列表 返回List<T>
        /// </summary>
        /// <param name="fields">查询返回字段 如果查询全部则不需要传入参数</param>
        /// <param name="topWhere">返回条数 例："Top n"</param>
        /// <param name="selectWhere">查询条件(不带Where)</param>
        /// <param name="sort">排序(不带Order By) 默认：ID DESC</param>
        /// <returns></returns>
        public List<Sys_Menu> GetModelList(string fields, string topWhere = "", string selectWhere = "", string sort = "")
        {
            return DalSys_Menu.Singleton.GetModelList(fields, topWhere, selectWhere, sort);
        }
        
        //// <summary>
        /// 分页取数据列表 返回List<T>Model
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">页在大小</param> 
        /// <param name="selectWhere">过滤条件(不带Where)</param>
        /// <param name="fields">查询返回字段 如果查询全部则不需要传入参数</param>
        /// <param name="sort">排序(不带Order By) 默认：ID DESC</param>
        /// <returns></returns>
        public Page<Sys_Menu> GetPageList(int pageIndex, int pageSize, string selectWhere = "", string fields = "", string sort = "")
        {
            return DalSys_Menu.Singleton.GetPageList(pageIndex, pageSize, selectWhere, fields, sort);
        }
        #endregion
        
        #region 自定义服务接口
        
        #endregion
    }
}