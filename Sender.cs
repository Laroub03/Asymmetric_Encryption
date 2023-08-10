using System;
using System.Security.Cryptography;

namespace Asymmetric_Encryption
{
    class Sender
    {
        internal static void Send()
        {
            Console.Write("Enter public Exponent (format as F9-9A-98-6F-BC-9F): ");
            string exponentInput = Console.ReadLine();
            Console.Write("Enter Modulus (format as F9-9A-98-6F-BC-9F): ");
            string modulusInput = Console.ReadLine();

            string[] exponentBytesStr = exponentInput.Split('-');
            string[] modulusBytesStr = modulusInput.Split('-');

            byte[] exponentBytes = new byte[exponentBytesStr.Length];
            byte[] modulusBytes = new byte[modulusBytesStr.Length];

            for (int i = 0; i < exponentBytesStr.Length; i++)
            {
                exponentBytes[i] = Convert.ToByte(exponentBytesStr[i], 16);
                modulusBytes[i] = Convert.ToByte(modulusBytesStr[i], 16);
            }

            RSAParameters publicKeyParams = new RSAParameters
            {
                Exponent = exponentBytes,
                Modulus = modulusBytes
            };

            using (RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider())
            {
                rsaProvider.ImportParameters(publicKeyParams);
                Console.WriteLine();
                Console.Write("Enter message for encryption: ");
                string message = Console.ReadLine();

                byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
                byte[] encryptedBytes = rsaProvider.Encrypt(messageBytes, false);
                Console.WriteLine("Encrypted message: " + BitConverter.ToString(encryptedBytes));
            }
        }
    }
}
