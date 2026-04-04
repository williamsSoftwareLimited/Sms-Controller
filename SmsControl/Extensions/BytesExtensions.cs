using System;
using System.Collections.Generic;

namespace SmsControl.Extensions
{
    public static class BytesExtensions
    {
        public static int ToLeInt(this IEnumerable<byte> bytes)
        {
            return bytes.ToLeInt();
        }
        // this quietly fails fo more then 4 bytes
        public static int ToLeInt(this byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0 || bytes.Length > 4) return 0;
            if (bytes.Length <= 3)
            {
                byte[] smallBytes = new byte[4];
                for (int i = 0; i < bytes.Length; i++)
                {
                    if (i > bytes.Length - 1)
                    {
                        smallBytes[i] = 0;
                    }
                    else
                    {
                        smallBytes[i] = bytes[i];
                    }
                }
                return BitConverter.ToInt32(smallBytes, 0);
            }

            return BitConverter.ToInt32(bytes, 0);
        }
    }
}
