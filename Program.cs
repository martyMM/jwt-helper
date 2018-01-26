using System;
using System.Security.Cryptography;
using System.Text;

namespace JWTConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = new byte[32];
            RNGCryptoServiceProvider.Create().GetBytes(key);
            var base64Secret = Convert.ToBase64String(key);
            var clientId = RandomString(32);

            Console.WriteLine("JWT secret:");
            Console.WriteLine(base64Secret);

            Console.WriteLine("ClientID");
            Console.WriteLine(clientId);

            Console.ReadLine();
        }

        private static string RandomString(int length)
        {
            const string pool = "1234567890abcdefghijkmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();

            Random rnd = new Random();

            for (var i = 0; i < length; i++)
            {
                var c = pool[rnd.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
    }
}
