using System.Data;

namespace EntityLib
{
    /// <summary>
    /// 实体类接口
    /// </summary>
    /// <typeparam name="TEntity">实体类类型</typeparam>
    public interface IEntity<out TEntity>
    {
        /// <summary>
        /// 从一行数据中加载数据
        /// </summary>
        /// <param name="dataRow">数据源</param>
        /// <returns>返回实体本身 支持链式调用</returns>
        TEntity LoadData(DataRow dataRow);
    }
}
