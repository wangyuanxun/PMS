//------------------------------------------------------------------------------
//Description: Sys_Button实体
//Author: WANGYX
//Date: 2015/11/13 10:57:17
//------------------------------------------------------------------------------
using System;
using System.Data;

namespace EntityLib
{
    [Serializable]
    public partial class Sys_Button : EntityBase<Sys_Button>
    {
        #region 私有属性
        private long _iD;
        ///<summary>
		///按钮名称
		///</summary>
        private string _buttonName;
        ///<summary>
		///按钮事件
		///</summary>
        private string _buttonFunction;
        ///<summary>
		///按钮图标
		///</summary>
        private string _buttonImg;
        ///<summary>
		///按钮备注
		///</summary>
        private string _intro;
        ///<summary>
		///按钮排序 正序
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
		///按钮名称
		///</summary>
        public virtual string ButtonName
		{
			get { return _buttonName; }
			set { _buttonName = value; }
		}
        ///<summary>
		///按钮事件
		///</summary>
        public virtual string ButtonFunction
		{
			get { return _buttonFunction; }
			set { _buttonFunction = value; }
		}
        ///<summary>
		///按钮图标
		///</summary>
        public virtual string ButtonImg
		{
			get { return _buttonImg; }
			set { _buttonImg = value; }
		}
        ///<summary>
		///按钮备注
		///</summary>
        public virtual string Intro
		{
			get { return _intro; }
			set { _intro = value; }
		}
        ///<summary>
		///按钮排序 正序
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
        ///Sys_Button构造函数
        ///</summary>
        public Sys_Button()
		{
            CustomConstructor();
        }
        
        ///<summary>
        ///Sys_Button构造函数
        ///</summary>
        public Sys_Button(
          long iD,
          string buttonName,
          string buttonFunction,
          string buttonImg,
          string intro,
          int orderIndex,
          DateTime createTime
        )
		{
            ID = iD;
            ButtonName = buttonName;
            ButtonFunction = buttonFunction;
            ButtonImg = buttonImg;
            Intro = intro;
            OrderIndex = orderIndex;
            CreateTime = createTime;
            CustomConstructor();
        }
        
        /// <summary>
        /// Sys_Button构造函数
        /// </summary>
        /// <param name="dataRow">数据源</param>
        public Sys_Button(DataRow dataRow){
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
        public override sealed Sys_Button LoadData(DataRow dataRow)
        {
            if (dataRow != null)
            {
                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value && dataRow["ID"] != null)
                    _iD = (long)dataRow["ID"];
                if (dataRow.Table.Columns.Contains("ButtonName") && dataRow["ButtonName"] != DBNull.Value && dataRow["ButtonName"] != null)
                    _buttonName = (string)dataRow["ButtonName"];
                if (dataRow.Table.Columns.Contains("ButtonFunction") && dataRow["ButtonFunction"] != DBNull.Value && dataRow["ButtonFunction"] != null)
                    _buttonFunction = (string)dataRow["ButtonFunction"];
                if (dataRow.Table.Columns.Contains("ButtonImg") && dataRow["ButtonImg"] != DBNull.Value && dataRow["ButtonImg"] != null)
                    _buttonImg = (string)dataRow["ButtonImg"];
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