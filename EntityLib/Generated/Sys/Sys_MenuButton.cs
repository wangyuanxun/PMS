//------------------------------------------------------------------------------
//Description: Sys_MenuButton实体
//Author: WANGYX
//Date: 2015/11/13 10:57:18
//------------------------------------------------------------------------------
using System;
using System.Data;

namespace EntityLib
{
    [Serializable]
    public partial class Sys_MenuButton : EntityBase<Sys_MenuButton>
    {
        #region 私有属性
        private long _iD;
        ///<summary>
		///菜单ID
		///</summary>
        private long _menuID;
        ///<summary>
		///按钮ID
		///</summary>
        private long _buttonID;
        ///<summary>
		///按钮名称
		///</summary>
        private string _buttonName;
        ///<summary>
		///按钮排序
		///</summary>
        private int _orderIndex;
        #endregion
        
        #region 共有属性
        public virtual long ID
		{
			get { return _iD; }
			set { _iD = value; }
		}
        ///<summary>
		///菜单ID
		///</summary>
        public virtual long MenuID
		{
			get { return _menuID; }
			set { _menuID = value; }
		}
        ///<summary>
		///按钮ID
		///</summary>
        public virtual long ButtonID
		{
			get { return _buttonID; }
			set { _buttonID = value; }
		}
        ///<summary>
		///按钮名称
		///</summary>
        public virtual string ButtonName
		{
			get { return _buttonName; }
			set { _buttonName = value; }
		}
        ///<summary>
		///按钮排序
		///</summary>
        public virtual int OrderIndex
		{
			get { return _orderIndex; }
			set { _orderIndex = value; }
		}
        #endregion
        
        #region 构造函数
        ///<summary>
        ///Sys_MenuButton构造函数
        ///</summary>
        public Sys_MenuButton()
		{
            CustomConstructor();
        }
        
        ///<summary>
        ///Sys_MenuButton构造函数
        ///</summary>
        public Sys_MenuButton(
          long iD,
          long menuID,
          long buttonID,
          string buttonName,
          int orderIndex
        )
		{
            ID = iD;
            MenuID = menuID;
            ButtonID = buttonID;
            ButtonName = buttonName;
            OrderIndex = orderIndex;
            CustomConstructor();
        }
        
        /// <summary>
        /// Sys_MenuButton构造函数
        /// </summary>
        /// <param name="dataRow">数据源</param>
        public Sys_MenuButton(DataRow dataRow){
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
        public override sealed Sys_MenuButton LoadData(DataRow dataRow)
        {
            if (dataRow != null)
            {
                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value && dataRow["ID"] != null)
                    _iD = (long)dataRow["ID"];
                if (dataRow.Table.Columns.Contains("MenuID") && dataRow["MenuID"] != DBNull.Value && dataRow["MenuID"] != null)
                    _menuID = (long)dataRow["MenuID"];
                if (dataRow.Table.Columns.Contains("ButtonID") && dataRow["ButtonID"] != DBNull.Value && dataRow["ButtonID"] != null)
                    _buttonID = (long)dataRow["ButtonID"];
                if (dataRow.Table.Columns.Contains("ButtonName") && dataRow["ButtonName"] != DBNull.Value && dataRow["ButtonName"] != null)
                    _buttonName = (string)dataRow["ButtonName"];
                if (dataRow.Table.Columns.Contains("OrderIndex") && dataRow["OrderIndex"] != DBNull.Value && dataRow["OrderIndex"] != null)
                    _orderIndex = (int)dataRow["OrderIndex"];
                CustomConstructor(dataRow);
            }
            return this;
        }
        #endregion
    }
}