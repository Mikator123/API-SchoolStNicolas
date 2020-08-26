using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Utils.RSA
{
    public enum RSAKeySize
    {
        Key128 = 128,
        Key256 = 256,
        Key512 = 512,
        Key1024 = 1024,
        Key2048 = 2048,
        Key4096 = 4096,
        Key8192 = 8192,
        Key16384 = 16384,
        Key32768 = 32768
    }


    public class KeyGenerator
    {
        public string PublicKey { get; private set; }
        public string PrivateKey { get; private set; }

        public void GenerateKeys(RSAKeySize rsaKeySize)
        {
            using (var provider = new RSACryptoServiceProvider((int)rsaKeySize))
            {
                PublicKey = provider.ToXmlString(false);
                PrivateKey = provider.ToXmlString(true);
            }
        }
    }
}
