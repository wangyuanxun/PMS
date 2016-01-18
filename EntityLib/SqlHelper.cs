using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using TY.DatabaseOperation;

namespace EntityLib
{
    public static class SqlHelper
    {
        #region DataRow or DataTable To TEntity or List<TEntity>
        /// <summary>
        /// 根据传入的sql语句以及sql参数 获取DataTable后
        /// 实例化指定类型数据实体集合
        /// </summary>
        /// <typeparam name="TEntity">实体类类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>实体类集合</returns>
        public static List<TEntity> GetEntities<TEntity>(string sql, params SqlParameter[] parameters) where TEntity : EntityBase<TEntity>, new()
        {
            if (parameters == null)
                return GetEntities<TEntity>(sql, CommandType.Text);
            else
                return GetEntities<TEntity>(sql, CommandType.Text, parameters);
        }

        /// <summary>
        /// 根据传入的sql语句以及sql参数 获取DataRow后
        /// 实例化指定类型数据实体
        /// </summary>
        /// <typeparam name="TEntity">实体类类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>实体类</returns>
        public static TEntity GetEntity<TEntity>(string sql, params SqlParameter[] parameters)
            where TEntity : EntityBase<TEntity>, new()
        {
            if (parameters == null)
                return GetEntity<TEntity>(sql, CommandType.Text);
            else
                return GetEntity<TEntity>(sql, CommandType.Text, parameters);
        }

        /// <summary>
        /// 根据传入的sql语句、sql命令类型、sql参数 获取DataTable后
        /// 实例化指定类型数据实体集合
        /// </summary>
        /// <typeparam name="TEntity">实体类类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="commandType">sql命令类型</param>
        /// <param name="parameters">参数</param>
        /// <returns>实体类集合</returns>
        public static List<TEntity> GetEntities<TEntity>(string sql, CommandType commandType, params SqlParameter[] parameters) where TEntity : EntityBase<TEntity>, new()
        {
            DataTable datatable;
            switch (commandType)
            {
                case CommandType.StoredProcedure:
                    datatable = ExecuteProductData(sql, parameters);
                    return EntityBase<TEntity>.NewList(datatable);
                case CommandType.Text:
                    datatable = GetTable(sql, parameters);
                    return EntityBase<TEntity>.NewList(datatable);
                default:
                    throw new NotImplementedException("未实现直接对表的查询");
            }
        }

        /// <summary>
        /// 根据传入的sql语句、sql命令类型、sql参数 获取DataRow后
        /// 实例化指定类型数据实体
        /// </summary>
        /// <typeparam name="TEntity">实体类类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="commandType">sql命令类型</param>
        /// <param name="parameters">参数</param>
        /// <returns>实体类</returns>
        public static TEntity GetEntity<TEntity>(string sql, CommandType commandType, params SqlParameter[] parameters)
            where TEntity : EntityBase<TEntity>, new()
        {
            return GetEntities<TEntity>(sql, commandType, parameters).FirstOrDefault();
        }
        #endregion

        #region 分页
        /// <summary>
        /// 获取分页模型
        /// </summary>
        /// <typeparam name="TEntity">分页模型承载的实体类型</typeparam>
        /// <param name="page">当前页码</param>
        /// <param name="itemsPerPage">每页记录条数</param>
        /// <param name="sqlPage">分页sql语句</param>
        /// <param name="sqlPageParametersarameters">分页sql参数</param>
        /// <param name="sqlCount">统计记录数的sql语句</param>
        /// <param name="sqlCountParameters">统计记录数的sql参数</param>
        /// <returns>分页模型</returns>
        public static Page<TEntity> GetPage<TEntity>(int page, int itemsPerPage, string sqlPage, SqlParameter[] sqlPageParametersarameters, string sqlCount,
            SqlParameter[] sqlCountParameters) where TEntity : EntityBase<TEntity>, new()
        {
            var parameters = new List<SqlParameter>(sqlPageParametersarameters ?? new SqlParameter[0]);
            if (parameters.All(t => t.ParameterName != "@itemsPerPage"))
            {
                parameters.Add(new SqlParameter("@itemsPerPage", itemsPerPage));
            }
            if (parameters.All(t => t.ParameterName != "@page"))
            {
                parameters.Add(new SqlParameter("@page", page));
            }
            var entities = GetEntities<TEntity>(sqlPage, parameters.ToArray());
            var count = GetCount(sqlCount, sqlCountParameters);
            return Page<TEntity>.New(page, itemsPerPage, count, entities);
        }

