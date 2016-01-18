using System.Collections.Generic;
using System.Data;
using EntityLib.Model;

namespace LogicSrvInterfaceLib
{
    /// <summary>
    /// 支付服务
    /// </summary>
    public interface IPayService
    {
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="pl">订单实体</param>
        /// <param name="shopList">所购买产品的列表</param>
        /// <returns>返回订单ID 返回空字符串即添加失败</returns>
        string PaymentOrderAdd(PaymentLib pl, List<ShopCartLib> shopList); //提交付款订单
        /// <summary>
        /// 更新订单
        /// </summary>
        /// <param name="pl">订单实体</param>
        bool PaymentOrderUpdate(PaymentLib pl); //更新付款订单
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="productID">产品ID</param>
        /// <returns></returns>
        ProductLib ProductGet(int productID);
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="productType">产品类型</param>
        /// <param name="productGrade">产品年级</param>
        /// <returns></returns>
        ProductLib ProductGet(int productType, int productGrade);
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="guid">订单ID</param>
        /// <returns></returns>
        PaymentLib PaymentOrderGet(string guid); //获取订单信息
        /// <summary>
        /// 获取购物车
        /// </summary>
        /// <param name="guid">购物车GUID标识</param>
        /// <returns></returns>
        List<ShopCartLib> ShopCartListGet(string guid);
        /// <summary>
        /// 接收到支付宝返回调用时执行
        /// </summary>
        /// <param name="outTradeNo">订单号</param>
        /// <param name="tradeNo">支付交易号</param>
        /// <returns></returns>
        bool ResultReceive(string outTradeNo, string tradeNo); //充值结果接收


             /// <summary>
        ///     接收到支付宝返回调用时执行(积分充值)
        /// </summary>
        /// <param name="outTradeNo">订单号</param>
        /// <param name="tradeNo">支付交易号</param>
        /// <returns></returns>
        bool IntegralResultReceive(string outTradeNo, string tradeNo);//充值结果接收


        /// <summary>
        /// 确认积分兑换礼品
        /// </summary>
        /// <param name="PaymentID">订单id</param>
        /// <returns></returns>
        string PointsForAdd(string PaymentID, string UserID);

        /// <summary>
        /// 检查站点是否能使用这个卡 依据卡类型所属站点来实现
        /// </summary>
        /// <param name="cardNum">要判断的卡号</param>
        /// <param name="siteDescription">站点描述标识</param>
        /// <returns></returns>
        bool CheckCard(int cardNum, string siteDescription);



        /// <summary>
        /// 获取产品订单已付款
        /// </summary>
        /// <param name="paymentID"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        DataTable OrderProcductGetpay(string paymentID, string userid);

        /// <summary>
        /// 根据年级id获取产品
        /// </summary>
        /// <param name="grade">年级id</param>
        /// <returns></returns>
        DataTable ProductByGradeGet(int grade);
        /// <summary>
        /// 根据年级id获取技能训练产品
        /// </summary>
        /// <param name="grade">年级id</param>
        /// <returns></returns>
        DataTable ProductByGradeSkillGet(int grade);

        /// <summary>
        /// 获取订单商品
        /// </summary>
        /// <param name="paymentid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        DataTable ProductGetPid(string paymentid, string userid);

        /// <summary>
        /// 订单确认
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="paymentid">订单id</param>
        /// <returns></returns>
        bool UpdatePayStatus(string userid, string paymentid);
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="pid">订单id</param>
        /// <returns></returns>
        bool DelOrder(string pid);
        /// <summary>
        ///  商品评论
        /// </summary>
        /// <param name="pid">产品id</param>
        /// <param name="userid">用户id</param>
        /// <param name="username">用户名</param>
        /// <param name="truename">真实姓名</param>
        /// <param name="startnumber">评价几星</param>
        /// <param name="tips">评价内容</param>
        /// <param name="paymentid">订单id</param>
        /// <param name="shoppinggroup"></param>
        /// <returns></returns>
        bool InsertPingJia(string pid, string userid, string username, string truename, int startnumber, string tips, string paymentid, string shoppinggroup);
        /// <summary>
        /// 获取星级评价个数
        /// </summary>
        /// <param name="producttype"></param>
        /// <returns></returns>
        int StarNumGet(int producttype);
        /// <summary>
        /// 用户评价    
        /// </summary>
        /// <param name="producttype"></param>
        /// <param name="nowpage"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        DataTable UserPj(string producttype, int nowpage, int pageSize, ref int count);

