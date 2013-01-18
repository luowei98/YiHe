using System.Security.Cryptography;
using System.Text;


namespace YiHe.Core.Common
{
    public static class Md5Encrypt
    {
        public static string Md5EncryptPassword(string data)
        {
            var encoding = new ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(data);
            byte[] hashed = MD5.Create().ComputeHash(bytes);
            return Encoding.UTF8.GetString(hashed);
        }
    }
}