using System.Security.Cryptography;

namespace HealthTrack_FileCheck.Services
{
    public class HashMaker
    {

        /// <summary>
        /// Temporary service that turns strings into hash for hashmap. 
        /// turn into extension if time allows.
        /// </summary>
        /// <returns></returns>
        public byte[] GetHash(string toConvert)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(toConvert);
            return md5.ComputeHash(inputBytes);
        }
    }
}
