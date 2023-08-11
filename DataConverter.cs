using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asymmetric_Encryption
{
    internal class DataConverter : IDataConverter
    {
        public byte[] ConvertToByteArray(string data)
        {
            // Convert entered data into byte array and replace "-" with ""
            data = data.Replace("-", "");
            byte[] bytes = new byte[data.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(data.Substring(i * 2, 2), 16);
            }

            return bytes;
        }
    }

    public interface IDataConverter
    {
        byte[] ConvertToByteArray(string data);
    }
}
