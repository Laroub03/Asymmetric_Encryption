using System;
using System.Security.Cryptography;
using System.Text;

namespace Asymmetric_Encryption
{ 
    // Entry point of the program
    class Program
    {
        static void Main()
        {
            Receiver.Receive();
            Sender.Send();
        }
    }
}