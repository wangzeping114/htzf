using System;

namespace WS.HTZF.Utilities.Helper
{
    /// <summary>
    /// 随机生成密码类
    /// </summary>
    public static class PasswordGenterHelper
    {
        /// <summary>
        /// 生成密码默认长度为15
        /// </summary>
        /// <param name="length">15</param>
        /// <returns></returns>
        public static string GenerateRandomPassword(int length = 15)
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

    }
}