        /// <summary>
        /// 获取分页的sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public static string GetPagingSql(string sql, string orderBy)
        {
            const string format = @"
SELECT *
FROM    ( SELECT    page.* ,
                    ROW_NUMBER() OVER (ORDER BY {1} ) AS RowNumber
          FROM      ({0})page
        )t
WHERE   RowNumber BETWEEN ((@page-1)*@itemsPerPage+1) AND @page*@itemsPerPage";
            return string.Format(format, sql, orderBy);
        }

        public static string GetSqlParametersInfo(params SqlParameter[] parameters)
        {
            return parameters != null
                ? string.Join("\r\n",
                    parameters.Select(t => string.Format("{0}={1}", t.ParameterName, t.Value)))
                : "NULL";
        }
        #endregion

        #region 获取DataTable
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sql">传入SQL语句</param>
        /// <returns>返回DataTable</returns>
        public static DataTable GetTable(string sql)
        {
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                return dbo.getTable(sql);
            }
#if DEBUG
            catch (Exception exception)
            {
                Debug.WriteLine(sql, "sql");
                Debug.WriteLine(exception, "exception");
                throw;
            }
#endif
            finally
            {
                if (dbo != null)
                {
                    dbo.Close();
                }
            }
        }

        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sql">传入SQL语句</param>
        /// <param name="parameters">SqlParameter 参数</param>
        /// <returns>返回DataTable</returns>
        public static DataTable GetTable(string sql, params SqlParameter[] parameters)
        {
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                if (parameters == null)
                    return dbo.getTable(sql);
                else
                    return dbo.getTable(sql, parameters);
            }
#if DEBUG
            catch (Exception exception)
            {
                Debug.WriteLine(sql, "sql");
                Debug.WriteLine(GetSqlParametersInfo(parameters), "parameters");
                Debug.WriteLine(exception, "exception");
                throw;
            }
#endif
            finally
            {
                if (dbo != null)
                {
                    dbo.Close();
                }
            }
        }
        #endregion

        #region 获取GetCount
        /// <summary>
        /// 获取GetCount
        /// </summary>
        /// <param name="sql">传入SQL语句</param>
        /// <returns>返回[int]Count</returns>
        public static int GetCount(string sql)
        {
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                return dbo.getCount(sql);
            }
#if DEBUG
            catch (Exception exception)
            {
                Debug.WriteLine(sql, "sql");
                Debug.WriteLine(exception, "exception");
                throw;
            }
#endif
            finally
            {
                if (dbo != null)
                {
                    dbo.Close();
                }
            }
        }

        /// <summary>
        /// 获取GetCount
        /// </summary>
        /// <param name="sql">传入SQL语句</param>
        /// <param name="parameters">SqlParameter 参数</param>
        /// <returns>返回[int]Count</returns>
        public static int GetCount(string sql, params SqlParameter[] parameters)
        {
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                if (parameters == null)
                    return dbo.getCount(sql);
                else
                    return dbo.getCount(sql, parameters);
            }
#if DEBUG
            catch (Exception exception)
            {
                Debug.WriteLine(sql, "sql");
                Debug.WriteLine(GetSqlParametersInfo(parameters), "parameters");
                Debug.WriteLine(exception, "exception");
                throw;
            }
#endif
            finally
            {
                if (dbo != null)
                {
                    dbo.Close();
                }
            }
        }
        #endregion

        #region 获取GetObject
        /// <summary>
        /// 获取GetObject: 返回第一行第一列
        /// </summary>
        /// <param name="sql">传入SQL语句</param>
        /// <returns>返回Object</returns>
        public static object GetObject(string sql)
        {
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                return dbo.getObject(sql);
            }
#if DEBUG
            catch (Exception exception)
            {
                Debug.WriteLine(sql, "sql");
                Debug.WriteLine(exception, "exception");
                throw;
            }
#endif
            finally
            {
                if (dbo != null)
                {
                    dbo.Close();
                }
            }
        }

        /// <summary>
        /// 获取GetObject: 返回第一行第一列
        /// </summary>
        /// <param name="sql">传入SQL语句</param>
        /// <param name="parameters">SqlParameter 参数</param>
        /// <returns>返回Object</returns>
        public static object GetObject(string sql, params SqlParameter[] parameters)
        {
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                if (parameters == null)
                    return dbo.getObject(sql);
                else
                    return dbo.getObject(sql, parameters);
            }
