using System;
using System.Collections.Generic;
using System.Linq;

namespace SmsControl.Extensions
{
    public static class BytesExtensions
    {
        /// <summary>
        /// Converts an enumerable of bytes to a little-endian integer
        /// </summary>
        public static int ToLeInt(this IEnumerable<byte> bytes)
        {
            return bytes.ToArray().ToLeInt();
        }

        /// <summary>
        /// Converts a byte array to a little-endian integer
        /// Returns 0 for null, empty, or arrays longer than 4 bytes
        /// </summary>
        public static int ToLeInt(this byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0 || bytes.Length > 4) 
                return 0;

            if (bytes.Length <= 3)
            {
                byte[] paddedBytes = new byte[4];
                Array.Copy(bytes, paddedBytes, bytes.Length);
                return BitConverter.ToInt32(paddedBytes, 0);
            }

            return BitConverter.ToInt32(bytes, 0);
        }
    }
}
