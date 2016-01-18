using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLib.Model;

namespace LogicSrvInterfaceLib
{
    /// <summary>
    /// 第三方授权接口
    /// </summary>
    public interface IThirdAuthorization
    {
        
        /// <summary>
        /// 第三方授权登录
        /// </summary>
        /// <param name="loginType">授权类型</param>
        /// <param name="openId">授权成功id</param>
        /// <returns>返回用户ID 返回值&lt;=0时未绑定账号</returns>
        int ThirdAuthorizationLogin(ThirdAuthorizationReturnType.BoundType loginType, string openId);

        /// <summary>
        /// 绑定账号
        /// </summary>
        /// <param name="boundType">绑定内容类型</param>
        /// <param name="openId"></param>
        /// <param name="accessToken">授权令牌</param>
        /// <param name="userId"></param>
        /// <param name="nickName">昵称</param>
        /// <returns></returns>
        ThirdAuthorizationReturnType.BoundResult AuthorizationBound(ThirdAuthorizationReturnType.BoundType boundType, string openId, int userId, string accessToken, string nickName);

        /// <summary>
        /// 获取指定用户id 的第三方账号绑定记录
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        List<ThirdAccountBind> GetThirderAccountBinds(int userId);

        /// <summary>
        /// 删除指定用户id 、指定第三方绑定记录id 第三方账号绑定记录
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteAccountBindById(int userId, long id);

        /// <summary>
        /// 激活绑定
        /// </summary>
        /// <param name="id">绑定记录id</param>
        /// <returns></returns>
        bool Activation(long id);

        /// <summary>
        /// 删除指定用户id 、绑定类型、指定第三方授权id 第三方账号绑定记录
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="boundType"></param>
        /// <param name="identification"></param>
        /// <returns></returns>
        bool DeleteAccountBind(int userId, ThirdAuthorizationReturnType.BoundType boundType, string identification);

        /// <summary>
        /// 检查是否可以绑定该账号 
        /// </summary>
        /// <param name="boundType">绑定账号类型</param>
        /// <param name="identification">账号唯一标识</param>
        /// <param name="userId">绑定平台用户id</param>
        /// <returns></returns>
        ThirdAuthorizationReturnType.BoundCheck CheckBind(ThirdAuthorizationReturnType.BoundType boundType, string identification, int userId);
    }
}
