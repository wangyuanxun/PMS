﻿//------------------------------------------------------------------------------
//Description: Sys_Menu服务接口实现DAL
//Author: WANGYX
//Date: 2015/11/13 10:57:18
//------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Data.SqlClient;
using EntityLib;
using CommonLib;

namespace CacheSrvLib.DAL
{
    public class DalSys_Menu : SingletonFactory<DalSys_Menu>
    {
        #region 系统自动生成服务接口
        const string _fields = "ID,ParentID,MenuName,MenuImg,IsEnable,LinkUrl,Intro,OrderIndex,CreateTime";
        /// <summary>
        /// 获取表主键最大ID
        /// </summary>
        /// <returns></returns>
        public long GetMaxID()
        {
            var obj = SqlHelper.GetObject("SELECT MAX(ID) FROM [Sys_Menu] (NOLOCK)");
            if (obj != null)
                return obj.ToString().ToLong();
            return 1;
        }

        /// <summary>
        /// 根据主键判断是否存在记录
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns></returns>
        public bool Exists(long ID)
        {
            string strSQL = "SELECT COUNT(1) FROM [Sys_Menu] (NOLOCK) WHERE ID=@ID";
            int result = SqlHelper.GetCount(strSQL, new[] { new SqlParameter("@ID", ID) });
            if (result == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据自定义条件判断是否存在记录
        /// </summary>
        /// <param name="selectWhere">限定条件 不带Where</param>
        /// <returns>是否存在记录</returns>
        public bool ExistsDynamic(string selectWhere)
        {
            string strSQL = "SELECT COUNT(1) FROM [Sys_Menu] (NOLOCK) WHERE " + @selectWhere.FilterSQL();
            int result = SqlHelper.GetCount(strSQL);
            if (result > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据自定义条件统计记录数
        /// </summary>
        /// <param name="selectWhere">限定条件 不带Where</param>
        /// <returns>记录数</returns>
        public int GetCount(string selectWhere)
        {
            if (selectWhere != "") selectWhere = "WHERE " + selectWhere;
            string strSQL = "SELECT COUNT(1) FROM [Sys_Menu] (NOLOCK) " + @selectWhere.FilterSQL();
            return SqlHelper.GetCount(strSQL);
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="ID">查询编号</param>
        /// <param name="fields">查询返回字段 如果查询全部则不需要传入参数</param>
        /// <returns></returns>
        public Sys_Menu GetModel(long ID, string fields = "")
        {
            if (fields == "") fields = _fields;
            string strSQL = "SELECT " + fields.FilterSQL() + " FROM [Sys_Menu](NOLOCK) WHERE ID=@ID";
            return SqlHelper.GetEntity<Sys_Menu>(strSQL, new[] { new SqlParameter("@ID", ID) });
        }

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="selectWhere">查询条件 不带Where</param>
        /// <param name="fields">查询返回字段 如果查询全部则不需要传入参数</param>
        /// <returns></returns>
        public Sys_Menu GetModelDynamic(string selectWhere, string fields = "")
        {
            if (fields == "") fields = _fields;
            string strSQL = "SELECT " + fields.FilterSQL() + " FROM [Sys_Menu](NOLOCK) WHERE " + @selectWhere.FilterSQL();
            return SqlHelper.GetEntity<Sys_Menu>(strSQL);
        }

        /// <summary>
        /// 获得数据列表 返回List<T>
        /// </summary>
        /// <param name="fields">查询返回字段 如果查询全部则不需要传入参数</param>
        /// <param name="topWhere">返回条数 例："Top n"</param>
        /// <param name="selectWhere">查询条件(不带Where)</param>
        /// <param name="sort">排序(不带Order By) 默认：ID DESC</param>
        /// <returns></returns>
        public List<Sys_Menu> GetModelList(string fields = "", string topWhere = "", string selectWhere = "", string sort = "")
        {
            if (fields == "") fields = _fields;
            if (selectWhere != "") selectWhere = "WHERE " + selectWhere;
            if (sort != "")
                sort = "ORDER BY " + sort;
            else
                sort = "ORDER BY ID DESC";
            string strSQL = "SELECT " + topWhere.FilterSQL() + " " + fields.FilterSQL() + " FROM [Sys_Menu](NOLOCK) " + selectWhere.FilterSQL() + " " + sort.FilterSQL();
            return SqlHelper.GetEntities<Sys_Menu>(strSQL);
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
            if (selectWhere != "") selectWhere = "WHERE " + selectWhere;
            if (fields == "") fields = _fields;
            if (sort == "") sort = "ID DESC";
            string strSQL = "SELECT " + fields.FilterSQL() + " FROM [Sys_Menu](NOLOCK) " + selectWhere.FilterSQL();
            strSQL = SqlHelper.GetPagingSql(strSQL, sort.FilterSQL());
            string sqlCount = @"SELECT COUNT(1) FROM [Sys_Menu](NOLOCK) " + selectWhere.FilterSQL();
            return SqlHelper.GetPage<Sys_Menu>(pageIndex, pageSize, strSQL, null, sqlCount, null);
        }
        #endregion
        
        #region 自定义服务接口
        
        #endregion
    }
}