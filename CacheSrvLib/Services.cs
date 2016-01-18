//------------------------------------------------------------------------------
//Description: 缓存服务总接口实现
//Author: WANGYX
//Date: 2015/11/20 19:19:07
//------------------------------------------------------------------------------
using System;
using CacheSrvInterfaceLib;
using CommonLib;

namespace CacheSrvLib
{
    public class Services : MarshalByRefObject, IServices
    {
        private static readonly ServiceLog SLog;
        public static ServiceLog Log
        {
            get { return SLog; }
        }
        static Services()
        {
            SLog = new ServiceLog("缓存服务", "缓存服务");
        }
        
        #region 服务实现实例
        /// <summary>
        /// Sys_Button表缓存接口
        /// </summary>
        public ISys_ButtonService Sys_ButtonService
        {
            get { return CacheSrvLib.Sys_ButtonService.Instance; }
        } 
        /// <summary>
        /// Sys_Menu表缓存接口
        /// </summary>
        public ISys_MenuService Sys_MenuService
        {
            get { return CacheSrvLib.Sys_MenuService.Instance; }
        } 
        /// <summary>
        /// Sys_MenuButton表缓存接口
        /// </summary>
        public ISys_MenuButtonService Sys_MenuButtonService
        {
            get { return CacheSrvLib.Sys_MenuButtonService.Instance; }
        }  
        /// <summary>
        /// User表缓存接口
        /// </summary>
        public IUserService UserService
        {
            get { return CacheSrvLib.UserService.Instance; }
        } 
        #endregion
        
        #region 自定义服务接口
        
        #endregion
    }
}