using System;
using System.Collections.Generic;

namespace EntityLib
{
    /// <summary>
    /// 分页模型
    /// </summary>
    /// <typeparam name="TEntity">分页数据集类型</typeparam>
    [Serializable]
    public class Page<TEntity>
    {
        private int _itemsPerPage;
        private int _totalItems;
        private int _totalPages = 1;

        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 总页码
        /// </summary>
        public int TotalPages
        {
            get { return this._totalPages; }
            set { this._totalPages = value; }
        }

        /// <summary>
        /// 总记录条数
        /// </summary>
        public int TotalItems
        {
            get { return this._totalItems; }
            set
            {
                this._totalItems = value;
                SetTotalPages();
            }
        }

        /// <summary>
        /// 每页记录条数
        /// </summary>
        public int ItemsPerPage
        {
            get { return this._itemsPerPage; }
            set
            {
                this._itemsPerPage = value;
                SetTotalPages();
            }
        }

        /// <summary>
        /// 当前页的数据集合
        /// </summary>
        public List<TEntity> Items { get; set; }

        /// <summary>
        /// 分页参数上下文
        /// </summary>
        public object Context { get; set; }

        /// <summary>
        /// 设置总页数
        /// </summary>
        private void SetTotalPages()
        {
            if (this._itemsPerPage > 0 && this._totalItems > 0)
            {
                TotalPages = (int)Math.Ceiling(1.0 * this.TotalItems / this._itemsPerPage);
            }
            else
            {
                TotalPages = 1;
            }
        }

        public Page()
        {
            this.Items = new List<TEntity>();
        }

        public Page(int page, int itemsPerPage, int totalItems, IEnumerable<TEntity> entities)
        {
            this.CurrentPage = page;
            this.ItemsPerPage = itemsPerPage;
            this.TotalItems = totalItems;
            this.Items = new List<TEntity>(entities);
        }

        public static Page<TEntity> New()
        {
            return new Page<TEntity>();
        }

        public static Page<TEntity> New(int page, int itemsPerPage, int totalItems, IEnumerable<TEntity> entities)
        {
            return new Page<TEntity>(page, itemsPerPage, totalItems, entities);
        }
    }
}
