using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLib.Model;
namespace LogicSrvInterfaceLib
{
    /// <summary>
    /// 社会安全平台 服务接口
    /// </summary>
    public interface ISocietySafeEduService
    {
        /// <summary>
        /// 消防自查 查询一个用户消防自查情况
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        SocietyFireSelfCheckLib GetSelfCheckByUserID(int UserID);
        /// <summary>
        /// 消防自查 查询一个班级消防自查情况
        /// </summary>
        /// <param name="ClassRoom">班级ID</param>
        /// <returns></returns>
        List<SocietyFireSelfCheckLib> GetSelfCheckByClassRoom(int ClassRoom);
    }
}
