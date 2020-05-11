using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WS.HTZF.Core.Exceptions;
using WS.HTZF.Utilities.Helper;

namespace WS.HTZF.Application.Authentication
{
    /// <summary>
    /// 
    /// </summary>
    public class JwtHandler : IJwtHandler
    {

        private static readonly ISet<string> DefaultClaims = new HashSet<string>
        {
            JwtRegisteredClaimNames.Sub,
            JwtRegisteredClaimNames.UniqueName,
            JwtRegisteredClaimNames.Jti,
            JwtRegisteredClaimNames.Iat,
            ClaimTypes.Role,
        };
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private readonly SigningCredentials _signingCredentials;
        private readonly TokenValidationParameters _tokenValidationParameters;
        /// <summary>
        /// 
        /// </summary>
        public JwtHandler()
        {
            var issuerSingingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            _signingCredentials = new SigningCredentials(issuerSingingKey, SecurityAlgorithms.HmacSha256);
            _tokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = issuerSingingKey,
                ValidIssuer = _options.Issuer,
                ValidateAudience = _options.ValiddateAudience,
                ValidateLifetime = _options.ValidateLifetime
            };
        }
        /// <summary>
        /// 服务器上JWT配置
        /// </summary>
        private static JwtOptions _options = new JwtOptions()
        {
            //秘钥
            SecretKey = "F7peYX7825YkwztCxgjzZGF4yExvu4TK4mN8DLUtsVHMpnGa3V5jabYjFhGg",
            //JWT颁发者
            Issuer = "WSHTZF",
            //验证生命周期
            ValidateLifetime = true,
            //到期时间 以分钟为准 527040 相当于1年
            ExpiryMinutes = 527040,
            //有效日期受众
            ValiddateAudience = false

        };
        /// <summary>
        /// 创建令牌
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="claims">省份信息</param>
        /// <returns></returns>
        public WebToken CreateToken(string userId, IDictionary<string, string> claims = null)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new TokenFailException("声明不能为空");
            }
            var now = DateTime.Now;
            var jwtClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.GetTimestamp().ToString()),
            };

            var customClaims = claims?.Select(claim => new Claim(claim.Key, claim.Value)).ToArray()
                               ?? Array.Empty<Claim>();
            jwtClaims.AddRange(customClaims);

            var expires = now.AddMinutes(_options.ExpiryMinutes);
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                claims: jwtClaims,
                notBefore: now,
                expires: expires,
                signingCredentials: _signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new WebToken
            {
                AccessToken = token,
                RefreshToken = string.Empty,
                Expires = expires.GetTimestamp(),
                UserId = userId,
                Claims = customClaims.ToDictionary(c => c.Type, c => c.Value)
            };
        }
        /// <summary>
        /// 根据连接令牌获取实体信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public WebTokenPayload GetTokenPayload(string accessToken)
        {
            SecurityToken validatedSecurityToken;

            _jwtSecurityTokenHandler.ValidateToken(accessToken, _tokenValidationParameters,
               out validatedSecurityToken);
            if (!(validatedSecurityToken is JwtSecurityToken))
            {
                throw new TokenFailException($"无效的AccessToken");
            }
            var jwt = (JwtSecurityToken)validatedSecurityToken;
            return new WebTokenPayload
            {
                Subject = jwt.Subject,
                Role = jwt.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Role)?.Value,
                Expires = jwt.ValidTo.GetTimestamp(),
                Claims = jwt.Claims.Where(x => !DefaultClaims.Contains(x.Type))
                    .ToDictionary(k => k.Type, v => v.Value)
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public WebToken RefreshToken(string userId)
        {
            throw new NotImplementException(nameof(RefreshToken));
        }
    }
}
