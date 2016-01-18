using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLib;
using CommonLib;

namespace LogicSrvLib.DAL
{
    /// <summary>
    /// 表主键生成器
    /// </summary>
    public class BIdGenerator : SingletonFactory<BIdGenerator>
    {
        [Obsolete("不允许直接手动调用，请调用静态属性Singleton获取实例。", true)]
        public BIdGenerator() { }

        /// <summary>
        /// 生成表主键
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public long Generate(string tableName)
        {
            const string procedureName = "usp_GetNewID";
            var id = new SqlParameter("@TableID", 0) { Direction = ParameterDirection.Output, SourceColumn = "@TableID" };
            var hashtable = SqlHelper.ExecProduct(procedureName, new SqlParameter("@TableName", tableName), id);
            if (hashtable != null && hashtable.ContainsKey("@TableID"))
                return hashtable["@TableID"].ToLong();
            throw new InvalidOperationException("生成表主键失败");
        }
    }
}
