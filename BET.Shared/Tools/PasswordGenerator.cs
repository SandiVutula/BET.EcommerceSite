using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BET.Shared.Tools
{
    public class PasswordGenerator
    {
        public static string HashPassword(string password)
        {
            var hash = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var hashedPassword = hash.ComputeHash(asByteArray); 
            var result = Convert.ToBase64String(hashedPassword);

            return result;
        }
    }
}
