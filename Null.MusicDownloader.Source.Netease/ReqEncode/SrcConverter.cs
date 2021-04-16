using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Null.MusicDownloader.Source.Netease.ReqEncode
{
    public class SrcConverter
    {
        int[] ZERO_ARRAY;
        BigInt bigZero = new BigInt(1) { digits = new int[] { 0 } };
        BigInt bigOne = new BigInt(1) { digits = new int[] { 1 } };

        public void empty()
        {
            
        }

        public static string RandomStringSource = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public string a(int len)
        {
            StringBuilder sb = new StringBuilder();
            return new string(
                Enumerable.Range(0, len)
                .Select((v) => RandomStringSource[new Random().Next(0, len)])
                .ToArray());
        }
        public string b(string src, string key)
        {
            Aes Encryptor = Aes.Create();
            Encryptor.Mode = CipherMode.CBC;
            Encryptor.Key = Encoding.UTF8.GetBytes(key);
            Encryptor.IV = Encoding.UTF8.GetBytes("0102030405060708");

            byte[] srcArray = Encoding.UTF8.GetBytes(src);

            ICryptoTransform cryptoTransform = Encryptor.CreateEncryptor();
            cryptoTransform.TransformFinalBlock(srcArray, 0, srcArray.Length);

            return Convert.ToBase64String(srcArray);
        }
        public void setMaxDigis(int len)
        {
            this.ZERO_ARRAY = new int[len];
        }
        public static int biHighIndex(BigInt a)
        {
            int b;
            for (b = a.digits.Length - 1; b > 0 && 0 == a.digits[b];)
                --b;
            return b;
        }
        public static BigInt biFromHex(string a)
        {
            BigInt b = new BigInt(10);
            int d, e;
            //BigInt b = new BigInt();
            int c = a.Length;
            for (d = c, e = 0; d > 0; d -= 4, ++e)
                b.digits[e] = hexToDigit(a.Substring(Math.Max(d - 4, 0), Math.Min(d, 4)));
            return b;
        }
        public static int hexToDigit(string a)
        {
            int b = 0;
            int c = Math.Min(a.Length, 4);
            for (int d = 0; c > d; ++d)
            {
                b <<= 4;
                b |= charToHex(a[d]);
            }

            return b;
        }
        public static int charToHex(int a)
        {
            int h, b = 48, c = b + 9, d = 97, e = d + 25, f = 65, g = 90;
            return h = a >= b && c >= a ? a - b : a >= f && g >= a ? 10 + a - f : a >= d && e >= a ? 10 + a - d : 0;
        }
        public class BigInt
        {
            public BigInt(int len)
            {
                digits = new int[len];
            }
            public int[] digits;
            public bool isNeg = false;
        }
        class RSAKeyPair
        {
            public RSAKeyPair(string a, string b, string c)
            {
                this.e = biFromHex(a);
                this.d = biFromHex(b);
                this.m = biFromHex(c);
                this.chunkSize = 2 * biHighIndex(this.m);
                this.radix = 16;
            }
            BigInt e, d, m;
            public int chunkSize;
            public int radix;
        }
    }
}
