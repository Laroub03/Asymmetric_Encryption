using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Asymmetric_Encryption
{
    internal interface IKeyContainer
    {
        RSACryptoServiceProvider GetRSA();
    }

    internal class KeyContainer : IKeyContainer
    {
        private readonly string _containerName;

        public KeyContainer(string containerName)
        {
            _containerName = containerName;
        }

        public RSACryptoServiceProvider GetRSA()
        {
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = _containerName;
            return new RSACryptoServiceProvider(cspParams);
        }
    }
}
