using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using Null.MusicDownloader.Public.Library;

namespace Null.MusicDownloader.Source.Netease.ReqEncode
{
    public static class EncConvert
    {
        public static string RandomStringSource = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static string GenRandomString(int length)
        {
            StringBuilder sb = new StringBuilder();
            return new string(
                Enumerable.Range(0, length)
                .Select((v) => RandomStringSource[new Random().Next(0, length)])
                .ToArray());
        }

        public static string DefaultAesKey = "0CoJUm6Qyw8W8jud";

        public static Aes GenerateAes(string key, string iv)
        {
            Aes aes = Aes.Create();

            byte[] ivArray = Encoding.UTF8.GetBytes(iv);
            byte[] keyArray = Encoding.UTF8.GetBytes(key);

            byte[] newKeyArray = new byte[16];
            Array.Copy(keyArray, newKeyArray, keyArray.Length > newKeyArray.Length ? newKeyArray.Length : keyArray.Length);

            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            aes.IV = ivArray;
            aes.Key = newKeyArray;

            return aes;
        }
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="text">密文</param>
        /// <param name="password">密钥</param>
        /// <param name="iv">向量</param>
        /// <returns></returns>
        public static string AesDecrypt(string text, string password, string iv = "0102030405060708")
        {
            Aes aes = GenerateAes(password, iv);
            byte[] encryptedData = Convert.FromBase64String(text);

            ICryptoTransform iCryptoTransform = aes.CreateDecryptor();
            byte[] targetBytes = iCryptoTransform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            return Encoding.UTF8.GetString(targetBytes);
        }
        public static string AesEncrypt(string src, string key, string iv = "0102030405060708")
        {
            Aes aes = GenerateAes(key, iv);
            byte[] srcArray = Encoding.UTF8.GetBytes(src);

            ICryptoTransform cryptoTransform = aes.CreateEncryptor();
            byte[] result = cryptoTransform.TransformFinalBlock(srcArray, 0, srcArray.Length);
            return Convert.ToBase64String(result);
        }
        public static string RsaEncrypt(string text, string pubKey, string modulus)
        {
            string newTxt = new string(text.Reverse().ToArray());
            Encoding encoder = Encoding.UTF8;
            BigInteger biText = new BigInteger(encoder.GetBytes(newTxt), true);
            BigInteger biEx = new BigInteger(encoder.GetBytes(pubKey), true);
            BigInteger biMod = new BigInteger(encoder.GetBytes(modulus), true);
            BigInteger result = BigInteger.ModPow(biText, biEx, biMod);
            return result.ToString("X").PadLeft(256, '0');
        }
        public static IList<KeyValuePair<string, string>> GenRequestQuery(string src, string aesKey)
        {
            string encText, encSecKey;
            encText = AesEncrypt(src, aesKey);
            encText = AesEncrypt(encText, "i1kBg8rcr5GlADvW");
            encSecKey = "be959d28fa29ff54b0f784aa5c0a3f3de6ec1648b8d87035bac216d44121ceac78d98188a1612cb8b2db582852412d1f00c1a0d39e7cdddc78fb95567f6f856d3a601d9bf12c4639b3556d5c0f7bb343dbb04e1341810bdbb8079778f27e5b2cb01d85edf1a44fe22230fe658ed85c8d48e0f4783017b5cbe100c9c946f83428";
            return new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("params", encText),
                new KeyValuePair<string, string>("encText", encSecKey)
            };
        }
    }
}
