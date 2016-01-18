//------------------------------------------------------------------------------
//Description: 逻辑服务总接口
//Author: WANGYX
//Date: 2015/11/20 19:19:07
//------------------------------------------------------------------------------

namespace LogicSrvInterfaceLib
{
    public interface IServices
    {
        #region 服务实现实例
        /// <summary>
        /// Sys_Button表缓存接口
        /// </summary>
        ISys_ButtonService Sys_ButtonService { get; }
        /// <summary>
        /// Sys_Menu表缓存接口
        /// </summary>
        ISys_MenuService Sys_MenuService { get; }
        /// <summary>
        /// Sys_MenuButton表缓存接口
        /// </summary>
        ISys_MenuButtonService Sys_MenuButtonService { get; }
        /// <summary>
        /// User表缓存接口
        /// </summary>
        IUserService UserService { get; }
        #endregion
        
        #region 自定义服务接口
        
        #endregion
    }
}