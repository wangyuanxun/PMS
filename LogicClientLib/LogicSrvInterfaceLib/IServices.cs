namespace LogicSrvInterfaceLib
{
    /// <summary>
    /// 服务汇总
    /// </summary>
    public interface IServices
    {
        /// <summary>
        /// 支付服务
        /// </summary>
        IPayService PayService { get; }
        /// <summary>
        /// 日志服务
        /// </summary>
        ILogService LogService { get; }
        /// <summary>
        /// 用户数据服务
        /// </summary>
        IUserService UserService { get; }
        /// <summary>
        /// 站点数据服务
        /// </summary>
        ISiteService SiteService { get; }
        /// <summary>
        /// 社会安全平台服务
        /// </summary>
        ISocietySafeEduService SocietyService { get; }
        /// <summary>
        /// 管理服务
        /// </summary>
        IMangeService ManageService { get; }

        /// <summary>
        /// 积分服务
        /// </summary>
        IIntegralService IntegralService { get; }

        /// <summary>
        /// 第三方授权
        /// </summary>
        IThirdAuthorization ThirdAuthorization { get; }
    }
}
