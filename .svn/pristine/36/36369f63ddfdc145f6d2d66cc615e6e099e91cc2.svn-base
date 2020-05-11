using System.Collections.Generic;

namespace WS.HTZF.Application.Authentication
{
    /// <summary>
    ///   
    /// </summary>
    public interface IJwtHandler
    {
        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="expiryMinutes"></param>
        /// <param name="claims"></param>
        /// <returns></returns>
        WebToken CreateToken(string userId,IDictionary<string, string> claims = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        WebTokenPayload GetTokenPayload(string accessToken);

        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        WebToken RefreshToken(string userId);

    }
}
