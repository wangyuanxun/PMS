﻿//------------------------------------------------------------------------------
//Description: Sys_Menu服务接口实现BLL
//Author: WANGYX
//Date: 2015/11/13 10:57:18
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using LogicSrvInterfaceLib;
using LogicSrvLib.DAL;
using EntityLib;

namespace LogicSrvLib
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
        /// 根据ID进行实体更新
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>是否成功</returns>
        public bool Insert(Sys_Menu model)
        {
            return DalSys_Menu.Singleton.Insert(model);
        }

        /// <summary>
        /// 根据实体整个更新数据库
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>是否成功</returns>
        public bool Update(Sys_Menu model)
        {
            return DalSys_Menu.Singleton.Update(model);
        }

        /// <summary>
        /// 自定义表更新
        /// </summary>
        /// <param name="fields">更新字段及字段值 不能为空 不带Set，如："Field1=value1,Field2=value2"</param>
        /// <param name="selectWhere">限定条件 不能为空 不带Where</param>
        /// <returns>是否成功</returns>
        public bool UpdateDynamic(string fields, string selectWhere)
        {
            return DalSys_Menu.Singleton.UpdateDynamic(fields, selectWhere);
        }

        /// <summary>
        /// 根据编号删除一条记录
        /// </summary>
        /// <param name="ID">编号</param> 
        /// <returns>是否成功</returns>
        public bool Delete(long ID)
        {
            return DalSys_Menu.Singleton.Delete(ID);
        }

        /// <summary>
        /// 根据自定义条件删除记录
        /// </summary>
        /// <param name="selectWhere">查询条件 不带Where</param> 
        /// <returns>返回删除行数</returns>
        public bool DeleteDynamic(string selectWhere)
        {
            return DalSys_Menu.Singleton.DeleteDynamic(selectWhere);
        }
        #endregion
        
        #region 自定义服务接口
        
        #endregion
    }
}