using System;
using System.Collections.Generic;
using System.Data;
using EntityLib.Model;

namespace LogicSrvInterfaceLib {
    /// <summary>
    /// 用户接口
    /// </summary>
    public interface IUserService {
        /// <summary>
        /// 保存学生信息 用于更新时，需要指定用户ID。
        /// 在不指定UserID的情况下，将尝试插入时，除以下一种情况：
        /// 若在同一学校同一班级如果导入了相同的UserName用户那么将造成覆盖更新
        /// </summary>
        /// <param name="sVUser">用户实体</param>
        /// <returns></returns>
        string SaveUser(string sVUser);
        /// <summary>
        /// 保存管理员信息, 若用于更新则需指定UserID。
        /// 在不指定UserID的情况下，尝试插入用户，除以下几种情况：
        /// 当导入校级管理员时，同一学校同一UserName的校级管理员将会造成覆盖
        /// 当导入区级管理员时，同一区县同一UserName的区级管理员将会造成覆盖
        /// 当导入市级管理员时，同一城市同一UserName的市级管理员将会造成覆盖
        /// </summary>
        /// <param name="sVAdmin">管理员实体</param>
        /// <returns></returns>
        string SaveAdmin(string sVAdmin);

        /// <summary>
        /// 保存教师信息
        /// 同UserName同市区学校 覆盖 ，否则尝试重新生成用户名
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        VAdmin SaveTeacher(VAdmin teacher);
        /// <summary>
        /// 检查用户是否vip，是否还存在有虚拟币。
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        bool UserCheck(string userID);
        /// <summary>
        /// 获取vip用户信息。
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <returns></returns>
        VipUserLib VipInfoGet(string userID);
        /// <summary>
        /// 用户VIP权限获取
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        List<VIPPermissionLib> VipPermissionGet(string userID);
        /// <summary>
        /// 检查用户名在主数据库中是否存在
        /// </summary>
        /// <param name="userName">需要检查的用户名</param>
        /// <returns></returns>
        bool CheckUserName(string userName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        bool CheckWebSite(string siteId, string schoolId);
        /// <summary>
        /// 检查站点是否有效
        /// </summary>
        /// <param name="siteID"></param>
        /// <returns></returns>
        bool CheckWebSite(string siteID);
        /// <summary>
        /// 根据UserID删除用户
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <returns></returns>
        bool DeleteByUserID(string userID);
        /// <summary>
        /// 根据用户id设置删除状态为-1
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <returns></returns>
        bool SetDeleteByUserID(string userID);
        /// <summary>
        /// 判断班级名称是否存在，不存在将添加
        /// </summary>
        /// <param name="schoolID">学校名</param>
        /// <param name="grade">年级</param>
        /// <param name="className">班级名</param>
        /// <returns></returns>
        string GetClassRoom(string schoolID, string grade, string className);
        /// <summary>
        /// 是否存在重名班级
        /// </summary>
        /// <param name="schoolId">学校Id</param>
        /// <param name="grade">年级</param>
        /// <param name="className">班级名称</param>
        /// <returns>-1有异常发生 、0 没有 正数代表重名的班级数量</returns>
        int ExistClassRoom(int schoolId, int grade, string className);
        /// <summary>
        /// 添加班级
        /// </summary>
        /// <param name="schoolId">学校id</param>
        /// <param name="grade">年级</param>
        /// <param name="className">班级名称</param>
        /// <returns>班级Id -1代表有异常</returns>
        int AddClassRoom(int schoolId, int grade, string className);
        ///// <summary>
        ///// 更新正式表用户信息
        ///// </summary>
        ///// <param name="UserID"></param>
        ///// <param name="UserName"></param>
        ///// <param name="Phone"></param>
        ///// <param name="TrueName"></param>
        ///// ...
        ///// <returns></returns>
        //[Obsolete("本方法已经不受支持，将在下一个版本中执行删除，请根据用户权限级别调用SaveUser或SaveAdmin来执行更新，非学生用户调用SaveAdmin，学生用户调用SaveUser", true)]
        //bool Update(string UserID, string UserName, string Phone, string TrueName, string Sex, string Birthday, string UserType, string PrvID, string CityID, string CunID, string SchoolID, string ClassRoom, string Grade, string Interest);
        ///// <summary>
        ///// 更新导入用户临时表用户信息
        ///// </summary>
        ///// <param name="UserID"></param>
        ///// <param name="UserName"></param>
        ///// <param name="Phone"></param>
        ///// <param name="TrueName"></param>
        ///// ...
        ///// <returns></returns>
        //[Obsolete("本方法已经不受支持，将在下一个版本中执行删除，请根据用户权限级别调用SaveUser或SaveAdmin来执行更新，非学生用户调用SaveAdmin，学生用户调用SaveUser", true)]
        //bool UpdateTmp(string UserID, string UserName, string Phone, string TrueName, string Sex, string Birthday, string UserType, string PrvID, string CityID, string CunID, string SchoolID, string ClassRoom, string Grade, string Interest);
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <param name="oldPassWord">原密码</param>
        /// <param name="newPassWord">新密码</param>
        /// <returns></returns>
        bool ModifyPassWord(string userID, string oldPassWord, string newPassWord);

        /// <summary>
        /// 升级年纪
        /// </summary>
        /// <param name="schoolId">学校Id</param>
        /// <param name="classRoom">班级Id</param>
        /// <exception cref="ArgumentException">传入的班级Id无效</exception>
        /// <exception cref="ArgumentException">传入的学校Id无效</exception>
        /// <returns></returns>
        bool GradeUpdate(int schoolId, int classRoom);
        /// <summary>
        /// 批量升级
        /// </summary>
        /// <param name="schoolId">学校Id</param>
        /// <param name="classRooms">班级Id数组</param>
        /// <returns></returns>
        bool GradeUpdateBatch(int schoolId, params int[] classRooms);

        /// <summary>
        /// 归档
        /// </summary>
        /// <param name="schoolId">学校Id</param>
        /// <param name="classRooms">班级Id数组</param>
        /// <returns></returns>
        bool Pigeonhole(int schoolId, params int[] classRooms);

        /// <summary>
        /// 开始导入学生用户
        /// </summary>
        /// <param name="source">
        /// 数据源 数据格式如：
        /// 预处理用户名          班级名称
        /// PreUserName        ClassName
        /// zhangsan               一班
        /// lisi                          二班
        /// </param>
        /// <param name="comeFrom">平台来源</param>
        /// <param name="schoolId">学校Id</param>
        /// <param name="grade">年级</param>
        /// <returns></returns>
        DataSet ImportStudent(DataTable source,int comeFrom, int schoolId, int grade);
        /// <summary>
        /// 福田导入学生账号
        /// </summary>
        /// <param name="source">
        /// 数据源 数据格式如：
        /// 预处理用户名          班级名称
        /// PreUserName        ClassName
        /// zhangsan               一班
        /// lisi                          二班
        /// </param>
        /// <param name="comeFrom">平台来源</param>
        /// <param name="schoolId">学校Id</param>
        /// <param name="grade">年级</param>
        /// <returns></returns>
        DataSet ImportStudentFutian(DataTable source, int comeFrom, int schoolId, int grade);

        /// <summary>
        /// 严格使用用户名导入学生账号
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="comeFrom">来源</param>
        /// <param name="schoolId">学校id</param>
        /// <param name="grade">年级</param>
        /// <returns></returns>
        DataSet ImportStudentWithStrictUserName(DataTable source, int comeFrom, int schoolId, int grade);
        /// <summary>
        /// 使用身份证导入账号 
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="adminInfo">公共属性</param>
        /// <param name="addTime">统一一个添加时间,方便数据查找</param>
        /// <param name="message">错误信息,成功时为空</param>
        /// <remarks>2014-09-16 zjb</remarks>
        /// <returns></returns>
        DataTable ImportStudentByIDCard(DataTable source, EntityLib.Model.AdminInfo adminInfo, out string message, out DateTime addTime);

        /// <summary>
        /// 使用身份证号导入教师账号
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="adminInfo">公共属性</param>
        /// <param name="message">错误信息,为空时说明存储过程执行成功</param>
        /// <param name="addTime">统一添加时间,方便数据查找,异常处理</param>
        /// <remarks>2014-09-16 zjb</remarks>
        /// <returns></returns>
        DataTable ImportTeacherByIDCard(DataTable source, EntityLib.Model.AdminInfo adminInfo, out string message, out DateTime addTime);
    }
}
