using WS.HTZF.Core.Exceptions;
using WS.HTZF.Utilities.Helper;

namespace WS.HTZF.Application.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class PasswordHandler : IPasswordHandler
    {
        /// <summary>
        /// 生成加密密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string GenerateEncryptPassword(string pwd)
           => SecurityHelper.MD5Hash(SecurityHelper.MD5Hash(pwd.Trim().ToUpper()));
            
        /// <summary>
        /// 验证密码是否正确
        /// </summary>
        /// <param name="encryptPassword">加密密码</param>
        /// <param name="providedPassword">提供的密码</param>
        /// <returns></returns>
        public bool VerifyHashedPassword(string encryptPassword, string providedPassword)
        {
            var generatePwd = GenerateEncryptPassword(providedPassword);
            return encryptPassword.Equals(generatePwd) ? true : false;
        }
    }
}
