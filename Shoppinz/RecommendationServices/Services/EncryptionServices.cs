using System.Security.Cryptography;
using System.Text;

namespace AuthAPI.Services
{
    public class EncryptionServices
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("b14ca5898a4e4133bbce2ea2315a1916"); // 16, 24, or 32 bytes key for AES-128, AES-192, or AES-256
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("testtesttesttest"); // 16 bytes IV for AES

        //Simple Non Secure Representational/Academic level Encryptor
        public static string EncryptPass(string Password, int shift)
        {
            char[] chars = Password.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char letter = chars[i];

                if (char.IsLetter(letter))
                {
                    char offset = char.IsUpper(letter) ? 'A' : 'a';
                    letter = (char)((letter - offset + shift) % 26 + offset);
                }
                chars[i] = letter;
            }
            return new string(chars);
        }


        //AES Industrial Level Encryptor
        public static string EncryptPassword(string password)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] encryptedBytes = null;
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(password);
                        }
                        encryptedBytes = msEncrypt.ToArray();
                    }
                }

                return Convert.ToBase64String(encryptedBytes);
            }
        }
    }
}
