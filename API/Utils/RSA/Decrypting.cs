using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Utils.RSA
{
    public class Decrypting
    {
        public byte[] ConvertedData { get; private set; }
        public byte[] DecryptedData { get; private set; }
        public string OkDecryptedData { get; private set; }

        public string Decrypt(string encryptedText, string privateKey)
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            ConvertedData = Convert.FromBase64String(encryptedText);

            if (ConvertedData == null || ConvertedData.Length == 0)
                throw new ArgumentException("Data are empty", "encryptedText");

            provider.FromXmlString(privateKey);

            DecryptedData = provider.Decrypt(ConvertedData, false);
            OkDecryptedData = Encoding.UTF8.GetString(DecryptedData);
            return OkDecryptedData;
        }
    }
}