#if DEBUG
            catch (Exception exception)
            {
                Debug.WriteLine(sql, "sql");
                Debug.WriteLine(GetSqlParametersInfo(parameters), "parameters");
                Debug.WriteLine(exception, "exception");
                throw;
            }
#endif
            finally
            {
                if (dbo != null)
                {
                    dbo.Close();
                }
            }
        }
        #endregion

        #region 执行SQL语句返回是否成功
        /// <summary>
        /// 执行SQL语句返回是否成功
        /// </summary>
        /// <param name="sql">传入SQL语句</param>
        /// <returns>返回是否成功</returns>
        public static bool ExecuteSql(string sql)
        {
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                return dbo.executeSql(sql);
            }
#if DEBUG
            catch (Exception exception)
            {
                Debug.WriteLine(sql, "sql");
                Debug.WriteLine(exception, "exception");
                throw;
            }
#endif
            finally
            {
                if (dbo != null)
                {
                    dbo.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL语句返回是否成功
        /// </summary>
        /// <param name="sql">传入SQL语句</param>
        /// <param name="parameters">SqlParameter 参数</param>
        /// <returns>返回是否成功</returns>
        public static bool ExecuteSql(string sql, params SqlParameter[] parameters)
        {
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                if (parameters == null)
                    return dbo.executeSql(sql);
                else
                    return dbo.executeSql(sql, parameters);
            }
#if DEBUG
            catch (Exception exception)
            {
                Debug.WriteLine(sql, "sql");
                Debug.WriteLine(GetSqlParametersInfo(parameters), "parameters");
                Debug.WriteLine(exception, "exception");
                throw;
            }
#endif
            finally
            {
                if (dbo != null)
                {
                    dbo.Close();
                }
            }
        }
        #endregion

        #region 分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="filename">需要返回的列</param>
        /// <param name="sortfilename">排序字段名</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderType">设置排序类型, 非 0 值则降序</param>
        /// <param name="strWhere">查询条件 (注意: 不要加 where)</param>
        /// <param name="recordCount">总记录</param>
        /// <returns></returns>
        public static DataTable GetDataByPage(string tablename, string filename, string sortfilename, int pageSize,
            int pageIndex, int orderType, string strWhere, out int recordCount)
        {
            recordCount = 0;
            //创建参数
            SqlParameter[] param =
            {
                new SqlParameter("@tblName", SqlDbType.VarChar, 50),
                new SqlParameter("@strGetFields", SqlDbType.VarChar, 1000),
                new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@OrderType", SqlDbType.Bit, 1),
                new SqlParameter("@strWhere", SqlDbType.VarChar, 500),
                new SqlParameter("@RecordCount", SqlDbType.Int)
            };
            param[0].Value = tablename;
            param[1].Value = filename;
            param[2].Value = sortfilename;
            param[3].Value = pageSize;
            param[4].Value = pageIndex;
            param[5].Value = orderType;
            param[6].Value = strWhere;
            param[7].Direction = ParameterDirection.Output;
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                var dt = dbo.ExecuteProductData("GetDataByPage", param);
                recordCount = (int)param[7].Value;
                return dt;
            }
#if DEBUG
            catch (Exception exception)
            {
                Debug.WriteLine(exception, "exception");
                throw;
            }
#endif
            finally
            {
                if (null != dbo)
                {
                    dbo.Close();
                }
            }
        }

        /// <summary>
        /// 分页查询(支持JOIN)
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="filename">需要返回的列</param>
        /// <param name="sortfilename">排序字段名(默认升序，降序需在排序字段名后面DESC关键字：sortField Desc)</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="strWhere">查询条件 (注意: 不要加 where)</param>
        /// <param name="recordCount">总记录</param>
        /// <returns></returns>
        public static DataTable GetDataByPage_V2(string tablename, string filename, string sortfilename, int pageSize,
            int pageIndex, string strWhere, out int recordCount)
        {
            recordCount = 0;
            //创建参数
            SqlParameter[] param =
            {
                new SqlParameter("@tblName", SqlDbType.VarChar, 200),
                new SqlParameter("@strGetFields", SqlDbType.VarChar, 500),
                new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@strWhere", SqlDbType.VarChar, 500),
                new SqlParameter("@RecordCount", SqlDbType.Int),
                new SqlParameter("@TotalPage", SqlDbType.Int)
            };
            param[0].Value = tablename; //表名
            param[1].Value = filename; //需要返回的列
            param[2].Value = sortfilename; //排序字段名
            param[3].Value = pageSize; //页尺寸
            param[4].Value = pageIndex; //页码
            param[5].Value = strWhere; //查询条件
            param[6].Direction = ParameterDirection.ReturnValue; //总记录
            param[7].Direction = ParameterDirection.Output; //总页数
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                var dt = dbo.ExecuteProductData("GetDataByPage_V2", param);
                recordCount = (int)param[6].Value;
                return dt;
            }
