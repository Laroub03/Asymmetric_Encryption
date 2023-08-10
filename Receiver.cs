using System;
using System.Security.Cryptography;

namespace Asymmetric_Encryption
{
    class Receiver
    {
        internal static void Receive()
        {
            using (RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider())
            {
                Console.WriteLine("Public Exponent: " + BitConverter.ToString(rsaProvider.ExportParameters(false).Exponent));
                Console.WriteLine("Modulus: " + BitConverter.ToString(rsaProvider.ExportParameters(false).Modulus));

                Console.WriteLine();

                Console.Write("Enter encrypted data (format as F9-9A-98-6F-BC-9F): ");
                string encryptedInput = Console.ReadLine();

                string[] encryptedBytesStr = encryptedInput.Split('-');
                byte[] encryptedBytes = new byte[encryptedBytesStr.Length];

                for (int i = 0; i < encryptedBytesStr.Length; i++)
                {
                    encryptedBytes[i] = Convert.ToByte(encryptedBytesStr[i], 16);
                }

                byte[] decryptedBytes = rsaProvider.Decrypt(encryptedBytes, false);
                string decryptedText = System.Text.Encoding.UTF8.GetString(decryptedBytes);

                Console.WriteLine("Decrypted message: " + decryptedText);
            }
        }
    }
}
