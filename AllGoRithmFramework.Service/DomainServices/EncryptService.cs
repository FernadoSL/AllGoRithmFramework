using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AllGoRithmFramework.Service.DomainServices
{
    public class EncryptService
    {
        private string Key { get; set; }

        private string Iv { get; set; }

        public EncryptService(string key, string iv)
        {
            this.Key = key;
            this.Iv = iv;
        }

        public string Encrypt(string content)
        {
            string result;

            using (var aes = Aes.Create())
            {
                aes.Key = ASCIIEncoding.ASCII.GetBytes(this. Key);
                aes.IV = ASCIIEncoding.ASCII.GetBytes(this.Iv);

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(content);
                            }

                            var iv = aes.IV;

                            var decryptedContent = msEncrypt.ToArray();

                            byte[] byteResult = new byte[iv.Length + decryptedContent.Length];

                            Buffer.BlockCopy(iv, 0, byteResult, 0, iv.Length);
                            Buffer.BlockCopy(decryptedContent, 0, byteResult, iv.Length, decryptedContent.Length);

                            result = Convert.ToBase64String(byteResult);
                        }
                    }
                }
            }
            return result;
        }
    }
}
