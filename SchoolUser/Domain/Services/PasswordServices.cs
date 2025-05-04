using System.Security.Cryptography;
using System.Text;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Domain.Services
{
    public class PasswordServices : IPasswordServices
    {
        private readonly Random random = new Random();

        public string CreatePasswordHashService(string password, string salt, string pepper, int iteration)
        {
            if (iteration <= 0) return password;

            using var sha256 = SHA256.Create();
            var passwordSaltPepper = $"{password}{salt}{pepper}";
            var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
            var byteHash = sha256.ComputeHash(byteValue);
            var hash = Convert.ToBase64String(byteHash);
            return CreatePasswordHashService(hash, salt, pepper, iteration - 1);
        }

        public string GenerateSaltService()
        {
            using var rng = RandomNumberGenerator.Create();
            var byteSalt = new byte[16];
            rng.GetBytes(byteSalt);
            var salt = Convert.ToBase64String(byteSalt);
            return salt;
        }

        public string CreateRandomPasswordService()
        {
            int length = 8;
            const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
            const string numberChars = "0123456789";
            const string specialChars = "!@#$%^&*.,_";
            const string allChars = upperChars + lowerChars + numberChars + specialChars;

            char[] password = new char[length];

            // Ensure at least one character from each category
            password[0] = upperChars[random.Next(upperChars.Length)];
            password[1] = lowerChars[random.Next(lowerChars.Length)];
            password[2] = numberChars[random.Next(numberChars.Length)];
            password[3] = specialChars[random.Next(specialChars.Length)];

            // Fill the rest of the password with random characters
            for (int i = 4; i < length; i++)
            {
                password[i] = allChars[random.Next(allChars.Length)];
            }

            // Shuffle the password to ensure randomness
            return new string(password.OrderBy(x => random.Next()).ToArray());
        }
    }
}