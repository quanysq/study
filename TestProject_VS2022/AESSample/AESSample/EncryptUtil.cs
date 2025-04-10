using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AESSample
{
    /// <summary>
    /// AES 加解密封闭类
    /// </summary>
    public class EncryptUtil
    {
        private static byte[] _commonKey = new byte[0];
        private static byte[] _commonIv = new byte[0];
        private static string keyBody = "WQbdG5pvDFaaZKCi4td3Jrx2OvPlIQgc";

        /// <summary>
        /// 初始化密钥和变量
        /// </summary>
        private static void InitAES(string key)
        {
            string commonKey = "";
            string commonIv = "";

            commonKey = string.IsNullOrWhiteSpace(key) ? keyBody : key;
            commonKey = commonKey.Trim();
            commonIv = commonKey.Length >= 16 ? commonKey.Substring(16, 16) : commonKey;

            if (commonIv.Length != 16 || commonKey.Length != 32)
            {
                throw new Exception("密钥长度不正确.");
            }
            _commonKey = Encoding.UTF8.GetBytes(commonKey);
            _commonIv = Encoding.UTF8.GetBytes(commonIv);
        }

        /// <summary>
        /// 使用 AES 加密数据
        /// </summary>
        /// <param name="data">待加密的数据</param>
        /// <returns></returns>
        public static string AESEncode(string data, string keyStr)
        {
            InitAES(keyStr);
            byte[] valueByte = Encoding.UTF8.GetBytes(data);

            using (Aes aes = Aes.Create())
            {
                aes.Key = _commonKey;
                aes.IV = _commonIv; 
                aes.Mode = CipherMode.CBC; // 选择CBC模式
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cryptoTransform = aes.CreateEncryptor();
                byte[] resultArray = cryptoTransform.TransformFinalBlock(valueByte, 0, valueByte.Length);
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
        }

        /// <summary>
        /// 解密使用 AES 加密后的数据
        /// </summary>
        /// <param name="data">使用 AES 加密后的密文数据</param>
        /// <returns></returns>
        public static string AESDecode(string data, string keyStr)
        {
            if (string.IsNullOrEmpty(data))
            {
                return "Please enter data!";
            }

            InitAES(keyStr);
            byte[] valueByte = Convert.FromBase64String(data);

            using (Aes aes = Aes.Create())
            {
                aes.Key = _commonKey;
                aes.IV = _commonIv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cryptoTransform = aes.CreateDecryptor();
                byte[] resultArray = cryptoTransform.TransformFinalBlock(valueByte, 0, valueByte.Length);
                return Encoding.UTF8.GetString(resultArray);
            }
        }
    }
}
