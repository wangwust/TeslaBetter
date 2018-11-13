using System;
using System.Security.Cryptography;

namespace Tesla.Utils
{
    /// <summary>
    /// Random帮助类
    /// </summary>
    public static class RandomHelper
    {
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <returns></returns>
        public static Random GetInstance()
        {
            return new Random(GetRandomSeed());
        }

        /// <summary>
        /// 获取随机种子
        /// </summary>
        /// <returns></returns>
        public static int GetRandomSeed()
        {
            byte[] randomBytes = new byte[4];
            RNGCryptoServiceProvider rngServiceProvider = new RNGCryptoServiceProvider();
            rngServiceProvider.GetBytes(randomBytes);
            int result = BitConverter.ToInt32(randomBytes, 0);
            return result;
        }
    }
}
