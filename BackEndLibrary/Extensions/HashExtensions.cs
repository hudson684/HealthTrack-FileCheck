using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Extensions
{
    public static class HashExtensions
    {
        public static byte[] ToHash(this string toConvert)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(toConvert);
            return md5.ComputeHash(inputBytes);
        }
    }
}
