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
        public static byte[] HashByAlgName(string fileName, string algName)
        {
            HashAlgorithm hasher = HashAlgorithm.Create(algName);
            var fileBytes = File.ReadAllBytes(fileName);

            var outputBuffer = new byte[fileBytes.Length];
            hasher.TransformBlock(fileBytes, 0, fileBytes.Length, outputBuffer, 0);
            //hasher.TransformFinalBlock(fileBytes, fileBytes.Length - 1, fileBytes.Length);
            return outputBuffer;

            hasher.ComputeHash(fileBytes);
            return hasher.Hash;
        }
    }
}
