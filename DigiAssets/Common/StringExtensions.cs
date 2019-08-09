using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace DigiAssets.Core.Common
{
    internal static class StringExtensions
    {
        public static bool IsHex(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            bool isHex = false;
            foreach (var c in str)
            {
                isHex = ((c >= '0' && c <= '9') ||
                         (c >= 'a' && c <= 'f') ||
                         (c >= 'A' && c <= 'F'));

                if (!isHex) return false;
            }
            return true;
        }

        public static byte[] ToBytes(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            if (str.IsHex())
            {
                return Enumerable.Range(0, str.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(str.Substring(x, 2), 16))
                     .ToArray();
            }
            return Encoding.UTF8.GetBytes(str);
        }

        public unsafe static SecureString ToSecureString(this string str)
        {
            SecureString secureString = new SecureString();
            foreach (char c in str)
            {
                secureString.AppendChar(c);
            }
            secureString.MakeReadOnly();
            str.Zero();
            return secureString;
        }

        public unsafe static void Zero(this string str)
        {
            fixed (char* ptr = str)
            {
                for (int i = 0; i < str.Length; ++i)
                {
                    ptr[i] = '0';
                }
            }
        }
    }
}
