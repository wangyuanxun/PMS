using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLib.Model;

namespace LogicSrvInterfaceLib
{
    /// <summary>
    /// 站点服务接口
    /// </summary>
    public interface ISiteService
    {
        /// <summary>
        /// 检查站点是否有效若有效则返回站点信息实体
        /// </summary>
        /// <param name="SiteID">站点ID</param>
        /// <returns></returns>
        WebSiteLib GetSiteInfo(string SiteID);
        /// <summary>
        /// 区县添加
        /// </summary>
        /// <param name="cb">区县实体</param>
        /// <returns>添加操作状态</returns>
        [Obsolete("此方法已经无效，因为这将导致平台库不能保存当前添加的区县信息。请使用CountryAddOrUpdate(int CountryID, string CountryName, int CityID)", true)]
        int CountryAdd(EntityLib.Model.CountryLib cb);
        /// <summary>
        /// 添加或更新区县
        /// </summary>
        /// <param name="CountryID">区县ID</param>
        /// <param name="CountryName">区县名称</param>
        /// <param name="CityID">城市ID</param>
        /// <returns></returns>
        bool CountryAddOrUpdate(int CountryID, string CountryName, int CityID);
        /// <summary>
        /// 学校添加
        /// </summary>
        /// <param name="sb">学校实体</param>
        /// <returns>添加操作状态</returns>
        [Obsolete("学校添加调用此方法时，将返回操作状态，而不是返回学校ID。若需要获得学校ID则请调用重载方法")]
        int SchoolAdd(EntityLib.Model.SchoolLib sb);
        /// <summary>
        /// 添加学校
        /// </summary>
        /// <param name="SchoolName">学校名称</param>
        /// <param name="CountryCode">学校区县</param>
        /// <param name="StartGrade">起始年级</param>
        /// <param name="EndGrade">终止年级</param>
        /// <param name="SchoolType">学校类型</param>
        /// <param name="GradeType">年级类型</param>
        /// <param name="SchoolProperty">学校性质</param>
        /// <param name="SchoolAddress">学校地址</param>
        /// <returns>返回学校ID，ID小于等于0时 表示添加失败</returns>
        int SchoolAdd(string SchoolName, int CountryCode, int StartGrade, int EndGrade, int SchoolType, int GradeType, int SchoolProperty, string SchoolAddress);
        /// <summary>
        /// 删除学校
        /// </summary>
        /// <param name="id">学校ID</param>
        /// <returns></returns>
        bool SchoolDelete(int id);
        /// <summary>
        /// 学校更新
        /// </summary>
        /// <param name="sb">学校实体</param>
        /// <returns></returns>
        bool SchoolUpdate(EntityLib.Model.SchoolLib sb);
        /// <summary>
        /// 区县更新
        /// </summary>
        /// <param name="cb">区县实体</param>
        /// <returns></returns>
        [Obsolete("建议采用CountryAddOrUpdate(int CountryID, string CountryName, int CityID)执行更新，便于统一管理代码")]
        bool CountryUpdate(EntityLib.Model.CountryLib cb);
    }
}
