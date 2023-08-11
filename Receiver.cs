using System;
using System.Security.Cryptography;
using System.Text;

namespace Asymmetric_Encryption
{
    internal class Receiver
    {
        private readonly IKeyContainer _keyContainer;
        private readonly IDecryptor _decryptor;

        public Receiver(IKeyContainer keyContainer, IDecryptor decryptor)
        {
            _keyContainer = keyContainer;
            _decryptor = decryptor;
        }

        public void Run()
        {
            // Create an RSA object with an associated key that is stored in a key container
            RSACryptoServiceProvider rsa = _keyContainer.GetRSA();

            // Display public Exponent and Modulus
            RSAParameters rsaParams = rsa.ExportParameters(false);
            Console.WriteLine("Public Exponent: {0}", BitConverter.ToString(rsaParams.Exponent));
            Console.WriteLine("Modulus: {0}", BitConverter.ToString(rsaParams.Modulus));

            // User enters encrypted data
            Console.Write("Enter encrypted data: ");
            string encryptedData = Console.ReadLine();

            // Decrypt data using private key
            string decryptedData = _decryptor.DecryptData(rsa, encryptedData);
            Console.WriteLine("Decrypted data: {0}", decryptedData);
        }
    }
    public interface IDecryptor
    {
        string DecryptData(RSACryptoServiceProvider rsa, string encryptedData);
    }

    public class Decryptor : IDecryptor
    {
        private readonly IDataConverter _dataConverter;

        public Decryptor(IDataConverter dataConverter)
        {
            _dataConverter = dataConverter;
        }

        public string DecryptData(RSACryptoServiceProvider rsa, string encryptedData)
        {
            byte[] encryptedBytes = _dataConverter.ConvertToByteArray(encryptedData);
            byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
