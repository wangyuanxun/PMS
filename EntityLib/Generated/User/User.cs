//------------------------------------------------------------------------------
//Description: User实体
//Author: WANGYX
//Date: 2015/11/20 19:19:13
//------------------------------------------------------------------------------
using System;
using System.Data;

namespace EntityLib
{
    [Serializable]
    public partial class User : EntityBase<User>
    {
        #region 私有属性
        private long _iD;
        ///<summary>
		///登录名
		///</summary>
        private string _userName;
        ///<summary>
		///登录密码
		///</summary>
        private string _passWord;
        ///<summary>
		///真实姓名
		///</summary>
        private string _realName;
        ///<summary>
		///性别 1=男 2=女
		///</summary>
        private int _sex;
        ///<summary>
		///手机
		///</summary>
        private string _mobile;
        ///<summary>
		///身份证号
		///</summary>
        private string _iDCard;
        ///<summary>
		///出生日期
		///</summary>
        private DateTime _birthday;
        ///<summary>
		///头像路径
		///</summary>
        private string _photo;
        ///<summary>
		///QQ
		///</summary>
        private string _qQ;
        ///<summary>
		///Email
		///</summary>
        private string _email;
        ///<summary>
		///状态 1=在职 2=离职
		///</summary>
        private int _state;
        ///<summary>
		///排序 正序
		///</summary>
        private int _orderIndex;
        ///<summary>
		///登录次数
		///</summary>
        private int _loginCount;
        ///<summary>
		///最后登录时间
		///</summary>
        private DateTime _lastLoginTime;
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
		///登录名
		///</summary>
        public virtual string UserName
		{
			get { return _userName; }
			set { _userName = value; }
		}
        ///<summary>
		///登录密码
		///</summary>
        public virtual string PassWord
		{
			get { return _passWord; }
			set { _passWord = value; }
		}
        ///<summary>
		///真实姓名
		///</summary>
        public virtual string RealName
		{
			get { return _realName; }
			set { _realName = value; }
		}
        ///<summary>
		///性别 1=男 2=女
		///</summary>
        public virtual int Sex
		{
			get { return _sex; }
			set { _sex = value; }
		}
        ///<summary>
		///手机
		///</summary>
        public virtual string Mobile
		{
			get { return _mobile; }
			set { _mobile = value; }
		}
        ///<summary>
		///身份证号
		///</summary>
        public virtual string IDCard
		{
			get { return _iDCard; }
			set { _iDCard = value; }
		}
        ///<summary>
		///出生日期
		///</summary>
        public virtual DateTime Birthday
		{
			get { return _birthday; }
			set { _birthday = value; }
		}
        ///<summary>
		///头像路径
		///</summary>
        public virtual string Photo
		{
			get { return _photo; }
			set { _photo = value; }
		}
        ///<summary>
		///QQ
		///</summary>
        public virtual string QQ
		{
			get { return _qQ; }
			set { _qQ = value; }
		}
        ///<summary>
		///Email
		///</summary>
        public virtual string Email
		{
			get { return _email; }
			set { _email = value; }
		}
        ///<summary>
		///状态 1=在职 2=离职
		///</summary>
        public virtual int State
		{
			get { return _state; }
			set { _state = value; }
		}
        ///<summary>
		///排序 正序
		///</summary>
        public virtual int OrderIndex
		{
			get { return _orderIndex; }
			set { _orderIndex = value; }
		}
        ///<summary>
		///登录次数
		///</summary>
        public virtual int LoginCount
		{
			get { return _loginCount; }
			set { _loginCount = value; }
		}
        ///<summary>
		///最后登录时间
		///</summary>
        public virtual DateTime LastLoginTime
		{
			get { return _lastLoginTime; }
			set { _lastLoginTime = value; }
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
        ///User构造函数
        ///</summary>
        public User()
		{
            CustomConstructor();
        }
        
        ///<summary>
        ///User构造函数
        ///</summary>
        public User(
          long iD,
          string userName,
          string passWord,
          string realName,
          int sex,
          string mobile,
          string iDCard,
          DateTime birthday,
          string photo,
          string qQ,
          string email,
          int state,
          int orderIndex,
          int loginCount,
          DateTime lastLoginTime,
          DateTime createTime
        )
		{
            ID = iD;
            UserName = userName;
            PassWord = passWord;
            RealName = realName;
            Sex = sex;
            Mobile = mobile;
            IDCard = iDCard;
            Birthday = birthday;
            Photo = photo;
            QQ = qQ;
            Email = email;
            State = state;
            OrderIndex = orderIndex;
            LoginCount = loginCount;
            LastLoginTime = lastLoginTime;
            CreateTime = createTime;
            CustomConstructor();
        }
        
        /// <summary>
        /// User构造函数
        /// </summary>
        /// <param name="dataRow">数据源</param>
        public User(DataRow dataRow){
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
        public override sealed User LoadData(DataRow dataRow)
        {
            if (dataRow != null)
            {
                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value && dataRow["ID"] != null)
                    _iD = (long)dataRow["ID"];
                if (dataRow.Table.Columns.Contains("UserName") && dataRow["UserName"] != DBNull.Value && dataRow["UserName"] != null)
                    _userName = (string)dataRow["UserName"];
                if (dataRow.Table.Columns.Contains("PassWord") && dataRow["PassWord"] != DBNull.Value && dataRow["PassWord"] != null)
                    _passWord = (string)dataRow["PassWord"];
                if (dataRow.Table.Columns.Contains("RealName") && dataRow["RealName"] != DBNull.Value && dataRow["RealName"] != null)
                    _realName = (string)dataRow["RealName"];
                if (dataRow.Table.Columns.Contains("Sex") && dataRow["Sex"] != DBNull.Value && dataRow["Sex"] != null)
                    _sex = (int)dataRow["Sex"];
                if (dataRow.Table.Columns.Contains("Mobile") && dataRow["Mobile"] != DBNull.Value && dataRow["Mobile"] != null)
                    _mobile = (string)dataRow["Mobile"];
                if (dataRow.Table.Columns.Contains("IDCard") && dataRow["IDCard"] != DBNull.Value && dataRow["IDCard"] != null)
                    _iDCard = (string)dataRow["IDCard"];
                if (dataRow.Table.Columns.Contains("Birthday") && dataRow["Birthday"] != DBNull.Value && dataRow["Birthday"] != null)
                    _birthday = (DateTime)dataRow["Birthday"];
                if (dataRow.Table.Columns.Contains("Photo") && dataRow["Photo"] != DBNull.Value && dataRow["Photo"] != null)
                    _photo = (string)dataRow["Photo"];
                if (dataRow.Table.Columns.Contains("QQ") && dataRow["QQ"] != DBNull.Value && dataRow["QQ"] != null)
                    _qQ = (string)dataRow["QQ"];
                if (dataRow.Table.Columns.Contains("Email") && dataRow["Email"] != DBNull.Value && dataRow["Email"] != null)
                    _email = (string)dataRow["Email"];
                if (dataRow.Table.Columns.Contains("State") && dataRow["State"] != DBNull.Value && dataRow["State"] != null)
                    _state = (int)dataRow["State"];
                if (dataRow.Table.Columns.Contains("OrderIndex") && dataRow["OrderIndex"] != DBNull.Value && dataRow["OrderIndex"] != null)
                    _orderIndex = (int)dataRow["OrderIndex"];
                if (dataRow.Table.Columns.Contains("LoginCount") && dataRow["LoginCount"] != DBNull.Value && dataRow["LoginCount"] != null)
                    _loginCount = (int)dataRow["LoginCount"];
                if (dataRow.Table.Columns.Contains("LastLoginTime") && dataRow["LastLoginTime"] != DBNull.Value && dataRow["LastLoginTime"] != null)
                    _lastLoginTime = (DateTime)dataRow["LastLoginTime"];
                if (dataRow.Table.Columns.Contains("CreateTime") && dataRow["CreateTime"] != DBNull.Value && dataRow["CreateTime"] != null)
                    _createTime = (DateTime)dataRow["CreateTime"];
                CustomConstructor(dataRow);
            }
            return this;
        }
        #endregion
    }
}