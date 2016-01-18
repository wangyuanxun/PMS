//------------------------------------------------------------------------------
//Description: Sys_MenuButton服务接口
//Author: WANGYX
//Date: 2015/11/13 10:57:18
//------------------------------------------------------------------------------
using System.Collections.Generic;
using EntityLib; 

namespace LogicSrvInterfaceLib
{
    public interface ISys_MenuButtonService
    {
        #region 系统自动生成服务接口
        /// <summary>
        /// 根据实体添加数据库
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>是否成功</returns>
        bool Insert(Sys_MenuButton model);

        /// <summary>
        /// 根据ID进行实体更新
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>是否成功</returns>
        bool Update(Sys_MenuButton model);

        /// <summary>
        /// 自定义表更新
        /// </summary>
        /// <param name="fields">更新字段及字段值 不能为空 不带Set 如："Field1=value1,Field2=value2"</param>
        /// <param name="selectWhere">限定条件 不能为空 不带Where</param>
        /// <returns>是否成功</returns>
        bool UpdateDynamic(string fields, string selectWhere);

        /// <summary>
        /// 根据编号删除一条记录
        /// </summary>
        /// <param name="ID">编号</param> 
        /// <returns>是否成功</returns>
        bool Delete(long ID);

        /// <summary>
        /// 根据自定义条件删除记录
        /// </summary>
        /// <param name="selectWhere">查询条件 不带Where</param> 
        /// <returns>返回删除行数</returns>
        bool DeleteDynamic(string selectWhere);
        #endregion
        
        #region 自定义服务接口
        
        #endregion
    }
}