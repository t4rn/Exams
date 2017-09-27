using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483.Services
{
    public class Hashers
    {
        public static byte[] HashByAlgName(string fileName, string hashAlgorithm)
        {
            HashAlgorithm hasher = HashAlgorithm.Create(hashAlgorithm);
            var fileBytes = File.ReadAllBytes(fileName);

            var outputBuffer = new byte[fileBytes.Length];

            hasher.TransformBlock(fileBytes, 0, fileBytes.Length, outputBuffer, 0);

            return hasher.ComputeHash(fileBytes);
            return hasher.Hash;
        }

        public static string HashAlgorithmBySHA1(string input)
        {
            byte[] sha1byte = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(input));

            var sb = new StringBuilder();
            foreach (byte b in sha1byte)
            {
                sb.Append(b.ToString("X2"));
            }
            string sha1hash = sb.ToString();

            return sha1hash;
        }
    }
}
