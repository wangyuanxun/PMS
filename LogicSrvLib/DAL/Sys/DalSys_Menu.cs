﻿//------------------------------------------------------------------------------
//Description: Sys_Menu服务接口实现DAL
//Author: WANGYX
//Date: 2015/11/13 10:57:18
//------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Data.SqlClient;
using EntityLib;
using CommonLib;

namespace LogicSrvLib.DAL
{
    public class DalSys_Menu : SingletonFactory<DalSys_Menu>
    {
        #region 系统自动生成服务接口
        /// <summary>
        /// 根据实体添加数据库
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>是否成功</returns>
        public bool Insert(Sys_Menu model)
        {
            string sql = @"INSERT INTO [Sys_Menu]
           (
           [ID],
           [ParentID],
           [MenuName],
           [MenuImg],
           [IsEnable],
           [LinkUrl],
           [Intro],
           [OrderIndex],
           [CreateTime])
        VALUES
           (
           @ID,
           @ParentID,
           @MenuName,
           @MenuImg,
           @IsEnable,
           @LinkUrl,
           @Intro,
           @OrderIndex,
           @CreateTime)";
            SqlParameter[] para = { 
                new SqlParameter("@ID", BIdGenerator.Singleton.Generate("Sys_Menu")),
                new SqlParameter("@ParentID",model.ParentID),
                new SqlParameter("@MenuName",model.MenuName),
                new SqlParameter("@MenuImg",model.MenuImg),
                new SqlParameter("@IsEnable",model.IsEnable),
                new SqlParameter("@LinkUrl",model.LinkUrl),
                new SqlParameter("@Intro",model.Intro),
                new SqlParameter("@OrderIndex",model.OrderIndex),
                new SqlParameter("@CreateTime",model.CreateTime)
            };
            return SqlHelper.ExecuteSql(sql, para);
        }

        /// <summary>
        /// 根据ID进行实体更新
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>是否成功</returns>
        public bool Update(Sys_Menu model)
        {
            string sql = @"UPDATE [Sys_Menu] SET
               [ID]=@ID,
               [ParentID]=@ParentID,
               [MenuName]=@MenuName,
               [MenuImg]=@MenuImg,
               [IsEnable]=@IsEnable,
               [LinkUrl]=@LinkUrl,
               [Intro]=@Intro,
               [OrderIndex]=@OrderIndex,
               [CreateTime]=@CreateTime WHERE ID=@ID";
            SqlParameter[] para = { 
                new SqlParameter("@ID",model.ID),
                new SqlParameter("@ParentID",model.ParentID),
                new SqlParameter("@MenuName",model.MenuName),
                new SqlParameter("@MenuImg",model.MenuImg),
                new SqlParameter("@IsEnable",model.IsEnable),
                new SqlParameter("@LinkUrl",model.LinkUrl),
                new SqlParameter("@Intro",model.Intro),
                new SqlParameter("@OrderIndex",model.OrderIndex),
                new SqlParameter("@CreateTime",model.CreateTime)
            };
            return SqlHelper.ExecuteSql(sql, para);
        }

        /// <summary>
        /// 自定义表更新
        /// </summary>
        /// <param name="fields">更新字段及字段值 不能为空 不带Set 如："Field1=value1,Field2=value2"</param>
        /// <param name="selectWhere">限定条件 不能为空 不带Where</param>
        /// <returns>是否成功</returns>
        public bool UpdateDynamic(string fields, string selectWhere)
        {
            string sql = @"UPDATE [Sys_Menu] SET " + fields.FilterSQL() + " WHERE " + selectWhere.FilterSQL();
            return SqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 根据编号删除一条记录
        /// </summary>
        /// <param name="ID">编号</param> 
        /// <returns>是否成功</returns>
        public bool Delete(long ID)
        {
            string sql = @"DELETE [Sys_Menu] WHERE ID=@ID";
            var para = new[] { new SqlParameter("@ID", ID) };
            return SqlHelper.ExecuteSql(sql, para);
        }

        /// <summary>
        /// 根据自定义条件删除记录
        /// </summary>
        /// <param name="selectWhere">查询条件 不带Where</param> 
        /// <returns>返回删除行数</returns>
        public bool DeleteDynamic(string selectWhere)
        {
            string sql = @"DELETE [Sys_Menu] WHERE " + selectWhere.FilterSQL();
            return SqlHelper.ExecuteSql(sql);
        }
        #endregion
        
        #region 自定义服务接口
        
        #endregion
    }
}