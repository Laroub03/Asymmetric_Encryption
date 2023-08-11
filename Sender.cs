using System;
using System.Security.Cryptography;
using System.Text;

namespace Asymmetric_Encryption
{
    internal class Sender
    {
        private readonly IPublicKeyImporter _publicKeyImporter;
        private readonly IEncryptor _encryptor;

        public Sender(IPublicKeyImporter publicKeyImporter, IEncryptor encryptor)
        {
            _publicKeyImporter = publicKeyImporter;
            _encryptor = encryptor;
        }

        public void Run()
        {
            // User enters public Exponent and Modulus
            Console.Write("Enter public Exponent: ");
            string exponentString = Console.ReadLine();
            Console.Write("Enter Modulus: ");
            string modulusString = Console.ReadLine();

            // Import public key
            RSACryptoServiceProvider rsa = _publicKeyImporter.ImportPublicKey(exponentString, modulusString);

            // User enters message to encrypt
            Console.Write("Enter message to encrypt: ");
            string message = Console.ReadLine();

            // Encrypt message using public key
            string encryptedData = _encryptor.EncryptData(rsa, message);
            Console.WriteLine("Encrypted data: {0}", encryptedData);
        }
    }

    public interface IEncryptor
    {
        string EncryptData(RSACryptoServiceProvider rsa, string message);
    }

    public class Encryptor : IEncryptor
    {
        public string EncryptData(RSACryptoServiceProvider rsa, string message)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] encryptedBytes = rsa.Encrypt(messageBytes, false);
            return BitConverter.ToString(encryptedBytes);
        }
    }
}
