namespace WS.HTZF.Application.Authentication
{
    /// <summary>
    /// Jwt配置
    /// </summary>
    public class JwtOptions
    {
        /// <summary>
        /// 密钥
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        public int ExpiryMinutes { get; set; }
        /// <summary>
        /// 发行人
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ValidateLifetime { get; set; }
        /// <summary>
        ///验证生命周期 
        /// </summary>
        public bool ValiddateAudience { get; set; }
        /// <summary>
        /// 受众人
        /// </summary>
        public string ValidAudience { get; set; }
    }
}
