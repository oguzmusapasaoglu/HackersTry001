using Microsoft.AspNetCore.Cryptography.KeyDerivation;

using System.Text;

namespace HackersTry001.Core.Common.Helper
{
    public class PasswordHelper
    {
        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CAES = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "123456789";
        const string SPECIALS = @"!@£$%^&*()#€";
        public static string GeneratePassword(int passwordSize = 6)
        {
            char[] _password = new char[passwordSize];
            Random _random = new Random();
            int counter;
            var charSet = "";
            charSet += LOWER_CASE;
            charSet += UPPER_CAES;
            charSet += NUMBERS;
            charSet += SPECIALS;

            for (counter = 0; counter < passwordSize; counter++)
                _password[counter] = charSet[_random.Next(charSet.Length - 1)];
            return String.Join(null, _password);
        }

        public static string HashPassword(string password, string userName)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                                     password: password,
                                     salt: Encoding.UTF8.GetBytes(userName),
                                     prf: KeyDerivationPrf.HMACSHA512,
                                     iterationCount: 10000,
                                     numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes) + "æ" + userName;
        }

        public static bool ValidateHash(string password, string userName, string hash)
               => HashPassword(password, userName).Split('æ')[0] == hash;
    }
}
