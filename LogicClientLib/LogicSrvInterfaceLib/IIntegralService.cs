using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLib.Model;
using System.Data;

namespace LogicSrvInterfaceLib
{
    /// <summary>
    /// 积分服务接口
    /// </summary>
    public interface IIntegralService
    {

        /// <summary>
        /// 添加积分收支记录
        /// </summary>
        /// <param name="IntegralRecord">所添加积分收支记录列表</param>
        /// <returns></returns>
        bool IntegralAdd(List<IntegralLib> IntegralRecord);


        /// <summary>
        /// 检测积分是否够用或将要失效的积分是否够用(返回的值  -2：总的积分不够用或没有积分，  -1:将要失效的积分不够用 ，1：将要失效的积分够用)
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="Integral">所需要消耗的积分数</param>
        ///<param name="WillFailureIntegral">将要失效的积分数</param>
        /// <returns></returns>
        string CheckWillFailureIntegralIsUse(int UserID, int Integral, ref int WillFailureIntegral);


        /// <summary>
        /// 获取我的积分
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <returns></returns>
        DataTable MyIntegralGet(int UserID);


        /// <summary>
        /// 获取我的积分明细记录
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <param name="type">类型：-1：全部（积分明细） 1：积分收入 2：积分支出</param>
        /// <returns></returns>
        DataTable MyIntegralSubsidiaryGet(int UserID, int type, int Nowpage, int PageSize, ref int count);

        /// <summary>
        /// 获取我的积分充值记录
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <returns></returns>
        DataTable MyIntegralTopUpRecordGet(int UserID, int Nowpage, int PageSize, ref int count);

        /// <summary>
        /// 我的积分兑换礼品记录表
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <param name="Nowpage"></param>
        /// <param name="PageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        DataTable MyIntegralPointsForRecordGet(int UserID, int Nowpage, int PageSize, ref int count);


        /// <summary>
        /// 获取可用积分兑换的产品详细信息
        /// </summary>
        /// <param name="productid">产品id</param>
        /// <returns></returns>
        DataTable ProductDetailGetByID(string productid);



        /// <summary>
        /// 获取可用积分兑换的产品
        /// </summary>
        /// <param name="Nowpage"></param>
        /// <param name="PageSize"></param>
        /// <param name="count"></param>
        /// <param name="comefrom">平台站点类型区分 20001：家庭（jt平台），20002:safe61平台</param>
        /// <returns></returns>
        DataTable JtProductListGet(int Nowpage, int PageSize, ref int count, int comefrom);


        /// <summary>
        /// 获取用户是否观看该课程视频
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <param name="IncomeOrExpensexType">支出项目类型</param>
        /// <param name="objid">对象id：课程id</param>
        /// <returns></returns>
        bool IsSeeVideoByCourseID(int UserID, int IncomeOrExpensexType, int objid);


        /// <summary>
        /// 积分汇总
        /// </summary>
        /// <param name="UserID">用户id</param>
        /// <returns></returns>
        bool IntegralSummary(int UserID);


        /// <summary>
        /// 获取抽奖的产品所需积分
        /// </summary>
        /// <param name="productId">抽奖产品Id</param>
        /// <param name="comefrom">站点</param>
        /// <returns>抽奖产品所需积分</returns>
        int GetAppDrawProductList(int productId, int comefrom);

        /// <summary>
        /// 获取积分规则的分页数据
        /// </summary>
        /// <param name="currentPage">当前页</param>
        /// <param name="pageSize">页面容量</param>
        /// <param name="count">总条数</param>
        /// <param name="ruleId">-1时查询全部</param>
        /// <returns></returns>
        DataTable GetIntegralRule(int currentPage, int pageSize, ref int count, int ruleId = -1);

    }
}
