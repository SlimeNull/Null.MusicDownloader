using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Public.Library
{
    public static class Helper
    {
        public static T[] PadLeft<T>(this T[] self, int length, T value = default)
        {
            int oldLen = self.Length;
            int addLen = length - oldLen;
            int newLen = oldLen + addLen;
            T[] newArray = new T[newLen];
            if (addLen > 0)
            {
                Array.Fill(newArray, value, 0, addLen);
                Array.Copy(self, 0, newArray, addLen, oldLen);
            }
            else
            {
                Array.Copy(self, 0 - addLen, newArray, 0, newLen);
            }
            return newArray;
        }
        public static T[] PadRight<T>(this T[] self, int length, T value = default)
        {
            int oldLen = self.Length;
            int addLen = length - oldLen;
            int newLen = oldLen + addLen;
            T[] newArray = new T[newLen];
            if (addLen > 0)
            {
                Array.Copy(self, 0, newArray, 0, oldLen);
                Array.Fill(newArray, value, oldLen, addLen);
            }
            else
            {
                Array.Copy(self, 0, newArray, 0, newLen);
            }
            return newArray;
        }
    }
}
