using System.Collections.Generic;

namespace WS.HTZF.Application.Authentication
{
    /// <summary>
    /// 令牌
    /// </summary>
    public class WebToken
    {
        /// <summary>
        /// 连接令牌
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 刷新的令牌
        /// </summary>
        public string RefreshToken { get; set; }
        /// <summary>
        /// 失效时间
        /// </summary>
        public long Expires { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 扩展声明
        /// </summary>
        public IDictionary<string,string> Claims { get; set; }
    }
}
