using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Asymmetric_Encryption
{
     // Class importing an public key using RSA
    internal class PublicKeyImporter : IPublicKeyImporter
    {
        private readonly IDataConverter _dataConverter;

        public PublicKeyImporter(IDataConverter dataConverter)
        {
            _dataConverter = dataConverter;
        }

        public RSACryptoServiceProvider ImportPublicKey(string exponentString, string modulusString)
        {
            // Convert entered Exponent and Modulus into byte arrays
            byte[] exponentBytes = _dataConverter.ConvertToByteArray(exponentString);
            byte[] modulusBytes = _dataConverter.ConvertToByteArray(modulusString);

            // Create an RSA object with entered public Exponent and Modulus
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            RSAParameters rsaParams = new RSAParameters();
            rsaParams.Exponent = exponentBytes;
            rsaParams.Modulus = modulusBytes;
            rsa.ImportParameters(rsaParams);

            return rsa;
        }
    }


    internal interface IPublicKeyImporter
    {
        RSACryptoServiceProvider ImportPublicKey(string exponentString, string modulusString);
    }
}
