﻿//------------------------------------------------------------------------------
//Description: User服务接口
//Author: WANGYX
//Date: 2015/11/20 19:19:13
//------------------------------------------------------------------------------
using System.Collections.Generic;
using EntityLib; 

namespace CacheSrvInterfaceLib
{
    public interface IUserService
    {
        #region 系统自动生成服务接口
        /// <summary>
        /// 获取表主键最大ID
        /// </summary>
        /// <returns></returns>
        long GetMaxID();
        
        /// <summary>
		/// 根据主键判断是否存在记录
		/// </summary>
        /// <param name="ID">编号</param>
        /// <returns></returns>
        bool Exists(long ID);
        
        /// <summary>
		/// 根据自定义条件判断是否存在记录
		/// </summary>
        /// <param name="selectWhere">限定条件 不带Where</param>
        /// <returns>是否存在记录</returns>
        bool ExistsDynamic(string selectWhere);
        
        /// <summary>
		/// 根据自定义条件统计记录数
		/// </summary>
        /// <param name="selectWhere">限定条件 不带Where</param>
        /// <returns>记录数</returns>
        int GetCount(string selectWhere);
        
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="ID">查询编号</param>
        /// <param name="fields">查询返回字段 如果查询全部则不需要传入参数</param>
        /// <returns></returns>
        User GetModel(long ID, string fields = "");
        
        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="selectWhere">查询条件 不带Where</param>
        /// <param name="fields">查询返回字段 如果查询全部则不需要传入参数</param>
        /// <returns></returns>
        User GetModelDynamic(string selectWhere, string fields = "");
        
        /// <summary>
        /// 获得数据列表 返回List<T>
        /// </summary>
        /// <param name="fields">查询返回字段 如果查询全部则不需要传入参数</param>
        /// <param name="topWhere">返回条数 例："Top n"</param>
        /// <param name="selectWhere">查询条件(不带Where)</param>
        /// <param name="sort">排序(不带Order By) 默认：ID DESC</param>
        /// <returns></returns>
        List<User> GetModelList(string Fields, string TopWhere = "", string SelectWhere = "", string Sort = "");
        
        //// <summary>
        /// 分页取数据列表 返回List<T>Model
        /// </summary>
        /// <param name="selectWhere">过滤条件(不带Where)</param>
        /// <param name="fields">查询返回字段 如果查询全部则不需要传入参数</param>
        /// <param name="sort">排序(不带Order By) 默认：ID DESC</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">页在大小</param> 
        /// <returns></returns>
        Page<User> GetPageList(int pageIndex, int pageSize, string selectWhere = "",string fields = "", string sort = "");
        #endregion
        
        #region 自定义服务接口
        
        #endregion
    }
}