using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace WS.HTZF.Utilities.Helper
{
    /// <summary>
    /// 随机生成账号
    /// </summary>
    public static class NumberGenterHelper
    {

        static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// 通过Guid  获取随机种子
        /// </summary>
        /// <returns></returns>
        static int GetGuidSeed()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iSeed = BitConverter.ToInt32(buffer, 0);
            return iSeed;
        }

        /// <summary>
        /// 获取绝对随机数
        /// </summary>
        /// <returns></returns>
        public static string GetRandOnlyId()
        {
            var timeStamp =
                DateTimeHelper
                    .Timestamp; // (DateTime.Now.ToUniversalTime().Ticks - 13560192000000000) / 10000000; // 减少时间戳位数形成新的短时间戳
            var beginRand = IntToi64(new Random(GetRandomSeed()).Next(0, 999999)); // 基于计算机硬件的随机因子产生随机数
            var endRand = IntToi64(new Random(GetGuidSeed()).Next(0, 999999)); // 基于Guid随机因子产生的的随机数
            var MiddleRand = IntToi64(timeStamp);
            var randString = beginRand + MiddleRand + endRand;
            return randString;
        }

        /// <summary>
        /// 十进制转64进制
        /// </summary>
        /// <param name="xx"></param>
        /// <returns></returns>
        static string IntToi64(long xx)
        {
            string retStr = "";
            while (xx >= 1)
            {
                int index = Convert.ToInt16(xx - (xx / 64) * 64);
                retStr = Base64Code[index] + retStr;
                xx = xx / 64;
            }

            return retStr;
        }

        /// <summary>
        /// 64 位转化参数
        /// </summary>
        private static Dictionary<int, string> Base64Code = new Dictionary<int, string>()
        {
            {0, "A"}, {1, "B"}, {2, "C"}, {3, "D"}, {4, "E"}, {5, "F"}, {6, "G"}, {7, "H"}, {8, "I"}, {9, "J"},
            {10, "K"}, {11, "L"}, {12, "M"}, {13, "N"}, {14, "O"}, {15, "P"}, {16, "Q"}, {17, "R"}, {18, "S"},
            {19, "T"},
            {20, "U"}, {21, "V"}, {22, "W"}, {23, "X"}, {24, "Y"}, {25, "Z"}, {26, "a"}, {27, "b"}, {28, "d"},
            {29, "c"},
            {30, "e"}, {31, "f"}, {32, "g"}, {33, "h"}, {34, "i"}, {35, "j"}, {36, "k"}, {37, "l"}, {38, "m"},
            {39, "n"},
            {40, "o"}, {41, "p"}, {42, "q"}, {43, "r"}, {44, "s"}, {45, "t"}, {46, "u"}, {47, "v"}, {48, "w"},
            {49, "x"},
            {50, "y"}, {51, "z"}, {52, "0"}, {53, "1"}, {54, "2"}, {55, "3"}, {56, "4"}, {57, "5"}, {58, "6"},
            {59, "7"},
            {60, "8"}, {61, "9"}, {62, "x"}, {63, "y"},
        };
    }
}