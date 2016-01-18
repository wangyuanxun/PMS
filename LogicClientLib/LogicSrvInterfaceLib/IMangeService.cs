using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicSrvInterfaceLib
{
    /// <summary>
    /// 管理服务接口
    /// </summary>
    public interface IMangeService
    {
        /// <summary>
        /// 清除学校用户
        /// </summary>
        /// <param name="userTypes">用户类型</param>
        /// <param name="schoolID">学校ID</param>
        /// <param name="delSchool">
        /// 是否删除学校信息 
        /// 是：删除班级所有用户类型的用户（此时不会依据UserTypes参数执行删除）、并且删除学校下的所有班级信息、再删除学校信息
        /// 否：依据UserTypes删除用户，留下学校和学校的班级信息</param>
        /// <returns></returns>
        bool BatchDeleteUserForSchool(int[] userTypes, int schoolID, bool delSchool);
        /// <summary>
        /// 删除指定学校的指定年级指定类型的用户
        /// </summary>
        /// <param name="userTypes">指定的用户类型</param>
        /// <param name="schoolID">学校ID</param>
        /// <param name="grade">年级</param>
        /// <param name="delGradeClass">
        /// 是否删除这个年级下的所有班级信息
        /// 是：删除这个年级下所有班级的账户信息（不按照UserTypes参数来删除用户）、再删除班级
        /// 否：删除这个学校的指定年级下的所有班级指定的用户类型信息，留下班级
        /// </param>
        /// <returns></returns>
        bool BatchDeleteUserForGrade(int[] userTypes, int schoolID, int grade, bool delGradeClass);
        /// <summary>
        /// 清除班级用户
        /// </summary>
        /// <param name="userTypes">要清除的的用户类型</param>
        /// <param name="classRoom">班级ID</param>
        /// <param name="delClass">
        /// 是否同时删除班级
        /// 是：删除班级所有用户类型的用户（此时不会依据UserTypes参数执行删除）、再删除班级信息
        /// 否：依据UserTypes删除用户，留下班级信息</param>
        /// <returns></returns>
        bool BatchDeleteUserForClass(int[] userTypes, int classRoom, bool delClass);
    }
}
