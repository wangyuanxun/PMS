using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EntityLib
{
    /// <summary>
    /// 实体类基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    [Serializable]
    public abstract class EntityBase<TEntity> : IEntity<TEntity> where TEntity : EntityBase<TEntity>, new()
    {
        /// <summary>
        /// 实例化一个集合
        /// </summary>
        /// <param name="table">数据源</param>
        /// <returns></returns>
        public static List<TEntity> NewList(DataTable table)
        {
            if (table != null && table.Rows.Count > 0)
            {
                return table.AsEnumerable().Select(t => new TEntity().LoadData(t)).ToList();
            }
            return new List<TEntity>();
        }

        /// <summary>
        /// 实例化一个实体
        /// </summary>
        /// <param name="dataRow">数据源</param>
        /// <returns></returns>
        public static TEntity New(DataRow dataRow)
        {
            return new TEntity().LoadData(dataRow);
        }

        /// <summary>
        /// 从一行数据中加载数据
        /// </summary>
        /// <param name="dataRow">数据源</param>
        /// <returns>返回实体本身 支持链式调用</returns>
        public abstract TEntity LoadData(DataRow dataRow);

        /// <summary>
        /// 实例化一个实体
        /// </summary>
        public static TEntity New()
        {
            return new TEntity();
        }
    }
}
