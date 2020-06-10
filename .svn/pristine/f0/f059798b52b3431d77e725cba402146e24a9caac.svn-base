using System;
using System.IO;

namespace WS.HTZF.Utilities.Extensions
{
    public static class StreamExtension
    {
        public static byte[] ReadAllBytes(this Stream stream)
        {
            var fBytes = new Byte[stream.Length];
            stream.Read(fBytes, 0, fBytes.Length);
            return fBytes;
        }
    }
}
