using System;

namespace WS.HTZF.Utilities.Helper
{
    /// <summary>
    /// 获取当前时间戳
    /// </summary>
    public static class DateTimeHelper
    {

        public static long Timestamp => DateTime.Now.GetTimestamp();
    }

    public static class DateTimeExtension
    {

        public static long GetTimestamp(this DateTime dt)
        {
            return (long)((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
        }
    }
}