//------------------------------------------------------------------------------
//Description: Sys_Menu实体
//Author: WANGYX
//Date: 2015/11/13 10:57:18
//------------------------------------------------------------------------------
using System;
using System.Data;

namespace EntityLib
{
    [Serializable]
    public partial class Sys_Menu : EntityBase<Sys_Menu>
    {
        #region 私有属性
        private long _iD;
        ///<summary>
		///父节点ID 没有父节点=0
		///</summary>
        private long _parentID;
        ///<summary>
		///菜单名称
		///</summary>
        private string _menuName;
        ///<summary>
		///菜单图标
		///</summary>
        private string _menuImg;
        ///<summary>
		///是否启用 1：启用 2：禁用
		///</summary>
        private byte _isEnable;
        ///<summary>
		///链接地址
		///</summary>
        private string _linkUrl;
        ///<summary>
		///菜单备注
		///</summary>
        private string _intro;
        ///<summary>
		///菜单排序 正序
		///</summary>
        private int _orderIndex;
        ///<summary>
		///创建时间
		///</summary>
        private DateTime _createTime;
        #endregion
        
        #region 共有属性
        public virtual long ID
		{
			get { return _iD; }
			set { _iD = value; }
		}
        ///<summary>
		///父节点ID 没有父节点=0
		///</summary>
        public virtual long ParentID
		{
			get { return _parentID; }
			set { _parentID = value; }
		}
        ///<summary>
		///菜单名称
		///</summary>
        public virtual string MenuName
		{
			get { return _menuName; }
			set { _menuName = value; }
		}
        ///<summary>
		///菜单图标
		///</summary>
        public virtual string MenuImg
		{
			get { return _menuImg; }
			set { _menuImg = value; }
		}
        ///<summary>
		///是否启用 1：启用 2：禁用
		///</summary>
        public virtual byte IsEnable
		{
			get { return _isEnable; }
			set { _isEnable = value; }
		}
        ///<summary>
		///链接地址
		///</summary>
        public virtual string LinkUrl
		{
			get { return _linkUrl; }
			set { _linkUrl = value; }
		}
        ///<summary>
		///菜单备注
		///</summary>
        public virtual string Intro
		{
			get { return _intro; }
			set { _intro = value; }
		}
        ///<summary>
		///菜单排序 正序
		///</summary>
        public virtual int OrderIndex
		{
			get { return _orderIndex; }
			set { _orderIndex = value; }
		}
        ///<summary>
		///创建时间
		///</summary>
        public virtual DateTime CreateTime
		{
			get { return _createTime; }
			set { _createTime = value; }
		}
        #endregion
        
        #region 构造函数
        ///<summary>
        ///Sys_Menu构造函数
        ///</summary>
        public Sys_Menu()
		{
            CustomConstructor();
        }
        
        ///<summary>
        ///Sys_Menu构造函数
        ///</summary>
        public Sys_Menu(
          long iD,
          long parentID,
          string menuName,
          string menuImg,
          byte isEnable,
          string linkUrl,
          string intro,
          int orderIndex,
          DateTime createTime
        )
		{
            ID = iD;
            ParentID = parentID;
            MenuName = menuName;
            MenuImg = menuImg;
            IsEnable = isEnable;
            LinkUrl = linkUrl;
            Intro = intro;
            OrderIndex = orderIndex;
            CreateTime = createTime;
            CustomConstructor();
        }
        
        /// <summary>
        /// Sys_Menu构造函数
        /// </summary>
        /// <param name="dataRow">数据源</param>
        public Sys_Menu(DataRow dataRow){
            LoadData(dataRow);
            CustomConstructor(dataRow);
        }
        
        /// <summary>
        /// 部分类无参构造函数默认调用方法
        /// </summary>
        partial void CustomConstructor();
        
        /// <summary>
        /// 部分类包含参数dataRow的构造函数默认调用方法
        /// </summary>
        /// <param name="dataRow"></param>
        partial void CustomConstructor(DataRow dataRow);
        
        /// <summary>
        /// 从一行数据中加载数据
        /// </summary>
        /// <param name="dataRow">数据源</param>
        /// <returns>实体本身</returns>
        public override sealed Sys_Menu LoadData(DataRow dataRow)
        {
            if (dataRow != null)
            {
                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value && dataRow["ID"] != null)
                    _iD = (long)dataRow["ID"];
                if (dataRow.Table.Columns.Contains("ParentID") && dataRow["ParentID"] != DBNull.Value && dataRow["ParentID"] != null)
                    _parentID = (long)dataRow["ParentID"];
                if (dataRow.Table.Columns.Contains("MenuName") && dataRow["MenuName"] != DBNull.Value && dataRow["MenuName"] != null)
                    _menuName = (string)dataRow["MenuName"];
                if (dataRow.Table.Columns.Contains("MenuImg") && dataRow["MenuImg"] != DBNull.Value && dataRow["MenuImg"] != null)
                    _menuImg = (string)dataRow["MenuImg"];
                if (dataRow.Table.Columns.Contains("IsEnable") && dataRow["IsEnable"] != DBNull.Value && dataRow["IsEnable"] != null)
                    _isEnable = (byte)dataRow["IsEnable"];
                if (dataRow.Table.Columns.Contains("LinkUrl") && dataRow["LinkUrl"] != DBNull.Value && dataRow["LinkUrl"] != null)
                    _linkUrl = (string)dataRow["LinkUrl"];
                if (dataRow.Table.Columns.Contains("Intro") && dataRow["Intro"] != DBNull.Value && dataRow["Intro"] != null)
                    _intro = (string)dataRow["Intro"];
                if (dataRow.Table.Columns.Contains("OrderIndex") && dataRow["OrderIndex"] != DBNull.Value && dataRow["OrderIndex"] != null)
                    _orderIndex = (int)dataRow["OrderIndex"];
                if (dataRow.Table.Columns.Contains("CreateTime") && dataRow["CreateTime"] != DBNull.Value && dataRow["CreateTime"] != null)
                    _createTime = (DateTime)dataRow["CreateTime"];
                CustomConstructor(dataRow);
            }
            return this;
        }
        #endregion
    }
}