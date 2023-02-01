using System.Text;
using System;
using System.Security.Cryptography;

namespace Lemondo.Helper
{
    public class PassworHashing
    {
        public string HashPass(string password)
        {
            SHA256 hash = SHA256.Create();
            var passwordbyte = Encoding.Default.GetBytes(password);
            var hashedpassword = hash.ComputeHash(passwordbyte);
            return Convert.ToHexString(hashedpassword);

        }
    }
}
