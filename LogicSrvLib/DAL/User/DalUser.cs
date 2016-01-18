//------------------------------------------------------------------------------
//Description: User服务接口实现DAL
//Author: WANGYX
//Date: 2015/11/20 19:19:14
//------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Data.SqlClient;
using EntityLib;
using CommonLib;

namespace LogicSrvLib.DAL
{
    public class DalUser : SingletonFactory<DalUser>
    {
        #region 系统自动生成服务接口
        /// <summary>
        /// 根据实体添加数据库
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>是否成功</returns>
        public bool Insert(User model)
        {
            string sql = @"INSERT INTO [User]
           (
           [ID],
           [UserName],
           [PassWord],
           [RealName],
           [Sex],
           [Mobile],
           [IDCard],
           [Birthday],
           [Photo],
           [QQ],
           [Email],
           [State],
           [OrderIndex],
           [LoginCount],
           [LastLoginTime],
           [CreateTime])
        VALUES
           (
           @ID,
           @UserName,
           @PassWord,
           @RealName,
           @Sex,
           @Mobile,
           @IDCard,
           @Birthday,
           @Photo,
           @QQ,
           @Email,
           @State,
           @OrderIndex,
           @LoginCount,
           @LastLoginTime,
           @CreateTime)";
            SqlParameter[] para = { 
                new SqlParameter("@ID", BIdGenerator.Singleton.Generate("User")),
                new SqlParameter("@UserName",model.UserName),
                new SqlParameter("@PassWord",model.PassWord),
                new SqlParameter("@RealName",model.RealName),
                new SqlParameter("@Sex",model.Sex),
                new SqlParameter("@Mobile",model.Mobile),
                new SqlParameter("@IDCard",model.IDCard),
                new SqlParameter("@Birthday",model.Birthday),
                new SqlParameter("@Photo",model.Photo),
                new SqlParameter("@QQ",model.QQ),
                new SqlParameter("@Email",model.Email),
                new SqlParameter("@State",model.State),
                new SqlParameter("@OrderIndex",model.OrderIndex),
                new SqlParameter("@LoginCount",model.LoginCount),
                new SqlParameter("@LastLoginTime",model.LastLoginTime),
                new SqlParameter("@CreateTime",model.CreateTime)
            };
            return SqlHelper.ExecuteSql(sql, para);
        }

        /// <summary>
        /// 根据ID进行实体更新
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>是否成功</returns>
        public bool Update(User model)
        {
            string sql = @"UPDATE [User] SET
               [ID]=@ID,
               [UserName]=@UserName,
               [PassWord]=@PassWord,
               [RealName]=@RealName,
               [Sex]=@Sex,
               [Mobile]=@Mobile,
               [IDCard]=@IDCard,
               [Birthday]=@Birthday,
               [Photo]=@Photo,
               [QQ]=@QQ,
               [Email]=@Email,
               [State]=@State,
               [OrderIndex]=@OrderIndex,
               [LoginCount]=@LoginCount,
               [LastLoginTime]=@LastLoginTime,
               [CreateTime]=@CreateTime WHERE ID=@ID";
            SqlParameter[] para = { 
                new SqlParameter("@ID",model.ID),
                new SqlParameter("@UserName",model.UserName),
                new SqlParameter("@PassWord",model.PassWord),
                new SqlParameter("@RealName",model.RealName),
                new SqlParameter("@Sex",model.Sex),
                new SqlParameter("@Mobile",model.Mobile),
                new SqlParameter("@IDCard",model.IDCard),
                new SqlParameter("@Birthday",model.Birthday),
                new SqlParameter("@Photo",model.Photo),
                new SqlParameter("@QQ",model.QQ),
                new SqlParameter("@Email",model.Email),
                new SqlParameter("@State",model.State),
                new SqlParameter("@OrderIndex",model.OrderIndex),
                new SqlParameter("@LoginCount",model.LoginCount),
                new SqlParameter("@LastLoginTime",model.LastLoginTime),
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
            string sql = @"UPDATE [User] SET " + fields.FilterSQL() + " WHERE " + selectWhere.FilterSQL();
            return SqlHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 根据编号删除一条记录
        /// </summary>
        /// <param name="ID">编号</param> 
        /// <returns>是否成功</returns>
        public bool Delete(long ID)
        {
            string sql = @"DELETE [User] WHERE ID=@ID";
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
            string sql = @"DELETE [User] WHERE " + selectWhere.FilterSQL();
            return SqlHelper.ExecuteSql(sql);
        }
        #endregion
        
        #region 自定义服务接口
        
        #endregion
    }
}