#if DEBUG
            catch (Exception exception)
            {
                Debug.WriteLine(exception, "exception");
                throw;
            }
#endif
            finally
            {
                if (null != dbo)
                {
                    dbo.Close();
                }
            }
        }

        /// <summary>
        /// 分页查询(支持JOIN)
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="filename">需要返回的列</param>
        /// <param name="sortfilename">排序字段名(默认升序，降序需在排序字段名后面DESC关键字：sortField Desc)</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="strWhere">查询条件 (注意: 不要加 where)</param>
        /// <param name="recordCount">总记录</param>
        /// <returns></returns>
        public static DataTable GetDataByPage_V2_Join(string tablename, string filename, string sortfilename,
            int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            recordCount = 0;
            //创建参数
            SqlParameter[] param =
            {
                new SqlParameter("@tblName", SqlDbType.VarChar, 200),
                new SqlParameter("@strGetFields", SqlDbType.VarChar, 500),
                new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@strWhere", SqlDbType.VarChar, 500),
                new SqlParameter("@RecordCount", SqlDbType.Int),
                new SqlParameter("@TotalPage", SqlDbType.Int)
            };
            param[0].Value = tablename; //表名
            param[1].Value = filename; //需要返回的列
            param[2].Value = sortfilename; //排序字段名
            param[3].Value = pageSize; //页尺寸
            param[4].Value = pageIndex; //页码
            param[5].Value = strWhere; //查询条件
            param[6].Direction = ParameterDirection.ReturnValue; //总记录
            param[7].Direction = ParameterDirection.Output; //总页数
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                var dt = dbo.ExecuteProductData("GetDataByPage_V2_Join", param);
                recordCount = (int)param[6].Value;
                return dt;
            }
            finally
            {
                if (null != dbo)
                {
                    dbo.Close();
                }
            }
        }
        #endregion

        #region 执行存储过程
        /// <summary>
        /// 
        /// </summary>
        /// <param name="produreName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Hashtable ExecProduct(string produreName, params SqlParameter[] parameters)
        {
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                return dbo.executeProduct(produreName, parameters ?? new SqlParameter[0]);
            }
#if DEBUG
            catch (Exception exception)
            {
                Debug.WriteLine(produreName, "produreName");
                Debug.WriteLine(GetSqlParametersInfo(parameters), "parameters");
                Debug.WriteLine(exception, "exception");
                throw;
            }
#endif
            finally
            {
                if (dbo != null)
                {
                    dbo.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produreName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool ExecProductNonQuery(string produreName, params SqlParameter[] parameters)
        {
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                return dbo.ExecuteProduct(produreName, parameters ?? new SqlParameter[0]);
            }
#if DEBUG
            catch (Exception exception)
            {
                Debug.WriteLine(produreName, "produreName");
                Debug.WriteLine(GetSqlParametersInfo(parameters), "parameters");
                Debug.WriteLine(exception, "exception");
                throw;
            }
#endif
            finally
            {
                if (dbo != null)
                {
                    dbo.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produreName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteProductData(string produreName, params SqlParameter[] parameters)
        {
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                return dbo.ExecuteProductData(produreName, parameters ?? new SqlParameter[0]);
            }
#if DEBUG
            catch (Exception exception)
            {
                Debug.WriteLine(produreName, "produreName");
                Debug.WriteLine(GetSqlParametersInfo(parameters), "parameters");
                Debug.WriteLine(exception, "exception");
                throw;
            }
#endif
            finally
            {
                if (dbo != null)
                {
                    dbo.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produreName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteProductDataSet(string produreName, params SqlParameter[] parameters)
        {
            DataOperator dbo = null;
            try
            {
                dbo = new DataOperator();
                return dbo.ExecuteProductDataSet(produreName, parameters ?? new SqlParameter[0]);
            }
#if DEBUG
            catch (Exception exception)
            {
                Debug.WriteLine(produreName, "produreName");
                Debug.WriteLine(GetSqlParametersInfo(parameters), "parameters");
                Debug.WriteLine(exception, "exception");
                throw;
            }
#endif
            finally
            {
                if (dbo != null)
                {
                    dbo.Close();
                }
            }
        }
        #endregion
    }
}