        /// <summary>
        /// 根据年级、类型获取产品
        /// </summary>
        /// <param name="grade">年级</param>
        /// <param name="type">1：生命，2：商城 3：心里：4：技能训练短片 5：班主任激活</param>
        /// <returns></returns>
        DataTable ProductByGradeAndType(int grade, int type);
        /// <summary>
        ///  确认订单
        /// </summary>
        /// <param name="paymentid"></param>
        /// <param name="bank"></param>
        /// <param name="remittancenum"></param>
        /// <param name="userid"></param>
        /// <param name="truename"></param>
        /// <returns></returns>
        bool InsertBank(string paymentid, string bank, string remittancenum, string userid, string truename);

        /// <summary>
        /// 根据卡号和密码获得该支付卡的详细信息
        /// </summary>
        /// <param name="cardNum">卡号</param>
        /// <returns></returns>
        DataTable PayCardDetailGet(string cardNum);

        /// <summary>
        /// 更新卡的状态
        /// </summary>
        /// <param name="cardNum"></param>
        /// <param name="cardPwd"></param>
        /// <returns></returns>
        bool UpdatePayCard(string cardNum, int cardPwd);

        /// <summary>
        /// 判断用户之前是否已经使用过赠品学习卡
        /// </summary>
        /// <param name="accountID">用户ID</param>
        /// <returns>True:已试用过赠卡    False:未使用过赠卡</returns>
        bool CheckGift(string accountID);

        /// <summary>
        /// 1.修改支付卡状态(改为已用)
        /// 2.如果卡类型为赠品卡,修改用户表CardNum字段
        /// 3.如果卡类型为赠品卡,且推荐表中不存在重复,则向推荐表中插入记录
        /// 4.记录卡使用日志7
        /// </summary>
        /// <param name="accountID">用户ID</param>
        /// <param name="cardNum">卡号</param>
        /// <param name="cardType">卡类型</param>
        /// <param name="payMoney">卡的面值</param>
        /// <returns></returns>
        bool SetPayCardInfo(int accountID, string cardNum, int cardType, decimal payMoney);

        #region 20131224 赵喜合发过来的
        /// <summary>
        /// 获取支付动态
        /// </summary>
        /// <param name="comefrom">站点名称</param>
        ///<param name="citycode">城市id</param>
        /// <returns></returns>
        DataTable ZiFuStatusGet_sql(string comefrom, string citycode);
        /// <summary>
        /// 获取支付动态里的购物车里的产品
        /// </summary>
        /// <param name="shoppinggroup">购物车id</param>
        /// <returns></returns>
        DataTable ZiFuStatusShopCart(string shoppinggroup);
        /// <summary>
        /// 获取购买过用户的信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        DataTable OrderUserGet(string userid);
        /// <summary>
        /// 获取平台所有产品
        /// </summary>
        /// <param name="comefrom">平台来源</param>
        /// <returns></returns>
        DataTable ProductAll(string comefrom);

        /// <summary>
        /// 订单列表 
        /// </summary>
        /// <param name="comeFrom"></param>
        /// <param name="userid"></param>
        /// <param name="Nowpage"></param>
        /// <param name="PageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        DataTable SaleProductGet(int comeFrom, string userid, int Nowpage, int PageSize, ref int count);



        /// <summary>
        /// 获取未付款订单记录
        /// </summary>
        /// <param name="paymentid">订单id</param>
        /// <returns></returns>
        int SelectPaymentNopay(string paymentid);
        /// <summary>
        /// 获取用户未付款的订单数量
        /// </summary>
        /// <param name="comeFrom">站点来源</param>
        int OrderNoPayCount(int comeFrom, string userid);

        /// <summary>
        /// 获取单个产品信息
        /// </summary>
        /// <param name="pid">产品id</param>
        /// <returns></returns>
        DataTable ProductByIDGet(int pid);

        /// <summary>
        /// 获取未付款产品订单
        /// </summary>
        /// <param name="PaymentID"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        DataTable OrderProcductGet(string PaymentID, string userid);

        /// <summary>
        /// 获取产品评价
        /// </summary>
        /// <param name="nowPage">当前页码</param>
        /// <param name="pageSize">每页数目</param>
        /// <param name="count">总共数据</param>
        /// <param name="productid">产品id</param>
        /// <returns></returns>
        DataTable ProductEvaluationGet(int nowPage, int pageSize, ref int count, string productid);

        /// <summary>
        /// 获取产品订单
        /// </summary>
        /// <param name="PaymentID">订单编号</param>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        DataTable OrderProcductGet2(string PaymentID, string userid);

        /// <summary>
        /// 重新确认订单是删除旧订单
        /// </summary>
        /// <param name="paymentid">订单id</param>
        /// <returns></returns>
        bool DeletePayment(string paymentid);

        /// <summary>
        /// 首页支付用户动态
        /// </summary>
        /// <param name="schoolid">学校信息</param>
        /// <returns></returns>
        DataTable IndexPayLog_SQL(int schoolID, int cityid);

        #endregion
    }
}
