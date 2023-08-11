using System;
using System.Security.Cryptography;
using System.Text;

namespace Asymmetric_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize components for the sender's side
            IDataConverter dataConverter = new DataConverter();
            IPublicKeyImporter publicKeyImporter = new PublicKeyImporter(dataConverter);
            IEncryptor encryptor = new Encryptor();
            Sender sender = new Sender(publicKeyImporter, encryptor);
            sender.Run();

            // Initialize components for the receiver's side
            IKeyContainer keyContainer = new KeyContainer("MyKeyContainer");
            IDecryptor decryptor = new Decryptor(dataConverter);
            Receiver receiver = new Receiver(keyContainer, decryptor);
            receiver.Run();
        }
    }
}